#pragma once

#include <string>

namespace Studio
{
	namespace Softer
	{
		namespace Core
		{
			class __declspec(dllexport) Logging
			{
			public:
				static void open(std::string logName, std::string filePath);
				static void critical(std::string message);
				static void warning(std::string message);
				static void error(std::string message);
				static void debug(std::string message);
				static void info(std::string message);
			};
		}
	}
}
