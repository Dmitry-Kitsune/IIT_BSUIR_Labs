// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"
#include "BURLYAEV_DLL.h"

BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved
)
{
	int g_nDllCallsCount = 0;
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	{
		MessageBox(NULL, L"Loading library BURLYAEV_DLL. Project BURLYAEV D.A.",
			L"MESSAGE", MB_OK);
		g_nDllCallsCount++;
		return true;
	}
	case DLL_THREAD_ATTACH:
	{
		MessageBox(NULL, L"THREAD START", L"MESSAGE", MB_OK);
		break;
	}
	case DLL_THREAD_DETACH:
	{
		MessageBox(NULL, L"THREAD WAS DESTROY", L"MESSAGE", MB_OK);
		break;
	}
	case DLL_PROCESS_DETACH:
	{
		MessageBox(NULL, L"Unloading library BURLYAEV_DLL. BURLYAEV D.A.",
			L"MESSAGE", MB_OK);
		g_nDllCallsCount--;
		return true;
	}
	break;
	}
	return TRUE;
}

