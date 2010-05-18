using System;
using System.Runtime.InteropServices;

namespace Lextm.MSBuildLaunchPad
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern void SetForegroundWindow(IntPtr handle);
    }
}
