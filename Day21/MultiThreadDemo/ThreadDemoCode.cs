using System;

namespace MultiThreadDemo;

public class ThreadDemoCode
{
    public void DoTask1()
    {
        for (int i = 1; i < 10; i++)
        {
            Console.WriteLine($"Thread 2 value is :{0}", i);
        }
    }
    public void DoTask2()
    {
        for (int i = 11; i < 20; i++)
        {
            Console.WriteLine($"Thread 1 value is :{0}",i);
        }
    }
    public static void ThreadDemoMain()
    {
        ThreadDemoCode tObj = new ThreadDemoCode();
        Thread t1 = new Thread(new ThreadStart(tObj.DoTask2));
        Thread t2 = new Thread(new ThreadStart(tObj.DoTask1));
        t1.Start();
        t2.Start();
    }
}
