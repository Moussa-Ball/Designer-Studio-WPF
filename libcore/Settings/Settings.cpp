#include "Settings.h"

#include <iostream>
#include <iomanip>
#include <cstdlib>
#include <string>

#include "../Logger/Logging.h"

namespace Libcore
{
	namespace Settings
	{
		void Settings::open(const std::string& filepath)
		{
			this->filepath = filepath + ".json";
		}

		void Settings::save()
		{
			pt::write_json(this->filepath, pt);
		}
	}
}
