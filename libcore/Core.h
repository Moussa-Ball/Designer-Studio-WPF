#pragma once

#if BUILD_DLL
	#define	SHARED_LIBRARY __declspec(dllexport)
#else
	#define	SHARED_LIBRARY __declspec(dllimport)
#endif
