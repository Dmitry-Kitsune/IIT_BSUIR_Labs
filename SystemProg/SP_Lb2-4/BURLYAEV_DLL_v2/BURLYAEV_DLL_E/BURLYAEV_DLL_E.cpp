// BURLYAEV_DLL_I.cpp : Defines the entry point for the application.
//

//#include "stdafx.h"
//#include "Windows.h"
//#include "Windowsx.h"
//#include <tchar.h>
#include "stdafx.h"
//#include "..\BURLYAEV_DLL\BURLYAEV_DLL.h"
#include "..\BURLYAEV_DLL\BURLYAEV_DLL.h"
#include "targetver.h"
#include <Windows.h>
#include <locale.h>
#include <WinBase.h>
//#include <Windows.h>
//#include <locale.h>
//#include <WinBase.h>
//#include <iostream>

int _tmain(int argc, _TCHAR* argv[])
{

	setlocale(LC_CTYPE, "Russian");
	int a = 3;
	int b = 4;
	int c = 7;
	int(*res)(int, int);
	float(*res1)(int, int, int);
	void (*res2) (double, double*);
	int* n;
	int* m;
	double d = 2.5;
	double e = 0;
	bool t = true;
	HINSTANCE hDll;
	LPCWSTR Address = L"BURLYAEV.dll";
	hDll = LoadLibrary(Address);
	if (hDll == NULL)
	{
		puts("Error load dll library. Press any key to continue.");
		getchar();
		return 1;
	}
	//res = (int(*)(int, int))GetProcAddress(hDll, (LPCSTR)MAKEINTRESOURCE(3));
	res = (int(*)(int, int))GetProcAddress(hDll, "Fun11");
	//FARPROC rez = GetProcAddress(hDll, "Fun11");
	if (res == NULL)
	{
		puts("Error load function Fun11. Press any key to continue.");
		getchar();
		return 1;
	}
	//res1 = (float(*)(int, int, int))GetProcAddress(hDll, (LPCSTR)MAKEINTRESOURCE(4));
	res1 = (float(*)(int, int, int))GetProcAddress(hDll, "Fun12");
	//FARPROC rez1 = GetProcAddress(hDll, "Fun12");
	if (res1 == NULL)
	{
		puts("Error load function Fun12. Press any key to continue.");
		getchar();
		return 1;
	}
	//res2 = (void(*)(double, double*))GetProcAddress(hDll, (LPCSTR)MAKEINTRESOURCE(5));
	res2 = (void(*)(double, double*))GetProcAddress(hDll, "Fun13");
	//FARPROC rez2 = GetProcAddress(hDll, "Fun11");
	if (res2 == NULL)
	{
		puts("Error load function Fun13. Press any key to continue.");
		getchar();
		return 1;
	}
	//n =(int *) GetProcAddress(hDll, (LPCSTR)MAKEINTRESOURCE(8));
	n = (int*)GetProcAddress(hDll, "g_nFnCallsCount");
	if (n == NULL)
	{
		puts("Error load item g_nFnCallsCount. Press any key to continue.");
		getchar();
		return 1;
	}
	//m = (int *)GetProcAddress(hDll, (LPCSTR)MAKEINTRESOURCE(7));
	m = (int*)GetProcAddress(hDll, "g_nDllCallsCount");
	if (m == NULL)
	{
		puts("Error load item g_nDllCallsCount. Press any key to continue.");
		getchar();
		return 1;
	}
	/*n = 0;
	m = 0;*/

	*m = *m + 1;

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
			int r = res(a, b);
			*n = *n + 1;
			printf("Result Fun11=%d, Number of calls to the library functions=%d,  Number of calls to the library=%d\n",
				r, *n, *m);
			break;
		}
		case 2:
		{
			float r = res1(a, b, c);
			*n = *n + 1;
			printf("Result Fun12=%f, Number of calls to the library functions=%d, Number of calls to the library=%d\n",
				r, *n, *m);
			break;
		}
		case 3:
		{
			res2(d, &e);
			*n = *n + 1;
			printf("Result Fun12=%lf, Number of calls to the library functions=%d, Number of calls to the library=%d\n",
				e, *n, *m);
			break;
		}
		case 4:
		{
			return 0;
		}
		}
	}

}