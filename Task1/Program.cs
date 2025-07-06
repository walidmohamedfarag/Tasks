namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int costPerSmall = 25;
            int costPerLarge = 35;
            double taxRate = 0.06;
            Console.WriteLine("Estimate for carpet cleaning service");

            Console.Write("enter the number of small carpet: ");
            int smallCarpet = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter the number of large carpet: ");
            int largeCarpet = Convert.ToInt32(Console.ReadLine());

            double totalCostPerSmall = costPerSmall * smallCarpet;
            double totalCostPerLarge = costPerLarge * largeCarpet;
            Console.WriteLine($"price per small carpet: {totalCostPerSmall:C}");
            Console.WriteLine($"price per large carpet: {totalCostPerLarge:C}");

            double totaEstimate = totalCostPerSmall + totalCostPerLarge;
            Console.WriteLine($"cost: {totaEstimate:C}");

            double tax = taxRate * (totalCostPerSmall + totalCostPerLarge);
            Console.WriteLine($"tax: {tax:C}");

            Console.WriteLine($"total estimate: {totaEstimate + tax :c}\n this estimate is valid for 30 days");
        }
    }
}

