//
// Client322_2.cpp
//
#include <windows.h>
#include <tchar.h>
#include <stdio.h>
#include <initguid.h>
#include "..\LB_1_Server332\IMath.h"

int main(int argc, char* argv[])
{
	printf("Initializing COM \n");
	if (FAILED(CoInitialize(NULL)))
		{
			printf("Unable to initialize COM \n"); return -1;
		} 

	HRESULT hr;
	IMath* pMath = NULL;
	hr = CoCreateInstance(CLSID_CMath, nullptr, CLSCTX_INPROC_SERVER,
		IID_IMath, (LPVOID*)&pMath);///////////////

	if (FAILED(hr))
		{
			printf("Failed to create server instance. HR =%X \n", hr); return -1;
		}
		printf("Instance created \n");


	long result;
	pMath->Multiply(20, 7, &result);
	printf("202 * 7 is %d \n", result);
	pMath->Subtract(200, 123, &result);
	printf("202 - 123 is %d \n", result);
	printf("Releasing instance \n");
	pMath->Release();
	printf("Shuting down COM\n");
	CoUninitialize();
	return 0;
}