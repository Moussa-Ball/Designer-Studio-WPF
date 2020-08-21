#pragma once

using namespace System;
using namespace System::IO;

namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			public ref class Application abstract : public Windows::Application
			{
			public:
				/* Get the current app domain. */
				static property Application^ Current { 
					Application^ get() {
						return static_cast<Application^>(System::Windows::Application::Current);
					} 
				};

				/* Contains the full name of an application. */
				virtual property String^ FullName { String^ get() { return FullName;}}

				/* Contains the full name of an application. */
				virtual property String^ ShortName { String^ get() { return ShortName; }}

				/* Contains the full name of an application. */
				virtual property String^ Guid { String^ get() { return Guid; }}

				/* Contains the full name of an application. */
				virtual property String^ Version { String^ get() { return Version; }}

				/* Contains the full name of an application. */
				virtual property String^ MajorVersion { String^ get() { return MajorVersion; }}

				/* Contains the full name of an application. */
				virtual property String^ MinorVersion { String^ get() { return MinorVersion; }}

				/* Contains the revision number of an application. */
				virtual property String^ Build { String^ get() { return Build; }}

				/* Contains the revision number of an application. */
				virtual property String^ Revision { String^ get() { return Revision; }}

				/* Contains the major revision number of an application. */
				virtual property String^ MajorRevision { String^ get() { return MajorRevision; }}

				/* Contains the minor revision number of an application. */
				virtual property String^ MinorRevision { String^ get() { return MinorRevision; }}
				
				/* Contains the log file path */
				virtual property String^ logFilePath { String^ get() { return logFilePath; }}

				/* Allows to get full path of an folder from windows os. */
				String^ GetSystemFolder(Environment::SpecialFolder sysfolder);

				/* Allows to get a directories anywhere in windows os. */
				String^ GetOrCreateDirectory(Environment::SpecialFolder sysfolder, String^ folderPath);

				/* Allows to get a file path */
				String^ GetOrCreateFilePath(Environment::SpecialFolder sysfolder, String^ folderPath, String^ filename);
			};
		}
	}
}
