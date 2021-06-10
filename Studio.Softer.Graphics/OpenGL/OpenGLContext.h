#pragma once

#include "../Core.h"

// Exclude rarely used parts of the windows headers.
#define WIN32_LEAN_AND_MEAN
#include <Windows.h>

namespace Studio
{
	namespace Softer
	{
		namespace Graphics
		{
			namespace OpenGL
			{
				class SHARED_LIBRARY OpenGLContext
				{
				public:
					void MakeOpenGLContext(HWND window);
					HGLRC gerRenderingContext();
					HDC getDeviceContext();

					void glewViewport(int x, int y, int width, int height);
					
					void DestroyOpenGLContext(HWND window);
					void OnRender();
				};
			}
		}
	}
}
