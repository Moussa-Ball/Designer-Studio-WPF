#include "pch.h"
#include "ServiceManager.h"


namespace Studio
{
	namespace Softer
	{
		namespace Interoperate
		{
			namespace Services
			{
				bool ServiceManager::Contains(System::Type^ serviceType)
				{
					this->CheckIsNullableAndThrowException(serviceType);
					return (services->ContainsKey(serviceType)) ? true : false;
				}

				System::Object^ ServiceManager::GetService(System::Type^ serviceType)
				{
					this->CheckIsNullableAndThrowException(serviceType);
					Object^ value = nullptr;
					this->services->TryGetValue(serviceType, value);
					return static_cast<Object^>(value);
				}
				
				System::Collections::Generic::IEnumerator<System::Type^>^ ServiceManager::GetEnumerator()
				{
					return this->services->Keys->GetEnumerator();
				}
				
				
				void ServiceManager::Publish(System::Type^ serviceType, System::Object^ serviceInstance)
				{
					this->CheckIsNullableAndThrowException(serviceType);
					this->CheckIsNullableAndThrowException(serviceInstance);
					this->services->Add(serviceType, serviceInstance);
				}

				void ServiceManager::CheckIsNullableAndThrowException(System::Object^ serviceType)
				{
					if (serviceType == nullptr)
						throw gcnew ArgumentNullException(serviceType->GetType()->ToString());
				}

				void ServiceManager::Unsubscribe(System::Type^ serviceType, System::Activities::Presentation::SubscribeServiceCallback^ callback) 
				{
					callback(serviceType, Activator::CreateInstance(serviceType));
				}

				void ServiceManager::Subscribe(System::Type^ serviceType, System::Activities::Presentation::SubscribeServiceCallback^ callback) 
				{
					callback(serviceType, Activator::CreateInstance(serviceType));
				}

				void ServiceManager::Publish(System::Type^ serviceType, System::Activities::Presentation::PublishServiceCallback^ callback) 
				{
					callback(serviceType);
				}
			}
		}
	}
}
