#pragma once

#include "../Core.h"

#include <boost/property_tree/ptree.hpp>
#include <boost/property_tree/xml_parser.hpp>
#include <boost/property_tree/json_parser.hpp>
#include <boost/foreach.hpp>
#include <string>
#include <set>
#include <exception>
#include <iostream>
#include <memory>
#include <fstream>

namespace pt = boost::property_tree;

namespace Libcore
{
	namespace Settings
	{
		class SHARED_LIBRARY Settings 
		{
		public:
			// Set the file path of settings.
			void open(const std::string& filepath);
			
			// Add config in file settings.
			template<typename T> 
			void set(const std::string& path, const T& value)
			{
				pt.put(path, value);
			}

			// Get the value of setting using the path.
			template<typename T>
			T get(const std::string& path)
			{
				std::fstream file;
				file.open(this->filepath);
				if (!file.good()) {
					this->set(path, "");
					this->save();
				}
				pt::read_json(filepath, pt);
				return pt.get<T>(path);
			}
			
			// Get the value of setting using the type of value.
			template<typename T>
			T get(const std::string& path, const T& value)
			{
				std::fstream file;
				file.open(this->filepath);
				if (!file.good()) {
					this->set(path, value);
					this->save();
				}
				pt::read_json(filepath, pt);
				return pt.get(path, value);
			}

			// Save settings.
			void save();

		private:
			std::string filepath;
			pt::ptree pt;
		};
	}
}
