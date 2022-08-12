#define _WIN32_WINDOWS 0x0410 
#define WINVER 0x0400

#include <windows.h>
#include <stdio.h>

#include <locale.h>

void main(void)
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_CTYPE, "Russian");

	const int nTimerUnitsPerSecond = 10000000;
	int cAbrasionCount = 0;
	SYSTEMTIME st;
	LARGE_INTEGER li;

	HANDLE hTimer = CreateWaitableTimer(NULL, FALSE, NULL);

	printf("\n���������� ������ ������. ����������� ����������� �.�.");
	printf("\n������ ������������ ����� 2 ������, ����������� ������ 11 ������.\n\n");
	GetLocalTime(&st);
	printf("������� �����: \t\t%.2d:%.2d:%.2d\n\n", st.wHour, st.wMinute, st.wSecond);
	li.QuadPart = -(120 * nTimerUnitsPerSecond);
	if (SetWaitableTimer(hTimer, &li, 11 * 1000, NULL, NULL, FALSE)) {
		while (TRUE) {
			WaitForSingleObject(hTimer, INFINITE);
			GetLocalTime(&st);
			cAbrasionCount++;
			printf("������ �%d. ������� �����: \t%.2d:%.2d:%.2d\n", cAbrasionCount, st.wHour, st.wMinute, st.wSecond);
		}
	}
}