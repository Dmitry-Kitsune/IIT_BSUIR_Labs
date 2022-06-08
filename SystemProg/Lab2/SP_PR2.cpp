#include <windows.h>
#include <tchar.h>


#define IDC_BTN_SAVE 100
#define IDC_BTN_ADD 101
#define IDC_EDIT1 102
#define IDC_LISTBOX 103

//�������� ������� ���������
LRESULT CALLBACK Pr2_WndProc(HWND, UINT, WPARAM, LPARAM);

//���������� ���������� ����������
LPCTSTR g_lpszClassName = TEXT ("sp_pr2_class");
LPTSTR g_lpszAplicationTitle = TEXT("������� ���� ����������.���������� ������� �.�.");
LPTSTR g_lpszDestroyMessage = TEXT("����������� ����. � ����� � ���� ��������� ��������� WM_DESTROY, �� ����������� �������� � �������� ������ �����.");

//��������� �������
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
		MessageBox(NULL, TEXT("������ ����������� ������ ����!"),
			TEXT("������"), MB_OK | MB_ICONERROR);
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
		MessageBox(NULL, TEXT("���� �� �������!"),
			TEXT("������"), MB_OK | MB_ICONERROR);
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

// ������� ���������
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

	case WM_DESTROY:// ���������� ������ ����������
	{
		MessageBox(NULL, g_lpszDestroyMessage,
					TEXT("���� �����������!"), MB_OK | MB_ICONERROR);
		PostQuitMessage(5); // ������� WM_QUIT ����������
		break;
	}

	case WM_LBUTTONDOWN:
	{
		LPCTSTR lpszString = TEXT("��������� ��������� WM_LBUTTONDOWN, ������� ���������� � ���� ��� ������ ����� ������ ����");
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
		LPCTSTR lpszString2 = TEXT("����� ������ ��� ��������� ��������� WM_PAINT.��� ���������� ���� �������� ����� ����, ��� ��� ���� ������� ������ ����� � ����� �������.");
		PAINTSTRUCT paint;
		hDC = BeginPaint(hWnd, &paint);
		TextOut(hDC, 20, 100, lpszString2, 600);
		EndPaint(hWnd, &paint);
		break;
		}*/
	case WM_CREATE:
	{
		LPCTSTR lpszString3 = TEXT("����������� ��������� WM_CREATE");
		LPCTSTR lpszTitleCreat = TEXT("Creat Window");
		MessageBox(NULL, lpszString3, lpszTitleCreat, MB_OK);
		if (!(hEdit = CreateWindowEx(0L, L"Edit", L"��������",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			20, 50, 160, 40, hWnd, (HMENU)(IDC_EDIT1),
			NULL, NULL))) return (-1);
		if (!(hListBox = CreateWindowEx(0L, L"ListBox", L"������",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			200, 50, 160, 180, hWnd, (HMENU)(IDC_LISTBOX),
			NULL, NULL))) return (-1);
		if (!(hButtonSave = CreateWindowEx(0L, L"Button", L"� �����",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			20, 240, 80, 24, hWnd, (HMENU)(IDC_BTN_SAVE),
			NULL, NULL))) return (-1);
		if (!(hButtonAdd = CreateWindowEx(0L, L"Button", L"� ������",
			WS_CHILD | WS_BORDER | WS_VISIBLE,
			120, 240, 80, 24, hWnd, (HMENU)(IDC_BTN_ADD),
			NULL, NULL))) return (-1);
		if (!(hButtonExit = CreateWindowEx(0L, L"Button", L"�����",
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
				if (cch == 0) MessageBox(hWnd, L"������� �����", L"������ Edit", MB_OK);
				else
				{
				TCHAR Buff1[500] = { 0 };
				SYSTEMTIME st; 
				GetSystemTime(&st);
				wsprintf(Buff1, L"����� : %d � %d ��� %d ���\n", st.wHour, st.wMinute, st.wSecond);
				lstrcat(Buff1, __TEXT("����� � ������: "));
				lstrcat(Buff1, pszTextBuff);
				MessageBox(hWnd, Buff1, L"���������� ������", MB_OK);
				}
				break;
			 }
			 case IDC_BTN_ADD:
			 {
				int ind;
				ind = SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)pszTextBuff);
				if (ind == LB_ERR) MessageBox(hWnd, L"������ � ������", L"", MB_OK);
				break;
			 }
			 default:
				 return DefWindowProc(hWnd, msg, wParam, lParam);
		}

	default: // ����� "����������� �� ���������"
	return(DefWindowProc(hWnd, msg, wParam, lParam));
	}
	return FALSE;// ��� ������ � "break"
}
}

