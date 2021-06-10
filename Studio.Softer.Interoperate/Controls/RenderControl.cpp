#include "pch.h"
#include "RenderControl.h"

namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			namespace Controls
			{
				RenderControl::RenderControl() : window(nullptr) {}

				IntPtr RenderControl::WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, bool% handled)
				{
					switch (msg)
					{
					case WM_PAINT:
						PAINTSTRUCT ps;
						context->OnRender();
						BeginPaint(reinterpret_cast<HWND>(hwnd.ToPointer()), &ps);
						EndPaint(reinterpret_cast<HWND>(hwnd.ToPointer()), &ps);
						handled = true;
						return System::IntPtr::Zero;
					case WM_SIZE:
						RECT rect;
						if (GetWindowRect(parent, &rect))
						{
							m_width = rect.right - rect.left;
							m_height = rect.bottom - rect.top;
						}
						context->glewViewport(0, 0, m_width, m_height);
						handled = false;
						return System::IntPtr::Zero;
					}
					handled = false;
					return System::IntPtr::Zero;
				}

				HandleRef RenderControl::BuildWindowCore(HandleRef hwndParent)
				{
					parent = reinterpret_cast<HWND>(hwndParent.Handle.ToPointer());

					RECT rect;
					if (GetWindowRect(parent, &rect))
					{
						m_width = rect.right - rect.left;
						m_height = rect.bottom - rect.top;
					}

					this->window = CreateWindowEx(
						0, 
						L"static", 
						NULL,
						WS_CHILD | WS_VISIBLE,
						0, 0,
						m_width,
						m_height,
						parent,
						NULL,
						NULL,
						0
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
