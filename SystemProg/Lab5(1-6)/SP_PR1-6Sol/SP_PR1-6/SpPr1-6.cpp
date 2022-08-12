// ��������� ����� ���� � ���������� 
// ���������� ����������
// Platform SDK/User Interface Services/User Input/Keyboard Input/
// Keyboard Input Reference/Keyboard Input Messages

#include <windows.h>
#include <windowsx.h>
#include <tchar.h>
#include <string.h> //������� ������ �� ��������
#include  <stdio.h>
#include <CommCtrl.h>

// ���������� ����������
int     nPosX = 20;
int     nPosY = 120;
LPCTSTR  lpszAppName = TEXT("������������ ��������� ����� ���� � ����������");
LPCTSTR lpszClassName = TEXT("Key And Mause Demo Class");
HWND    hMainWnd; // ���������� ���������� ����
BOOL fTrace = FALSE;
HDC g_hdc = nullptr;

//========��������������� ���������� �������=========================
  /* ��������� �������� ���� */
LRESULT WINAPI WndProc(HWND, UINT, WPARAM, LPARAM);
/* ����������� ������ �������� ���� */
BOOL Register(HINSTANCE);
/* �������� �������� ���� */
HWND Create(HINSTANCE, int);

/* ����������� �������� */ //���������� ����� �� ����� windowsx.h
/*--- WM_DESTROY -----------------------------------------------------*/
void  km_OnDestroy(HWND hwnd);
/*--- WM_CHAR --------------------------------------------------------*/
void  km_OnChar(HWND hwnd, UINT ch, int cRepeat);
/*--- WM_KEYUP,WM_KEYDOWN --------------------------------------------*/
void  km_OnKey(HWND hwnd, UINT vk, BOOL fDown, int cRepeat, UINT flags);
/*--- WM_SYSKEYDOWN, WM_SYSKEYUP  ------------------------------------*/
void  km_OnSysKey(HWND hwnd, UINT vk, BOOL fDown, int cRepeat, UINT flags);
/*--- WM_LBUTTONDOWN, WM_LBUTTONDBLCLK -------------------------------*/
void  km_OnLButtonDown(HWND hwnd, BOOL fDoubleClick, int x, int y, UINT keyFlags);
/*--- WM_LBUTTONUP ---------------------------------------------------*/
void  km_OnLButtonUp(HWND hwnd, int x, int y, UINT keyFlags);
/*--- WM_MOUSEMOVE ---------------------------------------------------*/
void  km_OnMouseMove(HWND hwnd, int x, int y, UINT keyFlags);
/*--- WM_PAINT -------------------------------------------------------*/
void  km_OnPaint(HWND hwnd);
/*--------------------------------------------------------------------*/
//====================================================================//


// ����� ����� � ��������� ===========================================//
int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrevInst,
	LPTSTR lpszCmdLine, int nCmdShow)
{
	MSG Msg;
	BOOL ok;

	ok = Register(hInst);
	if (!ok) return FALSE;

	hMainWnd = Create(hInst, nCmdShow);
	if (!hMainWnd) return FALSE;
	while (GetMessage(&Msg, NULL, 0, 0))
	{
		TranslateMessage(&Msg);
		DispatchMessage(&Msg);
	}
	return Msg.wParam;
}

//== ������� ��� ����������� ������ ���� =============================//
BOOL Register(HINSTANCE hinst)
{
	WNDCLASSEX WndClass;
	BOOL fRes;

	memset(&WndClass, 0, sizeof(WNDCLASSEX));
	WndClass.cbSize = sizeof(WNDCLASSEX);
	WndClass.lpszClassName = lpszClassName;
	WndClass.style = CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS;
	WndClass.lpfnWndProc = WndProc;
	WndClass.cbClsExtra = 0;
	WndClass.cbWndExtra = 0;
	WndClass.hInstance = hinst;
	WndClass.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	WndClass.hCursor = LoadCursor(NULL, IDC_ARROW);
	//WndClass.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	WndClass.hbrBackground = (HBRUSH)CreateSolidBrush(RGB(0, 255, 0));

	WndClass.lpszMenuName = NULL;

	fRes = (BOOL)RegisterClassEx(&WndClass);
	return fRes;
}

//== ������� �������� ���� ===========================================//
HWND Create(HINSTANCE hInstance, int nCmdShow)
{
	HWND hwnd = CreateWindowEx(0,
		lpszClassName, lpszAppName,
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, CW_USEDEFAULT,
		CW_USEDEFAULT, CW_USEDEFAULT,
		NULL, NULL, hInstance, NULL);
	if (hwnd == NULL) return hwnd;
	ShowWindow(hwnd, nCmdShow);
	UpdateWindow(hwnd);
	return hwnd;
}

//== ������� ��������� �������� ���� =================================//
LRESULT WINAPI
WndProc(HWND hwnd, UINT MesId, WPARAM wParam, LPARAM lParam)
{
	switch (MesId)
	{
		HANDLE_MSG(hwnd, WM_DESTROY, km_OnDestroy);
		HANDLE_MSG(hwnd, WM_CHAR, km_OnChar);
		HANDLE_MSG(hwnd, WM_KEYDOWN, km_OnKey);
		HANDLE_MSG(hwnd, WM_KEYUP, km_OnKey);
		HANDLE_MSG(hwnd, WM_MOUSEMOVE, km_OnMouseMove);
		HANDLE_MSG(hwnd, WM_LBUTTONDBLCLK, km_OnLButtonDown);
		HANDLE_MSG(hwnd, WM_LBUTTONDOWN, km_OnLButtonDown);
		HANDLE_MSG(hwnd, WM_LBUTTONUP, km_OnLButtonUp);
		HANDLE_MSG(hwnd, WM_PAINT, km_OnPaint);
		HANDLE_MSG(hwnd, WM_SYSKEYUP, km_OnSysKey);
		HANDLE_MSG(hwnd, WM_SYSKEYDOWN, km_OnSysKey);
	default:
		return DefWindowProc(hwnd, MesId, wParam, lParam);
	}
}

//====================================================================//
//====================================================================//

//=== ���������� ��������� WM_DESTROY ================================//
void km_OnDestroy(HWND hwnd)
{
	PostQuitMessage(0);
}

//=== ���������� ��������� WM_TCHAR ===================================//

void km_OnChar(HWND hwnd, UINT ch, int cRepeat)
{
	TCHAR S[100];//����� ��� ������������ ��������� ������(100 ����)
	HDC DC = GetDC(hwnd);//�������� �������� ���������� ������������ ������

	wsprintf(S, TEXT("WM_CHAR ==> Ch = %c   cRepeat = %d    "), ch, cRepeat);

	SetBkColor(DC, GetSysColor(COLOR_WINDOW));//������ ���� ����
	TextOut(DC, nPosX, nPosY + 20, S, lstrlen(S));//������� ������

	ReleaseDC(hwnd, DC);//����������� ��������
}

//=== ���������� ��������� WM_KEYUP,WM_KEYDOWN =======================//
void km_OnKey(HWND hwnd, UINT vk, BOOL fDown, int cRepeat, UINT flags)
{
	TCHAR S[100];//����� ��� ������������ ��������� ������(100 ����)
	HDC DC = GetDC(hwnd);//�������� �������� ���������� ������������ ������

	if (fDown) { //������� ������
		wsprintf(S, TEXT("WM_KEYDOWN ==> vk = %d fDown = %d cRepeat = %d flags = %d    "),
			vk, fDown, cRepeat, flags);
	}
	else {//������� ��������
		wsprintf(S, TEXT("WM_KEYUP ==> vk = %d fDown = %d cRepeat = %d flags = %d      "),
			vk, fDown, cRepeat, flags);
	}
	SetBkColor(DC, GetSysColor(COLOR_WINDOW));//������ ���� ����
	
	TextOut(DC, nPosX, nPosY + 40, S, lstrlen(S));//������� ������
	ReleaseDC(hwnd, DC);//����������� ��������
}


//=== ���������� ��������� WM_LBUTTONDOWN, WM_LBUTTONDBLCLK ==========//
void km_OnLButtonDown(HWND hwnd, BOOL fDoubleClick, int x,
	int y, UINT keyFlags)
{
	TCHAR S[100];//����� ��� ������������ ��������� ������(100 ����)
	HDC DC = GetDC(hwnd);//�������� �������� ���������� ������������ ������

	if (fDoubleClick) //������� ������
		wsprintf(S, TEXT("WM_LBUTTONDBLCLK ==> Db = %d x = %d y = %d Flags = %d "),
			fDoubleClick, x, y, keyFlags);
	else // ��������� ������ 
		wsprintf(S, TEXT("WM_LBUTTONDOWN ==> Db = %d x = %d y = %d Flags = %d "),
			fDoubleClick, x, y, keyFlags);

	//SetBkColor(DC, GetSysColor(RGB(0, 255, 0)));//������ ���� ����
	SetBkColor(DC, GetSysColor(COLOR_WINDOW));//������ ���� ����
	TextOut(DC, nPosX, nPosY + 100, S, lstrlen(S));//������� ������
	ReleaseDC(hwnd, DC);//����������� ��������


	fTrace = TRUE; // DRAW	
	if (fTrace) 
	{
		g_hdc = GetDC(hwnd); MoveToEx(g_hdc, x, y, NULL);
		SetCapture(hwnd);
	}
}

//=== ���������� ��������� WM_LBUTTONUP ==============================//
void km_OnLButtonUp(HWND hwnd, int x, int y, UINT keyFlags)
{
	TCHAR S[100];//����� ��� ������������ ��������� ������(100 ����)
	HDC  DC = GetDC(hwnd);//�������� �������� ���������� ������������ ������

	wsprintf(S, TEXT("MM LBUTTONUP ==> x = %d y = %d F = %d   "),
		x, y, keyFlags);

	//SetBkColor(DC, CreateSolidBrush(RGB(0, 255, 0)));//������ ���� ����
	SetBkColor(DC, GetSysColor(COLOR_WINDOW));
	TextOut(DC, nPosX, nPosY + 120, S, lstrlen(S));
	ReleaseDC(hwnd, DC);//����������� ��������
	
	ReleaseDC(hwnd, g_hdc);
	fTrace = FALSE;
	ReleaseCapture();

}

//=== ���������� ��������� WM_MOUSEMOVE ==============================//
void km_OnMouseMove(HWND hwnd, int x, int y, UINT keyFlags)
{
	TCHAR S[100];//����� ��� ������������ ��������� ������(100 ����)
	HDC DC = GetDC(hwnd);//�������� �������� ���������� ������������ ������

	wsprintf(S, TEXT("WM_MOUSEMOVE ==> x = %d y = %d keyFlags = %X    "),
		x, y, keyFlags);
	//������ ���� � ����������� �� ������� ������ ���� � ���������� 
	if ((keyFlags & MK_CONTROL) == MK_CONTROL) SetTextColor(DC, RGB(0, 0, 255));
	if ((keyFlags & MK_LBUTTON) == MK_LBUTTON) SetTextColor(DC, RGB(0, 255, 0));
	if ((keyFlags & MK_RBUTTON) == MK_RBUTTON) SetTextColor(DC, RGB(255, 0, 0));
	if ((keyFlags & MK_SHIFT) == MK_SHIFT)   SetTextColor(DC, RGB(255, 0, 255));


	//SetBkColor(DC, GetSysColor(RGB(0, 255, 0)));//������ ���� ����
	SetBkColor(DC, GetSysColor(COLOR_WINDOW)); //������������� ���� ����
	TextOut(DC, nPosX, nPosY + 80, S, lstrlen(S));// ������� ������ ������
	
	if (fTrace) LineTo(g_hdc, x, y);
	

	ReleaseDC(hwnd, DC);//����������� ��������
}



//=== ���������� ��������� WM_SYSKEYDOWN � WM_SYSKEYUP ===============//
void km_OnSysKey(HWND hwnd, UINT vk, BOOL fDown, int cRepeat, UINT flags)
{
	TCHAR S[100];//����� ��� ������������ ��������� ������(100 ����)
	HDC DC = GetDC(hwnd); //�������� �������� ���������� ������������ ������
	
	
	SetBkColor(DC, GetSysColor(COLOR_WINDOW)); //������ ����

	if (fDown)
	{// ��������� ������� ������
		wsprintf(S, TEXT("WM_SYSKEYDOWN ==> vk = %d fDown = %d cRepeat = %d flags = %d     "),
			vk, fDown, cRepeat, flags);
		TextOut(DC, nPosX, nPosY + 60, S, lstrlen(S));
		FORWARD_WM_SYSKEYDOWN(hwnd, vk, cRepeat, flags, DefWindowProc);
	}
	else
	{// ��������� ������� ��������
		wsprintf(S, TEXT("WM_SYSKEYUP == > vk = %d fDown = %d cRepeat = %d flags = %d      "),
			vk, fDown, cRepeat, flags);
		TextOut(DC, nPosX, nPosY + 60, S, lstrlen(S));
		FORWARD_WM_SYSKEYUP(hwnd, vk, cRepeat, flags, DefWindowProc);
	}
	ReleaseDC(hwnd, DC);//����������� �������� ����������
}

//=== ���������� ��������� WM_PAINT ==================================//
void km_OnPaint(HWND hwnd)
{
	PAINTSTRUCT PaintStruct;
	RECT Rect;
	//������ 1 � 2 ������ ������
	static LPCTSTR lpszTitle1 = TEXT("������������ ��������� ����� ���� � ����������");
	static LPCTSTR lpszTitle2 = TEXT("������������������ � ����� � �����������");

	//������ ���������� �� ������ ������������� ������ 
	static LPCTSTR SList[] =
	{
	TEXT("WM_CHAR     "),
	TEXT("WM_KEY      "),
	TEXT("WM_SYSKEY   "),
	TEXT("WM_MOUSEMOVE"),
	TEXT("WM_MOUSEDOWN"),
	TEXT("WM_MOUSEUP  ")
	};
	TCHAR S[200], S1[200]; //������ ��� ������������ ������ ������������� ������

	//��������� ������ S1 100 ��������� � ��������� �����
	TCHAR c = ' ';
	for (int i = 0; i < 100; i++) S1[i] = c;
	S1[100] = '\0';

	HDC PaintDC = BeginPaint(hwnd, &PaintStruct);//�������� ��������
	
	
	SetBkColor(PaintDC, GetSysColor(COLOR_WINDOW));//������ ����
	GetClientRect(hwnd, &Rect);//�������� ���������� ��������� �������
	DrawText(PaintDC, lpszTitle1, -1, &Rect, DT_CENTER);//������� ������ 1

	Rect.top = 20; //������ ���������� � ����� ������ ������
	Rect.bottom = 40; //������ ���������� � ���� ������ ������
	DrawText(PaintDC, lpszTitle2, -1, &Rect, DT_CENTER); //������� ������ 2 

	for (int i = 0; i < 6; i++)
	{// ������� 6 ����� � ����������� �� SList � ����������� 100 ���������
		lstrcpy(&S[0], SList[i]);//�������� � S ������ � ���������� �� SList[i]
		lstrcat(S, S1);// ���������� ������ S �� ������� S1    
		TextOut(PaintDC, nPosX, nPosY + (20 * (i + 1)), S, lstrlen(S));
	}
	EndPaint(hwnd, &PaintStruct);//����������� �������� ����������

}

//====================================================================//