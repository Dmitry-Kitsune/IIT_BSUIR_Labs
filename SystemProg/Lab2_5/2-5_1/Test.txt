#include <windows.h> 
#include <windowsx.h>
//#include <tchar.h> 
#include <string.h>
//#include "resource.h"

#define FILENAME "FILEREV.DAT"


int WINAPI WinMain (HINSTANCE hinstExe,	HINSTANCE hinstPrev, 
					          LPSTR lpszCmdLine, 	int nCmdShow) 
{
	// Объявление локальных переменных:

	HANDLE hFile;        // Для дескриптора объекта "файл"
  HANDLE hFileMap;     // Для дескриптора объекта 'проецируемый файл'
	LPVOID lpvFile;      // Для адреса региона в адресном пространстве
                       // куда будет отображаться файл

	LPSTR  lpchANSI;     // Указатель на ANSI строку
 
	DWORD  dwFileSize;   // Для значения размера файла 
	LPTSTR lpszCmdLineT; // Указатель на командную строку 
                       // в ANSI или UNICODE
 	
	STARTUPINFO si={0};    // Структуры для функции
	PROCESS_INFORMATION pi;// CreateProcess 

	
	// Получаем из командной строки имя преобразуемого файла.
  
  lpszCmdLineT =lpszCmdLine; // Только для Windows 95/98


  if((lpszCmdLineT == NULL) || (*lpszCmdLineT ==0))
		{
    // Указатель равен нулю или указывает на 
    // конец строки (нулевой байт в конце). Значит аргументов после
    // имени исполняемого файла не указано. Сообщаем об ошибке.
		MessageBox( NULL, 
               "You must enter a filename on "
					     "the command line.", // Строка сообщения
					      "FileRev", // Строка заголовка окна
                MB_OK );
		return(0);
		}

  // Чтобы не испортить входной файл, копируем его в новый файл,
  // имя которого указываем через определенную выше константу FILENAME.
	
  if (!CopyFile(lpszCmdLineT, FILENAME, FALSE)) 
		{
		// Копирование не удалось
		MessageBox( NULL, "New file could not be created.",
					      "FileRev", MB_OK);
		return (0);
		}

	// Открываем файл для чтения и записи. Для этого создаем объект
  // ядра "Файл". В зависимости от указанных параметров функция 
  // CreateFile либо открывает существующий файл, либо создает новый.
  // Только эта функция может использоваться для открытия файла,
  // проецируемого в память. Функция возвращает дескриптор открытого
  // объекта ядра, или код ошибки INVALID_HANDLE_VALUE.

	hFile = CreateFile(	
          FILENAME,  // Указатель на строку с имененм файла
          GENERIC_WRITE | GENERIC_READ, // Требуемый режим доступа
					0,   //  Режим разделения,0 - безраздельный доступ к файлу.       
          NULL,// LPSECURITY_ATTRIBUTES=0 - объект не наследуемый.
          OPEN_EXISTING,//Если файл не существует, то возвратить ошибку.
          FILE_ATTRIBUTE_NORMAL,//Оставить атрибуты как есть 
          NULL //Не давать имя объекту ядра "Файл"
          );

	if (hFile == INVALID_HANDLE_VALUE) 
		{  // Открыть файл не удалось
		MessageBox(	NULL, "File could not be opened.",
					      "FileRev", MB_OK);
		return(0);
		}

	// Узнаем размер файла. Второй параметр NULL, так как предполагается,
  // что файл меньше 4 Гб.
	dwFileSize = GetFileSize(hFile, NULL);

	// Создаем объект "проецируемый файл". Он - на 1 байт больше, чем
	// размер файла, чтобы можно было записать в конец файла нулевой 
  // символ  и работать с файлом как с нуль-терминированной строкой.
  // Поскольку пока еще неизвестно содержит файл ANSI - или Unicode
  // - символы, увеличиваем файл на величину размера символа WCHAR
	
	hFileMap = CreateFileMapping(	
                    hFile,  // Дескриптор проецирумого объекта "Файл" 
                    NULL,   // 
                    PAGE_READWRITE, // Атрибуты защиты страниц 
									  0,  // LPSECURITY_ATTRIBUTES
                    dwFileSize+sizeof(WCHAR),   //Младшие 32 разряда
                    NULL  // и старшие 32 разряда размера файла.
                    );
	if (hFileMap == NULL) 
		{	// Открыть объект "проецируемый файл" не удалось
		MessageBox(	NULL,"File map could not be opened.",
					      "FileRev",    MB_OK);
	  CloseHandle(hFile);// Перед выходом закрываем открытые объекты
		return (0);
		}

	// Открываем отображение файла на виртуальное адресное пространство и
  // получаем адрес, начиная с которого располагается образ файла в памяти.
  
  lpvFile = MapViewOfFile(
                hFileMap, // Дескриптор объекта "Проецируемый файл" 
                FILE_MAP_WRITE, // Режим доступа
                0, // Старшие 32 разряда смещения от начала файла, 
                0, // младшие 32 разряда смещения от начала файла
                0  // и количество отображаемых байт. 0 - весь файл.
                );

	if (lpvFile == NULL)
		{// Спроецировать оконное представление файла не удалось
		MessageBox(	NULL, "Could   not map view of tile.",
					      "FileRev", MB_OK);
		CloseHandle (hFileMap);// Перед выходом закрываем открытые объекты
		CloseHandle(hFile);
		return(0);
		}

 
 		// Записываем в конец файла нулевой символ
		lpchANSI = (LPSTR) lpvFile;
		lpchANSI[dwFileSize] = 0;

		// "Переворачиваем" содержимое файла наоборот
		_strrev(lpchANSI);

		// Преобразуем все комбинации управляющих символов "\n\r" обратно в "\r\n",
		// чтобы сохранить нормальную последовательность кодов "возврат каретки"
    // "перевод строки", завершающих строки в текстовом файле
		
    lpchANSI = strchr(lpchANSI,(int)'\n');   // Находим адрес первого '\n'
		while (lpchANSI != NULL) //Пока не найдены все символы '\n'
			{
			  *lpchANSI  =(int) '\r'; // Заменяем '\n' на '\r'
         lpchANSI++;           // Увеличиваем указатель
			  *lpchANSI =(int)'\n';// Заменяем '\r' на '\n' и увеличиваем указатель
         lpchANSI++; 
			   lpchANSI  = strchr(lpchANSI,(int)'\n');  // Ищем дальше
			}
    

	// Очищаем все перед завершением
  // Закрываем представление файла в окне адресного пространства
	UnmapViewOfFile(lpvFile);
  
  // Уменьшаем счетчик ссылок на объект ядра "Проецируемый файл"
	CloseHandle(hFileMap);
	
	// Удаляем добавленный ранее концевой нулевой байт.Для этого
	// перемещаем указатель файла в конец на нулевой байт,
	// а затем даем команду установить в этом месте конец файла
	
  SetFilePointer(hFile, dwFileSize, NULL, FILE_BEGIN);
  SetEndOfFile(hFile);
	// SetEndOfFlle нужно вызывать после закрытия дескриптора объекта
  // ядра "Проецируемый файл"
	
	CloseHandle(hFile);// Уменьшаем счетчик ссылок на объект ядра "Файл"

	// Запускаем NOTEPAD и загружаем в него созданный файл,
  // чтобы увидеть плоды своих трудов
	si.cb = sizeof (si);// Заполняем поле размера структуры si
	si.wShowWindow = SW_SHOW;// Задаем режим показа окна NOTEPAD
	si.dwFlags = STARTF_USESHOWWINDOW;// Устанавливаем флаг - учитывать
                                    // значение поля wShowWindow
	if( CreateProcess(	NULL, "NOTEPAD.EXE " FILENAME,
						          NULL, NULL, FALSE, 0, 
						          NULL, NULL, &si, &pi) )
    {
    // Если процесс создан, освобождаем 
    // дескрипторы потока и процесса	
    CloseHandle(pi.hThread);
		CloseHandle(pi.hProcess);
		}
	return( 0 );
}


