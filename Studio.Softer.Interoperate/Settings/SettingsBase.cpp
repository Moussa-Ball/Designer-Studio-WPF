#include "../pch.h"
#include "SettingsBase.h"

#include "../Application.h"

namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			namespace Settings
			{
				SettingsBase::SettingsBase()
				{
					open(String::Join("\\", SettingsFolder, Name));
				}
			}
		}
	}
}