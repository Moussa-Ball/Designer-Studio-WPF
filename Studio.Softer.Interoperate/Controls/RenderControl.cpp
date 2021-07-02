#include "../pch.h"
#include "RenderControl.h"

namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			namespace Controls
			{
				RenderControl::RenderControl(ContentPresenter^ container) :
					window(nullptr), context(nullptr)
				{
					this->container = container;
				}

				IntPtr RenderControl::WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, bool% handled)
				{
					switch (msg)
					{
					case WM_PAINT:
						PAINTSTRUCT ps;
						BeginPaint(reinterpret_cast<HWND>(hwnd.ToPointer()), &ps);
						context->OnRender();
						EndPaint(reinterpret_cast<HWND>(hwnd.ToPointer()), &ps);
						handled = true;
						return System::IntPtr::Zero;
						break;
					case WM_SIZE:
						context->glewViewport(0, 0, (int)this->container->ActualWidth, (int)this->container->ActualHeight);
						handled = true;
						return System::IntPtr::Zero;
						break;
					}
					handled = false;
					return System::IntPtr::Zero;
				}

				HandleRef RenderControl::BuildWindowCore(HandleRef hwndParent)
				{
					this->parent = reinterpret_cast<HWND>(hwndParent.Handle.ToPointer());
					this->window = CreateWindowEx(
						0, 
						L"static", 
						NULL,
						WS_CHILD | WS_VISIBLE,
						0, 0,
						(int)this->container->ActualWidth,
						(int)this->container->ActualHeight,
						parent,
						NULL,
						(HINSTANCE)GetModuleHandle(NULL),
						NULL
					);

					// Make an opengl context for a win32 window and initlize glew.
					context->MakeOpenGLContext(this->window);
					return HandleRef(this, IntPtr(this->window));
				}

				void RenderControl::DestroyWindowCore(HandleRef hwnd)
				{
					HWND window = reinterpret_cast<HWND>(hwnd.Handle.ToPointer());
					context->DestroyOpenGLContext(window);
					DestroyWindow(reinterpret_cast<HWND>(window));
				}
			}
		}
	}
}
