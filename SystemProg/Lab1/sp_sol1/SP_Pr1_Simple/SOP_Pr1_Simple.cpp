#include <windows.h>
#include <tchar.h>
#include <windowsx.h>

//-- Prototypes -------------------
LRESULT CALLBACK SimWndProc(HWND, UINT, WPARAM, LPARAM);

//  Стартовая функция 
int APIENTRY _tWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPTSTR lpszCmdLine, int nCmdShow) {
	WNDCLASSEX wc;
	MSG msg;
	HWND hWnd;

	memset(&wc, 0, sizeof(WNDCLASSEX));
	wc.cbSize = sizeof(WNDCLASSEX); //размер этой структуры, обязательно установить
	wc.lpszClassName = TEXT("SimpleClassName");
	wc.lpfnWndProc = SimWndProc;
	wc.style = CS_VREDRAW | CS_HREDRAW; //стиль класса окна; перерисовывает горизонталь | вертикаль
	wc.hInstance = hInstance; //дескриптор приложения
	//wc.hIcon = LoadIcon(NULL, MAKEINTRESOURCE(IDI_APPLICATION)); //конверитрует №значения в тип ресурса
	wc.hIcon = LoadIcon(NULL, MAKEINTRESOURCE(IDI_ERROR)); //конверитрует №значения в тип ресурса
	//wc.hCursor = LoadCursor(NULL, MAKEINTRESOURCE(IDC_ARROW));
	wc.hCursor = LoadCursor(NULL, MAKEINTRESOURCE(IDC_HAND));
	//wc.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	//wc.hbrBackground = CreateSolidBrush(RGB(0, 255, 255)); // Бирюзовый фон
	wc.hbrBackground = GetStockBrush(GRAY_BRUSH);//Серый фон окна 
	wc.lpszMenuName = NULL; //ссылка на имя ресурса меню
	wc.cbClsExtra = 0; //кол-во дополнительных байтов для каждого экз. класса
	wc.cbWndExtra = 0; //кол-во дополнительных байтов для каждого окна класса

	if (!RegisterClassEx(&wc)) {
		MessageBox(NULL, TEXT("Ошибка регистрации класса окна!"), TEXT("Ошибка"), MB_OK | MB_ICONERROR);
		return FALSE;
	}

	hWnd = CreateWindowEx(
		NULL, //расширенный стиль окна
		TEXT("SimpleClassName"), // адрес строки с именем класса
		TEXT("Simple Application with Message handling"), // адрес строки с загол.окна
		WS_OVERLAPPEDWINDOW, //перекрывающееся окна (стиль создаваемого окна)
		//0, 0, //позиция по х, у
		400, 400, //позиция по х, у
		//CW_USEDEFAULT, CW_USEDEFAULT, //размеры окна
		400, 100, //размеры окна
		NULL, //дескриптор род. окна
		NULL, //дескриптор меню
		hInstance, //дескриптор приложения
		NULL //адрес доп. данных, обычно не требуется (структура)
	);

	if (!hWnd) {
		MessageBox(NULL, TEXT("Окно не создано!"), TEXT("Ошибка"), MB_OK | MB_ICONERROR);
		return FALSE;
	}

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd); //обновляет клиентскую область окна посылая WM_PAINT
						//WM_PAINT закрывает область окна которая стала не действительной
	while (GetMessage(&msg, NULL, 0, 0))
		DispatchMessage(&msg);

	return msg.wParam;
}

// Оконная процедура
LRESULT CALLBACK SimWndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam) {
	HDC hDC;

	switch (msg) {

		case WM_PAINT:    // Вывод при обновлении окна
			PAINTSTRUCT ps; // Эту стуктуру заполняет BeginPaint
			hDC = BeginPaint(hWnd, &ps);  // Получение контекста для
										  // обновления окна   
			TextOut(hDC, 10, 10, TEXT("Hello, World!"), 13); // Настройка этого контекста
			EndPaint(hWnd, &ps); // Завершение обновления окна
			break;

		case WM_DESTROY:  // Завершение работы приложения (освобождает использ. ресурсы - шрифты, кисти)
			PostQuitMessage(0); // Посылка WM_QUIT в очередь
			break;

		default: // Вызов "Обработчика по умолчанию"
			return(DefWindowProc(hWnd, msg, wParam, lParam));
	}

	return FALSE;// Для ветвей с "break"
}