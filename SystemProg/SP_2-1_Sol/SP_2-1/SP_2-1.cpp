// SP_2-1.cpp : Defines the entry point for the application.
//

#include <Windows.h>
#include <tchar.h>
#include <wchar.h>
#include "resource.h"
#include <WindowsX.h>
#include "framework.h"
#include "processthreadsapi.h"
#include <CommCtrl.h>

#include "SP_2-1.h"

#define MAX_LOADSTRING 100
#define MAX_BYTES  10000

#define g_lpszClassName TEXT("sp_pr2_class")
#define g_lpszAplicationTitle TEXT("SP-LB2-1 Бурляев Д.А. гр.00332")

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
INT_PTR CALLBACK    ProcInfo(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam); // Делегат

PCTSTR pszNotepad;
PCTSTR pszCalc;
PTSTR pszCommandLine;
INT_PTR CALLBACK ProcInfo(HWND, UINT, WPARAM, LPARAM);
HINSTANCE g_Inst;
//TCHAR CmdParam[4][260];

HWND g_MyhWnd;
HANDLE ProcHandleSam = NULL;
DWORD ProcIdSam = NULL;

//===============================================================================================
LRESULT CALLBACK Pr2_WndProc(HWND, UINT, WPARAM, LPARAM);
void OnCommand(HWND, int, HWND, UINT);
void OnDestroy(HWND);
BOOL WndProc_OnCreate(HWND, LPCREATESTRUCT);


BOOL WndAboutProc_OnInitDialog(HWND, HWND, LPARAM);
BOOL CALLBACK DlgProc(HWND, UINT, WPARAM, LPARAM);
BOOL DlgProc_OnInitDialog(HWND, HWND, LPARAM);
BOOL DlgProc_OnCommand(HWND, int, HWND, UINT);

BOOL CALLBACK TestProc(HWND, UINT, WPARAM, LPARAM);
BOOL TestProc_OnInitDialog(HWND, HWND, LPARAM);
BOOL TestProc_OnCommand(HWND, int, HWND, UINT);
BOOL CALLBACK EnumWindowsProc(HWND, LPARAM);

_int64 FileTimeToQuadWord(PFILETIME);
BOOL CALLBACK EnumWindowsProc(HWND, LPARAM);

//===============================================================================================


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

   // WindowsProc[] = EnumWindowsProc();
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

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDI_SP21));

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
    //wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_SP21));
    wcex.hIcon          = LoadIcon(hInstance, IDI_ASTERISK);
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
   // wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_SP21);
    //wcex.lpszMenuName = NULL;
    wcex.lpszClassName  = szWindowClass;
    // wcex.lpszClassName = g_lpszClassName;
    //wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));
    wcex.hIconSm        = LoadIcon(NULL, IDI_ASTERISK);
    wcex.hbrBackground  = CreateSolidBrush(RGB(0, 255, 0));
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

   //HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
   HWND hWnd = CreateWindowW(szWindowClass, g_lpszAplicationTitle, WS_OVERLAPPEDWINDOW & ~WS_MAXIMIZEBOX, // исключить MAXIMIZEBOX
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
            {
                SECURITY_ATTRIBUTES sap, sat;
                sap.nLength = sizeof(SECURITY_ATTRIBUTES);
                sap.lpSecurityDescriptor = nullptr;
                sap.bInheritHandle = FALSE;

                sat.nLength = sizeof(SECURITY_ATTRIBUTES);
                sat.lpSecurityDescriptor = nullptr;
                sat.bInheritHandle = FALSE;

            }

            //==========================================================================
        case IDM_PROCESSES_NOTE:
        {
            SECURITY_ATTRIBUTES sap, sat;
            sap.nLength = sizeof(SECURITY_ATTRIBUTES);
            sap.lpSecurityDescriptor = nullptr;
            sap.bInheritHandle = FALSE;

            sat.nLength = sizeof(SECURITY_ATTRIBUTES);
            sat.lpSecurityDescriptor = nullptr;
            sat.bInheritHandle = FALSE;

            STARTUPINFO si;
            ZeroMemory(&si, sizeof(STARTUPINFO));
            si.cb = sizeof(STARTUPINFO);
            PROCESS_INFORMATION pi;
            TCHAR szCammandLine[] = TEXT("NOTEPAD");
            TCHAR ProcImage[] = TEXT(" C:\\Windows\\notepad.exe");
            TCHAR CmdParam[] = TEXT("Resource.h");

            if (CreateProcess(nullptr,
                szCammandLine,
                //nullptr, cmd,// TEXT("Notepad"),
                // nullptr, 
                //ProcImage,// nullptr,
                // (LPTSTR)ProcImage1,
                &sap, &sat,
                FALSE, 0, nullptr, nullptr, &si, &pi))
            {
                ProcHandle[1] = pi.hProcess;
                ThreadHandle[1] = pi.hThread;
                ProcId[1] = pi.dwProcessId;
                ThreadId[1] = pi.dwThreadId;

          /*      CloseHandle(pi.hProcess);
                CloseHandle(pi.hThread);*/

            }
            TerminateProcess(ProcHandle[2], 5);
        }
        break;
        //============================================================================================
        case IDOK:
        {
            EndDialog(hWnd, IDOK);
        case IDM_PROCESSES_TEST:
        {
            SECURITY_ATTRIBUTES sap, sat;
            sap.nLength = sizeof(SECURITY_ATTRIBUTES);
            sap.lpSecurityDescriptor = nullptr;
            sap.bInheritHandle = FALSE;

            sat.nLength = sizeof(SECURITY_ATTRIBUTES);
            sat.lpSecurityDescriptor = nullptr;
            sat.bInheritHandle = FALSE;

            STARTUPINFO si;
            ZeroMemory(&si, sizeof(STARTUPINFO));
            si.cb = sizeof(STARTUPINFO);
            PROCESS_INFORMATION pi;

            DialogBoxParam(g_Inst, MAKEINTRESOURCE(IDD_DIALOG2),
                hWnd,
                (DLGPROC)TestProc,
                NULL);

            if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
            {
                EndDialog(hWnd, LOWORD(wParam));
                return (INT_PTR)TRUE;
            }break;

        case IDM_PROCESSES_TEST2:
        {
            SECURITY_ATTRIBUTES sap, sat;
            sap.nLength = sizeof(SECURITY_ATTRIBUTES);
            sap.lpSecurityDescriptor = nullptr;
            sap.bInheritHandle = FALSE;

            sat.nLength = sizeof(SECURITY_ATTRIBUTES);
            sat.lpSecurityDescriptor = nullptr;
            sat.bInheritHandle = FALSE;

            STARTUPINFO si;
            ZeroMemory(&si, sizeof(STARTUPINFO));
            si.cb = sizeof(STARTUPINFO);
            PROCESS_INFORMATION pi;

            DialogBoxParam(g_Inst, MAKEINTRESOURCE(IDD_DIALOG3),
                hWnd,
                (DLGPROC)TestProc,
                NULL);

            if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
            {
                EndDialog(hWnd, LOWORD(wParam));
                return (INT_PTR)TRUE;
            }break;
        }break;
        case IDM_PROCESSES_WORK:
        {
            DWORD dwNumbOfBytes = MAX_BYTES;
            TCHAR Buffer[MAX_BYTES] = { 0 };
            HANDLE hFile = NULL;
            TCHAR CmdParam7[260];
            OPENFILENAME ofn;   // структура для common dialog box
            TCHAR lpszFileSpec[260];   // массив для имени файла

                                       //Иницализация OPENFILENAME
            ZeroMemory(&ofn, sizeof(OPENFILENAME));
            ofn.lStructSize = sizeof(OPENFILENAME);
            ofn.hwndOwner = hWnd;  // hwnd – дескриптор окна–влвдельца
            ofn.lpstrFile = lpszFileSpec;
            ofn.lpstrFile[0] = '\0';
            ofn.nMaxFile = sizeof(lpszFileSpec);
            // Формирование массива строк шаблонов фильтра
            ofn.lpstrFilter = TEXT("All\0*.*\0Text\0*.TXT\0");
            ofn.nFilterIndex = 1; // Индекс для текущего шаблона фильтра
            ofn.lpstrFileTitle = NULL; // Без заголовка
            ofn.nMaxFileTitle = 0;
            ofn.lpstrInitialDir = NULL; // В качестве начального текущий каталог
            ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;

            // Отображение диалогового окна
            BOOL fRet = GetOpenFileName(&ofn);
            STARTUPINFO si;
            ZeroMemory(&si, sizeof(STARTUPINFO));
            si.cb = sizeof(STARTUPINFO);
            PROCESS_INFORMATION pi;

            if (fRet != FALSE)
            {
                TCHAR Buff1[100] = { 0 };
                TCHAR temp[100] = TEXT("notepad ");
                _tcscpy_s(Buff1, ofn.lpstrFile);
                int j = 8;
                for (int i = 0; i < _tcslen(Buff1); i++)
                {
                    temp[j] = Buff1[i];
                    if (Buff1[i] == '\\')
                    {
                        temp[j + 1] = '\\';
                        j++;
                    }
                    j++;
                }
                _tcscpy_s(CmdParam7, temp);

                if (!CreateProcess(NULL, CmdParam7, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi))
                    MessageBox(NULL, TEXT("Процесс не создан"), TEXT(""), MB_OK | MB_ICONERROR);


                WaitForSingleObject(pi.hProcess, INFINITE);


                hFile = CreateFile(ofn.lpstrFile, GENERIC_READ,
                    0, (LPSECURITY_ATTRIBUTES)NULL,
                    OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL,
                    (HANDLE)NULL);
                //Проверка корректности открытия файла
                if (hFile != INVALID_HANDLE_VALUE)
                {
                    ReadFile(hFile, Buffer, dwNumbOfBytes, &dwNumbOfBytes, NULL);
                    SetDlgItemText(hWnd, IDM_PROCESSES_WORK, Buffer);
                }
            }
            CloseHandle(hFile);
            CloseHandle(pi.hProcess);
            CloseHandle(pi.hThread);
        }break;
        }
        case IDM_EXIT:
            DestroyWindow(hWnd);
            break;
            //============================================================================================
        case IDM_PROCESSES_TEXT:
        {
            SECURITY_ATTRIBUTES sap, sat;
            sap.nLength = sizeof(SECURITY_ATTRIBUTES);
            sap.lpSecurityDescriptor = nullptr;
            sap.bInheritHandle = FALSE;

            sat.nLength = sizeof(SECURITY_ATTRIBUTES);
            sat.lpSecurityDescriptor = nullptr;
            sat.bInheritHandle = FALSE;


            STARTUPINFO si;
            ZeroMemory(&si, sizeof(STARTUPINFO));
            si.cb = sizeof(STARTUPINFO);
            PROCESS_INFORMATION pi;

            //TCHAR szCammandLine[] = TEXT("NOTEPAD");
            //TCHAR ProcImage[] = TEXT("C:\\Windows\\notepad.exe");
            //TCHAR cmdparam[] = TEXT(" Resource.h");
            //TCHAR cmdparam[] = TEXT(" C:\\Users\\Fuzzy\\Source\\Repos\\Dmitry-Kitsune\\SystemProg\\SP_2-1_Sol\\SP_2-1\\");
            TCHAR CmdParam[] = TEXT("Notepad.exe C:\\Users\\Fuzzy\\Source\\Repos\\Dmitry-Kitsune\\SystemProg\\SP_2-1_Sol\\SP_2-1\\Resource.h");
            if (CreateProcess(
                //ProcImage, 
                //cmdparam,
                nullptr, CmdParam,
                &sap, &sat,
                FALSE, 0, nullptr, nullptr, &si, &pi))
            {
                ProcHandle[2] = pi.hProcess;
                ThreadHandle[2] = pi.hThread;
                ProcId[2] = pi.dwProcessId;
                ThreadId[2] = pi.dwThreadId;

                //CloseHandle(pi.hProcess);
                //CloseHandle(pi.hThread);
            }

        }break;

        case IDM_PROCESSES_CALC:
        {
            SECURITY_ATTRIBUTES sap, sat;
            sap.nLength = sizeof(SECURITY_ATTRIBUTES);
            sap.lpSecurityDescriptor = nullptr;
            sap.bInheritHandle = FALSE;

            sat.nLength = sizeof(SECURITY_ATTRIBUTES);
            sat.lpSecurityDescriptor = nullptr;
            sat.bInheritHandle = FALSE;

            STARTUPINFO si;
            ZeroMemory(&si, sizeof(STARTUPINFO));
            si.cb = sizeof(STARTUPINFO);
            PROCESS_INFORMATION pi;
            //TCHAR szCammandLine[] = TEXT("NOTEPAD");
            //TCHAR ProcImage[] = TEXT("C:\\Windows\\notepad.exe");
            TCHAR CmdParam[] = TEXT(" calc");

            if (CreateProcess(
                ProcImage[3], CmdParam,
                // nullptr, cmd, //TEXT("Notepad"),
                // nullptr,(LPTSTR)ProcImage1,
                &sap, &sat,
                FALSE, 0, nullptr, nullptr, &si, &pi))
            {
                ProcHandle[3] = pi.hProcess;
                ThreadHandle[3] = pi.hThread;
                ProcId[3] = pi.dwProcessId;
                ThreadId[3] = pi.dwThreadId;

     /*           CloseHandle(pi.hProcess);
                CloseHandle(pi.hThread);*/
            }
        }break;
        return TRUE;
        case IDM_PROCESSES_CLOSE:
        {
             TerminateProcess(ProcHandle[3], 5);
        }break;

        //==========================================================================
        case IDOK1:
        {
            EndDialog(hWnd, IDOK);
        case IDM_INFIO_CURRENT:
        {
            DialogBoxParam((HINSTANCE)GetWindowLong(hWnd, GWL_HINSTANCE),
                MAKEINTRESOURCE(IDD_DIALOG1), hWnd, ProcInfo, 0);

            //    MENUITEM "Current process", IDM_INFIO_CURRENT
        }break;

        case IDM_INFIO_NOTE:
        {
            DialogBoxParam((HINSTANCE)GetWindowLong(hWnd, GWL_HINSTANCE),
                MAKEINTRESOURCE(IDD_DIALOG1), hWnd, ProcInfo, 1);
            //    MENUITEM "Notepad", IDM_INFIO_NOTE
        }break;

        case IDM_INFIO_TEXT:
        {
            DialogBoxParam((HINSTANCE)GetWindowLong(hWnd, GWL_HINSTANCE),
                MAKEINTRESOURCE(IDD_DIALOG1), hWnd, ProcInfo, 2);
            //    MENUITEM "Text", IDM_INFIO_TEXT
        }break;

        case IDM_INFIO_CALC:
        {
            DialogBoxParam((HINSTANCE)GetWindowLong(hWnd, GWL_HINSTANCE),
                MAKEINTRESOURCE(IDD_DIALOG1), hWnd, ProcInfo, 3);

            //    MENUITEM "Calc", IDM_INFIO_CALC
        }break;

        /* default:
         return DefWindowProc(hWnd, message, wParam, lParam);*/
        }
        case ID_INFO2_CURRENT:
        {
            DialogBoxParam(g_Inst, MAKEINTRESOURCE(IDD_DIALOG3), hWnd, (DLGPROC)ProcInfo, 0);
            // последний параметр "за кулисами" передается как последний параметр с инфой для функции 
            //типа DLGPROC
            break;
            // последний параметр "за кулисами" передается как последний параметр с инфой для функции 
            //типа DLGPROC
        }

        case ID_INFO2_NOTEPAD:
        {
            if (ProcHandle[1] != NULL)
            {
                DialogBoxParam(g_Inst, MAKEINTRESOURCE(IDD_DIALOG3),
                    hWnd,
                    (DLGPROC)ProcInfo,
                    1);
            }
            else
                MessageBox(hWnd, TEXT("Процесс не создан"), TEXT("Ошибка"), MB_OK);
        }  break;

        case ID_INFO2_TEXT:
        {
            if (ProcHandle[2] != NULL)
            {
                DialogBoxParam(g_Inst, MAKEINTRESOURCE(IDD_DIALOG3),
                    hWnd,
                    (DLGPROC)ProcInfo,
                    2);
            }
            else
                MessageBox(hWnd, TEXT("Процесс не создан"), TEXT("Ошибка"), MB_OK);
        } break;

        case ID_INFO2_CALC:
        {
            if (ProcHandle[3] != NULL)
            {
                DialogBoxParam(g_Inst, MAKEINTRESOURCE(IDD_DIALOG3),
                    hWnd,
                    (DLGPROC)ProcInfo,
                    3);
            }
            else
                MessageBox(hWnd, TEXT("Процесс не создан"), TEXT("Ошибка"), MB_OK);
        }break;

        return TRUE;
        }break;
        }
        
    }break;
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

// Message handler for about ProcInfo.
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

        wsprintf(message, TEXT("0x%08X"), ProcHandle[lParam]);
        SetDlgItemText(hDlg, IDC_EDIT2, message);
       
        wsprintf(message, TEXT("%d"), ProcId[lParam]);
        SetDlgItemText(hDlg, IDC_EDIT3, message);

        wsprintf(message, TEXT("x%08X"), ThreadHandle[lParam]);
        SetDlgItemText(hDlg, IDC_EDIT4, message);

        wsprintf(message, TEXT("%d"), ThreadId[lParam]);
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
                wsprintf(message, TEXT(" %s"), TEXT("Процесс еще не завершился"));

            }
            else
            { // process not end
                wsprintf(message, TEXT("Код завершения процесса %d"), dwExitCode);
            }
        SetDlgItemText(hDlg, IDC_EDIT6, message);
   
        TCHAR Buff[500] = { 0 };
        SYSTEMTIME st; GetSystemTime(&st);
        wsprintf(Buff, TEXT("Текущие дата и время: %02d.%02d.%d %02d:%02d "), st.wDay, st.wMonth, st.wYear, st.wHour, st.wMinute);
        SetDlgItemText(hDlg, IDC_EDIT7, Buff);

        HWND hEdit1 = GetDlgItem(hDlg, IDC_EDIT11);
        HWND hEdit2 = GetDlgItem(hDlg, IDC_EDIT12);
        HWND hEdit3 = GetDlgItem(hDlg, IDC_EDIT13);
        HWND hEdit4 = GetDlgItem(hDlg, IDC_EDIT14);
        HWND hEdit5 = GetDlgItem(hDlg, IDC_EDIT15);
        HWND hEdit6 = GetDlgItem(hDlg, IDC_EDIT16);
        HWND hEdit7 = GetDlgItem(hDlg, IDC_EDIT17);
        HWND hEdit8 = GetDlgItem(hDlg, IDC_EDIT18);
        HWND hEdit9 = GetDlgItem(hDlg, IDC_EDIT19);
        HWND hEdit10 = GetDlgItem(hDlg, IDC_EDIT20);
        HWND hEdit11 = GetDlgItem(hDlg, IDC_EDIT21);
        HWND hEdit12 = GetDlgItem(hDlg, IDC_EDIT22);
        HWND hEdit13 = GetDlgItem(hDlg, IDC_EDIT23);
        HWND hEdit14 = GetDlgItem(hDlg, IDC_EDIT6);
       
        _int64 FileTimeToQuadWord(PFILETIME);
        PFILETIME QuadWordToFileTime(_int64, PFILETIME);
        TCHAR Buff1[256] = { 0 };
        DWORD exitCodeProc = NULL;
        DWORD exitCodeThread = NULL;
        DWORD prior = NULL;


        lstrcpy(Buff1, ProcImage[lParam]);
        SendMessage(hEdit1, WM_SETTEXT, 0, (LPARAM)Buff1);

        lstrcpy(Buff1, CmdParam[lParam]);
        SendMessage(hEdit6, WM_SETTEXT, 0, (LPARAM)Buff1);

        wsprintf(Buff1, TEXT("%d"), ProcHandle[lParam]);
        SendMessage(hEdit2, WM_SETTEXT, 0, (LPARAM)Buff1);

        wsprintf(Buff1, TEXT("%d"), ProcId[lParam]);
        SendMessage(hEdit3, WM_SETTEXT, 0, (LPARAM)Buff1);

        wsprintf(Buff1, TEXT("%d"), ThreadHandle[lParam]);
        SendMessage(hEdit4, WM_SETTEXT, 0, (LPARAM)Buff1);

        wsprintf(Buff1, TEXT("%d"), ThreadId[lParam]);
        SendMessage(hEdit5, WM_SETTEXT, 0, (LPARAM)Buff1);

        GetExitCodeProcess(ProcHandle[lParam], &exitCodeProc);
        if (exitCodeProc == STILL_ACTIVE)
            wsprintf(Buff1, TEXT("Состояние - Активен"));
        else
            wsprintf(Buff1, TEXT("%d"), exitCodeProc);
        SendMessage(hEdit7, WM_SETTEXT, 0, (LPARAM)Buff1);

        GetExitCodeThread(ThreadHandle[lParam], &exitCodeThread);
        if (exitCodeThread == STILL_ACTIVE)
            wsprintf(Buff1, TEXT("Состояние - Активен"));
        else
            wsprintf(Buff1, TEXT("%d"), exitCodeThread);
        SendMessage(hEdit8, WM_SETTEXT, 0, (LPARAM)Buff1);
        SendMessage(hEdit14, WM_SETTEXT, 0, (LPARAM)Buff1);


        prior = GetPriorityClass(ProcHandle[lParam]);

        switch (prior)
        {
        case REALTIME_PRIORITY_CLASS:
            lstrcpy(Buff1, TEXT("Real-time"));
            break;

        case HIGH_PRIORITY_CLASS:
            lstrcpy(Buff1, TEXT("High"));
            break;

        case ABOVE_NORMAL_PRIORITY_CLASS:
            lstrcpy(Buff1, TEXT("Above normal"));
            break;

        case NORMAL_PRIORITY_CLASS:
            lstrcpy(Buff1, TEXT("Normal"));
            break;

        case BELOW_NORMAL_PRIORITY_CLASS:
            lstrcpy(Buff1, TEXT("Below normal"));
            break;

        case IDLE_PRIORITY_CLASS:
            lstrcpy(Buff1, TEXT("Idle"));
            break;
        }
        SendMessage(hEdit9, WM_SETTEXT, 0, (LPARAM)Buff1);


        FILETIME ftCreation, ftExit, ftKernel, ftUser, ftWorking, ftWaiting;
        _int64 working64, temp64, waiting64;
        SYSTEMTIME stCreation, stExit, stKernel, stUser, stWorkind, stWaiting;
        if (GetProcessTimes(ProcHandle[lParam], &ftCreation, &ftExit, &ftKernel, &ftUser))
        {
            FileTimeToSystemTime(&ftUser, &stUser);
            FileTimeToSystemTime(&ftKernel, &stKernel);

            if (exitCodeProc == STILL_ACTIVE)
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
            SendMessage(hEdit10, WM_SETTEXT, 0, (LPARAM)Buff1);

            wsprintf(Buff1, TEXT("%d мин, %d с, %d мс"), stUser.wMinute, stUser.wSecond, stUser.wMilliseconds);//в пользовательском режиме
            SendMessage(hEdit11, WM_SETTEXT, 0, (LPARAM)Buff1);
            wsprintf(Buff1, TEXT("%d мин, %d с, %d мс"), stKernel.wMinute, stKernel.wSecond, stKernel.wMilliseconds);//в режиме ядра
            SendMessage(hEdit12, WM_SETTEXT, 0, (LPARAM)Buff1);

            temp64 = FileTimeToQuadWord(&ftKernel) + FileTimeToQuadWord(&ftUser);
            waiting64 = working64 - temp64;
            QuadWordToFileTime(waiting64, &ftWaiting);
            FileTimeToSystemTime(&ftWaiting, &stWaiting);

            wsprintf(Buff1, TEXT("%d мин, %d с, %d мс"), stWaiting.wMinute, stWaiting.wSecond, stWaiting.wMilliseconds);//время простоя
            SendMessage(hEdit13, WM_SETTEXT, 0, (LPARAM)Buff1);
        }
        return TRUE;

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
//===============================================================================================

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
//==================================================================================== Самостоятельная работа
BOOL WndAboutProc_OnInitDialog(HWND hWnd, HWND hDlg, LPARAM lParam)
{
    TCHAR message[500];
    TCHAR Buff[500] = { 0 };
    SYSTEMTIME st; GetSystemTime(&st);
    wsprintf(Buff, TEXT("Текущие дата и время: %02d.%02d.%d %02d:%02d "), st.wDay, st.wMonth, st.wYear, st.wHour, st.wMinute);
    SetDlgItemText(hDlg, IDC_EDIT7, Buff);
    return (INT_PTR)TRUE;
}

BOOL CALLBACK TestProc(HWND hdlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
    switch (msg)
    {
        HANDLE_MSG(hdlg, WM_INITDIALOG, TestProc_OnInitDialog);
        HANDLE_MSG(hdlg, WM_COMMAND, TestProc_OnCommand);
    }	return FALSE;
}

BOOL TestProc_OnInitDialog(HWND hdlg, HWND hwndFocus, LPARAM lParam)
{
    HWND hR = GetDlgItem(hdlg, IDC_RADIO1);
    SendMessage(hR, BM_SETCHECK, 1, 0);

    SetDlgItemText(hdlg, IDC_EDIT_WIDTH, TEXT("400"));
    SetDlgItemText(hdlg, IDC_EDIT_HEIGHT, TEXT("250"));
    SetDlgItemText(hdlg, IDC_EDIT_XPOS, TEXT("100"));
    SetDlgItemText(hdlg, IDC_EDIT_YPOS, TEXT("30"));

    return TRUE;
}

BOOL TestProc_OnCommand(HWND hdlg, int id, HWND hwndCtl, UINT codeNotify)
{
    STARTUPINFO si;
    PROCESS_INFORMATION pi;
    ZeroMemory(&pi, sizeof(pi));
    ZeroMemory(&si, sizeof(si));
    DWORD dwExitCode = 0;
    DWORD wShowWind;
    TCHAR buffer1[100];

    switch (id)
    {
    case IDOK:
    {
        EndDialog(hdlg, IDOK);


        HWND hWidth = GetDlgItem(hdlg, IDC_EDIT_WIDTH);
        HWND hHeight = GetDlgItem(hdlg, IDC_EDIT_HEIGHT);
        HWND hXpos = GetDlgItem(hdlg, IDC_EDIT_XPOS);
        HWND hYpos = GetDlgItem(hdlg, IDC_EDIT_YPOS);

        GetWindowText(hWidth, (LPWSTR)buffer1, sizeof(buffer1));
        si.dwXSize = _ttoi(buffer1);
        GetWindowText(hHeight, (LPWSTR)buffer1, sizeof(buffer1));
        si.dwYSize = _ttoi(buffer1);
        GetWindowText(hXpos, (LPWSTR)buffer1, sizeof(buffer1));
        si.dwX = _ttoi(buffer1);
        GetWindowText(hYpos, (LPWSTR)buffer1, sizeof(buffer1));
        si.dwY = _ttoi(buffer1);

        GetExitCodeProcess(ProcHandleSam, &dwExitCode);

        if (dwExitCode == STILL_ACTIVE)
        {
            EnumWindows((WNDENUMPROC)EnumWindowsProc, (LPARAM)ProcIdSam);

            SetWindowPos(g_MyhWnd, 0, si.dwX, si.dwY, si.dwXSize, si.dwYSize, NULL);

            if (IsDlgButtonChecked(hdlg, IDC_RADIO1))
                SendMessage(g_MyhWnd, WM_SYSCOMMAND, SC_RESTORE, 0);
            if (IsDlgButtonChecked(hdlg, IDC_RADIO2))
                SendMessage(g_MyhWnd, WM_SYSCOMMAND, SC_MINIMIZE, 0);
            if (IsDlgButtonChecked(hdlg, IDC_RADIO3))
                SendMessage(g_MyhWnd, WM_SYSCOMMAND, SC_MAXIMIZE, 0);
        }
        else
        {
            TCHAR CmdTest[] = TEXT("C:\\Users\\Fuzzy\\Source\\Repos\\Dmitry-Kitsune\\SystemProg\\SP_2-1_Sol\\Debug\\SP_2-1.exe");

            si.cb = sizeof(STARTUPINFO);

            //si.lpTitle = TEXT("TestProc");

            if (IsDlgButtonChecked(hdlg, IDC_RADIO1))
                si.wShowWindow = SW_NORMAL;
            if (IsDlgButtonChecked(hdlg, IDC_RADIO2))
                si.wShowWindow = SW_MINIMIZE;
            if (IsDlgButtonChecked(hdlg, IDC_RADIO3))
                si.wShowWindow = SW_MAXIMIZE;

            si.dwFlags = STARTF_USESIZE | STARTF_USEPOSITION | STARTF_USESHOWWINDOW;

            if (!CreateProcess(NULL, CmdTest, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi))
                MessageBox(NULL, TEXT("Процесс не создан"), TEXT(""), MB_OK);
            ProcHandleSam = pi.hProcess;
            ProcIdSam = pi.dwProcessId;
        }

    }
    return TRUE;
    case IDCANCEL:
        EndDialog(hdlg, IDCANCEL);
        return TRUE;
    }
}

BOOL CALLBACK EnumWindowsProc(HWND hwnd, LPARAM lParam)
{
    DWORD dwPID;
    GetWindowThreadProcessId(hwnd, &dwPID);

    if (dwPID == (DWORD)lParam)
    {
        g_MyhWnd = hwnd;

        return FALSE;
    }
    return TRUE;
}
