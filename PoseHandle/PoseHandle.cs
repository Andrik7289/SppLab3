using System.Runtime.InteropServices;

namespace PoseHandle;

using System;

public class PoseHandle : IDisposable
{
    private IntPtr handle = IntPtr.Zero;

    private bool isDisposed = false;

    public PoseHandle(IntPtr handle)
    {
        this.handle = handle;
    }

    public IntPtr Handle
    {
        get { return handle; }
        set { handle = value; }
    }

    public void Dispose()
    {
        DisposeHandle();
        GC.SuppressFinalize(this);
    }

    private void DisposeHandle()
    {
        if (!isDisposed)
        {
            bool result = Kernel32.CloseHandle(handle);
            if (!result)
            {
                Console.WriteLine("Error closing handle");
            }
            else
            {
                Console.WriteLine("Handle closed successfully");
            }

            handle = IntPtr.Zero;
            isDisposed = true;
        }
    }

    ~PoseHandle()
    {
        DisposeHandle();
    }
}

internal static class Kernel32
{
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseHandle(IntPtr hObject);
}