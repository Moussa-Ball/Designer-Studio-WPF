#include "pch.h"
#include "Settings.h"

#include "../Logger/Logging.h"

#include <iostream>

namespace Libcore
{
	namespace Settings
	{
		void Settings::open(std::string filePath)
		{
			try
			{
				cfg.readFile("example.cfg");
			}
			catch (const FileIOException& fioex)
			{
				Logger::Logging::error("LibConfig: I/O error while reading file.");
				std::cerr << "I/O error while reading file." << std::endl;
			}
			catch (const ParseException& pex)
			{
				// Get error infos
				std::string file = pex.getFile();
				std::string error = pex.getError();
				std::string line = std::to_string(pex.getLine());
				
				Logger::Logging::error("LibConfig: Parse error at " + file + ":" + line + " - " + error);
				std::cerr << "Parse error at " << pex.getFile() << ":" << pex.getLine()
					<< " - " << pex.getError() << std::endl;
			}
		}
	}
}
