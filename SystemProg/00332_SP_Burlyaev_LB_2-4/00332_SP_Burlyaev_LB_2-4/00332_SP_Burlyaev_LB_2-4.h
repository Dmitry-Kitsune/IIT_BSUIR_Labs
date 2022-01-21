// The following ifdef block is the standard way of creating macros which make exporting
// from a DLL simpler. All files within this DLL are compiled with the MY00332SPBURLYAEVLB24_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see
// MY00332SPBURLYAEVLB24_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef MY00332SPBURLYAEVLB24_EXPORTS
#define MY00332SPBURLYAEVLB24_API __declspec(dllexport)
#else
#define MY00332SPBURLYAEVLB24_API __declspec(dllimport)
#endif

// This class is exported from the dll
class MY00332SPBURLYAEVLB24_API CMy00332SPBurlyaevLB24 {
public:
	CMy00332SPBurlyaevLB24(void);
	// TODO: add your methods here.
};

extern MY00332SPBURLYAEVLB24_API int nMy00332SPBurlyaevLB24;

MY00332SPBURLYAEVLB24_API int fnMy00332SPBurlyaevLB24(void);
