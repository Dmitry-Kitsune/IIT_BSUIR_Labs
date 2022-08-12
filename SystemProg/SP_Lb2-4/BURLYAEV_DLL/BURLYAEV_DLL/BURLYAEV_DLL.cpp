// BURLYAEV_DLL.cpp : Defines the exported functions for the DLL application.
//
//#include "framework.h"
#include "stdafx.h"
#include "BURLYAEV_DLL.h"
//using namespace BURLYAEV_DLL_API;
//#include "dllmain.cpp"


#pragma data_seg(".ASHARE")
#pragma data_seg()
#pragma comment(linker, "/SECTION:.ASHARE,RWS")
BURLYAEV_DLL_API int g_nDllCallsCount = 0;
BURLYAEV_DLL_API int g_nFnCallsCount = 0;

BURLYAEV_DLL_API double Fun31(double x, double y)
{
	return (double)x / y;
}

BURLYAEV_DLL_API int WINAPI Fun32(int x, int y, int z)
{

	return (int)y + x + z;

}

BURLYAEV_DLL_API void Fun33(int in, int *out)
{
	double s = in + 5;
	*out = s;
}
BURLYAEV_DLL_API float Fun12(int c, int d, int e)
{
	if (e != 0) return (float)(c * d) / e;
	else return (float)0;
}

// This is the constructor of a class that has been exported.
// see BURLYAEV_DLL.h for the class definition
DBURLYAEV_DLL::DBURLYAEV_DLL()
{
	return;
}
