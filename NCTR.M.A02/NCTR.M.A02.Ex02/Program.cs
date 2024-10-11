using System;
using System.Globalization;

class BirthdayList
{
    static void Main()
    {
        Console.WriteLine("========== Birthday List ==========");

        // Step a) Ask for the number of persons to add
        Console.Write("Enter the number of persons: ");
        int numberOfPersons = int.Parse(Console.ReadLine());

        // Step b) Create an array to store name and birthdate
        string[] personList = new string[numberOfPersons];
        DateTime[] birthDates = new DateTime[numberOfPersons];

        for (int i = 0; i < numberOfPersons; i++)
        {
            string name;
            DateTime birthDate;

            while (true)
            {
                // Ask for name and birth date
                Console.Write($"Enter the name and birthdate of person {i + 1} (format: Name - dd/MM/yyyy or yyyy/MM/dd): ");
                string input = Console.ReadLine();
                string[] parts = input.Split('-');

                if (parts.Length == 2)
                {
                    name = parts[0].Trim();
                    string datePart = parts[1].Trim();

                    // Step c) Validate date format
                    if (DateTime.TryParseExact(datePart, new[] { "dd/MM/yyyy", "yyyy/MM/dd" }, null, DateTimeStyles.None, out birthDate))
                    {
                        personList[i] = name + " - " + birthDate.ToString("dd/MM/yyyy");
                        birthDates[i] = birthDate;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter again.");
                }
            }
        }

        // Step d) Display the list of entered individuals
        Console.WriteLine("========== Birthday List ==========");
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine($"Person {i + 1}: {personList[i]}");
        }

        // Step e) Sort the list by birth dates (closest to furthest)
        SortBirthdayList(personList, birthDates);

        // Step f) Re-display the sorted list
        Console.WriteLine("========== Sorted Birthday List ==========");
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine($"Person {i + 1}: {personList[i]}");
        }
    }

    static void SortBirthdayList(string[] personList, DateTime[] birthDates)
    {
        for (int i = 0; i < birthDates.Length - 1; i++)
        {
            for (int j = 0; j < birthDates.Length - i - 1; j++)
            {
                if (birthDates[j] > birthDates[j + 1])
                {
                    // Swap birth dates
                    DateTime tempDate = birthDates[j];
                    birthDates[j] = birthDates[j + 1];
                    birthDates[j + 1] = tempDate;

                    // Swap corresponding person list entry
                    string tempPerson = personList[j];
                    personList[j] = personList[j + 1];
                    personList[j + 1] = tempPerson;
                }
            }
        }
    }
}
