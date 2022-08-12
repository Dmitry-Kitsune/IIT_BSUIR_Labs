#include <windows.h>
#include <windowsx.h>
#include <tchar.h>
#include <wchar.h>
#include <CommCtrl.h>
#include "resource.h"


# define MAX_BYTES 10000
#define IDC_BTN_SAVE 100
#define IDC_BTN_ADD 101
#define IDC_EDIT1 102
#define IDC_LISTBOX 103

//ПРОТОТИП ОКОННОЙ ПРОЦЕДУРЫ
LRESULT CALLBACK Pr2_WndProc(HWND, UINT, WPARAM, LPARAM);
void OnDestroy(HWND);
BOOL Cls_OnCreate(HWND , LPCREATESTRUCT);
void Cls_OnLButtonDown(HWND, BOOL, int, int, UINT);
void WndProc_OnMenuSelect(HWND, HMENU, int, HMENU, UINT); 
void Cls_OnCommand(HWND, int, HWND, UINT);
void Cls_OnRButtonDown(HWND, BOOL, int, int, UINT);
void WndProc_OnPaint(HWND);
void AddMenus(HWND hWnd);
BOOL WndAboutProc_OnInitDialog(HWND, HWND, LPARAM);
INT_PTR CALLBACK About(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK TextView(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK ImageView(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK ControlElement(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK MOVEIMG(HWND, UINT, WPARAM, LPARAM);





//ОБЪЯВЛЕНИЕ ГЛОБАЛЬНЫХ ПЕРЕМЕННЫХ
LPCTSTR g_lpszClassName = TEXT ("sp_pr2_class");
LPTSTR g_lpszAplicationTitle = TEXT("Главное окно приложения.Программист Бурляев Д.А.");
LPTSTR g_lpszDestroyMessage = TEXT("Разрушается окно. В связи с этим поступило сообщение WM_DESTROY, из обработчика которого и выполнен данный вывод.");
HINSTANCE hInstance;
HMENU hMenuNew;
static HWND hButtonSave;
static HWND hButtonAdd;
static HWND hButtonExit;
static HWND hEdit;
static HWND hListBox;
HDC hDC;
HWND hWnd;
HWND hStatusWindow;
UINT imageID = 122;


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
	
	hWnd = CreateWindowEx(NULL, g_lpszClassName,
		g_lpszAplicationTitle,
		WS_OVERLAPPEDWINDOW &~ WS_MINIMIZEBOX,
		0,
		0,
		500,
		350,
		NULL,
		LoadMenu(hInstance, MAKEINTRESOURCE(IDR_MENU1)),
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
	}
	return msg.wParam;
}

// Оконная процедура
LRESULT CALLBACK Pr2_WndProc(HWND hWnd,  UINT msg,
	WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
		HANDLE_MSG(hWnd, WM_PAINT, WndProc_OnPaint);
		HANDLE_MSG(hWnd, WM_CREATE, Cls_OnCreate);
		HANDLE_MSG(hWnd, WM_DESTROY, OnDestroy);
		HANDLE_MSG(hWnd, WM_COMMAND, Cls_OnCommand);
		HANDLE_MSG(hWnd, WM_MENUSELECT, WndProc_OnMenuSelect);


	default: // Вызов "Обработчика по умолчанию"
	return(DefWindowProc(hWnd, msg, wParam, lParam));
	}
}

void WndProc_OnPaint(HWND hWnd)
{
	HDC hDC;
	PAINTSTRUCT ps;
	hDC = BeginPaint(hWnd, &ps);  // Получение контекста 
	EndPaint(hWnd, &ps); // Завершение обновления окна
}

void WndProc_OnMenuSelect(HWND hWnd, HMENU hmenu, int itemID, HMENU hmenuPopup, UINT flags)
{
	TCHAR Buf[50];
	int size;
	size = LoadString(hInstance, itemID, Buf, 300);
	SetWindowText(hStatusWindow, Buf);
}

void Cls_OnCommand(HWND hWnd, int id, HWND hwndCtl, UINT codeNotify)
{
		hInstance = (HINSTANCE)GetWindowLongPtr(hWnd, GWLP_HINSTANCE);
		int wmId, wmEvent;
		wmId = id;
		wmEvent = codeNotify;
		static TCHAR pszTextBuff[500];
		switch (wmId)
		{
			case IDM_FILE_OPEN:
			{
				MessageBox(NULL, L"Выбрана команда Открыть", L"Сообщения меню", MB_OK);
				break;
			}
			case IDM_FILE_EXIT:
			{
				DestroyWindow(hWnd);
				break;
			}
			case IDM_VIEW_TEXT:
			{
				//MessageBox(NULL, L"Выбрана команда просмотр текста", L"Сообщения меню", MB_OK);
				DialogBox(hInstance, MAKEINTRESOURCE(IDD_DIALOG2), hWnd, TextView);
				break;
			}
			case IDM_VIEW_BMP:
			{
				//MessageBox(NULL, L"Выбрана команда просмотр графики", L"Сообщения меню", MB_OK);
				CreateDialog(hInstance, MAKEINTRESOURCE(IDD_DIALOG3), hWnd, ImageView);
				break;
			}
			case IDM_VIEW_ELEMENT:
			{
				DialogBox(hInstance, MAKEINTRESOURCE(IDD_DIALOG4), hWnd, ControlElement);
				break;
			}
			case IDM_VIEW_MOVEIMG:
			{
									 DialogBox(hInstance, MAKEINTRESOURCE(IDD_DIALOG5), hWnd, MOVEIMG);
				break;
			}
			case IDM_SPRAVKA_SODERGANIE:
			{
				MessageBox(NULL, L"Выбрана команда содержание меню", L"Сообщения меню", MB_OK);
				break;
			}
			case IDM_SPRAVKA_ABOUT:
			{
				//MessageBox(NULL, L"Выбрана команда О программе", L"Сообщения меню", MB_OK);
				DialogBox(hInstance, MAKEINTRESOURCE(IDD_DIALOG1), hWnd, About);
				break;
			}
			 default:
			 {
				 TCHAR temp[100];
				 wsprintf(temp, L"Команда с идентификатором %d не реализована.", wmId);
				 MessageBox(NULL, temp, L"Сообщения меню", MB_OK);
			 }
		}
}

INT_PTR CALLBACK MOVEIMG(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		ShowWindow(hWnd, SW_SHOW);
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == 1 || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		WORD wmld;
		wmld = LOWORD(wParam);
		switch (wmld)
		{
		case IDC_BUTTON7:
		{
			HDC hDC;
			HDC hMemDC;
			HANDLE hBmp;
			HANDLE hOldBmp;
			BITMAP Bmp;
			hBmp = LoadImage(hInstance, MAKEINTRESOURCE(imageID),
				IMAGE_BITMAP, 0, 0, LR_DEFAULTSIZE);
			HWND hWndImage = GetDlgItem(hDlg, IDC_STATIC_PIC);
			hDC = GetDC(hWndImage);
			hMemDC = CreateCompatibleDC(hDC);
			GetObject(hBmp, sizeof(BITMAP), &Bmp);
			hOldBmp = SelectObject(hMemDC, hBmp);
			RECT Rect;
			GetClientRect(hWndImage, &Rect);
			StretchBlt(hDC, 0, 0, Rect.right, Rect.bottom,
				hMemDC, 0, 0, Bmp.bmWidth, Bmp.bmHeight, SRCCOPY);
			SelectObject(hMemDC, hOldBmp);
			DeleteDC(hMemDC);
			DeleteObject(hBmp);
			ReleaseDC(hWndImage, hDC);
			if (imageID == 125)
			{
				imageID = 122;
			}
			else
			{
				imageID++;
			}
		}
			break;
		}
	}
	return (INT_PTR)FALSE;
}

INT_PTR CALLBACK ControlElement(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
	{
		ShowWindow(hWnd, SW_SHOW);
		if (!(hEdit = CreateWindowEx(0L, L"Edit", L"Бурляев Д.А.",
		//if (!(hEdit = CreateWindowEx(0L, L"Edit", L"Редактор",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			10, 10, 160, 40, hDlg, (HMENU)(IDC_EDIT1),
			NULL, NULL))) return (-1);
		if (!(hListBox = CreateWindowEx(0L, L"ListBox", L"Список",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			180, 10, 260, 220, hDlg, (HMENU)(IDC_LISTBOX),
			NULL, NULL))) return (-1);
	}
		return (INT_PTR)TRUE;
	case WM_COMMAND:
		static TCHAR pszTextBuff[500];
		if (LOWORD(wParam) == 1 || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		WORD wmld;
		wmld = LOWORD(wParam);
		switch (wmld)
		{
		case IDC_BUFFER:
		{
			int cch;
			cch = SendMessage(hEdit, WM_GETTEXT, 500, (LPARAM)pszTextBuff);
			if (cch == 0)
				MessageBox(hWnd, L"Введите текст", L"Читаем Edit", MB_OK);
			else
			{
				TCHAR Buff1[500] = { 0 };
				SYSTEMTIME st; GetSystemTime(&st);
				wsprintf(Buff1, L"Время : %d ч %d мин %d сек\n",
					st.wHour, st.wMinute, st.wSecond);
				lstrcat(Buff1, __TEXT("Текст в памяти: "));
				lstrcat(Buff1, pszTextBuff);
				MessageBox(hWnd, Buff1, L"Содержимое буфера", MB_OK);
			}
		}
			break;
		case IDC_SPISOK:
		{
			int ind;
			ind = SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)pszTextBuff);
			if (ind == LB_ERR)
				MessageBox(hWnd, L"Ошибка в списке", L"", MB_OK);
		}
			break;
		}
	}
	return (INT_PTR)FALSE;
}

INT_PTR CALLBACK ImageView(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{

	case WM_INITDIALOG:

		ShowWindow(hDlg, SW_SHOW);
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == 1 || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		WORD wmld;
		wmld = LOWORD(wParam);
		switch (wmld)
		{
		case IDC_LOAD_IMAGE:
		{
			HDC hDC;
			HDC hMemDC;
			HANDLE hBmp;
			HANDLE hOldBmp;
			BITMAP Bmp;
			LPWSTR lpszFileSpec2 = L"3.bmp";
			hBmp = LoadImage(NULL, lpszFileSpec2,
				IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
			HWND hWndImage = GetDlgItem(hDlg, IDC_PICTURE);
			hDC = GetDC(hWndImage);
			hMemDC = CreateCompatibleDC(hDC);
			GetObject(hBmp, sizeof(BITMAP), &Bmp);
			hOldBmp = SelectObject(hMemDC, hBmp);
			RECT Rect;
			GetClientRect(hWndImage, &Rect);
			StretchBlt(hDC, 0, 0, Rect.right, Rect.bottom,
				hMemDC, 0, 0, Bmp.bmWidth, Bmp.bmHeight, SRCCOPY);
			SelectObject(hMemDC, hOldBmp);
			DeleteDC(hMemDC);
			DeleteObject(hBmp);
			ReleaseDC(hWndImage, hDC);
		}
			break;
		}
	}
	return (INT_PTR)FALSE;
}

INT_PTR CALLBACK TextView(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	LPCWSTR lpszInitEdit = L"Шаг 1. Начало работы";
	TCHAR Textbuf[1000] = TEXT("Шаг 2. Загрузка текста из файла");
	switch (message)
	{

	case WM_INITDIALOG:
		SetWindowText(GetDlgItem(hDlg, IDC_EDIT1), lpszInitEdit);
		if (GetDlgCtrlID((HWND)IDC_BUTTON1) != IDC_BUTTON1)//фокус ввода на кнопку загрузить
		{
			SetFocus(GetDlgItem(hDlg, IDC_BUTTON1));
			return FALSE;
		}
		return TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == 1 || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		WORD wmld;
		wmld = LOWORD(wParam);
		switch (wmld)
		{
		case IDC_BUTTON1:
		{
			OPENFILENAME ofn;   
			TCHAR lpszFileSpec[260];   
			SetDlgItemText(hDlg, IDC_EDIT1, Textbuf);
			TCHAR Buffer[MAX_BYTES];
			memset(&Buffer[0], 0, sizeof(Buffer));
			HANDLE hFile;       
			ZeroMemory(&ofn, sizeof(OPENFILENAME));
			ofn.lStructSize = sizeof(OPENFILENAME);
			ofn.hwndOwner = hWnd;  
			ofn.lpstrFile = lpszFileSpec;
			ofn.lpstrFile[0] = '\0';
			ofn.nMaxFile = sizeof(lpszFileSpec);
			ofn.lpstrFilter = L"All\0*.*\0Text\0*.txt\0";
			ofn.nFilterIndex = 1; 
			ofn.lpstrFileTitle = NULL; 
			ofn.nMaxFileTitle = 0;
			ofn.lpstrInitialDir = NULL; 
			ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;
			BOOL fRet = GetOpenFileName(&ofn);
			if (fRet == FALSE)
			{
				return 1;
			}
			hFile = CreateFile(ofn.lpstrFile, GENERIC_READ,
				0, (LPSECURITY_ATTRIBUTES)NULL,
				OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL,
				(HANDLE)NULL);
			if (hFile == INVALID_HANDLE_VALUE)
			{
				return (-1);
			}
			DWORD dwNumbOfBytes;
			ReadFile(hFile, Buffer, MAX_BYTES, &dwNumbOfBytes, NULL);
			SendMessage(GetDlgItem(hDlg, IDC_EDIT1), WM_SETTEXT, NULL, (LPARAM)Buffer);
			SetDlgItemText(hDlg, IDC_EDIT2, LPCWSTR(Buffer));
			if (hFile)
			{
				CloseHandle(hFile);
			}

			return (INT_PTR)TRUE;
			break;
}
		}

		return (INT_PTR)TRUE;
		break;
	}
	return (INT_PTR)FALSE;
}


INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
		HANDLE_MSG(hDlg, WM_INITDIALOG, WndAboutProc_OnInitDialog);
	case WM_COMMAND:
		if (LOWORD(wParam) == 1)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	
	}
	return (INT_PTR)FALSE;
}

BOOL WndAboutProc_OnInitDialog(HWND hWnd, HWND hDlg, LPARAM lParam)
{
	TCHAR Buff[500] = { 0 };
	SYSTEMTIME st; GetSystemTime(&st);
	wsprintf(Buff, TEXT("Сведения о программе: Проект SP_PR5\nСведения о разработчике: Бурляев Д.А. \nГруппа 00332 \nТекущие дата и время: %02d.%02d.%d %02d:%02d "), st.wDay, st.wMonth, st.wYear, st.wHour, st.wMinute);
	SetWindowText(GetDlgItem(hWnd, IDC_STATIC1), Buff);
	return (INT_PTR)TRUE;
}

void OnDestroy(HWND)
{
	PostQuitMessage(0);
}

BOOL Cls_OnCreate(HWND hWnd, LPCREATESTRUCT lpCreateStruct)
{
	
	UINT wID = 4000;
	hStatusWindow = CreateWindow(STATUSCLASSNAME , TEXT(""),
		WS_CHILD | WS_VISIBLE | WS_BORDER,
		0, 0, 0, 0, hWnd, (HMENU)wID, hInstance, NULL);
	return TRUE;
}
