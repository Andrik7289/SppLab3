namespace PoseHandle;

using System;
using System.IO;

class MainClass
{
    static void Main(string[] args)
    {
       using (var poseHandle = new PoseHandle(OpenFile("example.txt")))
       {
           if (poseHandle.Handle != IntPtr.Zero)
           {
               Console.WriteLine("File was successfully opened.");
           }
           else
           {
               Console.WriteLine("Error while opening file!");
           }
       }
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