#pragma once
//
// imath.h
//

#include <Windows.h>

// {981B4B72-D733-438D-A1D6-F51B9ECA93D4}
DEFINE_GUID(CLSID_CMath,
	0x981b4b72, 0xd733, 0x438d, 0xa1, 0xd6, 0xf5, 0x1b, 0x9e, 0xca, 0x93, 0xd4);


// {36D82DAD-7D2A-4636-9C2D-962599E56642}
DEFINE_GUID(IID_IMath,
	0x36d82dad, 0x7d2a, 0x4636, 0x9c, 0x2d, 0x96, 0x25, 0x99, 0xe5, 0x66, 0x42);

/*
// {A888F561-58E4-11d0-A68A-0000837E3100} 
DEFINE_GUID(IID_IMath,
	0xa888f561, 0x58e4, 0x11d0, 0xa6, 0x8a, 0x0, 0x0,
	0x83, 0x7e, 0x31, 0x0);*/



class IMath : public IUnknown
{
public:
	STDMETHOD(Add(long, long, long*))     PURE; 
	STDMETHOD(Subtract(long, long, long*)) PURE;
	STDMETHOD(Multiply(long, long, long*)) PURE;
	STDMETHOD(Divide(long, long, long*))  PURE;
};
