#pragma once

#include <string>

#include "../Core.h"

namespace Libcore
{
	namespace Logger
	{
		class SHARED_LIBRARY Logging
		{
		public:
			static void open(const std::string& logName, const std::string& filePath);
			static void critical(std::string message);
			static void warning(std::string message);
			static void error(std::string message);
			static void debug(std::string message);
			static void info(std::string message);
		};
	}
}
