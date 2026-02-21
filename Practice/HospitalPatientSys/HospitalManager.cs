using System;
using System.Collections;
using System.Linq;
namespace HPMS{

  public class HospitalManager
  {

    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
    private Queue<Patient> _appointmentQueue = new Queue<Patient>();

    public void RegisterPatient(int id, string name, int age, string condition)
    {
      Patient patObj = null;
      patObj = new Patient(id: id, name: name, age: age, condition: condition);
      _patients.Add(id, patObj);
    }
    public void ScheduleAppointment(int patientId)
    {
      var pObj1 = _patients[patientId];
      _appointmentQueue.Enqueue(pObj1);
    }
    public Patient ProcessNextAppointment()
    {
      if (_appointmentQueue.Count > 0)
      {
        _appointmentQueue.Dequeue();
        return _appointmentQueue.Peek();
      }
      Patient patObj = null;
      return patObj;
    }
    public List<Patient> FindPatientsByCondition(string condition)
    {
      var specificCondition = _patients.Where(x => x.Value.Condition == condition).Select(x => x.Value).ToList();
      return specificCondition;

    }

    public bool TryRegisterPatient(int id, string name, int age, string condition)
    {
      bool presentPatient = _patients.Any(x => x.Key == id);

      return presentPatient;


    }
   

    



  }
}
