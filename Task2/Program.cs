namespace Task2
{
    internal class Program
    {
       
            static void PrintList(List<int> numbers)
            {
                if(numbers.Count == 0)
                Console.WriteLine("the list is empty");
                for (int index = 0; index < numbers.Count; index++)
                    Console.WriteLine(numbers[index]);
            }
            static void AddNumber(List<int> numbers)
            {
                Console.Write("enter number to add the list: ");
                int numberToAdd = Convert.ToInt32(Console.ReadLine());
                //this not allowed the duplicate
                for(int index = 0; index < numbers.Count; index++)
                {
                if (numbers[index] == numberToAdd)
                    return;
                }
                //anthoer soluation use built in method (contain())
                numbers.Add(numberToAdd);
            Console.WriteLine($"the number ({numberToAdd}) is added\n\t=====================");
            }
            static int Avarage(List<int> numbers)
            {
                if (numbers.Count == 0) return 0;
                int sum = 0;
                for (int index = 0; index < numbers.Count; index++)
                    sum += numbers[index];
                return sum / numbers.Count;
            }
            static int SmallestNumber(List<int> numbers)
            {
                if (numbers.Count == 0) return 0;
                int smallNumber = numbers[0];
                for (int index = 0; index < numbers.Count; index++)
                {
                    if (numbers[index] < smallNumber)
                        smallNumber = numbers[index];
                }
                return smallNumber;
            }
            static int LargestNumber(List<int> numbers)
            {
                if (numbers.Count == 0) return 0;
                int LargeNumber = numbers[0];
                for (int index = 0; index < numbers.Count; index++)
                {
                    if (numbers[index] > LargeNumber)
                        LargeNumber = numbers[index];
                }
                return LargeNumber;
            }
            static int FindNumber(List<int> numbers)
            {
            Console.Write("enter the number you want search: ");
            int searchNumber = Convert.ToInt32(Console.ReadLine());
            for (int index = 0; index < numbers.Count; index++)
                {
                    if (numbers[index] == searchNumber)
                        return index;
                }
                return 0;
            }
        static void _Clear(List<int> numbers)//this methode is build me to clear the element
        {
            if(numbers.Count == 0) return;
            for(int index = 0; index < numbers.Count; index++)
                numbers.RemoveAt(index);
        }
        static void OperationInList(List<int> numbers)
        {
            string quit = string.Empty;
            do
            {
                Console.WriteLine("\t\tp: print\t\ta: add\n\t\tm: avarage\t\ts: smallest number\n\t\tl: largest number\tf: find number\n\t\tc: clear\t\tq: quit");
                Console.Write("chioce the operation: ");
                char operation = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("\t=====================");
                switch (operation.ToString().ToLower())
                {
                    case "p":
                        PrintList(numbers);
                        break;
                    case "a":
                        AddNumber(numbers);
                        break;
                    case "m":
                        Console.WriteLine($"the avarage: {Avarage(numbers)}\n\t=====================");
                        break;
                    case "s":
                        Console.WriteLine($"the smallest number: {SmallestNumber(numbers)}\n\t=====================");
                        break;
                    case "l":
                        Console.WriteLine($"the largest number: {LargestNumber(numbers)}\n\t=====================");
                        break;
                    case "f":
                        {
                            int findNumber = FindNumber(numbers);
                            if (findNumber > 0)
                                Console.WriteLine($"the index of number: {findNumber}\n\t=====================");
                            else Console.WriteLine("the number not found");
                            break;
                        }
                    case "c":
                        _Clear(numbers);
                        break;
                    case "q":
                        quit = operation.ToString();
                        break;
                    default:
                        Console.WriteLine("invalid operation!!!\n\t=====================");
                        break;
                }

            } while (quit.ToLower() != "q");
        }
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { };
            OperationInList(numbers);
        }
    }
}
