using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PhoneBook;

    internal class Controller
    {
        internal static void AddInformation()
        {
            Console.WriteLine("Please Enter your name: ");
            string name = Console.ReadLine();

            while (!Validation.NameCheck(name))
            {
                Console.WriteLine("Invalid Name entered, try again!");
                name = Console.ReadLine();
            }

            Console.WriteLine("Please Enter your Email ID:");
            string email = Console.ReadLine();

            Console.WriteLine("Please Enter your Phone Number:");
            string phoneNo = Console.ReadLine();

            using (var db = new PostgresContext())
            {
                var records = new Models.PhoneBook();
                records.Name = name;
                records.Email = email;
                records.Phone = phoneNo;
                db.PhoneBooks.Add(records);
                var count = db.SaveChanges();
            }
        }

        internal static void DeleteInformation()
        {
            // Your code for deleting information goes here
        }

        internal static void UpdateInformation()
        {
            // Your code for updating information goes here
        }

        internal static void ViewAllInformation()
        {
            using (var db = new PostgresContext())
            {
                Console.WriteLine("Here is your information: ");

                foreach (var record in db.PhoneBooks)
                {
                    Console.WriteLine($"{record.Id}, {record.Name}, {record.Email}, {record.Phone}");
                }
            }
        }
    }
