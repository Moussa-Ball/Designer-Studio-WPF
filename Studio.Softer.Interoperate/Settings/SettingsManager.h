#pragma once

#include "Settings/Settings.h"

#include <msclr\marshal_cppstd.h>

using namespace msclr::interop;

using namespace System;
using namespace System::Collections::Generic;

namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			namespace Settings
			{
				public ref class SettingsManager abstract
				{
				public:
					// Main name of settings.
					virtual property String^ Name { String^ get() { return Name; }}

					// Default Constructor.
					SettingsManager();

					// Set the absolute filpath for settings.
					void open(String^ filepath);

					// Write a config in the settings file.
					void write(String^ path, String^ value);

					// Get param or config in file settings.
					String^ read(String^ path, String^ value);

					// Saves settings in file settings.
					void save();

				private:
					Libcore::Settings::Settings* m_setting = nullptr;
				};
			}
		}
	}
}
