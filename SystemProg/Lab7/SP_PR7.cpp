#include <windows.h>
#include <windowsx.h>
#include <tchar.h>
#include <cmath>


//-- Prototypes -------------------
LRESULT CALLBACK PR2_WndProc(HWND, UINT, WPARAM, LPARAM); // прототип оконной процедуры

bool OnDESTROY(HWND hWnd);
BOOL OnCREATE(HWND hWnd, LPCREATESTRUCT lpCreateStruct);
BOOL OnPAINT(HWND hWnd);
BOOL OnCOMAND(HWND hWnd, int id, HWND hwndCtl, UINT codeNotify);


//-- Global Variables ------------

int wmId;


int APIENTRY _tWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPTSTR lpszCmdLine, int nCmdShow) {
	WNDCLASSEX wc;
	MSG msg;
	HWND hWnd;

	memset(&wc, 0, sizeof(WNDCLASSEX));
	wc.cbSize = sizeof(WNDCLASSEX);
	wc.lpszClassName = TEXT("SimpleClassName");
	wc.lpfnWndProc = PR2_WndProc;
	wc.style = CS_VREDRAW | CS_HREDRAW;
	wc.hInstance = hInstance;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;

	if (!RegisterClassEx(&wc)) {
		MessageBox(NULL, TEXT("Ошибка регистрации класса окна!"), TEXT("Ошибка"), MB_OK | MB_ICONERROR);
		return FALSE;
	}

	hWnd = CreateWindowEx(NULL,
		TEXT("SimpleClassName"),
		TEXT("Лабораторная работа 7-Графический вывод"),
		WS_OVERLAPPEDWINDOW,
		150, 100, 
		600, 500, 
		NULL, NULL, hInstance, NULL);

	if (!hWnd) 	{
		MessageBox(NULL, TEXT("Окно не создано!"), TEXT("Ошибка"), MB_OK | MB_ICONERROR);
		return FALSE;
	}

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	while (GetMessage(&msg, NULL, 0, 0)) {
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return msg.wParam;
}

// Оконная процедура 
LRESULT CALLBACK PR2_WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam) {
	switch (msg)
	{
		HANDLE_MSG(hWnd, WM_CREATE, OnCREATE);
		HANDLE_MSG(hWnd, WM_COMMAND, OnCOMAND);
		HANDLE_MSG(hWnd, WM_DESTROY, OnDESTROY);
		HANDLE_MSG(hWnd, WM_PAINT, OnPAINT);
	default:
		return(DefWindowProc(hWnd, msg, wParam, lParam));
	}
	return 0;
}

BOOL OnPAINT(HWND hWnd)
{
	PAINTSTRUCT ps;
	HDC hdc = BeginPaint(hWnd, &ps);
	static LOGFONT lf;
	WCHAR lpszFace1[] = TEXT("Times New Roman");
	lf.lfCharSet = DEFAULT_CHARSET;
	lf.lfPitchAndFamily = DEFAULT_PITCH;
	wcscpy_s(lf.lfFaceName, lpszFace1);
	lf.lfHeight = 20;// высота текста в пунктах
	lf.lfWidth = 0;
	lf.lfWeight = FW_NORMAL;//Начертание обычное
	lf.lfEscapement = 0;
	HFONT hFont = CreateFontIndirect(&lf);
	SelectObject(hdc, hFont);
	SetTextColor(hdc, RGB(0, 0, 255));
	TextOut(hdc, 100, 100, TEXT("Гедройц Максим Васильевич"), lstrlen(TEXT("Гедройц Максим Васильевич")));
	DeleteObject(hFont);

	//вывод в окно графического изображения/

HPEN hPen = CreatePen(PS_SOLID, 2, RGB(0, 255, 0));
HBRUSH hBrush = CreateHatchBrush(HS_BDIAGONAL, RGB(255, 0, 0));
SelectObject(hdc, hPen);
	SelectPen(hdc, hPen);
	Ellipse(hdc, 245, 190, 305, 250);
	SelectBrush(hdc, hBrush);
	Rectangle(hdc, 250, 250,300,300);
	DeleteObject(hBrush);
	DeleteObject(hPen);
EndPaint(hWnd, &ps);
	
	return TRUE;

}

BOOL OnCREATE(HWND hWnd, LPCREATESTRUCT lpCreateStruct)
{
	return TRUE;
}

BOOL OnCOMAND(HWND hWnd, int id, HWND hwndCtl, UINT codeNotify)
{
	wmId = LOWORD(MAKEWPARAM((UINT)(id), (UINT)(codeNotify)));

	return TRUE;
}

bool OnDESTROY(HWND hWnd)
{
	PostQuitMessage(0);
	return TRUE;
}





