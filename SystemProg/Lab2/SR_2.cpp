#include <windows.h>
#include <tchar.h>
#include <cstdlib>

#define UNICODE
#define IDC_BTN_COMBINE 100
#define IDC_EDIT1 101
#define IDC_EDIT2 102
#define IDC_LISTBOX 103

//ПРОТОТИП ОКОННОЙ ПРОЦЕДУРЫ
LRESULT CALLBACK Pr2_WndProc(HWND, UINT, WPARAM, LPARAM);

//ОБЪЯВЛЕНИЕ ГЛОБАЛЬНЫХ ПЕРЕМЕННЫХ
LPCTSTR g_lpszClassName = TEXT("sr_2_class");
LPTSTR g_lpszAplicationTitle = TEXT("Главное окно самостоятельной работы.Програмист Гедройц М.В.");

LPCTSTR mounth_1 = TEXT("Январь");
LPCTSTR mounth_2 = TEXT("Февраль");
LPCTSTR mounth_3 = TEXT("Март");
LPCTSTR mounth_4 = TEXT("Апрель");
LPCTSTR mounth_5 = TEXT("Май");
LPCTSTR mounth_6 = TEXT("Июнь");
LPCTSTR mounth_7 = TEXT("Июль");
LPCTSTR mounth_8 = TEXT("Август");
LPCTSTR mounth_9 = TEXT("Сентябрь");
LPCTSTR mounth_10 = TEXT("Октябрь");
LPCTSTR mounth_11 = TEXT("Ноябрь");
LPCTSTR mounth_12 = TEXT("Декабрь");
//СТАРТОВАЯ ФУНКЦИЯ
int APIENTRY _tWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
	LPTSTR lpszCmdLine, int nCmdShow)
{
	WNDCLASSEX wc;
	MSG msg;
	HWND hWnd;

	memset(&wc, 0, sizeof(WNDCLASSEX));
	wc.cbSize = sizeof(WNDCLASSEX);
	wc.lpszClassName = g_lpszClassName;
	wc.lpfnWndProc = Pr2_WndProc;
	wc.style = CS_VREDRAW | CS_HREDRAW;
	wc.hInstance = hInstance;
	wc.hIcon = LoadIcon(NULL, MAKEINTRESOURCE(IDI_APPLICATION));
	wc.hCursor = LoadCursor(NULL, MAKEINTRESOURCE(IDC_ARROW));
	wc.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
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
		WS_OVERLAPPEDWINDOW,
		0,
		0,
		700,
		350,
		NULL,
		NULL,
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
	while (GetMessage(&msg, NULL, 0, 0))
	{
		DispatchMessage(&msg);
	}
	return msg.wParam;
}

// Оконная процедура
LRESULT CALLBACK Pr2_WndProc(HWND hWnd, UINT msg,
	WPARAM wParam, LPARAM lParam)
{
	
	HDC hDC;
	int wmId, wmEvent;
	static HWND hButtonCombine;
	static HWND hButtonExit;
	static HWND hEdit;
	static HWND hEdit2;
	static HWND hListBox;

	switch (msg)
	{

	case WM_DESTROY:// Завершение работы приложения
	{
		PostQuitMessage(0); // Посылка WM_QUIT приложению
		break;
	}

	case WM_CREATE:
	{
		if (!(hEdit = CreateWindowEx(0L, L"Edit", L"Редактор1",
			WS_CHILD | WS_BORDER | WS_VISIBLE|ES_MULTILINE,
			20, 30, 160, 200, hWnd, (HMENU)(IDC_EDIT1),
			NULL, NULL)))
			return (-1);
		if (!(hEdit2 = CreateWindowEx(0L, L"Edit", L"Редактор2",
			WS_CHILD | WS_BORDER | WS_VISIBLE|ES_NUMBER,
			250, 30, 160, 70, hWnd, (HMENU)(IDC_EDIT2),
			NULL, NULL)))
			return (-1);
		if (!(hListBox = CreateWindowEx(0L, L"ListBox", L"Список",
			WS_CHILD | WS_BORDER | WS_VISIBLE|LBS_MULTIPLESEL,
			500, 30, 160, 200, hWnd, (HMENU)(IDC_LISTBOX),
			NULL, NULL))) return (-1);
		if (!(hButtonCombine = CreateWindowEx(0L, L"Button", L"Объединить",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			200, 240, 110, 24, hWnd, (HMENU)(IDC_BTN_COMBINE),
			NULL, NULL))) return (-1);
		if (!(hButtonExit = CreateWindowEx(0L, L"Button", L"Выход",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			340, 240, 80, 24, hWnd, (HMENU)(IDCANCEL),
			NULL, NULL))) return (-1);			  
		SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)mounth_1);
		SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)mounth_2);
		SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)mounth_3);
		SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)mounth_4);
		SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)mounth_5);
		SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)mounth_6);
		SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)mounth_7);
		SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)mounth_8);
		SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)mounth_9);
		SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)mounth_10);
		SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)mounth_11);
		SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)mounth_12);
		return 0;
	}
	case WM_COMMAND:
	{
		wmId = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		static TCHAR pszBuff[500];
			switch (wmId)
			{
				case IDCANCEL:
				{
					DestroyWindow(hWnd);
					break;
				}

				case IDC_BTN_COMBINE:
				{
					int temp = SendMessage(hListBox, LB_GETSELCOUNT, 0, 0L);
					int pszBuff1[12];
					int day = 0;
					int buf = 0;
					TCHAR TEMP[30];
					LPCTSTR probel = TEXT(", ");
					SendMessage(hListBox, LB_GETSELITEMS, 12, (LPARAM)pszBuff1);
					for (int i = 0; i < temp; i++)
					{
						SendMessage(hListBox, LB_GETTEXT, (WPARAM)pszBuff1[i], (LPARAM)TEMP);
						if (pszBuff1[i] == 0 || pszBuff1[i] == 2 || pszBuff1[i] == 4 || pszBuff1[i] == 6 || pszBuff1[i] == 7 || pszBuff1[i] == 9 || pszBuff1[i] == 11)
						{
							buf = 31;
							day += buf;
						}
						else
						{
							if (pszBuff1[i] == 1)
							{
								buf = 28-30;
								day += buf;
							}
						buf = 30;
						day += buf;
						}   
						lstrcat(pszBuff, TEMP);
						lstrcat(pszBuff, probel);
					}
					WCHAR tempbuff[100];
					wsprintf(tempbuff, TEXT("summa=%d day"), day);
					SendMessage(hEdit, WM_SETTEXT, 0, (LPARAM)pszBuff);
					SendMessage(hEdit2, WM_SETTEXT, 0, (LPARAM)tempbuff);
				}
			    default:return DefWindowProc(hWnd, msg, wParam, lParam);
			}
	}

	default: // Вызов "Обработчика по умолчанию"
		return(DefWindowProc(hWnd, msg, wParam, lParam));
	}
		return FALSE;// Для ветвей с "break"
	}


