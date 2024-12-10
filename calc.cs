using System;

class Calculator
{
    static void Main()
    {
        Console.WriteLine("Basic Arithmetic Calculator");
        Console.WriteLine("---------------------------");
        Console.WriteLine("Choose an operation:");
        Console.WriteLine("1. Addition (+)");
        Console.WriteLine("2. Subtraction (-)");
        Console.WriteLine("3. Multiplication (*)");
        Console.WriteLine("4. Division (/)");
        Console.Write("Enter your choice (1-4): ");
        
        int choice;
        bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);

        if (!isValidChoice || choice < 1 || choice > 4)
        {
            Console.WriteLine("Invalid choice. Please restart the program and select a valid option.");
            return;
        }

        Console.Write("Enter the first number: ");
        double num1;
        bool isValidNum1 = double.TryParse(Console.ReadLine(), out num1);

        Console.Write("Enter the second number: ");
        double num2;
        bool isValidNum2 = double.TryParse(Console.ReadLine(), out num2);

        if (!isValidNum1 || !isValidNum2)
        {
            Console.WriteLine("Invalid input. Please restart the program and enter valid numbers.");
            return;
        }

        double result = 0;

        switch (choice)
        {
            case 1:
                result = num1 + num2;
                Console.WriteLine($"Result: {num1} + {num2} = {result}");
                break;
            case 2:
                result = num1 - num2;
                Console.WriteLine($"Result: {num1} - {num2} = {result}");
                break;
            case 3:
                result = num1 * num2;
                Console.WriteLine($"Result: {num1} * {num2} = {result}");
                break;
            case 4:
                if (num2 == 0)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                }
                else
                {
                    result = num1 / num2;
                    Console.WriteLine($"Result: {num1} / {num2} = {result}");
                }
                break;
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
