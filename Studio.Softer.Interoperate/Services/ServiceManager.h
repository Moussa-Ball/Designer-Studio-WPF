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
			namespace Services
			{
				public ref class ServiceManager : Presentation::ServiceManager
				{
				public:

					/// <summary>
					/// Check if the manager contains a given service.
					/// </summary>
					/// <param name="serviceType">The type of service.</param>
					/// <returns>A boolean if the service is find or not.</returns>
					virtual bool Contains(System::Type^ serviceType) override;
					
					/// <summary>
					/// Get the service if it is registered in the service manager.
					/// </summary>
					/// <param name="serviceType">The type of services</param>
					/// <returns></returns>
					virtual System::Object^ GetService(System::Type^ serviceType) override;
					
					/// <summary>
					/// Obtain an enumeration of all the services registered in the service manager.
					/// </summary>
					/// <returns>An enumeration of all types of service.</returns>
					virtual System::Collections::Generic::IEnumerator<System::Type^>^ GetEnumerator() override;	
					
					/// <summary>
					/// Add a service in service manager.
					/// </summary>
					/// <param name="serviceType">The type of service.</param>
					/// <param name="serviceInstance">An instance of this service.</param>
					virtual void Publish(System::Type^ serviceType, System::Object^ serviceInstance) override;

					/// <summary>
					/// Removes a subscription for a service type.
					/// </summary>
					/// <param name="serviceType">The type of the service to remove the subscription from.</param>
					/// <param name="callback">The callback object to remove from the subscription.</param>
					virtual void Unsubscribe(System::Type^ serviceType, System::Activities::Presentation::SubscribeServiceCallback^ callback) override;

					/// <summary>
					/// Invokes the provided callback when someone has published the requested service. 
					/// If the service was already available, this method invokes the callback immediately.
					/// </summary>
					/// <param name="serviceType">The type of service to subscribe to.</param>
					/// <param name="callback">A callback that will be notified when the service is available.</param>
					virtual void Subscribe(System::Type^ serviceType, System::Activities::Presentation::SubscribeServiceCallback^ callback) override;

					/// <summary>
					/// Publishes the specified service type, but does not declare an instance. 
					/// When the service is requested, the Publish service callback will be invoked to create the instance. 
					/// The callback is invoked only once. After that, the instance it returned is cached.
					/// </summary>
					/// <param name="serviceType">The type of the service to publish.</param>
					/// <param name="callback">A callback that will be invoked when an instance of the service is needed.</param>
					virtual void Publish(System::Type^ serviceType, System::Activities::Presentation::PublishServiceCallback^ callback) override;

				private:
					/// <summary>
					/// Allows to contain all services.
					/// </summary>
					Dictionary<System::Type^, System::Object^>^ services = gcnew Dictionary<System::Type^, System::Object^>();
					
					/// <summary>
					/// Check if a service type or object is null and throw exception if it's true.
					/// </summary>
					/// <param name="serviceType">The instance of service type.</param>
					void CheckIsNullableAndThrowException(System::Object^ serviceType);
				};
			}
		}
	}
}
