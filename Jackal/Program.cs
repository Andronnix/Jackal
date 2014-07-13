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
        [MTAThread]
        static void Main()
        {
            var program = new Brain(new WinFormRenderer());
        }
    }
}