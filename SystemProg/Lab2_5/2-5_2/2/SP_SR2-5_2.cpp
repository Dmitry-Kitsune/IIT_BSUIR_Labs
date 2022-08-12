#include <windows.h>
#include <windowsx.h>

#include "resource.h"

/*static */HANDLE s_hFileMap;
HANDLE hFileMapT;
LPVOID	lpView;
HWND hDlg;


BOOL Dlg_OnInitDialog (HWND hwnd, HWND hwndFocus, LPARAM lParam) 
{

	// Связываем значок с диалоговым окном
	HINSTANCE hInst=(HINSTANCE) GetWindowLong(hwnd,GWL_HINSTANCE);
	HICON hIcon=LoadIcon( hInst, MAKEINTRESOURCE(IDI_MMFSHARE));//__TEXT("MMFShare"))
	SetClassLong(hwnd, GCL_HICON,(LONG) hIcon);

	// Инициализируем поле ввода тестовыми данными
	HWND hEditWnd=GetDlgItem(hwnd ,   // handle of dialog box 
					         IDC_DATA // identifier of control 
					         ); 
	Edit_SetText(hEditWnd,__TEXT( "Здесь вводите данные."));

	// Отключаем кнопку Закрыть, т.к. файл нельзя закрыть,
	// если он не создан или не открыт
	//Button_Enable(GetDlgItem(hwnd, IDC_CLOSEFILE), FALSE);



	// Создаем в памяти проецируемый файл, содержащий
	// данные, набранные в поле ввода. Файл занимает 4 Кб
	// и называется MMFSharedData.
	s_hFileMap = CreateFileMapping((HANDLE)0xFFFFFFFF,
		NULL, PAGE_READWRITE, 0, 4 * 1024,
		__TEXT("MMFSharedData"));
	if (s_hFileMap != NULL)
	{
		if (GetLastError() == ERROR_ALREADY_EXISTS)
		{
			MessageBox(hwnd, __TEXT("Mapping already exists - ")
				__TEXT("not created."),
				NULL, MB_OK);
			CloseHandle(s_hFileMap);
		}
		else
		{
			// Создание проецируемого файла завершилось успешно
			// Проецируем оконное представление файла
			// на адресное пространство
			lpView = MapViewOfFile(s_hFileMap,
				FILE_MAP_READ | FILE_MAP_WRITE, 0, 0, 4 * 1024);
		}
	}
	else 
	{
		MessageBox(hwnd, __TEXT("Can't create file mapping."), NULL, MB_OK);
	}
		
	return (TRUE);
}

void Dlg_OnCommand( HWND hwnd,int id, HWND hwndCtl,
                    UINT codeNotify) 
{
// Описатель проецируемого в память файла


switch (id) 
	{

case IDC_CREATEFILE:
{
	
		if ((BYTE *)lpView != NULL)
		{
			// Окно спроецировано успешно: поместим содержимое
			// элемента управления EDIT в проецируемый файл
			Edit_GetText(GetDlgItem(hwnd, IDC_DATA),
				(LPTSTR)lpView, 4 * 1024);
			// Прекращаем проецирование окна. 
			UnmapViewOfFile((LPVOID)lpView);

			// Пользователь не может создать сейчас
			// еще один файл
			Button_Enable(hwndCtl, FALSE);

			// Пользователь закрыл файл
			//Button_Enable(GetDlgItem(hwnd, IDC_CLOSEFILE), TRUE);
		}
		else
		{
			MessageBox(hwnd, __TEXT("Can't map view of file. "),
				NULL, MB_OK);
		}
		break;
}




	//case IDC_CLOSEFILE:
	//	if (codeNotify != BN_CLICKED)	break;
	//	if (CloseHandle(s_hFileMap)) 
	//		{
	//		// Пользователь закрыл файл.  Новый файл создать можно,
	//		// но закрыть его нельзя.
	//		Button_Enable(GetDlgItem(hwnd, IDC_CREATEFILE),TRUE);
	//		Button_Enable(hwndCtl, FALSE);
	//		}
	//	break;

	case IDC_OPENFILE:
		if (codeNotify != BN_CLICKED)  break;
		
		// Смотрим: не существует ли уже проецируемый в память файл
		// с именем MMFSharedDafa
		hFileMapT = OpenFileMapping(FILE_MAP_READ | FILE_MAP_WRITE,
									FALSE, __TEXT( "MMFSharedData"));
		if (hFileMapT != NULL) 
			{
			// Такой файл существует. Проецируем его оконное
			// представление на адресное пространство процесса.
			LPVOID lpView = MapViewOfFile(hFileMapT,
							FILE_MAP_READ | FILE_MAP_WRITE, 0,0,0);
			if ((BYTE *) lpView != NULL) 
				{
				// Помещаем содержимое файла в поле ввода
				// (элемент управления EDIT)
				Edit_SetText(GetDlgItem(hwnd, IDC_DATA),
							(LPTSTR) lpView);
				UnmapViewOfFile((LPVOID) lpView);
				} 
			else 
				{
				MessageBox(hwnd,__TEXT("Can't map view."), NULL, MB_OK);
				}

			CloseHandle(hFileMapT);
			} 
		else 
			{
			MessageBox(hwnd,__TEXT("Can't open mapping."), NULL, MB_OK);
			}
		
		break;

	case IDCANCEL:
		EndDialog(hwnd, id);
		break;
	}
}

BOOL CALLBACK Dlg_Proc( HWND hDlg, UINT uMsg,
						WPARAM wParam, LPARAM lParam) 
{

	BOOL fProcessed = TRUE;
	switch (uMsg) 
		{
		HANDLE_MSG(hDlg, WM_INITDIALOG, Dlg_OnInitDialog);
		HANDLE_MSG(hDlg, WM_COMMAND, Dlg_OnCommand);
		default:
			fProcessed = FALSE;
			break;
		}
	return(fProcessed);
}

int WINAPI WinMain( HINSTANCE hinstExe,
					HINSTANCE hinstPrev, 
					LPSTR lpszCmdLine, 
					int nCrndShow) 
	{
	DialogBox(  hinstExe, MAKEINTRESOURCE(IDD_MMFSHARE),
				NULL, (DLGPROC)Dlg_Proc);
    return (0);
	}

