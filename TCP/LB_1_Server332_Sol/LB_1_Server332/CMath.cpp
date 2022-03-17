//
// СMath.cpp
//

#include <windows.h>
#include "CMath.h"
//
// Math class implementation
//
// Constructors
CMath::CMath()
	{

		m_lRef = 0;
		// Увеличить значение внешнего счетчика объектов
		InterlockedIncrement(&g_lObjs);
	}
// The destructor
CMath::~CMath()
	{

		// Уменьшить значение внешнего счетчика объектов
		InterlockedDecrement(&g_lObjs);
	}


STDMETHODIMP CMath::QueryInterface(REFIID riid, void** ppv)
{
	*ppv = 0;
	if (riid == IID_IUnknown || riid == IID_IMath)
		*ppv = this;
	if (*ppv)
		{
			AddRef();
			return(S_OK);
		}
	return (E_NOINTERFACE);
}
STDMETHODIMP_(ULONG) CMath::AddRef()
	{
		return InterlockedIncrement(&m_lRef);
	}
STDMETHODIMP_(ULONG) CMath::Release()
	{
		if (InterlockedDecrement(&m_lRef) == 0)
		{
			delete this;
			return 0;
		}
		return m_lRef;
	}
STDMETHODIMP CMath::Add(long lOp1, long lOp2, long* pResult)
	{
		*pResult = lOp1 + lOp2;
		return S_OK;
	}
STDMETHODIMP CMath::Subtract(long lOp1, long lOp2, long* pResult)
	{
		*pResult = lOp1 - lOp2;
		return S_OK;
	}
STDMETHODIMP CMath::Multiply(long lOp1, long lOp2, long* pResult)
	{
		*pResult = lOp1 * lOp2;
		return S_OK;
	}
STDMETHODIMP CMath::Divide(long lOp1, long lOp2, long* pResult)
	{
	if (lOp2 == 0)
	{// Ошибка - вывести сообщение и вернуть E_FAIL
		return E_FAIL;
	}

		*pResult = lOp1 / lOp2;
		return S_OK;
	}
MathClassFactory::MathClassFactory()
	{
		m_lRef = 0;
	}
MathClassFactory::~MathClassFactory()
	{
	}
STDMETHODIMP  MathClassFactory::QueryInterface(REFIID  riid, void** ppv)
	{
		*ppv = 0;

		if (riid == IID_IUnknown || riid == IID_IClassFactory)
			*ppv = this;
		if (*ppv)
		{

			AddRef();
			return S_OK;
		}
		return(E_NOINTERFACE);
	}
STDMETHODIMP_(ULONG) MathClassFactory::AddRef()
	{


		return InterlockedIncrement(&m_lRef);
	}

STDMETHODIMP_(ULONG) MathClassFactory::Release()
	{
		if (InterlockedDecrement(&m_lRef) == 0)
		{
			delete this;
			return 0;
		}
		return m_lRef;
	}
STDMETHODIMP MathClassFactory::CreateInstance
(LPUNKNOWN pUnkOuter, REFIID riid, void** ppvObj)
	{
		CMath* pMath; HRESULT    hr;

		*ppvObj = 0;

		pMath = new CMath;

		if (pMath == 0)
			return(E_OUTOFMEMORY);

		hr = pMath->QueryInterface(riid, ppvObj);

		if (FAILED(hr))
			delete pMath;
		return hr;
	}
STDMETHODIMP MathClassFactory::LockServer(BOOL fLock)
	{


		if (fLock)
			InterlockedIncrement(&g_lLocks);
		else
			InterlockedDecrement(&g_lLocks);

		return S_OK;
	}

