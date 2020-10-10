#include "pch.h"
#include "Application.h"


String^ Studio::Softer::Interoperate::Application::GetSystemFolder(Environment::SpecialFolder sysfolder)
{
    return Environment::GetFolderPath(sysfolder);
}

String^ Studio::Softer::Interoperate::Application::GetOrCreateDirectory(Environment::SpecialFolder sysfolder, String^ folderPath)
{

    auto root = Path::Combine(this->GetSystemFolder(sysfolder), folderPath);
    if (!Directory::Exists(root))
        Directory::CreateDirectory(root);
    return root;
}

String^ Studio::Softer::Interoperate::Application::GetOrCreateFilePath(Environment::SpecialFolder sysfolder, String^ folderPath, String^ filename)
{
    auto filepath = Path::Combine(this->GetOrCreateDirectory(sysfolder, folderPath), filename);
    if (!File::Exists(filepath))
        File::Create(filepath);
    return filepath;
}

void Studio::Softer::Interoperate::Application::OnStartup(System::Windows::StartupEventArgs^ e)
{
    
}
