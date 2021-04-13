#include "pch.h"
#include "Settings.h"

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
