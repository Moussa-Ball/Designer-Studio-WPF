#pragma once

// Exclude rarely used parts of the windows headers
#define WIN32_LEAN_AND_MEAN
#include <Windows.h>

#include "../Logger.h"

#include "OpenGL/OpenGLContext.h"

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Input;
using namespace System::Windows::Media;
using namespace System::Windows::Interop;
using namespace System::Runtime::InteropServices;

namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			namespace Controls
			{
				public ref class RenderControl : public HwndHost
				{
				public:
					/*
					* \brief Default Constructor.
					*/
					RenderControl();

				protected:
					virtual IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, bool% handled) override;
					virtual HandleRef BuildWindowCore(HandleRef hwndParent) override;
					virtual void DestroyWindowCore(HandleRef hwnd) override;
					
				private:
					HWND parent;
					HWND window;

					int m_width;
					int m_height;

					Graphics::OpenGL::OpenGLContext* context;
				};
			}
		}
	}
}
