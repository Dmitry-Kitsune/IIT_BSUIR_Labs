// dllmain.cpp : Defines the entry point for the DLL application.
#include "framework.h"
#include "..\00332_SP_Burlyaev_LB_2-4\00332_SP_Burlyaev_LB_2-4.h"
#include "00332_SP_Burlyaev_LB_2-4_SoL.h"


BOOL APIENTRY DllMain(HMODULE hModule,
    DWORD  ul_reason_for_call,
    LPVOID lpReserved
)
{
    switch (ul_reason_for_call)
    {
        g_nDllCallCount = g_nDLLCallCOunt = +1;
    case DLL_PROCESS_ATTACH:
    {MessageBox(nullptr, TEXT("����������� ���������� SPLB2-4"),
        TEXT("�� DllMain ���������� SpLb24"), MB_OK);

    }return TRUE;
    case DLL_THREAD_ATTACH:
        break;
    case DLL_THREAD_DETACH:
        break;
    case DLL_PROCESS_DETACH:
    {
        {MessageBox(nullptr, TEXT("����������� ���������� SPLB2-4"),
            TEXT("�� DllMain ���������� SpLb24"), MB_OK);
        }
        break;
    }
    return TRUE;
    }

