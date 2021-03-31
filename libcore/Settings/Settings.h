#pragma once

#include "../Core.h"
#include <libconfig.h++>

using namespace libconfig;

namespace Libcore
{
	namespace Settings
	{
		class SHARED_LIBRARY Settings
		{
		public:
			void open(std::string filePath);

		private:
			Config cfg;
		};
	}
}
