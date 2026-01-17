namespace Test;
class Program
{
    /*  public static void Main()
     {
         int size;
         size = Int32.Parse(Console.ReadLine());
         List<int> num = new List<int>();
         for (int i = 0; i < size; i++)
         {
             num.Add(int.Parse(Console.ReadLine()));
         }
         var evenNum = num.Where(x => x % 2 == 0);


         foreach (var evnum in evenNum)
         {
             System.Console.WriteLine(evnum);
         }
     } */

    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "ROhit" },
            new Employee { Id = 2, Name = "Virat" },
            new Employee { Id = 3, Name = "Sachin" }
        };
 
        Console.WriteLine("Enter employee id:");
        int id = int.Parse(Console.ReadLine());
 
        Employee emp = employees
            .FirstOrDefault(e => e.Id == id);
 
        if (emp != null)
            Console.WriteLine($"Employee Found: {emp.Id} - {emp.Name}");
        else
            Console.WriteLine("Employee not found");
    }
}