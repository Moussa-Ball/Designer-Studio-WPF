﻿using System.Threading;
using Studio.Softer.Interoperate;

namespace Studio.Softer
{
    public abstract class Application : Interoperate.Application
    {
        /// <summary>
        /// Mutex instance used to manage the single instance.
        /// </summary>
        private Mutex m_mutex;

        /// <summary>
        /// Get the current app domain.
        /// </summary>
        public static new Application Current => (Application)System.Windows.Application.Current;

        /// <summary>
        /// Defualt constructor of this class.
        /// </summary>
        public Application()
        {
            Logger.Open(FullName, logFilePath);
            Logger.Warning($"{FullName} is already running. Shutting down.");
        }

        /// <summary>
        /// Runs the application in a single instance, otherwise it stops.
        /// </summary>
        protected void RunApplicationAsSingleInstance()
        {
            m_mutex = new Mutex(true, $"{Current.Guid}-{Current.Version}", out bool newInstance);

            if (newInstance)
            {
                m_mutex.ReleaseMutex();
            }
            else
            {
                Logger.Warning($"{FullName} is already running. Shutting down.");
                Shutdown();
            }
        }
    }
}