// 00332_SP_Burlyaev_LB_2-4_SoL.cpp : Defines the entry point for the application.
//

#include "framework.h"
#include "..\00332_SP_Burlyaev_LB_2-4\00332_SP_Burlyaev_LB_2-4.h"
#include "CLient_LB_2-4.h"
#pragma comment(lib,...)

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name
//========================================================================
//Пример разделяемой (между процессами) переменной
#pragma data_seg(AShare)
SPLB24_API int g_nFnaCallCount=0;
#pragma data_seg()
#pragma comment(linker, "/Section:Ashare,RWS")

//===========================================================================
SPLB24_API int = nSplb24 = 0;

SPLB24_API int g_nFnaCallCount = 0;

SOLB24_API int fnSpLb24(void)
{
    return 300;
}

int Var1 = nSpLb24;

// =======================================================================
// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Place code here.

    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_MY00332SPBURLYAEVLB24SOL, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MY00332SPBURLYAEVLB24SOL));

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
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_MY00332SPBURLYAEVLB24SOL));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_MY00332SPBURLYAEVLB24SOL);
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
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

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
                //================================================= Замена
            case IDM_DLL_CALL:
            {
           /* int fromDLL = fnSpLb24(); //Вызов фнк-ции
            int Var = nSpLb24 :
                nSpLb24 = 25;
            int Var1 = nSpLb24;
            TCHAR message[200];
            wsprintf(message, TEXT("Результат ф-ии %d, \n Значение переменной %d, \n ""))
                "Значение измененное в Dll %d,"
                MessageBoX(hWnd, message, TEXT(" "), MB_OK);
            }break;
            */

              //  Клиент с явной компоновкой(3)

               // Клиент с явной компоновкой(2)
                /*//////////////////////////////////////////////
                // Явная загрузка библиотеки
                typedef INT(*LPFN_1_TYPE)(VOID);
                HINSTANCE hDll; // Handle to DLL
                LPFN_1_TYPE lpfnDllFunc1; // Function pointer
                hDll = LoadLibrary(TEXT("SpLb24.dll"));
                if (hDll == NULL)
                {
                    MessageBox(hWnd, TEXT("Библиотека SpLb24.dll  не найдена"), TEXT(""), MB_OK);
                    break;
                }
                else
                {
                    lpfnDllFunc1 = (LPFN_1_TYPE) GetProcAddress(hDll, "fnSpLb24");
                    if (!lpfnDllFunc1)
                    { // handle the error
                        FreeLibrary(hDll);
                        MessageBox(hWnd, TEXT("Функция fnSpLb24 не найдена"), TEXT(""), MB_OK);
                        break;
                    }
                    else
                    {// call the function
                        int nFromLib = lpfnDllFunc1();

                        TCHAR message[200];
                        wsprintf(message, TEXT("Результат ф-ии %d, \n "),
                            nFromLib);
                        MessageBox(hWnd, message, TEXT("Явная загрузка"), MB_OK);

                        FreeLibrary(hDll);
                    }
                }
            
            }break;

            */
//===============================================
           
                    typedef UINT(*LPFN_1_TYPE)(VOID);
                    HINSTANCE hDll; // Handle to DLL
                    LPFN_1_TYPE lpfnDllFunc1; // Function pointer
                    hDll = LoadLibrary("MYDLL");




                    if (hDll != NULL)
                    {
                        lpfnDllFunc1 = (LPFN_1_TYPE)GetProcAddress(hDll, "fnMYDLL");
                        if (!lpfnDllFunc1)
                        {// handle the error
                            FreeLibrary(hDll);
                            returnERROR_FUNCTION_NOT_FOUND;
                        }break;
                        else
                        {//call the function
                            nFromLib = lpfnDllFunc1();
                            FreeLibrary(hDll);
                        }
                    }

                    /* int fromDLL = fnSpLb24(); //Вызов фнк-ции
            int Var = nSpLb24 :
                nSpLb24 = 25;
            int Var1 = nSpLb24;
            TCHAR message[200];
            wsprintf(message, TEXT("Результат ф-ии %d, \n Значение переменной %d, \n ""))
                "Значение измененное в Dll %d,"
                MessageBoX(hWnd, message, TEXT(" "), MB_OK);*/


//=========================================================================

            case IDM_ABOUT:
                DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
                break;
            case IDM_EXIT:
                DestroyWindow(hWnd);
                break;
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
