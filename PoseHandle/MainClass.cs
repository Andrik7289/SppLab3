namespace PoseHandle;

using System;
using System.IO;

class MainClass
{
    static void Main(string[] args)
    {
        IntPtr fileHandle = OpenFile("example.txt");
        PoseHandle poseHandle = new PoseHandle(fileHandle);

        if (poseHandle.Handle != IntPtr.Zero)
        {
            Console.WriteLine("File was successfully opened.");
            poseHandle.Dispose();
        }
        else
        {
            Console.WriteLine("Error while opening file!");
        }
        
        Console.WriteLine("Work with file ended.");
    }

    static IntPtr OpenFile(string filename)
    {
        IntPtr handle = IntPtr.Zero;
        try
        {
            FileStream fs = File.Open(filename, FileMode.OpenOrCreate);
            handle = fs.SafeFileHandle.DangerousGetHandle();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while opening file: {ex.Message}");
        }

        return handle;
    }
}