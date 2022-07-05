using AvailityInsurance.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AvailityInsurance
{
    class Program
    {
        private static object newEnrollee;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //Creating a file path that can locate the CVS file to be used.
            string filePath = @"C:\Users\12106\Downloads\archive\insurance.csv";
            string insurancefilePath = @"C:\Users\12106\Downloads\archive\SortedByInsurance.txt";

            //A program that will read the contents of the CSV file by using the path defined.
            File.ReadAllLines(filePath);


            //Seperating each line in the fie and display the output on the console.
            List<Enrollee> Enrollee = new List<Enrollee>();

            foreach (var enrollee in Enrollee)
            {
                Console.WriteLine(Enrollee);
            }

            //Adding new Enrollees by their respective fields to the database.
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                var newEnrollee = new Enrollee();

                newEnrollee.UserId = entries[0];

                newEnrollee.FirstName = entries[1];
                newEnrollee.LastName = entries[2];

                int value;
                if (Int32.TryParse(entries[3], out value))
                {
                    newEnrollee.Version = int.Parse(entries[3]);

                }
                newEnrollee.InsuranceCompany = entries[4];

                Enrollee.Add((Enrollee)newEnrollee);

            }

            //Adding a new enrollee to the list of enrollees with titles and their values.
            Enrollee.Add(new Enrollee { UserId = "1", LastName = "Somer", FirstName = "Ray", Version = 2, InsuranceCompany = "NormalRate"});


            //Sorting the contents of each file by last and first name in ascending order.
            foreach (var newEnrollee in Enrollee)
            {
                Console.WriteLine($"{ newEnrollee.UserId }, { newEnrollee.LastName }, { newEnrollee.FirstName }: { newEnrollee.Version }, { newEnrollee.InsuranceCompany }");
            }
            Console.ReadLine();


            //Grouping the enrollees by insurance company in its own file.
            List<string> output = new List<string>();

            Console.WriteLine("Grouping the enrollees by Insaurance Comanies in its own file");

            foreach (var newEnrollee in Enrollee)
            {
                output.Add($"{newEnrollee.InsuranceCompany}, {newEnrollee.UserId},  {newEnrollee.FirstName}, { newEnrollee.LastName}, {newEnrollee.Version}");
            }
            File.WriteAllLines(insurancefilePath, output);

        }
    }
}
