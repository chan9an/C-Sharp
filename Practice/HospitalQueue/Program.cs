using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalQueue
{
    public class Patient
    {
        public string PatientId { get; set; }
        public string Name { get; set; }
        public int SeverityLevel { get; set; }

        public Patient(string id, string name, int severity)
        {
            PatientId = id;
            Name = name;
            SeverityLevel = severity;
        }
    }

    public class InvalidSeverityLevelException : Exception
    {
        public InvalidSeverityLevelException(string message) : base(message) { }
    }

    public class PatientNotFoundException : Exception
    {
        public PatientNotFoundException(string message) : base(message) { }
    }

    public class PatientManager
    {
        private SortedDictionary<int, Queue<Patient>> patients = new SortedDictionary<int, Queue<Patient>>();

        public void AddPatient(Patient p)
        {
            if (p.SeverityLevel <= 0)
                throw new InvalidSeverityLevelException("Severity level must be positive.");

            if (!patients.ContainsKey(p.SeverityLevel))
                patients[p.SeverityLevel] = new Queue<Patient>();
            
            patients[p.SeverityLevel].Enqueue(p);
        }

        public void UpdateSeverity(string patientId, int newSeverity)
        {
            if (newSeverity <= 0)
                throw new InvalidSeverityLevelException("Severity level must be positive.");

            Patient target = null;
            int oldSeverity = -1;

            foreach (var pair in patients)
            {
                var list = pair.Value.ToList();
                var p = list.FirstOrDefault(x => x.PatientId == patientId);
                if (p != null)
                {
                    target = p;
                    oldSeverity = pair.Key;
                    break;
                }
            }

            if (target == null)
                throw new PatientNotFoundException($"Patient {patientId} not found.");

            // Remove from old queue
            var oldQueue = patients[oldSeverity];
            var newQueue = new Queue<Patient>();
            while (oldQueue.Count > 0)
            {
                var item = oldQueue.Dequeue();
                if (item.PatientId != patientId)
                    newQueue.Enqueue(item);
            }
            if (newQueue.Count == 0)
                patients.Remove(oldSeverity);
            else
                patients[oldSeverity] = newQueue;

            // Add to new severity
            target.SeverityLevel = newSeverity;
            if (!patients.ContainsKey(newSeverity))
                patients[newSeverity] = new Queue<Patient>();
            patients[newSeverity].Enqueue(target);
        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> all = new List<Patient>();
            foreach (var pair in patients)
            {
                all.AddRange(pair.Value);
            }
            return all;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PatientManager manager = new PatientManager();

            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1 -> Display Patients by Priority");
                Console.WriteLine("2 -> Update Severity");
                Console.WriteLine("3 -> Add Patient");
                Console.WriteLine("4 -> Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var list = manager.GetAllPatients();
                            if (list.Count == 0)
                                Console.WriteLine("No patients found.");
                            else
                            {
                                foreach (var p in list)
                                    Console.WriteLine($"Details: {p.PatientId} {p.Name} {p.SeverityLevel}");
                            }
                            break;

                        case "2":
                            Console.Write("Patient ID: ");
                            string id = Console.ReadLine();
                            Console.Write("New Severity Level: ");
                            if (int.TryParse(Console.ReadLine(), out int sev))
                            {
                                manager.UpdateSeverity(id, sev);
                                Console.WriteLine("Severity updated successfully.");
                            }
                            break;

                        case "3":
                            Console.WriteLine("Enter details (ID Name Severity):");
                            string[] pArr = Console.ReadLine().Split(' ');
                            if (pArr.Length == 3)
                            {
                                manager.AddPatient(new Patient(pArr[0], pArr[1], int.Parse(pArr[2])));
                                Console.WriteLine("Patient added successfully.");
                            }
                            break;

                        case "4":
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
