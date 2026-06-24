using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResultsProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[3];
            string[] ids = new string[3];
            string[] programmes = new string[3];
            string[] levels = new string[3];

            double[,] scores = new double[3, 5];

            double[] totals = new double[3];
            double[] averages = new double[3];
            string[] grades = new string[3];
            string[] statuses = new string[3];

            string[] courses =
            {
                "Programming with C#",
                "Database Systems",
                "Computer Networks",
                "Web Development",
                "Mathematics for Computing"
            };

            bool resultsEntered = false;
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("===== STUDENT RESULTS PROCESSING SYSTEM =====");
                Console.WriteLine("1. Enter Student Results");
                Console.WriteLine("2. View Student Report");
                Console.WriteLine("3. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter Details For Student " + (i + 1));

                            Console.Write("Enter Full Name: ");
                            names[i] = Console.ReadLine();

                            Console.Write("Enter Student ID: ");
                            ids[i] = Console.ReadLine();

                            Console.Write("Enter Programme: ");
                            programmes[i] = Console.ReadLine();

                            Console.Write("Enter Level: ");
                            levels[i] = Console.ReadLine();

                            double total = 0;

                            for (int j = 0; j < 5; j++)
                            {
                                double score;

                                while (true)
                                {
                                    Console.Write("Enter Score for " + courses[j] + ": ");

                                    if (double.TryParse(Console.ReadLine(), out score))
                                    {
                                        if (score >= 0 && score <= 100)
                                        {
                                            break;
                                        }
                                    }

                                    Console.WriteLine("Invalid score. Score must be between 0 and 100.");
                                }

                                scores[i, j] = score;
                                total += score;
                            }

                            totals[i] = total;
                            averages[i] = total / 5;

                            if (averages[i] >= 80)
                                grades[i] = "A";
                            else if (averages[i] >= 70)
                                grades[i] = "B";
                            else if (averages[i] >= 60)
                                grades[i] = "C";
                            else if (averages[i] >= 50)
                                grades[i] = "D";
                            else
                                grades[i] = "F";

                            if (averages[i] >= 50)
                                statuses[i] = "Passed";
                            else
                                statuses[i] = "Failed";
                        }

                        resultsEntered = true;

                        Console.WriteLine();
                        Console.WriteLine("Student results entered successfully.");
                        break;

                    case "2":

                        if (!resultsEntered)
                        {
                            Console.WriteLine("Please enter student results first.");
                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("===== STUDENT RESULTS REPORT =====");

                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine();
                            Console.WriteLine("-------------------------------------");

                            Console.WriteLine("Student Name: " + names[i]);
                            Console.WriteLine("Student ID: " + ids[i]);
                            Console.WriteLine("Programme: " + programmes[i]);
                            Console.WriteLine("Level: " + levels[i]);

                            Console.WriteLine();
                            Console.WriteLine("Programming with C#: " + scores[i, 0]);
                            Console.WriteLine("Database Systems: " + scores[i, 1]);
                            Console.WriteLine("Computer Networks: " + scores[i, 2]);
                            Console.WriteLine("Web Development: " + scores[i, 3]);
                            Console.WriteLine("Mathematics for Computing: " + scores[i, 4]);

                            Console.WriteLine();
                            Console.WriteLine("Total Score: " + totals[i]);
                            Console.WriteLine("Average Score: " + averages[i].ToString("F2"));
                            Console.WriteLine("Grade: " + grades[i]);
                            Console.WriteLine("Status: " + statuses[i]);
                        }

                        Console.WriteLine("-------------------------------------");
                        break;

                    case "3":

                        Console.WriteLine();
                        Console.WriteLine("Thank you for using the Student Results Processing System.");
                        running = false;
                        break;

                    default:

                        Console.WriteLine("Invalid option. Please choose 1, 2 or 3.");
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}