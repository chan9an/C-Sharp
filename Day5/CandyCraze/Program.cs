using Day5.CandyCraze;

class Program
{
    static void Main(string[] args)
    {
        Candy cObj = new Candy();
        System.Console.WriteLine("Enter The Enter the flavour: ");
        cObj.Flavour = Console.ReadLine();
        System.Console.WriteLine("Enter the quantity: ");
        cObj.Quantity = Int32.Parse(Console.ReadLine());
        System.Console.WriteLine("Enter the price per piece: ");
        cObj.PricePerPiece = Int32.Parse(Console.ReadLine());


        if (cObj.ValidateCandyFlavour(cObj.Flavour))
        {
            int discount = 0;
            switch (cObj.Flavour)
            {
                case "Strawberry":
                    {
                        discount = 15;
                        break;
                    }
                case "Mint":
                    {
                        discount = 5;
                        break;
                    }
                case "Lemon":
                    {
                        discount = 10;
                        break;
                    }

            }
            int TotalPrice = cObj.Quantity * cObj.PricePerPiece;
            double discounted_price = TotalPrice * (discount / 100.0);
            System.Console.WriteLine("Total Price:{0}" ,TotalPrice );
            System.Console.WriteLine("Discounted Price:{0}" ,TotalPrice-discounted_price );

        }
        else
        {
            System.Console.WriteLine("Invalid flavour");
        }
         
    }
}