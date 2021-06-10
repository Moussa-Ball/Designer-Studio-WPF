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
                    static  PIXELFORMATDESCRIPTOR pfd =             // pfd Tells Windows How We Want Things To Be
                    {
                        sizeof(PIXELFORMATDESCRIPTOR),              // Size Of This Pixel Format Descriptor
                        1,                                          // Version Number
                        PFD_DRAW_TO_WINDOW |                        // Format Must Support Window
                        PFD_SUPPORT_OPENGL |                        // Format Must Support OpenGL
                        PFD_DOUBLEBUFFER,                           // Must Support Double Buffering
                        PFD_TYPE_RGBA,                              // Request An RGBA Format
                        3,                                          // Select Our Color Depth
                        0, 0, 0, 0, 0, 0,                           // Color Bits Ignored
                        0,                                          // No Alpha Buffer
                        0,                                          // Shift Bit Ignored
                        0,                                          // No Accumulation Buffer
                        0, 0, 0, 0,                                 // Accumulation Bits Ignored
                        24,                                         // 16Bit Z-Buffer (Depth Buffer)  
                        0,                                          // No Stencil Buffer
                        0,                                          // No Auxiliary Buffer
                        PFD_MAIN_PLANE,                             // Main Drawing Layer
                        0,                                          // Reserved
                        0, 0, 0                                     // Layer Masks Ignored
                    };

                    deviceContext = GetDC(window);

                    int pixelFormat;
                    pixelFormat = ChoosePixelFormat(deviceContext, &pfd);
                    SetPixelFormat(deviceContext, pixelFormat, &pfd);
                    
                    renderingContext = wglCreateContext(deviceContext);
                    wglMakeCurrent(deviceContext, renderingContext);


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
