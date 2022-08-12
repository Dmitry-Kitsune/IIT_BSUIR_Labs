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
LPCSTR  lpszAppName = "Lab_7";
LPCTSTR lpszClassName = L"Key And Mause Demo Class";
HWND    hMainWnd;
static HMETAFILE hMF;
HDC hDCMeta;



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

	if (!hWnd) {
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
	PAINTSTRUCT PaintStruct;
	RECT Rect;
	HDC DC = GetDC(hWnd);
	DC = BeginPaint(hWnd, &PaintStruct);
	PlayMetaFile(DC, hMF);
	SetWindowOrgEx(DC, -400, 0, NULL);
	EndPaint(hWnd, &PaintStruct);
	return TRUE;
}

BOOL OnCREATE(HWND hWnd, LPCREATESTRUCT lpCreateStruct)
{
	PAINTSTRUCT ps;
	hDCMeta = CreateMetaFile(NULL);

	static LOGFONT lf;
	WCHAR lpszFace1[] = TEXT("Times New Roman");
	lf.lfCharSet = DEFAULT_CHARSET;
	lf.lfPitchAndFamily = DEFAULT_PITCH;
	wcscpy_s(lf.lfFaceName, lpszFace1);
	lf.lfHeight = 24;// высота текста в пунктах
	lf.lfWidth = 0;
	lf.lfWeight = FW_NORMAL;//Начертание обычное
	lf.lfItalic = 1;//Курсив
	lf.lfEscapement = 0;
	HFONT hFont = CreateFontIndirect(&lf);
	SelectObject(hDCMeta, hFont);
	SetTextColor(hDCMeta, RGB(255, 0, 0));
	TextOut(hDCMeta, 100, 100, TEXT("Бурляев Дмитрий Анатольевич"), lstrlen(TEXT("Бурляев Дмитрий Анатольевич")));

	HPEN hPen = CreatePen(PS_SOLID, 4, RGB(255, 0, 0)); // толщина линии и цвет
	HBRUSH hBrush = CreateHatchBrush(HS_BDIAGONAL, RGB(0, 255, 0)); // штриховка и цвет
	SelectObject(hDCMeta, hPen);
	SelectPen(hDCMeta, hPen);
	Ellipse(hDCMeta, 220, 190, 340, 310);// положение фигуры 1 R= 60
	SelectBrush(hDCMeta, hBrush);
	Rectangle(hDCMeta, 265, 310, 295, 340); //положение фигуры №2 и размер A 30x30
	DeleteObject(hBrush);
	DeleteObject(hPen);
	hMF = CloseMetaFile(hDCMeta);

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





