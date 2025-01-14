using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ComMutex
{
    [Guid("184B7CD9-CA53-4C9C-B26E-5EF14AC57270")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class ComMutex
    {
        private Mutex mutex;

        /// <summary>
        /// Creates a named mutex.
        /// </summary>
        /// <param name="name">The name of the mutex.</param>
        /// <returns>True if the mutex was created successfully, false otherwise.</returns>
        public bool Create(string name)
        {
            try
            {
                mutex = new Mutex(false, name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for the mutex to be available indefinitely.
        /// </summary>
        /// <returns>True if the mutex was acquired, false otherwise.</returns>
        public bool Wait()
        {
            return WaitWithTimeout(-1);
        }

        /// <summary>
        /// Waits for the mutex to be available within a specific timeout.
        /// </summary>
        /// <param name="timeoutMilliseconds">The timeout in milliseconds.</param>
        /// <returns>True if the mutex was acquired, false otherwise.</returns>
        public bool WaitWithTimeout(int timeoutMilliseconds)
        {
            try
            {
                if (mutex == null)
                    return false;

                return mutex.WaitOne(timeoutMilliseconds);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Releases the mutex.
        /// </summary>
        /// <returns>True if the mutex was released successfully, false otherwise.</returns>
        public bool ReleaseMutex()
        {
            try
            {
                if (mutex == null)
                    return false;

                mutex.ReleaseMutex();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
