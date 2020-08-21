#pragma once

using namespace System;
using namespace System::Runtime::InteropServices;

namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			public ref class Logger abstract sealed
			{
			public:
				static void Open(String^ logName, String^ filePath);
				static void Critical(String^ message);
				static void Warning(String^ message);
				static void Debug(String^ message);
				static void Error(String^ message);
				static void Info(String^ message);
			};
		}
	}
}
