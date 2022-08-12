#define _WIN32_WINDOWS 0x0410 
#define WINVER 0x0400

#include <windows.h>
#include <stdio.h>
#include <ctime>
#include <locale.h>
#include <iostream>
#include <iomanip>

// ������� ���������� ����������,
//������� ����� N = 7������ ����� ������� � ����� ����� ������ k = 3 ������
//����� �������� �� ������� ����� �� ������� ������� ������ <X> ������,
//��� � = n + i * k(i = 0, 1, 2, �, 20), ��� i � ����� ������������ �������.

void main(void)
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_CTYPE, "Russian");

	const int nTimerUnitsPerSecond = 10000000; // ���������
	int cAbrasionCount = 0;
	SYSTEMTIME st;
	LARGE_INTEGER li;

	HANDLE hTimer = CreateWaitableTimer(NULL, FALSE, NULL);

	printf("\n���������� ������ ������. ����������� ������� �. �.");
	printf("\n������ ������������ ����� 7 ������, ����������� ������ 3 ������.\n\n");
	GetLocalTime(&st);
	printf("������� �����: \t\t%.2d:%.2d:%.2d\n\n", st.wHour, st.wMinute, st.wSecond);
	li.QuadPart = -(7 * nTimerUnitsPerSecond);//���-�� ������ - 7 sec
	if (SetWaitableTimer(hTimer, &li, 3 * 1000, NULL, NULL, FALSE))  //������������ �������
	{
		unsigned int start_time = clock(); // ��������� �����
		while (TRUE) {
			WaitForSingleObject(hTimer, INFINITE);
			GetLocalTime(&st);
			/*int localTime = li.QuadPart;*/
			cAbrasionCount++;
			printf("������������ ������� �%d. ������� �����: \t%.2d:%.2d:%.2d\n", cAbrasionCount, st.wHour, st.wMinute, st.wSecond);
			unsigned int end_time = clock(); // �������� �����
			unsigned int search_time = ((end_time - start_time)/1000); // ������� �����
			printf("� ������ ������� ������\t%3d.������\n", search_time);
		}
	}return;
}