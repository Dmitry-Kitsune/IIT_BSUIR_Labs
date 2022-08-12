
#ifdef BURLYAEV_DLL_EXPORTS

#define BURLYAEV_DLL_API  __declspec(dllexport)
#else

#define BURLYAEV_DLL_API   __declspec(dllimport)
#endif




// Этот класс экспортирован из библиотеки DLL
class BURLYAEV_DLL_API DBURLYAEV_DLL
{
public:
	 DBURLYAEV_DLL(void);

	// TODO: add your methods here.
};


BURLYAEV_DLL_API int g_nDllCallsCount;
BURLYAEV_DLL_API int g_nFnCallsCount;

BURLYAEV_DLL_API int fnBURLYAEV_DLL(void);
BURLYAEV_DLL_API int Fun11(int, int);
BURLYAEV_DLL_API float Fun12(int, int, int);
BURLYAEV_DLL_API void Fun13(double in, double* out);