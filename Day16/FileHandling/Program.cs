using System;

namespace FileHandling;

 public class Program
    {
        static void Main()
        {
            
            string dirPath = "/home";
            string drivePath = "/";

            DirectoryDemo demo = new DirectoryDemo(dirPath);

            demo.ShowDirectoryInfo();
            demo.DriveInfoFunc(drivePath);
        }
    }
