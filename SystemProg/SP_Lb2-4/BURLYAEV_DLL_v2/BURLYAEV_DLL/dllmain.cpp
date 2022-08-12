// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"

//#include "BURLYAEV_DLL.h"
//#include "..\BURLYAEV_DLL\BURLYAEV_DLL.h"

TCHAR filename[260];
TCHAR buffer[200];


BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved
)
{

	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	{
		DWORD	mod;
		mod = GetModuleFileName(hModule, filename, 260);
		wsprintf(buffer, L"����������� ���������� %s. ������ ������� �.�.", filename);
		MessageBox(NULL, buffer, L"DllMain", MB_OK);
		return TRUE;
	}
	case DLL_THREAD_ATTACH:
	{
		MessageBox(NULL, L"������ ����� �����", L"DllMain", MB_OK);

		break;
	}
	case DLL_THREAD_DETACH:
	{
		MessageBox(NULL, L"���������� ����� ����������", L"DllMain", MB_OK);
		break;
	}
	case DLL_PROCESS_DETACH:
	{
		DWORD	mod;
		mod = GetModuleFileName(hModule, filename, 260);
		wsprintf(buffer, L"����������� ���������� %s. ������ ������� �.�.", filename);
		MessageBox(NULL, buffer, L"DllMain", MB_OK);
		return TRUE;
		break;
	}
	}
	return TRUE;
}

