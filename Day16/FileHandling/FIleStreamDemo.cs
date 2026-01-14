using System;

namespace FileHandling;

public class FIleStreamDemo
{
    FileStream fs = null;
    public void CreateFile(string fileName)
    {
        fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
        StreamWriter sWriter = new StreamWriter(fs);
        
    }
    //public void ReadFile(string fileName)


}
