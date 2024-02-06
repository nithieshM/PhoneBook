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
            Console.WriteLine("Enter the id you want to Update:");
            int id = int.Parse(Console.ReadLine());

            using (var db = new PostgresContext())
            {
                var dbId = db.PhoneBooks.Find(id);

                if(dbId == null)
                {
                    Console.WriteLine("Id not found try again!");
                    UpdateInformation();
                }

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

                dbId.Name = name;
                dbId.Email = email;
                dbId.Phone = phoneNo;

                db.SaveChanges();
            }
        }

        internal static void ViewAllInformation()
        {
            using (var db = new PostgresContext())
            {
                Console.WriteLine("Here is your information: ");

                 var records = db.PhoneBooks.OrderBy(record => record.Id).ToList();

                foreach (var record in db.PhoneBooks)
                {
                    Console.WriteLine($"{record.Id}, {record.Name}, {record.Email}, {record.Phone}");
                }
            }
        }
    }
