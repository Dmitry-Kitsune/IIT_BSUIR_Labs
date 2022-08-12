// Обработка ввода мыши и клавиатуры 
// Справочная информация
// Platform SDK/User Interface Services/User Input/Keyboard Input/
// Keyboard Input Reference/Keyboard Input Messages

#include <windows.h>
#include <windowsx.h>
#include <tchar.h>
#include <string.h> //функция работы со строками
#include  <stdio.h>
#include <CommCtrl.h>

// Глобальные переменные
int     nPosX = 20;
int     nPosY = 120;
LPCTSTR  lpszAppName = TEXT("Демонстрация обработки ввода мыши и клавиатуры");
LPCTSTR lpszClassName = TEXT("Key And Mause Demo Class");
HWND    hMainWnd; // глобальный дескриптор окна
BOOL fTrace = FALSE;
HDC g_hdc = nullptr;

//========Предварительное объявление функций=========================
  /* Процедура главного окна */
LRESULT WINAPI WndProc(HWND, UINT, WPARAM, LPARAM);
/* Регистрация класса главного окна */
BOOL Register(HINSTANCE);
/* Создание главного окна */
HWND Create(HINSTANCE, int);

/* Обработчики соощений */ //прототтипы взяти из файла windowsx.h
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


// Точка входа в программу ===========================================//
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

//== Функция для регистрации класса окна =============================//
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

//== Функция создания окна ===========================================//
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

//== Оконная процедура главного окна =================================//
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

//=== Обработчик сообщения WM_DESTROY ================================//
void km_OnDestroy(HWND hwnd)
{
	PostQuitMessage(0);
}

//=== Обработчик сообщения WM_TCHAR ===================================//

void km_OnChar(HWND hwnd, UINT ch, int cRepeat)
{
	TCHAR S[100];//Буфер для формирования выводимой строки(100 байт)
	HDC DC = GetDC(hwnd);//Получаем контекст устройства графического вывода

	wsprintf(S, TEXT("WM_CHAR ==> Ch = %c   cRepeat = %d    "), ch, cRepeat);

	SetBkColor(DC, GetSysColor(COLOR_WINDOW));//Задаем цвет фона
	TextOut(DC, nPosX, nPosY + 20, S, lstrlen(S));//Выводим строку

	ReleaseDC(hwnd, DC);//Освобождаем контекст
}

//=== Обработчик сообщения WM_KEYUP,WM_KEYDOWN =======================//
void km_OnKey(HWND hwnd, UINT vk, BOOL fDown, int cRepeat, UINT flags)
{
	TCHAR S[100];//Буфер для формирования выводимой строки(100 байт)
	HDC DC = GetDC(hwnd);//Получаем контекст устройства графического вывода

	if (fDown) { //Клавиша нажата
		wsprintf(S, TEXT("WM_KEYDOWN ==> vk = %d fDown = %d cRepeat = %d flags = %d    "),
			vk, fDown, cRepeat, flags);
	}
	else {//Клавиша отпущена
		wsprintf(S, TEXT("WM_KEYUP ==> vk = %d fDown = %d cRepeat = %d flags = %d      "),
			vk, fDown, cRepeat, flags);
	}
	SetBkColor(DC, GetSysColor(COLOR_WINDOW));//Задаем цвет фона
	
	TextOut(DC, nPosX, nPosY + 40, S, lstrlen(S));//Выводим строку
	ReleaseDC(hwnd, DC);//Освобождаем контекст
}


//=== Обработчик сообщения WM_LBUTTONDOWN, WM_LBUTTONDBLCLK ==========//
void km_OnLButtonDown(HWND hwnd, BOOL fDoubleClick, int x,
	int y, UINT keyFlags)
{
	TCHAR S[100];//Буфер для формирования выводимой строки(100 байт)
	HDC DC = GetDC(hwnd);//Получаем контекст устройства графического вывода

	if (fDoubleClick) //Двойной щелчек
		wsprintf(S, TEXT("WM_LBUTTONDBLCLK ==> Db = %d x = %d y = %d Flags = %d "),
			fDoubleClick, x, y, keyFlags);
	else // Одиночный щелчек 
		wsprintf(S, TEXT("WM_LBUTTONDOWN ==> Db = %d x = %d y = %d Flags = %d "),
			fDoubleClick, x, y, keyFlags);

	//SetBkColor(DC, GetSysColor(RGB(0, 255, 0)));//Задаем цвет фона
	SetBkColor(DC, GetSysColor(COLOR_WINDOW));//Задаем цвет фона
	TextOut(DC, nPosX, nPosY + 100, S, lstrlen(S));//Выводим строку
	ReleaseDC(hwnd, DC);//Освобождаем контекст


	fTrace = TRUE; // DRAW	
	if (fTrace) 
	{
		g_hdc = GetDC(hwnd); MoveToEx(g_hdc, x, y, NULL);
		SetCapture(hwnd);
	}
}

//=== Обработчик сообщения WM_LBUTTONUP ==============================//
void km_OnLButtonUp(HWND hwnd, int x, int y, UINT keyFlags)
{
	TCHAR S[100];//Буфер для формирования выводимой строки(100 байт)
	HDC  DC = GetDC(hwnd);//Получаем контекст устройства графического вывода

	wsprintf(S, TEXT("MM LBUTTONUP ==> x = %d y = %d F = %d   "),
		x, y, keyFlags);

	//SetBkColor(DC, CreateSolidBrush(RGB(0, 255, 0)));//Задаем цвет фона
	SetBkColor(DC, GetSysColor(COLOR_WINDOW));
	TextOut(DC, nPosX, nPosY + 120, S, lstrlen(S));
	ReleaseDC(hwnd, DC);//Освобождаем контекст
	
	ReleaseDC(hwnd, g_hdc);
	fTrace = FALSE;
	ReleaseCapture();

}

//=== Обработчик сообщения WM_MOUSEMOVE ==============================//
void km_OnMouseMove(HWND hwnd, int x, int y, UINT keyFlags)
{
	TCHAR S[100];//Буфер для формирования выводимой строки(100 байт)
	HDC DC = GetDC(hwnd);//Получаем контекст устройства графического вывода

	wsprintf(S, TEXT("WM_MOUSEMOVE ==> x = %d y = %d keyFlags = %X    "),
		x, y, keyFlags);
	//Задаем цвет в зависимости от нажатых клавиш мыши и клавиатуры 
	if ((keyFlags & MK_CONTROL) == MK_CONTROL) SetTextColor(DC, RGB(0, 0, 255));
	if ((keyFlags & MK_LBUTTON) == MK_LBUTTON) SetTextColor(DC, RGB(0, 255, 0));
	if ((keyFlags & MK_RBUTTON) == MK_RBUTTON) SetTextColor(DC, RGB(255, 0, 0));
	if ((keyFlags & MK_SHIFT) == MK_SHIFT)   SetTextColor(DC, RGB(255, 0, 255));


	//SetBkColor(DC, GetSysColor(RGB(0, 255, 0)));//Задаем цвет фона
	SetBkColor(DC, GetSysColor(COLOR_WINDOW)); //Устанавливаем цвет фона
	TextOut(DC, nPosX, nPosY + 80, S, lstrlen(S));// Выводим строку текста
	
	if (fTrace) LineTo(g_hdc, x, y);
	

	ReleaseDC(hwnd, DC);//Освобождаем контекст
}



//=== Обработчик сообщений WM_SYSKEYDOWN и WM_SYSKEYUP ===============//
void km_OnSysKey(HWND hwnd, UINT vk, BOOL fDown, int cRepeat, UINT flags)
{
	TCHAR S[100];//Буфер для формирования выводимой строки(100 байт)
	HDC DC = GetDC(hwnd); //Получаем контекст устройства графического вывода
	
	
	SetBkColor(DC, GetSysColor(COLOR_WINDOW)); //Задаем цвет

	if (fDown)
	{// Системная клавиша нажата
		wsprintf(S, TEXT("WM_SYSKEYDOWN ==> vk = %d fDown = %d cRepeat = %d flags = %d     "),
			vk, fDown, cRepeat, flags);
		TextOut(DC, nPosX, nPosY + 60, S, lstrlen(S));
		FORWARD_WM_SYSKEYDOWN(hwnd, vk, cRepeat, flags, DefWindowProc);
	}
	else
	{// Системная клавиша отпущена
		wsprintf(S, TEXT("WM_SYSKEYUP == > vk = %d fDown = %d cRepeat = %d flags = %d      "),
			vk, fDown, cRepeat, flags);
		TextOut(DC, nPosX, nPosY + 60, S, lstrlen(S));
		FORWARD_WM_SYSKEYUP(hwnd, vk, cRepeat, flags, DefWindowProc);
	}
	ReleaseDC(hwnd, DC);//Освобождаем контекст устройства
}

//=== Обработчик сообщения WM_PAINT ==================================//
void km_OnPaint(HWND hwnd)
{
	PAINTSTRUCT PaintStruct;
	RECT Rect;
	//Строки 1 и 2 вверху экрана
	static LPCTSTR lpszTitle1 = TEXT("ДЕМОНСТРАЦИЯ ПЕРЕХВАТА ВВОДА МЫШИ И КЛАВИАТУРЫ");
	static LPCTSTR lpszTitle2 = TEXT("Поэкпериментируйте с мышью и клавиатурой");

	//Массив указателей на строки инициализации экрана 
	static LPCTSTR SList[] =
	{
	TEXT("WM_CHAR     "),
	TEXT("WM_KEY      "),
	TEXT("WM_SYSKEY   "),
	TEXT("WM_MOUSEMOVE"),
	TEXT("WM_MOUSEDOWN"),
	TEXT("WM_MOUSEUP  ")
	};
	TCHAR S[200], S1[200]; //Буферы для формирования строки инициализации экрана

	//Заполняем массив S1 100 пробелами и закрываем нулем
	TCHAR c = ' ';
	for (int i = 0; i < 100; i++) S1[i] = c;
	S1[100] = '\0';

	HDC PaintDC = BeginPaint(hwnd, &PaintStruct);//Получаем контекст
	
	
	SetBkColor(PaintDC, GetSysColor(COLOR_WINDOW));//Задаем цвет
	GetClientRect(hwnd, &Rect);//Получаем координаты клиентной области
	DrawText(PaintDC, lpszTitle1, -1, &Rect, DT_CENTER);//Выводим строку 1

	Rect.top = 20; //Задаем координату Х верха полосы вывода
	Rect.bottom = 40; //Задаем координату Х низа полосы вывода
	DrawText(PaintDC, lpszTitle2, -1, &Rect, DT_CENTER); //Выводим строку 2 

	for (int i = 0; i < 6; i++)
	{// Выводим 6 строк с указателями из SList и дополненных 100 пробелами
		lstrcpy(&S[0], SList[i]);//Копируем в S строку с указателем из SList[i]
		lstrcat(S, S1);// Объединяем строку S со строкой S1    
		TextOut(PaintDC, nPosX, nPosY + (20 * (i + 1)), S, lstrlen(S));
	}
	EndPaint(hwnd, &PaintStruct);//Освобождаем контекст устройства

}

//====================================================================//