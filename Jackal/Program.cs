using System;
using System.Collections.Generic;

namespace Jackal
{
    /// <summary>
    /// Simple Jackal application using SharpDX.Toolkit.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var program = new Brain();
        }
    }
}