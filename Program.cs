using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace finalproject
{
   
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            double h = 0;
            while (true)
            {
                Console.WriteLine("Option 1: Sorting Numbers");
                Console.WriteLine("Option 2: Word Counter");
                Console.WriteLine("Option 3: Brackets Cheker");
                Console.WriteLine("Option 4: Symbol Counter");
                Console.WriteLine("Option 5: Calculator");
                Console.WriteLine("Option 6: Triangel Surface area");
                Console.WriteLine("Option 7: Exit");
                Console.WriteLine();
                Console.Write("Select one of the options above: ");
                string command = Console.ReadLine();
                if (command == "1")
                {
                    SortingNumbers();
                }
                else if (command == "2")
                {
                    WordCounter();
                }
                else if (command == "3")
                {
                    Brackets();
                }
                else if (command == "4")
                {
                    SymbolCounter();
                }
                else if (command == "5")
                {
                    ShutingYard();
                }
                else if (command == "6")
                {
                    TriangleSurface();
                }
                else if (command == "7")
                {
                    Console.WriteLine();
                    Console.WriteLine("You exit the program!!!");
                    Console.WriteLine("Goodbye!!!");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please try again, your command is invalid!!!"); Console.WriteLine();
                }
            }
        }
        static void SortNums(List<int> list)
        {
            for (int j = 0; j < list.Count; j++)
            {
                bool flag = false;
                for (int i = 0; i < list.Count - j - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        flag = true;
                        int temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                    }
                }
                if (flag == false)
                {
                    break;
                }
            }
        }
        public static void SortingNumbers()
        {
            int sum = 0;
            double average = 0;
            int max = 0;
            int min = 0;
            int secondSmallest = 0;
            int secondBiggest = 0;
            Console.Write("Your filename: ");
            string fileName = Console.ReadLine();
            List<int> nums = new List<int>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    nums.Add(int.Parse(line));
                }
            }
            SortNums(nums);
            secondSmallest = nums[1];
            secondBiggest = nums[nums.Count - 2];
            sum = nums.Sum();
            average = nums.Average();
            max = nums.Max();
            min = nums.Min();
            using (StreamWriter writer = new StreamWriter("SortNumsResult.txt"))
            {
                foreach (var item in nums)
                {
                    writer.WriteLine(item);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Result:");
            Console.WriteLine();
            Console.WriteLine($"The Sum is: {sum}");
            Console.WriteLine($"The Average is: {average}");
            Console.WriteLine($"The Smallest Number is: {min}"); Console.WriteLine($"The Biggest Number is: {max}");
            Console.WriteLine($"The Second Smallest Number is: {secondSmallest}"); Console.WriteLine($"The Second Biggest Number is: {secondBiggest}"); Console.WriteLine();
        }
        public static void WordCounter()
        {
            Console.Write("Your filename: ");
            string fileName = Console.ReadLine();
            Console.Write("What is the word you are looking for: "); string word = Console.ReadLine();
            Console.WriteLine();
            using (StreamReader reader = new StreamReader(fileName))
            {
                int counter = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    int index = line.IndexOf(word);
                    while (index != -1)
                    {
                        counter++;
                        index = line.IndexOf(word, (index + 1));
                    }
                    line = reader.ReadLine();
                }
                Console.WriteLine("The word " + $"\"{word}\" " + $"occurs in lower case: \"{counter} times\"");
            }
            using (StreamReader reader = new StreamReader(fileName))
            {
                word = word.ToLower();
                int counter = 0;
                string line = reader.ReadLine().ToLower();
                while (line != null)
                {
                    int index = line.IndexOf(word);
                    while (index != -1)
                    {
                        counter++;
                        index = line.IndexOf(word, (index + 1));
                    }
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        line = line.ToLower();
                    }
                }
                Console.WriteLine($"All \"{word}\" occurs: \"{counter} times\"");
                Console.WriteLine();
            }
        }
        public static void Brackets()
        {
            Console.Write("Your filename: ");
            string fileName = Console.ReadLine();
            using (StreamReader reader = new StreamReader(fileName))
            {
                Stack<char> stack = new Stack<char>();
                int lineCounter = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    char[] arr = line.ToCharArray();
                    foreach (var ch in arr)
                    {
                        if (ch == '(' || ch == '{' || ch == '[')
                        {
                            stack.Push(ch);
                        }
                        else if (ch == ')' || ch == '}' || ch == ']')
                        {
                            if (stack.Count == 0)
                            {
                                Console.WriteLine("There's a missing bracket");
                            }
                            else
                            {
                                stack.Pop();
                            }
                        }
                    }
                    lineCounter++;
                }
                if (stack.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("There are no missing brackets"); Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"There's a missing bracket at line: {lineCounter}"); Console.WriteLine();
                }
            }
        }
        public static void SymbolCounter()
        {
            Console.Write("Your filename: ");
            string fileName = Console.ReadLine();
            Dictionary<char, double> symbols = new Dictionary<char, double>(); double counter = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    char[] arr = line.ToCharArray();
                    foreach (var ch in arr)
                    {
                        if (!symbols.ContainsKey(ch) && ch != ' ')
                        {
                            symbols.Add(ch, 0);
                            symbols[ch]++;
                            counter++;
                        }
                        else if (symbols.ContainsKey(ch) && ch != ' ')
                        {
                            symbols[ch]++;
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Result: ");
            Console.WriteLine();
            foreach (var item in symbols)
            {
                Console.WriteLine($"{item.Key} - {(item.Value / counter * 100):f2}%");
            }
            Console.WriteLine();
        }
        public static void ShutingYard()
        {
            Console.Write("Your filename: ");
            string fileName = Console.ReadLine();
            string[] input = File.ReadAllLines(fileName);
            for (int i = 0; i < input.Length; i++)
            {
                int output = Calculation(input[i]);
                input[i] += " = " + output;
            }
            File.WriteAllLines(@"CalculatorResult", input);
        }
        static int Calculation(string a)
        {
            string[] input = a.Split();
            Queue<string> output = new Queue<string>();
            Stack<string> @operator = new Stack<string>();
            for (int i = 0; i < input.Length; i++)
            {
                int temp;
                if (int.TryParse(input[i], out temp))
                {
                    output.Enqueue(input[i]);
                }
                else if (input[i] == "+" || input[i] == "-" || input[i] == "*" || input[i] == "/")
                {
                    while (@operator.Count > 0 && ((@operator.Peek() == "*" || @operator.Peek() == "/") || @operator.Peek() == "-") && @operator.Peek() != "(")
                    {
                        output.Enqueue(@operator.Pop());
                    }
                    @operator.Push(input[i]);
                }
                else if (input[i] == "*" || input[i] == "/")
                {
                    while (@operator.Count > 0 && @operator.Peek() == "/" && @operator.Peek() != "(")
                    {
                        output.Enqueue(@operator.Pop());
                    }
                    @operator.Push(input[i]);
                }
                else if (input[i] == "(")
                {
                    @operator.Push(input[i]);
                }
                else if (input[i] == ")")
                {
                    while (@operator.Peek() != "(")
                    {
                        output.Enqueue(@operator.Pop());
                    }
                    @operator.Pop();
                }
            }
            while (@operator.Count > 0)
            {
                output.Enqueue(@operator.Pop());
            }
            string RPN = "";
            while (output.Count > 1)
            {
                RPN += output.Dequeue() + " ";
            }
            RPN += output.Dequeue();
            int finalOutput = Program.Calculator(RPN); return finalOutput;
        }
        static int Calculator(string read)
        {
            string[] input = read.Split();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                int temp;
                if (int.TryParse(input[i], out temp))
                {
                    stack.Push(temp);
                }
                else
                {
                    if (input[i] == "-")
                    {
                        int minus = stack.Pop(); stack.Push(stack.Pop() - minus);
                    }
                    else if (input[i] == "+")
                    {
                        int plus = stack.Pop(); stack.Push(stack.Pop() + plus);
                    }
                    else if (input[i] == "*")
                    {
                        int times = stack.Pop(); stack.Push(stack.Pop() * times);
                    }
                    else if (input[i] == "/")
                    {
                        int divide = stack.Pop(); stack.Push(stack.Pop() / divide);
                    }
                }
            }
            return stack.Pop();

        }
        private static void TriangleSurface()
        {
            
            Console.WriteLine("Change: a");
            double newA = double.Parse(Console.ReadLine());
            Console.WriteLine("Change: h");
            double newH = double.Parse(Console.ReadLine());
            Triangle TriangleBuilding = new Triangle(5.5, 4);
            TriangleBuilding.ChangeA(newA);
            TriangleBuilding.ChangeH(newH);
            double area = TriangleBuilding.surfaceArea();
            Console.WriteLine(area); 
        }
        class Triangle
        {
            public double a;
            public double h;

            public Triangle(double a, double h)
            {
                this.a = a;
                this.h = h;
            }
            public void ChangeA(double newA)
            {
                this.a = newA;
            }
            public void ChangeH(double newH)
            {
                this.h = newH;
            }
            public double surfaceArea()
            {
                return a * h / 2;
            }
        }
    }
    
}
