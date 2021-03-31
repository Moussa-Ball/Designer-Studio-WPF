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

Object^ Studio::Softer::Interoperate::Application::GetService(System::Type^ serviceType)
{
    return this->services->GetService(serviceType);
}

void Studio::Softer::Interoperate::Application::OnStartup(System::Windows::StartupEventArgs^ e)
{
    System::Windows::Application::OnStartup(e);

    this->MainWindow->Closing += gcnew System::ComponentModel::CancelEventHandler(this,
        &Studio::Softer::Interoperate::Application::OnClosing);

    // Register and get all services.
    this->RegisterServices(this->services);
    this->OnServicesRegistered(this->services);
}

void Studio::Softer::Interoperate::Application::RegisterServices(Services::ServiceManager^ services) {}

void Studio::Softer::Interoperate::Application::OnServicesRegistered(Services::ServiceManager^ services) {}

void Studio::Softer::Interoperate::Application::OnClosing(System::Object^ sender, System::ComponentModel::CancelEventArgs^ e) {}
