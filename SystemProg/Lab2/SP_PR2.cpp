#include <windows.h>
#include <tchar.h>


#define IDC_BTN_SAVE 100
#define IDC_BTN_ADD 101
#define IDC_EDIT1 102
#define IDC_LISTBOX 103

//ПРОТОТИП ОКОННОЙ ПРОЦЕДУРЫ
LRESULT CALLBACK Pr2_WndProc(HWND, UINT, WPARAM, LPARAM);

//ОБЪЯВЛЕНИЕ ГЛОБАЛЬНЫХ ПЕРЕМЕННЫХ
LPCTSTR g_lpszClassName = TEXT ("sp_pr2_class");
LPTSTR g_lpszAplicationTitle = TEXT("Главное окно приложения.Програмист Гедройц М.В.");
LPTSTR g_lpszDestroyMessage = TEXT("Разрушается окно. В связи с этим поступило сообщение WM_DESTROY, из обработчика которого и выполнен данный вывод.");

//СТАРТОВАЯ ФУНКЦИЯ
int APIENTRY _tWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
	LPTSTR lpszCmdLine, int nCmdShow)
{
	WNDCLASSEX wc;
	MSG msg;
	HWND hWnd;
	HBRUSH my = CreateSolidBrush(RGB(255, 0, 0));

	memset(&wc, 0, sizeof(WNDCLASSEX));
	wc.cbSize = sizeof(WNDCLASSEX);
	wc.lpszClassName = g_lpszClassName; 
	wc.lpfnWndProc = Pr2_WndProc;
	wc.style = CS_VREDRAW | CS_HREDRAW;
	wc.hInstance = hInstance;
	wc.hIcon = LoadIcon(NULL, MAKEINTRESOURCE(IDI_APPLICATION));
	wc.hCursor = LoadCursor(NULL, MAKEINTRESOURCE(IDC_ARROW));
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

	case WM_LBUTTONDOWN:
	{
		LPCTSTR lpszString = TEXT("Обработка сообщения WM_LBUTTONDOWN, которое посылается в окно при щелчке левой кнопки мыши");
		hDC = GetDC(hWnd);
		//TextOut(hDC, 50, 200, lpszString, 600);
		//TextOut(hDC, LOWORD(lParam), HIWORD(lParam), lpszString, 600);
		RECT rectangle;
		rectangle.top = HIWORD(lParam);
		rectangle.left = LOWORD(lParam);
		DrawText(hDC, lpszString, 150, &rectangle, DT_LEFT | DT_TOP);
		break;
	}
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
		return 0;
	}
	case WM_COMMAND:
	{
		wmId = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		static TCHAR pszTextBuff[500];
		switch (wmId)
		{
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
				 return DefWindowProc(hWnd, msg, wParam, lParam);
		}

	default: // Вызов "Обработчика по умолчанию"
	return(DefWindowProc(hWnd, msg, wParam, lParam));
	}
	return FALSE;// Для ветвей с "break"
}
}

