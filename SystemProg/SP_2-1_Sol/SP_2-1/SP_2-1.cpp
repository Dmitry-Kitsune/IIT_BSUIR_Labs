// SP_2-1.cpp : Defines the entry point for the application.
//

#include "framework.h"
#include "SP_2-1.h"

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name
//====================================================================================

HANDLE ProcHandle[4] = {nullptr, nullptr, nullptr,nullptr};// для дескрипторов процессов;
DWORD ProcId[4] = { 0,0,0,0 }; // для идентификаторов процессов;
HANDLE ThreadHandle[4] = { nullptr, nullptr, nullptr,nullptr };//для дескрипторов потоков;
DWORD ThreadId[4] = { 0,0,0,0 };//для.идентификаторов потоков;
LPTSTR ProcImage[4] = { (LPTSTR)TEXT(""), (LPTSTR)TEXT("C:\\Windows\\notepad.exe"),
(LPTSTR)TEXT("C:\\Windows\\notepad.exe"), (LPTSTR)TEXT("C:\\Windows\\System32\\calc.exe"), };//для указателей строк, идентифицирущих файлы запускаемых программ;
TCHAR CmdParam[4][260] = { (LPTSTR)TEXT(""), (LPTSTR)TEXT(""),
(LPTSTR)TEXT(""), (LPTSTR)TEXT(""), };//для строк c параметрами запускаемых программ.


// Forward declarations of functions included in this code module:

ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

PCTSTR pszNotepad;
PCTSTR pszCalc;
PTSTR pszCommandLine;
INT_PTR CALLBACK ProcInfo(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Place code here.
    //=======================================================================================
    ProcHandle[0] = GetCurrentProcess();
    ProcId[0] = GetCurrentProcessId();
    ThreadHandle[0] = GetCurrentThread();
    ThreadId[0] = GetCurrentThreadId();
    TCHAR lpszFileName[260] = { 0 };
    if (GetModuleFileName(nullptr, lpszFileName, 260))
        ProcImage[0] = lpszFileName;
    



    //=======================================================================================
    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_SP21, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_SP21));

    MSG msg;

    // Main message loop:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_SP21));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_SP21);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
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
   hInst = hInstance; // Store instance handle in our global variable

   HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
     /* CW_USEDEFAULT, 0,*/ CW_USEDEFAULT, 0, 500, 500, nullptr, nullptr, hInstance, nullptr);

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
//  PURPOSE: Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_COMMAND:
        {
            int wmId = LOWORD(wParam);
            // Parse the menu selections:
            switch (wmId)
            {
            case IDM_ABOUT:
                DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
                break;
            case IDM_EXIT:
                DestroyWindow(hWnd);
                break;
            //==========================================================================
            case IDM_PROCESSES_NOTE:
            {
                SECURITY_ATTRIBUTES sap, sat;
                sap.nLength = sizeof(SECURITY_ATTRIBUTES);
                sap.lpSecurityDescriptor = nullptr;
                sap.bInheritHandle = FALSE;

                sap.nLength = sizeof(SECURITY_ATTRIBUTES);
                sap.lpSecurityDescriptor = nullptr;
                sap.bInheritHandle = FALSE;

                sap.nLength = sizeof(SECURITY_ATTRIBUTES);
                sap.lpSecurityDescriptor = nullptr;
                sap.bInheritHandle = FALSE;
                
                STARTUPINFO si;
                ZeroMemory(&si, sizeof(STARTUPINFO));
                si.cb = sizeof(STARTUPINFO);
                PROCESS_INFORMATION pi;
                //TCHAR szCammandLine[] = TEXT("NOTEPAD");
                //TCHAR ProcImage[] = TEXT(" C:\\Windows\\notepad.exe");
                //TCHAR cmd[] = TEXT("notepad");

                if (CreateProcess(
                    ProcImage[1], nullptr,
                    // nullptr, cmd, //TEXT("Notepad"),
                    //nullptr, (LPTSTR)ProcImage[1],
                   & sap, &sat,
                   FALSE, 0, nullptr, nullptr, &si, &pi))
               {
                   ProcHandle[1] = pi.hProcess;
                   ThreadHandle[1] = pi.hThread;
                   ProcId[1] = pi.dwProcessId;
                   ThreadId[1] = pi.dwThreadId;

                   CloseHandle(pi.hProcess);
                   CloseHandle(pi.hThread);

               }
            

            
            }
            break;


            case IDM_PROCESSES_TEXT: 
            {
                  SECURITY_ATTRIBUTES sap, sat;
                  sap.nLength = sizeof(SECURITY_ATTRIBUTES);
                  sap.lpSecurityDescriptor = nullptr;
                  sap.bInheritHandle = FALSE;

                  sap.nLength = sizeof(SECURITY_ATTRIBUTES);
                  sap.lpSecurityDescriptor = nullptr;
                  sap.bInheritHandle = FALSE;

                  sap.nLength = sizeof(SECURITY_ATTRIBUTES);
                  sap.lpSecurityDescriptor = nullptr;
                  sap.bInheritHandle = FALSE;

                  STARTUPINFO si;
                  ZeroMemory(&si, sizeof(STARTUPINFO));
                  si.cb = sizeof(STARTUPINFO);
                  PROCESS_INFORMATION pi;

                  //TCHAR szCammandLine[] = TEXT("NOTEPAD");
                  //TCHAR ProcImage[] = TEXT("C:\\Windows\\notepad.exe");
                  //TCHAR cmdparam[] = TEXT(" Resource.h");
                  //TCHAR cmdparam[] = TEXT(" C:\\Users\\Fuzzy\\Source\\Repos\\Dmitry-Kitsune\\SystemProg\\SP_2-1_Sol\\SP_2-1\\");
                  
                  TCHAR cmdparam[] = TEXT("Notepad  C:\\Users\\Fuzzy\\Source\\Repos\\Dmitry-Kitsune\\SystemProg\\SP_2-1_Sol\\SP_2-1\\Resource.h");
                  if (CreateProcess(
                      //ProcImage[2], cmdparam,
                      nullptr, cmdparam,
                      &sap, &sat,
                      FALSE, 0, nullptr, nullptr, &si, &pi))
                  {
                      ProcHandle[2] = pi.hProcess;
                      ThreadHandle[2] = pi.hThread;
                      ProcId[2] = pi.dwProcessId;
                      ThreadId[2] = pi.dwThreadId;
                  }
                                                
               
            }break;

             case IDM_PROCESSES_CALC: 
             {
                 SECURITY_ATTRIBUTES sap, sat;
                 sap.nLength = sizeof(SECURITY_ATTRIBUTES);
                 sap.lpSecurityDescriptor = nullptr;
                 sap.bInheritHandle = FALSE;

                 sap.nLength = sizeof(SECURITY_ATTRIBUTES);
                 sap.lpSecurityDescriptor = nullptr;
                 sap.bInheritHandle = FALSE;

                 sap.nLength = sizeof(SECURITY_ATTRIBUTES);
                 sap.lpSecurityDescriptor = nullptr;
                 sap.bInheritHandle = FALSE;

                 STARTUPINFO si;
                 ZeroMemory(&si, sizeof(STARTUPINFO));
                 si.cb = sizeof(STARTUPINFO);
                 PROCESS_INFORMATION pi;
                 //TCHAR szCammandLine[] = TEXT("NOTEPAD");
                 //TCHAR ProcImage[] = TEXT("C:\\Windows\\notepad.exe");
                 TCHAR cmd[] = TEXT("calc");

                 if (CreateProcess(
                     ProcImage[1], nullptr,
                     // nullptr, cmd, //TEXT("Notepad"),
                     // nullptr,(LPTSTR)ProcImage1,
                     &sap, &sat,
                     FALSE, 0, nullptr, nullptr, &si, &pi))
                 {
                     ProcHandle[1] = pi.hProcess;
                     ThreadHandle[1] = pi.hThread;
                     ProcId[1] = pi.dwProcessId;
                     ThreadId[1] = pi.dwThreadId;
                 }
             }break;
                 
             case IDM_PROCESSES_CLOSE:
             {
                 TerminateProcess(ProcHandle[2], 5);
             }
                
             //==========================================================================
             
             case IDM_INFIO_CURRENT:
             {
                 DialogBoxParam((HINSTANCE)GetWindowLong(hWnd,GWL_HINSTANCE),
                     MAKEINTRESOURCE(IDD_DIALOG1),hWnd, ProcInfo, 0);
                // MENUITEM "Current process", IDM_INFIO_CURRENT
                //    MENUITEM "Notepad", IDM_INFIO_NOTE
                //    MENUITEM "Text", IDM_INFIO_TEXT
                //    MENUITEM "Calc", IDM_INFIO_CALC
             }



            default:
                return DefWindowProc(hWnd, message, wParam, lParam);
            }
        }
        break;
    case WM_PAINT:
        {
            PAINTSTRUCT ps;
            HDC hdc = BeginPaint(hWnd, &ps);
            // TODO: Add any drawing code that uses hdc here...
            EndPaint(hWnd, &ps);
        }
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

INT_PTR CALLBACK ProcInfo(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    UNREFERENCED_PARAMETER(lParam);
    switch (message)
    {
    case WM_INITDIALOG:
//=====================================================================================
    {
        TCHAR message[260];
        SetDlgItemText(hDlg, IDC_EDIT1, ProcImage[lParam]);

        wsprintf(message, TEXT("x%08X"), ProcHandle[lParam]);
        SetDlgItemText(hDlg, IDC_EDIT2, message);
       
        wsprintf(message, TEXT("x%08X"), ProcHandle[lParam]);
        SetDlgItemText(hDlg, IDC_EDIT3, message);

        wsprintf(message, TEXT("x%08X"), ProcHandle[lParam]);
        SetDlgItemText(hDlg, IDC_EDIT4, message);

        wsprintf(message, TEXT("x%08X"), ProcHandle[lParam]);
        SetDlgItemText(hDlg, IDC_EDIT5, message);

        DWORD dwExitCode;

        if (!GetExitCodeProcess(ProcHandle[lParam], &dwExitCode))
        {//Error  выполнения request
            DWORD dwError = GetLastError();
                wsprintf(message, TEXT("Ошибка, код %d "), dwError);
        }
        else
            if (dwExitCode == STILL_ACTIVE)
            { // process not end
                wsprintf(message, TEXT(" % s"), TEXT("Процесс еще не завершился"), dwExitCode);

            }

    }

//====================================================================================
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
