#include "OpenGLContext.h"

#include <iostream>
#include <GL/glew.h>

HDC deviceContext = NULL;
HGLRC renderingContext = NULL;

namespace Studio
{
	namespace Softer
	{
		namespace Graphics
		{
			namespace OpenGL
			{
                void OpenGLContext::MakeOpenGLContext(HWND window)
                {
                    deviceContext = GetDC(window);

                    PIXELFORMATDESCRIPTOR DesiredPixelFormat = {};
                    DesiredPixelFormat.nSize = sizeof(DesiredPixelFormat);
                    DesiredPixelFormat.nVersion = 1;
                    DesiredPixelFormat.iPixelType = PFD_TYPE_RGBA;
                    DesiredPixelFormat.dwFlags = PFD_SUPPORT_OPENGL | PFD_DRAW_TO_WINDOW | PFD_DOUBLEBUFFER;
                    DesiredPixelFormat.cColorBits = 32;
                    DesiredPixelFormat.cAlphaBits = 8;
                    DesiredPixelFormat.iLayerType = PFD_MAIN_PLANE;
                    DesiredPixelFormat.cDepthBits = 24;
                    DesiredPixelFormat.cStencilBits = 8;

                    int SuggestedPixelFormatIndex = ChoosePixelFormat(deviceContext, &DesiredPixelFormat);
                    PIXELFORMATDESCRIPTOR SuggestedPixelFormat;
                    DescribePixelFormat(deviceContext, SuggestedPixelFormatIndex, 
                        sizeof(SuggestedPixelFormat), &SuggestedPixelFormat);
                    SetPixelFormat(deviceContext, SuggestedPixelFormatIndex, &SuggestedPixelFormat);
                    
                    renderingContext = wglCreateContext(deviceContext);
                    if (!wglMakeCurrent(deviceContext, renderingContext))
                        ReleaseDC(window, deviceContext);

                    // Initialize GLEW
                    if (glewInit() != GLEW_OK) {
                        std::cout << "GLEW Initialization Failed!" << std::endl;
                    }

                    float positions[6] = {
                        -0.5f, -0.5f,
                        0.0f,  0.5f,
                        0.5f, -0.5f
                    };

                    // Create buffer and copy data
                    GLuint buffer;
                    glGenBuffers(1, &buffer);
                    glBindBuffer(GL_ARRAY_BUFFER, buffer);
                    glBufferData(GL_ARRAY_BUFFER, 6 * sizeof(float), positions, GL_STATIC_DRAW);

                    // define vertex layout
                    glVertexAttribPointer(0, 2, GL_FLOAT, GL_FALSE, 2 * sizeof(float), 0);
                    glEnableVertexAttribArray(0);
                }

                void OpenGLContext::DestroyOpenGLContext(HWND window)
                {
                    wglMakeCurrent(NULL, NULL);
                    ReleaseDC(window, deviceContext);
                    wglDeleteContext(renderingContext);
                }

                void OpenGLContext::OnRender()
                {
                    // Clear the screen
                    glClear(GL_COLOR_BUFFER_BIT);

                    // Draw the triangle !
                    glDrawArrays(GL_TRIANGLES, 0, 3); // 3 indices starting at 0 -> 1 triangle

                    // Swap buffers | Flush.
                    glFlush();
                    SwapBuffers(deviceContext);
                }

                HGLRC OpenGLContext::gerRenderingContext()
                {
                    return renderingContext;
                }

                HDC OpenGLContext::getDeviceContext()
                {
                    return deviceContext;
                }

                void OpenGLContext::glewViewport(int x, int y, int width, int height)
                {
                    glViewport(x, y, width, height);
                }
            }
		}
	}
}
