using System;

namespace Day4.Project;

public class MathClass : IAll
{
    public int AddMe(int num1, int num2)
    {
        return num1 + num2;
    }
    public int SubMe(int num1, int num2)
    {
        return num1 - num2;
    }
    public int ProdMe(int num1, int num2)
    {
        return num1 * num2;
    }
    public float DivMe(int num1, int num2)
    {
        return num1 / num2;
    }

}
public class onlyAdd :IAdd
{
     public int AddMe(int num1, int num2)
    {
        return num1 + num2;
    }
}
