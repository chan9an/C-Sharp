namespace HPMS
{
  public class Patient{

    public int id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Condition { get; set; }

    public Patient(int id,string name, int age, string condition){
      this.id=id;
      this.Name=name;
      this.Age=age;
      this.Condition=condition;
    }

  }

  
}
