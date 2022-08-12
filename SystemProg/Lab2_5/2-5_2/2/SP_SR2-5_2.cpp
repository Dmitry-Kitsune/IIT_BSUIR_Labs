#include <windows.h>
#include <windowsx.h>

#include "resource.h"

/*static */HANDLE s_hFileMap;
HANDLE hFileMapT;
LPVOID	lpView;
HWND hDlg;


BOOL Dlg_OnInitDialog (HWND hwnd, HWND hwndFocus, LPARAM lParam) 
{

	// ��������� ������ � ���������� �����
	HINSTANCE hInst=(HINSTANCE) GetWindowLong(hwnd,GWL_HINSTANCE);
	HICON hIcon=LoadIcon( hInst, MAKEINTRESOURCE(IDI_MMFSHARE));//__TEXT("MMFShare"))
	SetClassLong(hwnd, GCL_HICON,(LONG) hIcon);

	// �������������� ���� ����� ��������� �������
	HWND hEditWnd=GetDlgItem(hwnd ,   // handle of dialog box 
					         IDC_DATA // identifier of control 
					         ); 
	Edit_SetText(hEditWnd,__TEXT( "����� ������� ������."));

	// ��������� ������ �������, �.�. ���� ������ �������,
	// ���� �� �� ������ ��� �� ������
	//Button_Enable(GetDlgItem(hwnd, IDC_CLOSEFILE), FALSE);



	// ������� � ������ ������������ ����, ����������
	// ������, ��������� � ���� �����. ���� �������� 4 ��
	// � ���������� MMFSharedData.
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
			// �������� ������������� ����� ����������� �������
			// ���������� ������� ������������� �����
			// �� �������� ������������
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
// ��������� ������������� � ������ �����


switch (id) 
	{

case IDC_CREATEFILE:
{
	
		if ((BYTE *)lpView != NULL)
		{
			// ���� ������������� �������: �������� ����������
			// �������� ���������� EDIT � ������������ ����
			Edit_GetText(GetDlgItem(hwnd, IDC_DATA),
				(LPTSTR)lpView, 4 * 1024);
			// ���������� ������������� ����. 
			UnmapViewOfFile((LPVOID)lpView);

			// ������������ �� ����� ������� ������
			// ��� ���� ����
			Button_Enable(hwndCtl, FALSE);

			// ������������ ������ ����
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
	//		// ������������ ������ ����.  ����� ���� ������� �����,
	//		// �� ������� ��� ������.
	//		Button_Enable(GetDlgItem(hwnd, IDC_CREATEFILE),TRUE);
	//		Button_Enable(hwndCtl, FALSE);
	//		}
	//	break;

	case IDC_OPENFILE:
		if (codeNotify != BN_CLICKED)  break;
		
		// �������: �� ���������� �� ��� ������������ � ������ ����
		// � ������ MMFSharedDafa
		hFileMapT = OpenFileMapping(FILE_MAP_READ | FILE_MAP_WRITE,
									FALSE, __TEXT( "MMFSharedData"));
		if (hFileMapT != NULL) 
			{
			// ����� ���� ����������. ���������� ��� �������
			// ������������� �� �������� ������������ ��������.
			LPVOID lpView = MapViewOfFile(hFileMapT,
							FILE_MAP_READ | FILE_MAP_WRITE, 0,0,0);
			if ((BYTE *) lpView != NULL) 
				{
				// �������� ���������� ����� � ���� �����
				// (������� ���������� EDIT)
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

