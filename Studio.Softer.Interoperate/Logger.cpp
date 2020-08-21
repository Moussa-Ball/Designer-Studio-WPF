#include "pch.h"
#include "Logger.h"

#include "Logging.h"

using namespace msclr::interop;

void Studio::Softer::Interoperate::Logger::Open(String^ logName, String^ filePath)
{
	std::string log_name = msclr::interop::marshal_as<std::string>(logName);
	std::string file_path = msclr::interop::marshal_as<std::string>(filePath);
	Studio::Softer::Core::Logging::open(log_name, file_path);
}

void Studio::Softer::Interoperate::Logger::Critical(String^ message)
{
	std::string msg = msclr::interop::marshal_as<std::string>(message);
	Studio::Softer::Core::Logging::critical(msg);
}

void Studio::Softer::Interoperate::Logger::Warning(String^ message)
{
	std::string msg = msclr::interop::marshal_as<std::string>(message);
	Studio::Softer::Core::Logging::warning(msg);
}

void Studio::Softer::Interoperate::Logger::Error(String^ message)
{
	std::string msg = msclr::interop::marshal_as<std::string>(message);
	Studio::Softer::Core::Logging::error(msg);
}

void Studio::Softer::Interoperate::Logger::Info(String^ message)
{
	std::string msg = msclr::interop::marshal_as<std::string>(message);
	Studio::Softer::Core::Logging::info(msg);
}

void Studio::Softer::Interoperate::Logger::Debug(String^ message)
{
	std::string msg = msclr::interop::marshal_as<std::string>(message);
	Studio::Softer::Core::Logging::debug(msg);
}
