#define _WIN32_WINDOWS 0x0410 
#define WINVER 0x0400

#include <windows.h>
#include <stdio.h>
#include <ctime>
#include <locale.h>
#include <iostream>
#include <iomanip>

// Создать консольное приложение,
//которое через N = 7секунд после запуска и затем через каждые k = 3 секунд
//будет выводить на консоль фразу «С момента запуска прошло <X> секунд»,
//где Х = n + i * k(i = 0, 1, 2, …, 20), где i – номер срабатывания таймера.

void main(void)
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_CTYPE, "Russian");

	const int nTimerUnitsPerSecond = 10000000; // множитель
	int cAbrasionCount = 0;
	SYSTEMTIME st;
	LARGE_INTEGER li;

	HANDLE hTimer = CreateWaitableTimer(NULL, FALSE, NULL);

	printf("\nПриложение Ждущий таймер. Программист Бурляев Д. А.");
	printf("\nПервое срабатывание через 7 секунд, последующие каждые 3 секунд.\n\n");
	GetLocalTime(&st);
	printf("Текущее время: \t\t%.2d:%.2d:%.2d\n\n", st.wHour, st.wMinute, st.wSecond);
	li.QuadPart = -(7 * nTimerUnitsPerSecond);//кол-во секунд - 7 sec
	if (SetWaitableTimer(hTimer, &li, 3 * 1000, NULL, NULL, FALSE))  //срабатывание таймера
	{
		unsigned int start_time = clock(); // начальное время
		while (TRUE) {
			WaitForSingleObject(hTimer, INFINITE);
			GetLocalTime(&st);
			/*int localTime = li.QuadPart;*/
			cAbrasionCount++;
			printf("Срабатывание таймера №%d. Текущее время: \t%.2d:%.2d:%.2d\n", cAbrasionCount, st.wHour, st.wMinute, st.wSecond);
			unsigned int end_time = clock(); // конечное время
			unsigned int search_time = ((end_time - start_time)/1000); // искомое время
			printf("С момета запуска прошло\t%3d.секунд\n", search_time);
		}
	}return;
}