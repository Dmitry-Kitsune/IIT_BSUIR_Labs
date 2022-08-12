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

	HANDLE hFile;        // Для дескриптора объекта "файл"
	HANDLE hFileMap;     // Для дескриптора объекта 'проецируемый файл'
	LPVOID lpvFile;      // Для адреса региона в адресном пространстве
	// куда будет отображаться файл
	HMENU g_hMenu;
	LPSTR  lpchANSI;     // Указатель на ANSI строку

	DWORD  dwFileSize;   // Для значения размера файла 
	//LPTSTR lpszCmdLineT = "Test.txt\0"; // Указатель на командную строку 
	// в ANSI или UNICODE

	STARTUPINFO si = { 0 };    // Структуры для функции
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
					// Запускаем NOTEPAD и загружаем в него созданный файл,
					// чтобы увидеть плоды своих трудов
					si.cb = sizeof(si);// Заполняем поле размера структуры si
					si.wShowWindow = SW_SHOW;// Задаем режим показа окна NOTEPAD
					si.dwFlags = STARTF_USESHOWWINDOW;// Устанавливаем флаг - учитывать
					// значение поля wShowWindow
					if (CreateProcess(NULL, (LPWSTR)L"NOTEPAD.EXE" FILENAME,
						NULL, NULL, FALSE, 0,
						NULL, NULL, &si, &pi))
					{
						// Если процесс создан, освобождаем 
						// дескрипторы потока и процесса	
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
		// Чтобы не испортить входной файл, копируем его в новый файл,
		// имя которого указываем через определенную выше константу FILENAME.

		if (!CopyFile((LPCWSTR)L"Test.txt", (LPCWSTR)FILENAME, FALSE))
		{
			// Копирование не удалось
			MessageBoxW(NULL, (LPCWSTR)L"New file could not be created.", (LPCWSTR)L"FileRev", MB_OK);
			//MessageBoxW(NULL, (LPCWSTR)L"New file could not be created.", (LPCWSTR)L"FILEREV.DAT", MB_OK);
			return (0);
		}

		// Открываем файл для чтения и записи. Для этого создаем объект
		// ядра "Файл". В зависимости от указанных параметров функция 
		// CreateFile либо открывает существующий файл, либо создает новый.
		// Только эта функция может использоваться для открытия файла,
		// проецируемого в память. Функция возвращает дескриптор открытого
		// объекта ядра, или код ошибки INVALID_HANDLE_VALUE.

		hFile = CreateFile(
			(LPCWSTR)FILENAME,
			//FILENAME,// Указатель на строку с имененм файла
			GENERIC_WRITE | GENERIC_READ, // Требуемый режим доступа
			0,   //  Режим разделения,0 - безраздельный доступ к файлу.       
			NULL,// LPSECURITY_ATTRIBUTES=0 - объект не наследуемый.
			OPEN_EXISTING,//Если файл не существует, то возвратить ошибку.
			FILE_ATTRIBUTE_NORMAL,//Оставить атрибуты как есть 
			NULL //Не давать имя объекту ядра "Файл"
		);

		if (hFile == INVALID_HANDLE_VALUE)
		{  // Открыть файл не удалось
			//MessageBoxW(NULL, (LPCWSTR)L"File could not be opened.", (LPCWSTR)L"FileRev", MB_OK);
			MessageBoxW(NULL, (LPCWSTR)L"File could not be opened.", (LPCWSTR)L"FILEREV.DAT", MB_OK);
			return(0);
		}

		// Узнаем размер файла. Второй параметр NULL, так как предполагается,
		// что файл меньше 4 Гб.
		dwFileSize = GetFileSize(hFile, NULL);
	}

	BOOL CreateFileProekt()
	{
		setlocale(LC_ALL, "en_US.utf8");
		// Создаем объект "проецируемый файл". Он - на 1 байт больше, чем
		// размер файла, чтобы можно было записать в конец файла нулевой 
		// символ  и работать с файлом как с нуль-терминированной строкой.
		// Поскольку пока еще неизвестно содержит файл ANSI - или Unicode
		// - символы, увеличиваем файл на величину размера символа WCHAR

		hFileMap = CreateFileMapping(
			hFile,  // Дескриптор проецирумого объекта "Файл" 
			NULL,   // 
			PAGE_READWRITE, // Атрибуты защиты страниц 
			0,  // LPSECURITY_ATTRIBUTES
			dwFileSize + sizeof(WCHAR),   //Младшие 32 разряда
			NULL  // и старшие 32 разряда размера файла.
		);
		if (hFileMap == NULL)
		{	// Открыть объект "проецируемый файл" не удалось
			//MessageBoxW(NULL, (LPCWSTR)L"File map could not be opened.", (LPCWSTR)L"FileRev", MB_OK);
			MessageBoxW(NULL, (LPCWSTR)L"File map could not be opened.", (LPCWSTR)L"FILEREV.DAT", MB_OK);
			CloseHandle(hFile);// Перед выходом закрываем открытые объекты
			return (0);
		}
	}

	BOOL ViewToAddress()
	{
		setlocale(LC_ALL, "en_US.utf8");
		lpvFile = MapViewOfFile(
			hFileMap, // Дескриптор объекта "Проецируемый файл" 
			FILE_MAP_WRITE, // Режим доступа
			0, // Старшие 32 разряда смещения от начала файла, 
			0, // младшие 32 разряда смещения от начала файла
			0  // и количество отображаемых байт. 0 - весь файл.
		);

		if (lpvFile == NULL)
		{// Спроецировать оконное представление файла не удалось
			//MessageBoxW(NULL, (LPCWSTR)L"Could   not map view of tile.", (LPCWSTR)"FileRev", MB_OK);
			MessageBoxW(NULL, (LPCWSTR)L"Could   not map view of tile.", (LPCWSTR)L"FileRev", MB_OK);
			CloseHandle(hFileMap);// Перед выходом закрываем открытые объекты
			CloseHandle(hFile);
			return(0);
		}


		// Записываем в конец файла нулевой символ
		lpchANSI = (LPSTR)lpvFile;
		lpchANSI[dwFileSize] = 0;

		// "Переворачиваем" содержимое файла наоборот
		_strrev(lpchANSI);

		// Преобразуем все комбинации управляющих символов "\n\r" обратно в "\r\n",
		// чтобы сохранить нормальную последовательность кодов "возврат каретки"
		// "перевод строки", завершающих строки в текстовом файле

		lpchANSI = strchr(lpchANSI, (int)'\n');   // Находим адрес первого '\n'
		while (lpchANSI != NULL) //Пока не найдены все символы '\n'
		{
			*lpchANSI = (int)'\r'; // Заменяем '\n' на '\r'
			lpchANSI++;           // Увеличиваем указатель
			*lpchANSI = (int)'\n';// Заменяем '\r' на '\n' и увеличиваем указатель
			lpchANSI++;
			lpchANSI = strchr(lpchANSI, (int)'\n');  // Ищем дальше
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
		// Уменьшаем счетчик ссылок на объект ядра "Проецируемый файл"
		CloseHandle(hFileMap);

		// Удаляем добавленный ранее концевой нулевой байт.Для этого
		// перемещаем указатель файла в конец на нулевой байт,
		// а затем даем команду установить в этом месте конец файла

		SetFilePointer(hFile, dwFileSize, NULL, FILE_BEGIN);
		SetEndOfFile(hFile);
		// SetEndOfFlle нужно вызывать после закрытия дескриптора объекта
		// ядра "Проецируемый файл"

		CloseHandle(hFile);// Уменьшаем счетчик ссылок на объект ядра "Файл"
		return TRUE;
	}
