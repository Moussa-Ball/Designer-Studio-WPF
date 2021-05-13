#pragma once

using namespace System;
using namespace System::Windows::Input;
using namespace System::Windows::Media;

namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			namespace Workspaces
			{
				public ref class Workspace abstract
				{
				public:
					event EventHandler^ WorkspaceEvent;
					virtual ImageSource^ WorkspaceIcon() abstract;
				};
			}
		}
	}
}
