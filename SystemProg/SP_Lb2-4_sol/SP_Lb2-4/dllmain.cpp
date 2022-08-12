// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"

BOOL APIENTRY DllMain(HMODULE hModule,
    DWORD  ul_reason_for_call,
    LPVOID lpReserved
)
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    {MessageBox(nullptr, TEXT("Загружается библтотека SPLB2-4"),
        TEXT("Из DllMain библиотеки SpLb24"), MB_OK);

    }return TRUE;
    case DLL_THREAD_ATTACH:
        break;
    case DLL_THREAD_DETACH:
        break;
    case DLL_PROCESS_DETACH:
    {
        {MessageBox(nullptr, TEXT("Выгружается библтотека SPLB2-4"),
            TEXT("Из DllMain библиотеки SpLb24"), MB_OK);
        }
        break;
    }
    return TRUE;
    }
}
