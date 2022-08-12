// BURLYAEV_DLL.cpp : Defines the exported functions for the DLL application.
//
//#include "framework.h"
#include "stdafx.h"
#include "BURLYAEV_DLL.h"

//#pragma data_seg(".ASHARE")
//int g_nDllCallsCount = 0;
//#pragma data_seg()
//#pragma comment(linker, "/SECTION:.ASHARE,RWS")
//

BURLYAEV_DLL_API int fnBURLYAEV_DLL(void)
{
	return 42;
}

int Fun11(int a, int b)
{
	return a * a - b;
}

BURLYAEV_DLL_API float Fun12(int c, int d, int e)
{
	if (e != 0) return (float)(c * d) / e;
	else return (float)0;
}

BURLYAEV_DLL_API void Fun13(double in, double* out)
{
	*out = in / 3;
}


DBURLYAEV_DLL::DBURLYAEV_DLL()
{
	return;
}
