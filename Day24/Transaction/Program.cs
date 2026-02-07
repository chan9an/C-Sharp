namespace Transaction
{

    class Program
    {
        public static void Main(String[] args)
        {
            Card card1 = new Card(
            "Parth", "1234-4567-6789", 123, new DateTime(2027, 12, 19), "SBI"
            );
            Card card2 = new Card(
            "Nevin", "9876-4567-6789", 123, new DateTime(2028, 10, 9), "HDFC"
            );

            List<Transactions> transactions = new List<Transactions>
            {

                new Transactions("T001", DateTime.UtcNow.AddSeconds(-90), card1, 60000, "Jalandhar", "rec1"),
                new Transactions("T002", DateTime.UtcNow.AddSeconds(-60), card1, 70000, "Jalandhar", "rec2"),
                new Transactions("T003", DateTime.UtcNow.AddSeconds(-30), card1, 80000, "Jalandhar", "rec3"),


                new Transactions("T004", DateTime.UtcNow.AddMinutes(-9), card2, 20000, "Delhi", "rec4"),
                new Transactions("T005", DateTime.UtcNow.AddMinutes(-5), card2, 30000, "Mumbai", "rec5"),


                new Transactions("T006", DateTime.UtcNow.AddMinutes(-30), card1, 40000, "Jalandhar", "rec6"),
                new Transactions("T007", DateTime.UtcNow.AddMinutes(-25), card1, 45000, "Jalandhar", "rec7"),


                new Transactions("T008", DateTime.UtcNow.AddMinutes(-15), card2, 10000, "Delhi", "rec8"),
                new Transactions("T009", DateTime.UtcNow.AddMinutes(-10), card2, 15000, "Delhi", "rec9")
            };

            Dictionary<Card, List<Transactions>> CardFreq = new Dictionary<Card, List<Transactions>>();
            foreach (var item in transactions)
            {
                if (!CardFreq.ContainsKey(item.Card))
                {
                    CardFreq[item.Card] = new List<Transactions>();
                }


                CardFreq[item.Card].Add(item);

            }
            
           



            }    
        }
    }
    
