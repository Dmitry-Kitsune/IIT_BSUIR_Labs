#include <Windows.h>
#include "sp_pr1.h"

int APIENTRY WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpszCmdLine, int nCmdShow) {


	/*LPCTSTR lpszHelloText = TEXT("Hello World Win32 GUI Application");
	LPCTSTR lpszHelloWndTitle = TEXT("���� ���������");

	LPCTSTR lpszHelloText = MESSAGE_TEXT;
	LPCTSTR lpszHelloWndTitle = MESSAGE_TITLE;

	MessageBox(NULL, lpszHelloText, lpszHelloWndTitle, MB_OK);*/

	////////////////////////////////////////////////////////////////////////////////
		//
		//TCHAR buf1[200], buf2[200];
		////lstrcpy(buf1, TEXT("Hello World Win32 GUI Application"));

		//lstrcpy(buf1, TEXT("������ �� Win32 ���������� � ����������� ����������.\n"
		//	"�����: ������� �.�., ��.00332,"));
		//SYSTEMTIME st;
		//GetLocalTime(&st);

		//wsprintf(buf2, TEXT("\nDesign time: 09.06.2022 18�.00���."
		//	"\nRun time: %d.%d.%d %d�.%d���."), st.wDay, st.wMonth, st.wYear, st.wHour, st.wMinute);
		//lstrcat(buf1, buf2);

		//LPCTSTR lpszHelloWndTitle = MESSAGE_TITLE;
		//MessageBox(NULL, buf1, lpszHelloWndTitle, MB_OK | MB_ICONINFORMATION);
	//////////////////////////////////////////////////////////////////////////////////
	int iRetValue1, iRetValue2;
    LPCTSTR lpszMesBoxTitle = TEXT("������� 2");
	LPTSTR lpszResponce;

	do {
		iRetValue1 = MessageBox(NULL, TEXT("������� ���� �� ������."), lpszMesBoxTitle,
			MB_ABORTRETRYIGNORE | MB_ICONEXCLAMATION | MB_SETFOREGROUND);

		switch (iRetValue1) {
		case IDABORT:
			lpszResponce = TEXT("������ ������ �������� (ABORT)");
			break;

		case IDRETRY:
			lpszResponce = TEXT("������ ������ ��������� (RETRY)");
			break;

		case IDIGNORE:
			lpszResponce = TEXT("������ ������ ���������� (IGNORE)");
			break;

		default: lpszResponce = TEXT("����� ��� �� �������.");
		}

		TCHAR buf[200] = TEXT("");
		lstrcat(buf, lpszResponce);
		lstrcat(buf, TEXT(" ���������� �������� ������������ ��������?"));

		iRetValue2 = MessageBox(NULL, buf, lpszMesBoxTitle, MB_YESNO | MB_ICONQUESTION | MB_SETFOREGROUND);
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	//int iRetValue1, iRetValue2;

	//LPTSTR lpszResponce;
	//while (iRetValue2 != IDNO);

	TCHAR buf3[200];
	lstrcpy(buf3, TEXT("The message box contain three push buttons: Ok, Cancel"));
	LPCTSTR lpszHelloWndTitle = TEXT("������� 2");

	MessageBox(NULL, buf3, lpszHelloWndTitle, MB_OKCANCEL | MB_ICONINFORMATION);

	do {
		iRetValue2 = MessageBox(NULL, TEXT("������� ���� �� ������."), lpszMesBoxTitle,
			MB_OKCANCEL | MB_ICONINFORMATION);

		switch (iRetValue2) {
		case IDOK:
			lpszResponce = TEXT("������ ������ �� (OK)");
			break;

		case IDCANCEL:
			lpszResponce = TEXT("������ ������ ��������� (CANCEL)");
			break;

		default: lpszResponce = TEXT("����� ��� �� �������.");
		}

		TCHAR buf[200] = TEXT("");
		lstrcat(buf, lpszResponce);
		lstrcat(buf, TEXT(" ���������� �������� ������������ ��������?"));

		iRetValue2 = MessageBox(NULL, buf, lpszMesBoxTitle, MB_YESNO | MB_ICONQUESTION | MB_SETFOREGROUND);


	}
	while (iRetValue2 != IDNO);
	return 0;
}