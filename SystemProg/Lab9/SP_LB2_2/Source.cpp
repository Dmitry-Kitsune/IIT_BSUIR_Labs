/***
***									Лабараторная работа 2 - 2
***/


#include <Windows.h>
#include <tchar.h>
#include "resource.h"
#include <windowsx.h>

#define g_lpszClassName TEXT("sp_pr2_class")
#define g_lpszAplicationTitle TEXT("Главное окно приложения. Программист Бурляев Д.А.")


struct THREAD_PARAM
{
	int Num; // Номер потока
	UINT XPos; // Позиция X области вывода
	UINT YPos; // Позиция Y области вывода
	HWND hWnd; // Дескиптор окна вывода
};


//-- Prototypes ----

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
void WndProc_OnCommand(HWND, int, HWND, UINT);
void WndProc_OnDestroy(HWND);
BOOL WndProc_OnCreate(HWND, LPCREATESTRUCT);

BOOL CALLBACK DlgProc(HWND, UINT, WPARAM, LPARAM);
BOOL DlgProc_OnInitDialog(HWND, HWND, LPARAM);
BOOL DlgProc_OnCommand(HWND, int, HWND, UINT);

_int64 FileTimeToQuadWord(PFILETIME);
PFILETIME QuadWordToFileTime(_int64, PFILETIME);

void DrawBitmap(HDC hdc, HBITMAP hBitmap, int xStart, int yStart);
void ForAnimation(HBITMAP bmPicture);

DWORD WINAPI ThreadFunc1(PVOID);
DWORD WINAPI ThreadFunc2(PVOID);


//-- Global variables ---- 

HINSTANCE g_Inst;
BOOL fDraw = 0;
UINT g_uXPos = 50;
UINT g_uYPos = 30;
HDC g_hDC;
THREAD_PARAM ThrParam1;
THREAD_PARAM ThrParam2;
THREAD_PARAM ThrParam3;
INT g_uThCount = 0;
DWORD dwSecThreadId[4];
HANDLE hSecThread[4];
BOOL Suspend[3];



int APIENTRY _tWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
	LPTSTR lpszCmdLine, int nCmdShow)
{
	WNDCLASSEX wc;
	MSG msg;
	HWND hWnd;
	Suspend[1] = false;
	Suspend[2] = false;

	memset(&wc, 0, sizeof(WNDCLASSEX));
	wc.cbSize = sizeof(WNDCLASSEX);
	wc.lpszClassName = g_lpszClassName;
	wc.lpfnWndProc = WndProc;
	wc.style = CS_VREDRAW | CS_HREDRAW;
	wc.hInstance = hInstance;
	wc.hIcon = NULL;
	wc.hCursor = LoadCursor(hInstance, MAKEINTRESOURCE(IDC_ARROW));
	wc.hbrBackground = CreateSolidBrush(RGB(0, 255, 0));
	wc.lpszMenuName = NULL;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;

	if (!RegisterClassEx(&wc))
	{
		MessageBeep(MB_ICONASTERISK);
		MessageBox(NULL, TEXT("Ошибка регистрации класса окна"), TEXT("Ошибка"), MB_OK | MB_ICONERROR);
		return FALSE;
	}

	HMENU hMenu = LoadMenu(hInstance, MAKEINTRESOURCE(IDR_MENU1));

	hWnd = CreateWindowEx(NULL,
		g_lpszClassName,
		g_lpszAplicationTitle,
		WS_OVERLAPPEDWINDOW,
		200,
		200,
		600,
		500,
		NULL,
		hMenu,
		hInstance,
		NULL);

	g_hDC = GetDC(hWnd);
	g_Inst = hInstance;


	ThrParam1 = { 1, g_uXPos, g_uYPos, hWnd };
	ThrParam2 = { 2, g_uXPos, g_uYPos + 24, hWnd };
	ThrParam3 = { 3, g_uXPos, g_uYPos + 44, hWnd };


	if (!hWnd)
	{
		MessageBeep(MB_ICONASTERISK);
		MessageBox(NULL, TEXT("Окно не создано!"), TEXT("Ошибка"), MB_OK | MB_ICONERROR);
		return FALSE;
	}
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);


	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
}



LRESULT CALLBACK WndProc(HWND hWnd, UINT msg,
	WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
		HANDLE_MSG(hWnd, WM_DESTROY, WndProc_OnDestroy);
		HANDLE_MSG(hWnd, WM_CREATE, WndProc_OnCreate);
		HANDLE_MSG(hWnd, WM_COMMAND, WndProc_OnCommand);

	default: // Вызов "Обработчика по умолчанию"
		return(DefWindowProc(hWnd, msg, wParam, lParam));
	}
}


void WndProc_OnDestroy(HWND hwnd)
{
	ReleaseDC(hwnd, g_hDC);
	PostQuitMessage(0);
}

BOOL WndProc_OnCreate(HWND hWnd, LPCREATESTRUCT lpCreateStruct)
{
	DuplicateHandle(
		GetCurrentProcess(), // описатель процесса.к которому относится псевдоописатель потока;
		GetCurrentThread(), // псевдоописатель родительского потока;
		GetCurrentProcess(), // описатель процесса, к которому относится новый, настоящий описатель потока;
		&hSecThread[0], // даст новый, настоящий описатель, идентифицирующий родительский поток;
		0, // игнорируется из-за DUPLICATE_SAME_ACCESS;
		FALSE, // новый описатель потока ненаследуемый;
		DUPLICATE_SAME_ACCESS); // новому описателю потока присваиваются те же атрибуты защиты, что и псевдоописателю
	dwSecThreadId[0] = GetCurrentThreadId();

	hSecThread[3] = CreateThread(NULL, 0L, ThreadFunc2, &ThrParam3, 0L, &dwSecThreadId[3]);

	return -1;
}

void WndProc_OnCommand(HWND hWnd, int id, HWND hwndCtl, UINT codeNotify)
{
	DWORD prior = NULL;
	DWORD exitCodeThread = NULL;

	switch (id)
	{
	case ID_THREAD1_CREATETHREAD:
		GetExitCodeThread(hSecThread[1], &exitCodeThread);
		if (exitCodeThread != STILL_ACTIVE)
		{
			g_uThCount++;
			SetWindowLong(hWnd, GWLP_USERDATA, 0L);
			hSecThread[1] = CreateThread(NULL, 0L, ThreadFunc1, &ThrParam1, 0L, &dwSecThreadId[1]);
		}
		else
			MessageBox(NULL, TEXT("Поток 1 уже был создан"), TEXT(""), MB_OK);
		break;

	case ID_THREAD2_CREATETHREAD:
		GetExitCodeThread(hSecThread[2], &exitCodeThread);
		if (exitCodeThread != STILL_ACTIVE)
		{
			g_uThCount++;
			SetWindowLong(hWnd, GWLP_USERDATA, 0L);
			hSecThread[2] = CreateThread(NULL, 0L, ThreadFunc1, &ThrParam2, 0L, &dwSecThreadId[2]);
		}
		else
			MessageBox(NULL, TEXT("Поток 2 уже был создан"), TEXT(""), MB_OK);
		break;

	case ID_THREAD1_CREATEWAITTHRED:
		GetExitCodeThread(hSecThread[1], &exitCodeThread);
		if (exitCodeThread != STILL_ACTIVE)
		{
			g_uThCount++;
			Suspend[1] = true;
			SetWindowLong(hWnd, GWLP_USERDATA, 0L);
			hSecThread[1] = CreateThread(NULL, 0L, ThreadFunc1, &ThrParam1, CREATE_SUSPENDED, &dwSecThreadId[1]);
		}
		else
			MessageBox(NULL, TEXT("Поток 1 уже был создан"), TEXT(""), MB_OK);
		break;

	case ID_THREAD2_CREATEWAITTHRED:
		GetExitCodeThread(hSecThread[2], &exitCodeThread);
		if (exitCodeThread != STILL_ACTIVE)
		{
			g_uThCount++;
			Suspend[2] = true;
			SetWindowLong(hWnd, GWLP_USERDATA, 0L);
			hSecThread[2] = CreateThread(NULL, 0L, ThreadFunc1, &ThrParam2, CREATE_SUSPENDED, &dwSecThreadId[2]);
		}
		else
			MessageBox(NULL, TEXT("Поток 2 уже был создан"), TEXT(""), MB_OK);
		break;

	case ID_THREAD1_PAUSETHREAD:
		GetExitCodeThread(hSecThread[1], &exitCodeThread);
		if (exitCodeThread == STILL_ACTIVE & Suspend[1] == false)
		{
			Suspend[1] = true;
			SuspendThread(hSecThread[1]);
		}
		else
			MessageBox(NULL, TEXT("Поток 1 ещё не создан или уже остановлен"), TEXT(""), MB_OK);
		break;

	case ID_THREAD2_PAUSETHREAD:
		GetExitCodeThread(hSecThread[2], &exitCodeThread);
		if (exitCodeThread == STILL_ACTIVE & Suspend[2] == false)
		{
			Suspend[2] = true;
			SuspendThread(hSecThread[2]);
		}
		else
			MessageBox(NULL, TEXT("Поток 2 ещё не создан"), TEXT(""), MB_OK);
		break;

	case ID_THREAD1_STARTTHREAD:
		GetExitCodeThread(hSecThread[1], &exitCodeThread);
		if (exitCodeThread == STILL_ACTIVE & Suspend[1] == true)
		{
			Suspend[1] = false;
			ResumeThread(hSecThread[1]);
		}
		else
			MessageBox(NULL, TEXT("Поток 1 ещё не создан или ещё не останавливался"), TEXT(""), MB_OK);
		break;

	case ID_THREAD2_STARTTHREAD:
		GetExitCodeThread(hSecThread[2], &exitCodeThread);
		if (exitCodeThread == STILL_ACTIVE & Suspend[2] == true)
		{
			Suspend[2] = false;
			ResumeThread(hSecThread[2]);
		}
		else
			MessageBox(NULL, TEXT("Поток 2 ещё не создан или ещё не останавливался"), TEXT(""), MB_OK);
		break;

	case ID_THREAD1_DESTROY:
		GetExitCodeThread(hSecThread[1], &exitCodeThread);
		if (exitCodeThread == STILL_ACTIVE)
		{
			Suspend[1] = false;
			ResumeThread(hSecThread[1]);
			SetWindowLong(hWnd, GWLP_USERDATA, 1L);
			MessageBox(NULL, TEXT("Началось завершение потока 1"), TEXT(""), MB_OK);
		}
		else
			MessageBox(NULL, TEXT("Поток 1 ещё не создан"), TEXT(""), MB_OK);
		break;

	case ID_THREAD2_DESTROY:
		GetExitCodeThread(hSecThread[2], &exitCodeThread);
		if (exitCodeThread == STILL_ACTIVE)
		{
			Suspend[2] = false;
			ResumeThread(hSecThread[2]);
			SetWindowLong(hWnd, GWLP_USERDATA, 2L);
			MessageBox(NULL, TEXT("Началось завершение потока 2"), TEXT(""), MB_OK);
		}
		else
			MessageBox(NULL, TEXT("Поток 2 ещё не создан"), TEXT(""), MB_OK);
		break;

	case ID_THREAD1_PRIORITYUP:
		GetExitCodeThread(hSecThread[1], &exitCodeThread);
		if (exitCodeThread == STILL_ACTIVE)
		{
			prior = GetThreadPriority(hSecThread[1]);
			SetThreadPriority(hSecThread[1], prior + 1);
		}
		else
			MessageBox(NULL, TEXT("Поток 1 ещё не создан"), TEXT(""), MB_OK);
		break;

	case ID_THREAD2_PRIORITYUP:
		GetExitCodeThread(hSecThread[2], &exitCodeThread);
		if (exitCodeThread == STILL_ACTIVE)
		{
			prior = GetThreadPriority(hSecThread[2]);
			SetThreadPriority(hSecThread[2], prior + 1);
		}
		else
			MessageBox(NULL, TEXT("Поток 2 ещё не создан"), TEXT(""), MB_OK);
		break;

	case ID_THREAD1_PRIORITYDOWN:
		GetExitCodeThread(hSecThread[1], &exitCodeThread);
		if (exitCodeThread == STILL_ACTIVE)
		{
			prior = GetThreadPriority(hSecThread[1]);
			SetThreadPriority(hSecThread[1], prior - 1);
		}
		else
			MessageBox(NULL, TEXT("Поток 1 ещё не создан"), TEXT(""), MB_OK);
		break;

	case ID_THREAD2_PRIORITYDOWN:
		GetExitCodeThread(hSecThread[2], &exitCodeThread);
		if (exitCodeThread == STILL_ACTIVE)
		{
			prior = GetThreadPriority(hSecThread[2]);
			SetThreadPriority(hSecThread[2], prior - 1);
		}
		else
			MessageBox(NULL, TEXT("Поток 2 ещё не создан"), TEXT(""), MB_OK);
		break;

	case ID_INFO_PRIMARYTHREAD:

		DialogBoxParam(g_Inst, MAKEINTRESOURCE(IDD_DIALOG1),
			hWnd,
			(DLGPROC)DlgProc,
			0);
		break;

	case ID_INFO_THREAD1:
		DialogBoxParam(g_Inst, MAKEINTRESOURCE(IDD_DIALOG1),
			hWnd,
			(DLGPROC)DlgProc,
			1);
		break;

	case ID_INFO_THREAD2:
		DialogBoxParam(g_Inst, MAKEINTRESOURCE(IDD_DIALOG1),
			hWnd,
			(DLGPROC)DlgProc,
			2);
		break;

	default:
		break;
	}
}


//Функция, выполняемая в каждом отдельном потоке(функция потока)

DWORD WINAPI ThreadFunc1(PVOID pvParam)
{
	LONG exitFlag = 0L;
	TCHAR Line[MAXCHAR] = { 0 }; // Буфер для символов бегущей строки

	THREAD_PARAM * ThrParam; // Локальная переменная для хранения переданного параметра
	ThrParam = (THREAD_PARAM *)pvParam;

#define MAXCHAR 500
	TCHAR CreepingLine[MAXCHAR] = { 0 }; // Буфер для символов бегущей строки
	TCHAR buf[MAXCHAR] = { 0 }; // Рабочий буфер для циклического сдвига строки

	int   iBeginningIndex; // Индекс начала выводимой последовательности символов

	int   StringLength = 0; // Длина строки

	RECT  rc;
	HDC   hDC;
	int cRun = 0; // Счетчик “пробегов” строки
	int N = 3; // Количество “пробегов” в серии

			   // Формирование текста бегущей строки
	wsprintf(CreepingLine,
		TEXT("Вторичный поток создал Бурляев Д.А., поток - %d"),
		ThrParam->Num, dwSecThreadId[ThrParam->Num]);

	//MessageBox(NULL, CreepingLine, TEXT("CreepingLine"), MB_OK);
	// Длинна строки
	StringLength = iBeginningIndex = lstrlen(CreepingLine);

	lstrcpy(buf, CreepingLine);

	// Задание прямоугольной области вывода
	GetClientRect(ThrParam->hWnd, &rc);
	rc.top = ThrParam->YPos;
	rc.left = ThrParam->XPos;
	rc.right = rc.right - ThrParam->XPos;

	// Получение контекста для вывода строки
	hDC = GetDC(ThrParam->hWnd);

	// Бесконечный цикл вывода строк сериями по N строк
	while (TRUE)
	{
		exitFlag = GetWindowLong(ThrParam->hWnd, GWLP_USERDATA);

		if ((exitFlag == 1L & ThrParam->Num == 1) |
			(exitFlag == 2L & ThrParam->Num == 2))
		{
			break;
		}

		/* // Взаимное исключение одновременного вывода
		// серии строк более чем одним потоком
		WaitForSingleObject(g_hMutex, INFINITE);
		*/
		cRun = 0;
		while (cRun < N - 1)// Цикл вывода серии из N строк
		{
			// Цикл однократного продвижения строки от последнего
			// символа до первого(перемещение слева направо в области вывода)
			for (int j = 0; j< StringLength; j++)
			{
				if (iBeginningIndex == 0)
				{
					iBeginningIndex = StringLength;
					cRun++; // Подсчет количества полных пробегов строки
				}

				// Cдвиг символов в рабочем буфере на одну позицию
				TCHAR c;
				c = buf[StringLength];
				for (int i = StringLength; i>0; i--)// Цикл сдвига
					buf[i] = buf[i - 1];
				buf[0] = c;

				// Ввывод строки
				DrawText(hDC, buf, -1, &rc, DT_LEFT | DT_SINGLELINE);

				iBeginningIndex--;

				Sleep(110); // приостановка потока на 200 мсек - замедление цикла

							// Альтернативный" подход - замедление "вращения" цикла 
							// без отказа от остатка кванта путем выполнения for_delay(mywait).
							// Позволяет наблюдать эффект от изменения приоритетов потоков.
							// for_delay(mywait) - любая работа, занимающая процессор
							// на некоторое время

			} // Конец цикла полного однократного “пробега” строки

		} // Конец цикла вывода серии строк

		  /* // конец критического участка кода – вывод серии строк
		  ReleaseMutex(g_hMutex);
		  */
	}

	wsprintf(Line,
		TEXT("Поток № %d Уничтожен"),
		ThrParam->Num);
	MessageBox(NULL, Line, TEXT(""), MB_OK);
	//hSecThread[ThrParam->Num] = NULL;
	g_uThCount--;


	Suspend[ThrParam->Num] = false;
	return 1;
}

void for_delay(int param)
{
	double x, y, z; x = 2.0; y = 3.0;
	for (int i = 0; i<param; i++) { z = x*y - 1; z = z + 1; }
}


BOOL CALLBACK DlgProc(HWND hdlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
		HANDLE_MSG(hdlg, WM_INITDIALOG, DlgProc_OnInitDialog);
		HANDLE_MSG(hdlg, WM_COMMAND, DlgProc_OnCommand);
	}	return FALSE;
}


BOOL DlgProc_OnCommand(HWND hdlg, int id, HWND hwndCtl, UINT codeNotify)
{
	switch (id)
	{
	case IDOK:
		EndDialog(hdlg, IDOK);
		return TRUE;
	}
}

_int64 FileTimeToQuadWord(PFILETIME pFileTime)
{
	_int64 qw;
	qw = pFileTime->dwHighDateTime;
	qw <<= 32;
	qw |= pFileTime->dwLowDateTime;
	return qw;
}


PFILETIME QuadWordToFileTime(_int64 qw, PFILETIME pFileTime)
{
	pFileTime->dwHighDateTime = (DWORD)(qw >> 32);
	pFileTime->dwLowDateTime = (DWORD)(qw & 0xffffffff);
	return pFileTime;
}



BOOL DlgProc_OnInitDialog(HWND hdlg, HWND hwndFocus, LPARAM lParam)
{
	HWND hEdit1 = GetDlgItem(hdlg, IDC_EDIT1);
	HWND hEdit2 = GetDlgItem(hdlg, IDC_EDIT2);
	HWND hEdit3 = GetDlgItem(hdlg, IDC_EDIT3);
	HWND hEdit4 = GetDlgItem(hdlg, IDC_EDIT4);
	HWND hEdit5 = GetDlgItem(hdlg, IDC_EDIT5);

	TCHAR Buff1[256] = { 0 };
	DWORD prior = NULL;
	DWORD exitCodeThread = NULL;

	wsprintf(Buff1, TEXT("%d"), dwSecThreadId[lParam]);
	SendMessage(hEdit1, WM_SETTEXT, 0, (LPARAM)Buff1);

	wsprintf(Buff1, TEXT("%d"), hSecThread[lParam]);
	SendMessage(hEdit2, WM_SETTEXT, 0, (LPARAM)Buff1);

	GetExitCodeThread(hSecThread[lParam], &exitCodeThread);
	if (Suspend[lParam] == true)
		wsprintf(Buff1, TEXT("Состояние - Ожидание "));
	else
		switch (exitCodeThread)
		{
		case STILL_ACTIVE:
			wsprintf(Buff1, TEXT("Состояние - Активен"));
			break;
		case 0:
			wsprintf(Buff1, TEXT("Состояние - Процесс не создавался"));
			break;

		default:
			wsprintf(Buff1, TEXT("Завершён с кодом %d"), exitCodeThread);
		}
	SendMessage(hEdit3, WM_SETTEXT, 0, (LPARAM)Buff1);


	prior = GetThreadPriority(hSecThread[lParam]);
	switch (prior)
	{
	case THREAD_PRIORITY_HIGHEST:
		lstrcpy(Buff1, TEXT("+2"));
		break;

	case THREAD_PRIORITY_ABOVE_NORMAL:
		lstrcpy(Buff1, TEXT("+1"));
		break;

	case THREAD_PRIORITY_NORMAL:
		lstrcpy(Buff1, TEXT("0"));
		break;

	case THREAD_PRIORITY_BELOW_NORMAL:
		lstrcpy(Buff1, TEXT("-1"));
		break;

	case THREAD_PRIORITY_LOWEST:
		lstrcpy(Buff1, TEXT("-2"));
		break;

	}
	SendMessage(hEdit4, WM_SETTEXT, 0, (LPARAM)Buff1);

	FILETIME ftCreation, ftExit, ftKernel, ftUser, ftWorking;
	_int64 working64;
	SYSTEMTIME stWorkind;
	if (GetThreadTimes(hSecThread[lParam], &ftCreation, &ftExit, &ftKernel, &ftUser))
	{

		if (exitCodeThread == STILL_ACTIVE)
		{
			SYSTEMTIME stCurrentTime;
			FILETIME ftCurrentTime;
			GetSystemTime(&stCurrentTime);

			SystemTimeToFileTime(&stCurrentTime, &ftCurrentTime);
			working64 = FileTimeToQuadWord(&ftCurrentTime) - FileTimeToQuadWord(&ftCreation);
		}
		else
			working64 = FileTimeToQuadWord(&ftExit) - FileTimeToQuadWord(&ftCreation);

		QuadWordToFileTime(working64, &ftWorking);
		FileTimeToSystemTime(&ftWorking, &stWorkind);
		wsprintf(Buff1, TEXT("%d мин, %d с, %d мс"), stWorkind.wMinute, stWorkind.wSecond, stWorkind.wMilliseconds);//время жизни процесса
		SendMessage(hEdit5, WM_SETTEXT, 0, (LPARAM)Buff1);
	}

	return TRUE;
}



DWORD WINAPI ThreadFunc2(PVOID pvParam)
{
	while (true)
	{
		ForAnimation(LoadBitmap(g_Inst, MAKEINTRESOURCE(IDB_BITMAP1)));
		ForAnimation(LoadBitmap(g_Inst, MAKEINTRESOURCE(IDB_BITMAP2)));
		ForAnimation(LoadBitmap(g_Inst, MAKEINTRESOURCE(IDB_BITMAP3)));
		ForAnimation(LoadBitmap(g_Inst, MAKEINTRESOURCE(IDB_BITMAP4)));

		
	}

	return 0;
}

void ForAnimation(HBITMAP bmPicture)
{
	DrawBitmap(g_hDC, bmPicture, 150, 150);
	Sleep(100);
}


void DrawBitmap(HDC hdc, HBITMAP hBitmap, int xStart, int yStart)
{
	BITMAP bm;
	HDC hdcMem;
	DWORD dwSize;
	POINT ptSize, ptOrg;

	hdcMem = CreateCompatibleDC(hdc);

	SelectObject(hdcMem, hBitmap);
	SetMapMode(hdcMem, GetMapMode(hdc));

	GetObject(hBitmap, sizeof(BITMAP), (LPVOID)&bm);

	ptSize.x = bm.bmWidth;
	ptSize.y = bm.bmHeight;

	DPtoLP(hdc, &ptSize, 1);

	ptOrg.x = 0;
	ptOrg.y = 0;

	DPtoLP(hdcMem, &ptOrg, 1);

	if (!BitBlt(
		hdc, xStart, yStart,
		ptSize.x, ptSize.y, hdcMem,
		ptOrg.x, ptOrg.y, SRCCOPY
	))

		DeleteDC(hdcMem);
}