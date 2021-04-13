#pragma once

#include "SettingsManager.h"

using namespace System;

namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			namespace Settings
			{
				public ref class SettingsBase abstract : public SettingsManager
				{
				public:
					// Name of settings
					virtual property String^ Name { String^ get() override { return Name; }}

					// Settings folder
					virtual property String^ SettingsFolder { String^ get() override { return SettingsFolder; }}

					/// <summary>
					/// Defautl Constructor: Set Absolute file path for settings.
					/// </summary>
					SettingsBase();

					/// <summary>
					/// Read configuration in file settings.
					/// </summary>
					/// <param name="path"></param>
					/// <param name="value"></param>
					/// <returns></returns>
					generic<typename T> T Read(String^ path, T value)
					{
						return ConvertValue<T>(read(path, value->ToString()));
					}

					/// <summary>
					/// Write configuration in file settings.
					/// </summary>
					/// <param name="path"></param>
					/// <param name="value"></param>
					generic<typename T> void Write(String^ path, T value)
					{
						write(path, value->ToString());
					}

					/// <summary>
					/// Read configuration in file settings.
					/// </summary>
					/// <typeparam name="T"></typeparam>
					/// <param name="value"></param>
					/// <returns></returns>
					generic<typename T> T ConvertValue(Object^ value)
					{
						return (T)Convert::ChangeType(value, T::typeid);
					}

					/// <summary>
					/// Load main window settings.
					/// </summary>
					virtual void LoadSettings() abstract;

					/// <summary>
					/// Write main window settings.
					/// </summary>
					virtual void SaveSettings() abstract;

					/// <summary>
					/// Load all settings from parent class.
					/// </summary>
					void Load()
					{
						LoadSettings();
						save();
					}

					/// <summary>
					/// Saves all settings from parent class.
					/// </summary>
					void Save()
					{
						SaveSettings();
						save();
					}
				};
			}
		}
	}
}
