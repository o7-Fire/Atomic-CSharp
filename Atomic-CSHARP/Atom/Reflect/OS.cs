using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Atomic_CSHARP.Atom.Reflect
{
    public class OS
    {
        public static readonly bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static readonly bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        public static readonly bool isMac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        public static readonly bool isIos;
        public static readonly bool isAndroid;
        public static readonly bool isARM;
        public static readonly bool is64Bit = Environment.Is64BitOperatingSystem;

        static OS()
        {
            IntPtr handle = Process.GetCurrentProcess().Handle;
            IsWow64Process2(handle, out ushort processMachine, out ushort nativeMachine);
            isARM = nativeMachine == 0xaa64;
            isIos = false;
            isAndroid = false;
        }

        public static string getProperty(String s)
        {
            return Environment.GetEnvironmentVariable(s) ?? "null";
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool IsWow64Process2(
            IntPtr process,
            out ushort processMachine,
            out ushort nativeMachine
        );
    }
}