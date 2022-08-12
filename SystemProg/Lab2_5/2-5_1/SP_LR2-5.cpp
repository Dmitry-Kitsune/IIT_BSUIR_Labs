// SP_LR2-5.cpp : Defines the entry point for the application.
#include <locale.h>
#include "windows.h"
#include "stdafx.h"
#include "SP_LR2-5.h"
#include "string.h"

#define MAX_LOADSTRING 100
#define FILENAME L"FILEREV.DAT"
#define lpszCmdLineT " Test.txt"
#include <clocale>
// Global Variables:
//int WINAPI WinMain(HINSTACE hinstExe, HINSTANCE hunstPrev, LPSTR lpszcmdLine, int nCmdShow)
//{

	HANDLE hFile;        // ��� ����������� ������� "����"
	HANDLE hFileMap;     // ��� ����������� ������� '������������ ����'
	LPVOID lpvFile;      // ��� ������ ������� � �������� ������������
	// ���� ����� ������������ ����
	HMENU g_hMenu;
	LPSTR  lpchANSI;     // ��������� �� ANSI ������

	DWORD  dwFileSize;   // ��� �������� ������� ����� 
	//LPTSTR lpszCmdLineT = "Test.txt\0"; // ��������� �� ��������� ������ 
	// � ANSI ��� UNICODE

	STARTUPINFO si = { 0 };    // ��������� ��� �������
	PROCESS_INFORMATION pi;// CreateProcess 
	HINSTANCE hInst;								// current instance
	TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
	TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name

	// Forward declarations of functions included in this code module:
	ATOM				MyRegisterClass(HINSTANCE hInstance);
	BOOL				InitInstance(HINSTANCE, int);
	LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
	INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);
	BOOL				CreateFileObj();
	BOOL				CreateFileProekt();
	BOOL				ViewToAddress();
	BOOL				CloseProektToAddress();
	BOOL				CloseHandleKernel();

	int APIENTRY _tWinMain(_In_ HINSTANCE hInstance,
		_In_opt_ HINSTANCE hPrevInstance,
		_In_ LPTSTR    lpCmdLine,
		_In_ int       nCmdShow)
	{
		UNREFERENCED_PARAMETER(hPrevInstance);
		UNREFERENCED_PARAMETER(lpCmdLine);

		// TODO: Place code here.
		MSG msg;
		HACCEL hAccelTable;

		// Initialize global strings
		LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
		LoadString(hInstance, IDC_SP_LR25, szWindowClass, MAX_LOADSTRING);
		MyRegisterClass(hInstance);

		// Perform application initialization:
		if (!InitInstance(hInstance, nCmdShow))
		{
			return FALSE;
		}

		hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_SP_LR25));

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
	ATOM MyRegisterClass(HINSTANCE hInstance)
	{
		WNDCLASSEX wcex;

		wcex.cbSize = sizeof(WNDCLASSEX);

		wcex.style = CS_HREDRAW | CS_VREDRAW;
		wcex.lpfnWndProc = WndProc;
		wcex.cbClsExtra = 0;
		wcex.cbWndExtra = 0;
		wcex.hInstance = hInstance;
		wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_SP_LR25));
		wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
		wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
		wcex.lpszMenuName = MAKEINTRESOURCE(IDC_SP_LR25);
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
		g_hMenu = GetMenu(hWnd);
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
		setlocale(LC_ALL, "en_US.utf8");
		switch (message)
		{
		case WM_COMMAND:
			wmId = LOWORD(wParam);
			wmEvent = HIWORD(wParam);
			// Parse the menu selections:
			switch (wmId)
			{
			case IDM_FILE_OBJFILE:
			{

				if (!CreateFileObj())
				{
					setlocale(LC_ALL, "en_US.utf8");
					MessageBoxW(hWnd, (LPCWSTR)L"Error create object File", (LPCWSTR)L"Message Menu", MB_OK);
					//MessageBoxW(hWnd, (LPCWSTR)L"Create object FileProekt successfull!", (LPCWSTR)L"Messeage Menu", MB_OK);
					//MessageBoxW(hWnd, (LPCWSTR)L"Create object File successfull!", (LPCWSTR)L"Messeage Menu", MB_OK);
					//MessageBoxW(hWnd, (LPCWSTR)L"Close handle kernel successfull!\n Please press OK to view result.", (LPCWSTR)"Messeage Menu", MB_OK);
					return FALSE;
					//return TRUE;
				}
				else
				{
					setlocale(LC_ALL, "en_US.utf8");
					MessageBoxW(hWnd, (LPCWSTR)L"Create object File successfull!", (LPCWSTR)L"Messeage Menu", MB_OK);
					EnableMenuItem(g_hMenu, IDM_FILE_OBJFILEPROEKT, MF_ENABLED);
					EnableMenuItem(g_hMenu, IDM_FILE_OBJFILE, MF_GRAYED);
					return TRUE;
				}
				break;
			}
			case IDM_FILE_OBJFILEPROEKT:
			{
				if (!CreateFileProekt())
				{
					setlocale(LC_ALL, "en_US.utf8");
					MessageBoxW(hWnd, (LPCWSTR)L"Error create object FileProekt", (LPCWSTR)L"Message Menu", MB_OK);
					return FALSE;
				}
				else
				{
					MessageBoxW(hWnd, (LPCWSTR)L"Create object FileProekt successfull!", (LPCWSTR)L"Messeage Menu", MB_OK);
					EnableMenuItem(g_hMenu, IDM_FILE_OBJFILEPROEKT, MF_GRAYED);
					EnableMenuItem(g_hMenu, IDM_FILE_OBJFILE, MF_GRAYED);
					EnableMenuItem(g_hMenu, IDM_FILE_VIEWTOADDRESS, MF_ENABLED);
					return TRUE;
				}
				break;
			}
			case IDM_FILE_VIEWTOADDRESS:
			{
				if (!ViewToAddress())
				{
					setlocale(LC_ALL, "en_US.utf8");
					MessageBox(hWnd, (LPCWSTR)L"Error display on the address space", (LPCWSTR)L"Message Menu", MB_OK);
					return FALSE;
				}
				else
				{
					MessageBoxW(hWnd, (LPCWSTR)L"Display on the address space successfull!", (LPCWSTR)L"Messeage Menu", MB_OK);
					EnableMenuItem(g_hMenu, IDM_FILE_OBJFILEPROEKT, MF_GRAYED);
					EnableMenuItem(g_hMenu, IDM_FILE_OBJFILE, MF_GRAYED);
					EnableMenuItem(g_hMenu, IDM_FILE_VIEWTOADDRESS, MF_GRAYED);
					EnableMenuItem(g_hMenu, IDM_FILE_CLOSEPROEKTADDRESS, MF_ENABLED);
					return TRUE;
				}
				break;
			}
			case IDM_FILE_CLOSEPROEKTADDRESS:
			{
				if (!CloseProektToAddress())
				{
					MessageBoxW(hWnd, (LPCWSTR)L"Error close projection into the address space", (LPCWSTR)L"Message Menu", MB_OK);
					return FALSE;
				}
				else
				{
					MessageBoxW(hWnd, (LPCWSTR)L"Close projection into the address space successfull!", (LPCWSTR)L"Messeage Menu", MB_OK);
					EnableMenuItem(g_hMenu, IDM_FILE_OBJFILEPROEKT, MF_GRAYED);
					EnableMenuItem(g_hMenu, IDM_FILE_OBJFILE, MF_GRAYED);
					EnableMenuItem(g_hMenu, IDM_FILE_VIEWTOADDRESS, MF_GRAYED);
					EnableMenuItem(g_hMenu, IDM_FILE_CLOSEPROEKTADDRESS, MF_GRAYED);
					EnableMenuItem(g_hMenu, IDM_FILE_CLOSEHANDLE, MF_ENABLED);
					return TRUE;
				}
				break;
			}
			case IDM_FILE_CLOSEHANDLE:
			{
				setlocale(LC_ALL, "en_US.utf8");
				if (!CloseProektToAddress())
				{
					MessageBoxW(hWnd, (LPCWSTR)L"Error close handle kernel", (LPCWSTR)L"Message Menu", MB_OK);
					return FALSE;
				}
				else
				{
					MessageBoxW(hWnd, (LPCWSTR)L"Close handle kernel successfull!\n Please press OK to view result.", (LPCWSTR)L"Messeage Menu", MB_OK);
					// ��������� NOTEPAD � ��������� � ���� ��������� ����,
					// ����� ������� ����� ����� ������
					si.cb = sizeof(si);// ��������� ���� ������� ��������� si
					si.wShowWindow = SW_SHOW;// ������ ����� ������ ���� NOTEPAD
					si.dwFlags = STARTF_USESHOWWINDOW;// ������������� ���� - ���������
					// �������� ���� wShowWindow
					if (CreateProcess(NULL, (LPWSTR)L"NOTEPAD.EXE" FILENAME,
						NULL, NULL, FALSE, 0,
						NULL, NULL, &si, &pi))
					{
						// ���� ������� ������, ����������� 
						// ����������� ������ � ��������	
						CloseHandle(pi.hThread);
						CloseHandle(pi.hProcess);
					}
					DestroyWindow(hWnd);
					break;
				}
			}


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

	BOOL CreateFileObj()
	{
		setlocale(LC_ALL, "en_US.utf8");
		// ����� �� ��������� ������� ����, �������� ��� � ����� ����,
		// ��� �������� ��������� ����� ������������ ���� ��������� FILENAME.

		if (!CopyFile((LPCWSTR)L"Test.txt", (LPCWSTR)FILENAME, FALSE))
		{
			// ����������� �� �������
			MessageBoxW(NULL, (LPCWSTR)L"New file could not be created.", (LPCWSTR)L"FileRev", MB_OK);
			//MessageBoxW(NULL, (LPCWSTR)L"New file could not be created.", (LPCWSTR)L"FILEREV.DAT", MB_OK);
			return (0);
		}

		// ��������� ���� ��� ������ � ������. ��� ����� ������� ������
		// ���� "����". � ����������� �� ��������� ���������� ������� 
		// CreateFile ���� ��������� ������������ ����, ���� ������� �����.
		// ������ ��� ������� ����� �������������� ��� �������� �����,
		// ������������� � ������. ������� ���������� ���������� ���������
		// ������� ����, ��� ��� ������ INVALID_HANDLE_VALUE.

		hFile = CreateFile(
			(LPCWSTR)FILENAME,
			//FILENAME,// ��������� �� ������ � ������� �����
			GENERIC_WRITE | GENERIC_READ, // ��������� ����� �������
			0,   //  ����� ����������,0 - ������������� ������ � �����.       
			NULL,// LPSECURITY_ATTRIBUTES=0 - ������ �� �����������.
			OPEN_EXISTING,//���� ���� �� ����������, �� ���������� ������.
			FILE_ATTRIBUTE_NORMAL,//�������� �������� ��� ���� 
			NULL //�� ������ ��� ������� ���� "����"
		);

		if (hFile == INVALID_HANDLE_VALUE)
		{  // ������� ���� �� �������
			//MessageBoxW(NULL, (LPCWSTR)L"File could not be opened.", (LPCWSTR)L"FileRev", MB_OK);
			MessageBoxW(NULL, (LPCWSTR)L"File could not be opened.", (LPCWSTR)L"FILEREV.DAT", MB_OK);
			return(0);
		}

		// ������ ������ �����. ������ �������� NULL, ��� ��� ��������������,
		// ��� ���� ������ 4 ��.
		dwFileSize = GetFileSize(hFile, NULL);
	}

	BOOL CreateFileProekt()
	{
		setlocale(LC_ALL, "en_US.utf8");
		// ������� ������ "������������ ����". �� - �� 1 ���� ������, ���
		// ������ �����, ����� ����� ���� �������� � ����� ����� ������� 
		// ������  � �������� � ������ ��� � ����-��������������� �������.
		// ��������� ���� ��� ���������� �������� ���� ANSI - ��� Unicode
		// - �������, ����������� ���� �� �������� ������� ������� WCHAR

		hFileMap = CreateFileMapping(
			hFile,  // ���������� ������������ ������� "����" 
			NULL,   // 
			PAGE_READWRITE, // �������� ������ ������� 
			0,  // LPSECURITY_ATTRIBUTES
			dwFileSize + sizeof(WCHAR),   //������� 32 �������
			NULL  // � ������� 32 ������� ������� �����.
		);
		if (hFileMap == NULL)
		{	// ������� ������ "������������ ����" �� �������
			//MessageBoxW(NULL, (LPCWSTR)L"File map could not be opened.", (LPCWSTR)L"FileRev", MB_OK);
			MessageBoxW(NULL, (LPCWSTR)L"File map could not be opened.", (LPCWSTR)L"FILEREV.DAT", MB_OK);
			CloseHandle(hFile);// ����� ������� ��������� �������� �������
			return (0);
		}
	}

	BOOL ViewToAddress()
	{
		setlocale(LC_ALL, "en_US.utf8");
		lpvFile = MapViewOfFile(
			hFileMap, // ���������� ������� "������������ ����" 
			FILE_MAP_WRITE, // ����� �������
			0, // ������� 32 ������� �������� �� ������ �����, 
			0, // ������� 32 ������� �������� �� ������ �����
			0  // � ���������� ������������ ����. 0 - ���� ����.
		);

		if (lpvFile == NULL)
		{// ������������� ������� ������������� ����� �� �������
			//MessageBoxW(NULL, (LPCWSTR)L"Could   not map view of tile.", (LPCWSTR)"FileRev", MB_OK);
			MessageBoxW(NULL, (LPCWSTR)L"Could   not map view of tile.", (LPCWSTR)L"FileRev", MB_OK);
			CloseHandle(hFileMap);// ����� ������� ��������� �������� �������
			CloseHandle(hFile);
			return(0);
		}


		// ���������� � ����� ����� ������� ������
		lpchANSI = (LPSTR)lpvFile;
		lpchANSI[dwFileSize] = 0;

		// "��������������" ���������� ����� ��������
		_strrev(lpchANSI);

		// ����������� ��� ���������� ����������� �������� "\n\r" ������� � "\r\n",
		// ����� ��������� ���������� ������������������ ����� "������� �������"
		// "������� ������", ����������� ������ � ��������� �����

		lpchANSI = strchr(lpchANSI, (int)'\n');   // ������� ����� ������� '\n'
		while (lpchANSI != NULL) //���� �� ������� ��� ������� '\n'
		{
			*lpchANSI = (int)'\r'; // �������� '\n' �� '\r'
			lpchANSI++;           // ����������� ���������
			*lpchANSI = (int)'\n';// �������� '\r' �� '\n' � ����������� ���������
			lpchANSI++;
			lpchANSI = strchr(lpchANSI, (int)'\n');  // ���� ������
		}
		return TRUE;
	}

	BOOL CloseProektToAddress()
	{
		UnmapViewOfFile(lpvFile);
		return TRUE;
	}

	BOOL CloseHandleKernel()
	{
		// ��������� ������� ������ �� ������ ���� "������������ ����"
		CloseHandle(hFileMap);

		// ������� ����������� ����� �������� ������� ����.��� �����
		// ���������� ��������� ����� � ����� �� ������� ����,
		// � ����� ���� ������� ���������� � ���� ����� ����� �����

		SetFilePointer(hFile, dwFileSize, NULL, FILE_BEGIN);
		SetEndOfFile(hFile);
		// SetEndOfFlle ����� �������� ����� �������� ����������� �������
		// ���� "������������ ����"

		CloseHandle(hFile);// ��������� ������� ������ �� ������ ���� "����"
		return TRUE;
	}
