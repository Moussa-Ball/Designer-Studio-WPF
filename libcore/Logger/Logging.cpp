#include "pch.h"
#include "Logging.h"

#include "spdlog/spdlog.h"
#include "spdlog/sinks/basic_file_sink.h"

#include <iostream>

void Libcore::Logger::Logging::open(const std::string& logName, const std::string& filePath)
{
	try {
		spdlog::set_pattern("[%A, %b. %d, %Y - %I:%M %p] - (%n) - [%^%l] -> %v");
		auto logger = spdlog::basic_logger_mt(logName, filePath);
		spdlog::set_default_logger(logger);
	}
	catch (const spdlog::spdlog_ex& ex) {
		std::cout << "Log init failed: " << ex.what() << std::endl;
	}
}

void Libcore::Logger::Logging::critical(std::string message)
{
	spdlog::critical(message);
}

void Libcore::Logger::Logging::warning(std::string message)
{
	spdlog::warn(message);
}

void Libcore::Logger::Logging::error(std::string message)
{
	spdlog::error(message);
}

void Libcore::Logger::Logging::info(std::string message)
{
	spdlog::info(message);
}

void Libcore::Logger::Logging::debug(std::string message)
{
	spdlog::debug(message);
}
