#include <windows.h>
#include <tchar.h>
#include "resource.h"


#define IDC_BTN_SAVE 100
#define IDC_BTN_ADD 101
#define IDC_EDIT1 102
#define IDC_LISTBOX 103

//ПРОТОТИП ОКОННОЙ ПРОЦЕДУРЫ
LRESULT CALLBACK Pr2_WndProc(HWND, UINT, WPARAM, LPARAM);

//ОБЪЯВЛЕНИЕ ГЛОБАЛЬНЫХ ПЕРЕМЕННЫХ
LPCTSTR g_lpszClassName = TEXT ("sp_pr2_class");
LPTSTR g_lpszAplicationTitle = TEXT("Главное окно приложения.Программист Бурляев Д.А.");
LPTSTR g_lpszDestroyMessage = TEXT("Разрушается окно. В связи с этим поступило сообщение WM_DESTROY, из обработчика которого и выполнен данный вывод.");
HINSTANCE hInstance;
HMENU hMenuNew;

//СТАРТОВАЯ ФУНКЦИЯ
int APIENTRY _tWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
	LPTSTR lpszCmdLine, int nCmdShow)
{
	WNDCLASSEX wc;
	MSG msg;
	HWND hWnd;
	HBRUSH my = CreateSolidBrush(RGB(0, 255, 0));

	memset(&wc, 0, sizeof(WNDCLASSEX));
	wc.cbSize = sizeof(WNDCLASSEX);
	wc.lpszClassName = g_lpszClassName; 
	wc.lpfnWndProc = Pr2_WndProc;
	wc.style = CS_VREDRAW | CS_HREDRAW;
	wc.hInstance = hInstance;
	wc.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_ICON1));
	wc.hCursor = LoadCursor(hInstance, MAKEINTRESOURCE(IDC_CURSOR1));
	wc.hbrBackground = my;
	wc.lpszMenuName = NULL;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;

	if (!RegisterClassEx(&wc))
	{
		MessageBox(NULL, TEXT("Ошибка регистрации класса окна!"),
			TEXT("Ошибка"), MB_OK | MB_ICONERROR);
		return FALSE;
	}

	//HMENU hMenu = LoadMenu(hInstance, MAKEINTRESOURCE(IDR_MENU1));
	
	hWnd = CreateWindowEx(NULL, g_lpszClassName,
		g_lpszAplicationTitle,
		WS_OVERLAPPEDWINDOW &~ WS_MAXIMIZEBOX,
		0,
		0,
		500,
		350,
		NULL,
		NULL,//hMenu,
		hInstance,
		NULL
		);
	if (!hWnd)
	{
		MessageBox(NULL, TEXT("Окно не создано!"),
			TEXT("Ошибка"), MB_OK | MB_ICONERROR);
		return FALSE;
	}

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);
	HACCEL hAccel;
	hAccel = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDR_ACCELERATOR1));
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(hWnd, hAccel, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
		/*DispatchMessage(&msg);*/
	}
	return msg.wParam;
}
MENUITEMINFO CreateMenuItemInfo(HMENU hMenu,LPWSTR str, UINT ulns, UINT uCom, HMENU hSubMenu, BOOL flag, UINT fType)
{
	static MENUITEMINFO mii; mii.cbSize = sizeof(MENUITEMINFO);
	mii.fMask = MIIM_STATE | MIIM_TYPE | MIIM_SUBMENU | MIIM_ID;
	mii.fType = fType;
	mii.fState = MFS_ENABLED;
	mii.dwTypeData = str;
	mii.cch = sizeof(str);
	mii.wID = uCom;
	mii.hSubMenu = hSubMenu;
	return mii;
}

void AddMenus(HWND hWnd)
{
	HMENU hMenu = LoadMenu(hInstance, MAKEINTRESOURCE(IDR_MENU1));
	hMenuNew = hMenu;
	SetMenu(hWnd, hMenuNew);
	HMENU hPopMenuFile = CreatePopupMenu();
	MENUITEMINFO lps=CreateMenuItemInfo(hPopMenuFile, L"&Закрыть документ", 4, IDM_FILE_CLOSE, NULL, FALSE, MFT_STRING);
	InsertMenuItem(hMenuNew, (UINT)IDM_FILE_EXIT, FALSE, &lps);
}
MENUITEMINFO CreateItemInfo(UINT Id, UINT State)
{
	static MENUITEMINFO lps;
	lps.cbSize = sizeof(MENUITEMINFO);
	lps.fMask = MIIM_ID | MIIM_STATE;;
	lps.fState = State;
	lps.wID = Id;
	return lps;
}
// Оконная процедура
LRESULT CALLBACK Pr2_WndProc(HWND hWnd,  UINT msg,
	WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	int wmId, wmEvent;
	static HWND hButtonSave;
	static HWND hButtonAdd;
	static HWND hButtonExit;
	static HWND hEdit;
	static HWND hListBox;
	switch (msg)
	{

	case WM_DESTROY:// Завершение работы приложения
	{
		MessageBox(NULL, g_lpszDestroyMessage,
					TEXT("Окно разрушается!"), MB_OK | MB_ICONERROR);
		PostQuitMessage(5); // Посылка WM_QUIT приложению
		break;
	}
	case WM_MENUSELECT:
	{
		HDC hdc1;
		LPCTSTR lpszMsgSpace = TEXT("____________________________");
		TCHAR Buf[300];
		HINSTANCE hInst;
		hInst = (HINSTANCE)GetWindowLongPtr(hWnd, GWLP_HINSTANCE);
		int size;
		size = LoadString(hInst, LOWORD(wParam), Buf, 300);
		hdc1 = GetDC(hWnd);
		RECT rc;
		GetClientRect(hWnd, &rc);
		TextOut(hdc1, rc.left + 10, rc.bottom - 20,lpszMsgSpace, lstrlen(lpszMsgSpace));
		TextOut(hdc1, rc.left + 10, rc.bottom - 20, Buf, lstrlen(Buf));
		ReleaseDC(hWnd, hdc1);
		break;
	}
	case WM_RBUTTONDOWN:
	{
		DWORD xyPos = GetMessagePos();
		WORD xPos = LOWORD(xyPos);
		WORD yPos = HIWORD(xyPos);
		HMENU hFloatMenu = CreatePopupMenu();
		MENUITEMINFO lps;
		MENUITEMINFO lps1;
		MENUITEMINFO lps2;
		MENUITEMINFO lps3;
		lps.cbSize=sizeof(MENUITEMINFO);
		lps.dwTypeData = NULL;
		lps.fMask = MIIM_STATE;
		lps2.cbSize = sizeof(MENUITEMINFO);
		lps2.dwTypeData = NULL;
		lps2.fMask = MIIM_STATE;
		GetMenuItemInfo(hMenuNew, IDM_EDIT_PICKOUT, FALSE, &lps);
		lps1 = CreateMenuItemInfo(hMenuNew, L"&Выделить", 1, IDM_EDIT_PICKOUT, NULL, FALSE, MFT_STRING);
		lps1.fState = lps.fState;
		GetMenuItemInfo(hMenuNew, IDM_EDIT_COPY, FALSE, &lps2);
		lps3 = CreateMenuItemInfo(hMenuNew, L"&Копировать", 2, IDM_EDIT_COPY, NULL, FALSE, MFT_STRING);
		lps3.fState = lps2.fState;
		InsertMenuItem(hFloatMenu, IDM_EDIT_PICKOUT, FALSE, &lps1);
		InsertMenuItem(hFloatMenu, IDM_EDIT_COPY, FALSE, &lps3);
		TrackPopupMenu(hFloatMenu, TPM_CENTERALIGN | TPM_LEFTBUTTON | TPM_VCENTERALIGN, xPos, yPos, 0, hWnd, NULL);
		break;
	}

	//case WM_LBUTTONDOWN:
	//{
	//	LPCTSTR lpszString = TEXT("Обработка сообщения WM_LBUTTONDOWN, которое посылается в окно при щелчке левой кнопки мыши");
	//	hDC = GetDC(hWnd);
	//	//TextOut(hDC, 50, 200, lpszString, 600);
	//	//TextOut(hDC, LOWORD(lParam), HIWORD(lParam), lpszString, 600);
	//	RECT rectangle;
	//	rectangle.top = HIWORD(lParam);
	//	rectangle.left = LOWORD(lParam);
	//	DrawText(hDC, lpszString, 150, &rectangle, DT_LEFT | DT_TOP);
	//	break;
	//}
		/*case WM_PAINT:
		{
		LPCTSTR lpszString2 = TEXT("Вывод текста при обработке сообщения WM_PAINT.Это соообщение окно получает после того, как оно было закрыто другим окном и затем открыто.");
		PAINTSTRUCT paint;
		hDC = BeginPaint(hWnd, &paint);
		TextOut(hDC, 20, 100, lpszString2, 600);
		EndPaint(hWnd, &paint);
		break;
		}*/
	case WM_CREATE:
	{
		LPCTSTR lpszString3 = TEXT("Выполняется обработка WM_CREATE");
		LPCTSTR lpszTitleCreat = TEXT("Creat Window");
		MessageBox(NULL, lpszString3, lpszTitleCreat, MB_OK);
		if (!(hEdit = CreateWindowEx(0L, L"Edit", L"Редактор",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			20, 50, 160, 40, hWnd, (HMENU)(IDC_EDIT1),
			NULL, NULL))) return (-1);
		if (!(hListBox = CreateWindowEx(0L, L"ListBox", L"Список",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			200, 50, 160, 180, hWnd, (HMENU)(IDC_LISTBOX),
			NULL, NULL))) return (-1);
		if (!(hButtonSave = CreateWindowEx(0L, L"Button", L"В буфер",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			20, 240, 80, 24, hWnd, (HMENU)(IDC_BTN_SAVE),
			NULL, NULL))) return (-1);
		if (!(hButtonAdd = CreateWindowEx(0L, L"Button", L"В список",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			120, 240, 80, 24, hWnd, (HMENU)(IDC_BTN_ADD),
			NULL, NULL))) return (-1);
		if (!(hButtonExit = CreateWindowEx(0L, L"Button", L"Выход",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			220, 240, 80, 24, hWnd, (HMENU)(IDCANCEL),
			NULL, NULL))) return (-1);
		
		AddMenus(hWnd);
		return 0;
	}
	case WM_COMMAND:
	{
		wmId = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		static TCHAR pszTextBuff[500];
		switch (wmId)
		{
		
			case IDM_FILE_NEW:
			{
				MessageBox(NULL, L"Выбрана команда Создать", L"Сообщения меню", MB_OK);
				MENUITEMINFO lps = CreateItemInfo(IDM_EDIT_PICKOUT, MFS_ENABLED);
				SetMenuItemInfo(hMenuNew, IDM_EDIT_PICKOUT, FALSE, &lps);
				SetMenu(hWnd, hMenuNew);
				//HMENU hMenu = hMenuNew;

				break;
			}
			case IDM_FILE_OPEN:
			{
				MessageBox(NULL, L"Выбрана команда Открыть", L"Сообщения меню", MB_OK);
				break;
			}
			case IDM_FILE_EXIT:
			{
				MessageBox(NULL, L"Выбрана команда Выход", L"Сообщения меню", MB_OK);
				break;
			}
			case IDM_EDIT_PICKOUT:
			{
				MessageBox(NULL, L"Выбрана команда Выделить", L"Сообщения меню", MB_OK);
				MENUITEMINFO lps = CreateItemInfo(IDM_EDIT_COPY, MFS_ENABLED);
				SetMenuItemInfo(hMenuNew, IDM_EDIT_COPY, FALSE, &lps);
				MENUITEMINFO lps1 = CreateItemInfo(IDM_EDIT_PICKOUT, MFS_ENABLED);
				SetMenuItemInfo(hMenuNew, IDM_EDIT_PICKOUT, FALSE, &lps1);
				SetMenu(hWnd, hMenuNew);
				//HMENU hMenu = hMenuNew;
				break;
			}
			case IDM_EDIT_CUT:
			{
				MessageBox(NULL, L"Выбрана команда Вырезать", L"Сообщения меню", MB_OK);
				break;
			}
			case IDM_EDIT_COPY:
			{
				 MessageBox(NULL, L"Выбрана команда Копировать", L"Сообщения меню", MB_OK);
				 break;
			}
			case IDM_EDIT_PASTE:
			{
				MessageBox(NULL, L"Выбрана команда Вставить", L"Сообщения меню", MB_OK);
				break;
			}
			case IDM_SPRAVKA_HELP:
			{
				MessageBox(NULL, L"Выбрана команда Помощь", L"Сообщения меню", MB_OK);
				break;
			}
			case IDM_SPRAVKA_ABOUT:
			{
				MessageBox(NULL, L"Выбрана команда О программе", L"Сообщения меню", MB_OK);
				break;
			}
			case IDM_FILE_CLOSE:
			{
				MessageBox(NULL, L"Выбрана команда Закрыть документ", L"Сообщения меню", MB_OK);
				HMENU hMenu = LoadMenu(hInstance, MAKEINTRESOURCE(IDR_MENU1));
				SetMenu(hWnd,hMenu);
				AddMenus(hWnd);
				hMenuNew = hMenu;
				break;
			}
		
			 case IDCANCEL:
			 {
				DestroyWindow(hWnd);
				break;
			 }
			 case IDC_BTN_SAVE:
			 {
				int cch;
				cch = SendMessage(hEdit, WM_GETTEXT, 500, (LPARAM)pszTextBuff);
				if (cch == 0) MessageBox(hWnd, L"Введите текст", L"Читаем Edit", MB_OK);
				else
				{
				TCHAR Buff1[500] = { 0 };
				SYSTEMTIME st; 
				GetSystemTime(&st);
				wsprintf(Buff1, L"Время : %d ч %d мин %d сек\n", st.wHour, st.wMinute, st.wSecond);
				lstrcat(Buff1, __TEXT("Текст в памяти: "));
				lstrcat(Buff1, pszTextBuff);
				MessageBox(hWnd, Buff1, L"Содержимое буфера", MB_OK);
				}
				break;
			 }
			 case IDC_BTN_ADD:
			 {
				int ind;
				ind = SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)pszTextBuff);
				if (ind == LB_ERR) MessageBox(hWnd, L"Ошибка в списке", L"", MB_OK);
				break;
			 }
			 default:
			 {
				 TCHAR temp[100];
				 wsprintf(temp, L"Команда с идентификатором %d не реализована.", wmId);
				 MessageBox(NULL, temp, L"Сообщения меню", MB_OK);
				 return DefWindowProc(hWnd, msg, wParam, lParam);
			 }
		}

	default: // Вызов "Обработчика по умолчанию"
	return(DefWindowProc(hWnd, msg, wParam, lParam));
	}
	return FALSE;// Для ветвей с "break"
}
}

