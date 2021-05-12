#pragma once

using namespace System;
using namespace System::Windows::Input;

namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			namespace Commands
			{
				public ref class Command abstract : ICommand
				{
				public:
					virtual event EventHandler^ CanExecuteChanged;
					virtual bool CanExecute(System::Object^ parameter);
					virtual void Execute(System::Object^ parameter) abstract;
				};
			}
		}
	}
}