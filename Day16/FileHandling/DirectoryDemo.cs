using System;
using System.IO;

namespace FileHandling
{
    public class DirectoryDemo
    {
        private string path;

        // Constructor
        public DirectoryDemo(string path)
        {
            this.path = path;
        }

        // Display directory information
        public void ShowDirectoryInfo()
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                Console.WriteLine("\n--- Directory Info ---");
                Console.WriteLine("Full Name   : " + dir.FullName);
                Console.WriteLine("Name        : " + dir.Name);
                Console.WriteLine("Creation    : " + dir.CreationTime);
                Console.WriteLine("Last Access : " + dir.LastAccessTime);
            }
            else
            {
                Console.WriteLine("Directory not found!");
            }
        }

        // DriveInfo demonstration
        public void DriveInfoFunc(string driveName)
        {
            DriveInfo dInfo = new DriveInfo(driveName);

            Console.WriteLine("\n--- Drive Information ---");
            Console.WriteLine("Drive Name      : " + dInfo.Name);
            Console.WriteLine("Drive Type      : " + dInfo.DriveType);

            if (dInfo.IsReady)
            {
                Console.WriteLine("File System     : " + dInfo.DriveFormat);
                Console.WriteLine("Total Size (GB) : " + dInfo.TotalSize / (1024 * 1024 * 1024));
                Console.WriteLine("Free Space (GB) : " + dInfo.TotalFreeSpace / (1024 * 1024 * 1024));
                Console.WriteLine("Root Directory  : " + dInfo.RootDirectory);
            }
            else
            {
                Console.WriteLine("Drive is not ready.");
            }
        }
    }
}