using System;

namespace Day3{
    internal class Employee : Person
    {
        #region Fields
        string Skill;
        string desig;
        int empID;
        int bSAL;
        #endregion

        public Employee()
        {
            Console.WriteLine("Employee Class Constructor Invoked.");
        }

        ~Employee()
        {
            Console.WriteLine("Employee Class Destructor Invoked.");
        }
    }
}
