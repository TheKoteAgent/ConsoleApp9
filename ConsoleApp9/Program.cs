using System;
using System.Collections.Generic;
using System.Data;

class Program
{
    // Завдання 1: Калькулятор для конвертації чисел між системами числення
    public static string ConvertNumber(int number, int baseFrom, int baseTo)
    {
        try
        {
            int decimalNumber = Convert.ToInt32(number.ToString(), baseFrom);
            return Convert.ToString(decimalNumber, baseTo);
        }
        catch (FormatException)
        {
            return "Invalid input. Please enter a valid number.";
        }
        catch (OverflowException)
        {
            return "Number out of range. Please enter a valid number within the range of int.";
        }
    }

    // Завдання 2: Переведення слова у цифру
    public static int ConvertWordToDigit(string word)
    {
        Dictionary<string, int> wordToDigit = new Dictionary<string, int>
        {
            {"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4},
            {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
        };

        if (wordToDigit.ContainsKey(word))
        {
            return wordToDigit[word];
        }
        else
        {
            throw new ArgumentException("Invalid input. Please enter a valid word representing a digit.");
        }
    }

    // Завдання 3: Клас "Закордонний паспорт"
    public class Passport
    {
        private string passportNumber;
        private string fullName;
        private DateTime issueDate;

        public Passport(string passportNumber, string fullName, DateTime issueDate)
        {
            if (string.IsNullOrWhiteSpace(passportNumber))
            {
                throw new ArgumentException("Passport number cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be empty.");
            }

            if (issueDate == DateTime.MinValue)
            {
                throw new ArgumentException("Issue date cannot be empty.");
            }

            this.passportNumber = passportNumber;
            this.fullName = fullName;
            this.issueDate = issueDate;
        }
    }

    // Завдання 4: Обчислення логічного виразу
    public static bool CalculateExpression(string expression)
    {
        try
        {
            return Convert.ToBoolean(new System.Data.DataTable().Compute(expression, ""));
        }
        catch (SyntaxErrorException)
        {
            throw new FormatException("Invalid expression. Please enter a valid logical expression.");
        }
        catch (Exception)
        {
            throw new Exception("An error occurred while processing the expression.");
        }
    }

    static void Main()
    {
        // Приклади використання
        Console.WriteLine("Task 1: Number conversion");
        Console.WriteLine(ConvertNumber(123, 10, 2));
        Console.WriteLine();

        Console.WriteLine("Task 2: Word to digit conversion");
        try
        {
            Console.WriteLine(ConvertWordToDigit("three")); 
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine();

        Console.WriteLine("Task 3: Passport class");
        try
        {
            Passport passport = new Passport("AB123456", "John Doe", new DateTime(2024, 3, 16));
            Console.WriteLine("Passport created successfully.");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        Console.WriteLine();

        Console.WriteLine("Task 4: Logical expression evaluation");
        try
        {
            Console.WriteLine(CalculateExpression("3>2")); 
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        catch (Exception)
        {
            Console.WriteLine("An unexpected error occurred.");
        }
    }
}
