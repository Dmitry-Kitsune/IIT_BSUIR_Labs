// BURLYAEV_DLL_I.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "Windows.h"
#include "Windowsx.h"
#include "resource.h"
#include <tchar.h>
#include "..\BURLYAEV_DLL\BURLYAEV_DLL.h"
#include "BURLYAEV_DLL_I.h"
#include "Resource.h"

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name
												
HMODULE hDLL = 0;
//FARPROC pg_nDllCallsCount, pg_nFnCallsCount;
typedef int(*LPV_1_TYPE);
LPV_1_TYPE g_nDllCallsCount_1 = NULL;
LPV_1_TYPE g_nFnCallsCount_1 = NULL;
TCHAR BUFFER[260];

//int * g_nDllCallsCount1=NULL;
//int * g_nFnCallsCount1=NULL;

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY _tWinMain(HINSTANCE hInstance,
	HINSTANCE hPrevInstance,
	LPTSTR    lpCmdLine,
	int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_BURLYAEV_DLL_I, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance(hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_BURLYAEV_DLL_I));


	if (GetModuleHandle(L"BURLYAEV_DLL.dll") == NULL)
	{
		//hDLL = LoadLibrary(L"BURLYAEV_DLL.dll");
		hDLL = LoadLibrary(L"BURLYAEV_DLL.dll");

		if (!hDLL)
		{
			//swprintf(BUFFER, TEXT("%s"), GetLastError());
			//MessageBox(NULL, BUFFER, TEXT("Connection error"), MB_OK);
			swprintf_s(NULL, NULL, TEXT("cannot locate BURLYAEV_DLL.dll file"), MB_OK);
			return GetLastError();
		}
		else
		{
			g_nDllCallsCount_1 = (LPV_1_TYPE)GetProcAddress(hDLL, "g_nDllCallsCount");
			g_nFnCallsCount_1 = (LPV_1_TYPE)GetProcAddress(hDLL, "g_nFnCallsCount");
		}
		if (g_nDllCallsCount_1 == NULL || g_nFnCallsCount_1 == NULL)
		{
			swprintf_s(NULL, NULL, TEXT("Connection error 2"), MB_OK);
			//swprintf(BUFFER, TEXT("%s"), GetLastError());
			//MessageBox(NULL, BUFFER, TEXT("Error reading variable address"), MB_OK);
			return GetLastError();
		}
	}
	// Main message loop:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int)msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
//  COMMENTS:
//
//    This function and its usage are only necessary if you want this code
//    to be compatible with Win32 systems prior to the 'RegisterClassEx'
//    function that was added to Windows 95. It is important to call this function
//    so that the application will get 'well formed' small icons associated
//    with it.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_BURLYAEV_DLL_I));
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = MAKEINTRESOURCE(IDC_BURLYAEV_DLL_I);
	wcex.lpszClassName = szWindowClass;
	wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
	HWND hWnd;

	hInst = hInstance; // Store instance handle in our global variable

	hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

	if (!hWnd)
	{
		return FALSE;
	}

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND	- process the application menu
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;
	int x = 0, y = 0, z = 0;
	double Fun31_result = 0;
	int WINAPI Fun32_result = 0;
	TCHAR BUFF[200] = { 0 };

	double x1 = 0, m;

	switch (message)
	{
	case WM_COMMAND:
		wmId = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case ID_DLLFUN31:
		{
			typedef double(*LPFN_1_TYPE) (int, int);
			LPFN_1_TYPE lpfnDllFunc31;
			
			lpfnDllFunc31 = (LPFN_1_TYPE)GetProcAddress(hDLL, "Fun31");
			if (!lpfnDllFunc31)
			{
				
				swprintf_s(BUFFER, TEXT("%s"), GetLastError());
				
				MessageBox(NULL, BUFFER, TEXT("Error reading function address"), MB_OK);
				return GetLastError();
			}
			else
			{
				x = 9; y = 4;
				Fun31_result = lpfnDllFunc31(x, y);
				
				(*g_nFnCallsCount_1)++;
				
				swprintf_s(BUFF, TEXT("Result Fun31=%d/%d=%2.3f\n Count calling functions = %d\n Count loaded librares = %d"),
					x, y, Fun31_result, *g_nFnCallsCount_1, *g_nDllCallsCount_1);

				MessageBox(hWnd, BUFF, L"Result Fun31", MB_OK);
			}
		}
		break;
		case ID_DLLFUN32:
		{
			typedef int   (WINAPI * LPFN_2_TYPE) (int, int, int);
			LPFN_2_TYPE lpfnDllFunc32;
			lpfnDllFunc32 = (LPFN_2_TYPE)GetProcAddress(hDLL, "Fun32");
			if (!lpfnDllFunc32)
			{
				
				swprintf_s(BUFFER, TEXT("%s"), GetLastError());
				
				MessageBox(NULL, BUFFER, TEXT("Error reading function address"), MB_OK);
				return GetLastError();
			}
			else
			{
				x = 9; y = 4; z = 5;
				Fun32_result = lpfnDllFunc32(x, y, z);
				(*g_nFnCallsCount_1)++;
				swprintf_s(BUFF, TEXT("Result Fun32=%d/%d=%2.3f\n Count calling functions = %d\n Count loaded librares = %d"),
					x, y, z, Fun32_result, *g_nFnCallsCount_1, *g_nDllCallsCount_1);

				MessageBox(hWnd, BUFF, L"Result Fun32", MB_OK);
			}
		}
		break;
		case ID_DLLFUN33:
		{
			typedef void(*LPFN_3_TYPE)(double, double*);
			LPFN_3_TYPE lpfnDllFunc33;
			lpfnDllFunc33 = (LPFN_3_TYPE)GetProcAddress(hDLL, "Fun33");
			if (!lpfnDllFunc33)
			{
				
				swprintf_s(BUFFER, TEXT("%s"), GetLastError());
				
				MessageBox(NULL, BUFFER, TEXT("Error reading function address"), MB_OK);
				return GetLastError();
			}
			else
			{
				x1 = 9;
				lpfnDllFunc33(x1, &m);
				(*g_nFnCallsCount_1)++;
				swprintf_s(BUFF, TEXT("Result Fun33=%d/%d=%2.3f\n Count calling functions = %d\n Count loaded librares = %d"),
					x1, m, *g_nFnCallsCount_1, *g_nDllCallsCount_1);
				MessageBox(hWnd, BUFF, L"Result Fun33", MB_OK);
			}
		}
		break;
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		// TODO: Add any drawing code here...
		EndPaint(hWnd, &ps);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}
