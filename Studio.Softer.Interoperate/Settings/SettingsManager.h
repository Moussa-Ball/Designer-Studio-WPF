#pragma once

using namespace System;
using namespace System::Activities;
using namespace System::Collections::Generic;

namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			namespace Settings
			{
				public ref class SettingsManager : Presentation::ServiceManager
				{
				public:
					/// <summary>
					/// Contains the name of setting.
					/// </summary>
					virtual property String^ Name { String^ get() { return Name; }}

				private:
					/// <summary>
					/// Allows to contain all settings.
					/// </summary>
					Dictionary<System::Type^, System::Object^>^ settings = gcnew Dictionary<System::Type^, System::Object^>();
				};
			}
		}
	}
}
