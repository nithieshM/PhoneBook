using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Spectre.Console;

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
            while (!Validation.EmailCheck(email))
            {
                Console.WriteLine("Invalid Email entered, try again!");
                email = Console.ReadLine();
            }

            Console.WriteLine("Please Enter your Phone Number:");
            string phoneNo = Console.ReadLine();

             while (!Validation.EmailCheck(phoneNo))
            {
                Console.WriteLine("Invalid Phone Number entered, try again!");
                phoneNo = Console.ReadLine();
            }

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
            Console.WriteLine("Please Enter the id of the record you want to delete!");
            int DeleteId = int.Parse(Console.ReadLine());

            using(var db = new PostgresContext())
            {
                var dbId = db.PhoneBooks.Find(DeleteId);

                Console.WriteLine("Here are the details of the ID you've entered.");
                Console.WriteLine($"{dbId.Id}, {dbId.Name}, {dbId.Email} {dbId.Phone}");

                if(dbId == null)
                {
                    Console.WriteLine("Id not found try again!");
                    UpdateInformation();
                }

                Func<bool> confirm = () =>
                {
                    if (!AnsiConsole.Confirm("[bold red]Are you sure? This action cannot be reversed![/]"))
                    {
                        AnsiConsole.MarkupLine("Confirmed.");
                        return false;
                    }

                    return true;
                };

                if(!confirm())
                {
                    DeleteInformation();
                }

                else
                {
                    db.Remove(dbId);
                    db.SaveChanges();
                }
            }
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
                
                Console.WriteLine("Here are the details of the ID you've entered.");
                Console.WriteLine($"{dbId.Id}, {dbId.Name}, {dbId.Email} {dbId.Phone}");

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
