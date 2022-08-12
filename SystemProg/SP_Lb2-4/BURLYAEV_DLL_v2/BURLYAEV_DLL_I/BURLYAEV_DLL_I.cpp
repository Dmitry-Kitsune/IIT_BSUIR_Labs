// BURLYAEV_DLL_I.cpp : Defines the entry point for the application.


#include "stdafx.h"
#include "..\BURLYAEV_DLL\BURLYAEV_DLL.h"
#include "targetver.h"

//#include "BURLYAEV_DLL_I.h"
#include <Windows.h>
#include <locale.h>
#include <WinBase.h>

int _tmain(int argc, _TCHAR* argv[])
{
	g_nDllCallsCount++;
	setlocale(LC_CTYPE, "Russian");
	int a = 3;
	int b = 4;
	int c = 7;
	double d = 2.5;
	double e = 0;
	bool t = true;
	while (t)
	{
		puts("Выберите пункт меню:");
		puts("1. Вычисление функции Fun11;");
		puts("2. Вычисление функции Fun12;");
		puts("3. Вычисление функции Fun13;");
		puts("4. Выход.");
		int i;
		scanf_s("%d", &i);
		switch (i)
		{
		case 1:
		{
			int res = Fun11(a, b);
			g_nFnCallsCount++;
			printf("Result Fun11=%d, Number of calls to the library functions=%d,  Number of calls to the library=%d\n",
				res, g_nFnCallsCount, g_nDllCallsCount);
			break;
		}
		case 2:
		{
			float res = Fun12(a, b, c);
			g_nFnCallsCount++;
			printf("Result Fun12=%f, Number of calls to the library functions=%d, Number of calls to the library=%d\n",
				res, g_nFnCallsCount, g_nDllCallsCount);
			break;
		}
		case 3:
		{
			Fun13(d, &e);
			g_nFnCallsCount++;
			printf("Result Fun12=%lf, Number of calls to the library functions=%d, Number of calls to the library=%d\n",
				e, g_nFnCallsCount, g_nDllCallsCount);
			break;
		}
		case 4:
		{
			return 0;
		}
		}
	}

}