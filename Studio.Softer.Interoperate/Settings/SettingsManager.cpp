#include "../pch.h"
#include "SettingsManager.h"

namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			namespace Settings
			{
				// Constructor: Initialize new Settings Class.
				SettingsManager::SettingsManager()
				{
					this->m_setting = new Libcore::Settings::Settings();
				}

				void SettingsManager::open(String^ filepath)
				{
					auto file_path = marshal_as<std::string>(filepath);
					this->m_setting->open(file_path);
				}

				void SettingsManager::write(String^ path, String^ value)
				{
					auto pth = Name + "." + path;
					std::string setting_path = marshal_as<std::string>(pth);
					std::string setting_value = marshal_as<std::string>(value);
					this->m_setting->set(setting_path, setting_value);
				}

				String^ SettingsManager::read(String^ path, String^ value)
				{
					auto pth = Name + "." + path;
					std::string setting_path = marshal_as<std::string>(pth);
					std::string setting_value = marshal_as<std::string>(value);
					auto val = this->m_setting->get(setting_path, setting_value);
					String^ conf = gcnew String(val.c_str());
					return conf;
				}
				
				void SettingsManager::save()
				{
					this->m_setting->save();
				}
			}
		}
	}
}
