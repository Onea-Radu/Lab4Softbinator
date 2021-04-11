using Lab4Softbinator.Context;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Lab4Softbinator.Seeders;
using Lab4Softbinator.Services;

namespace Lab4Softbinator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DBContext())
            {
                var seed = new InitialSeeder(db);
                seed.Seed();


                Service.Initialize(db);


                while (true)
                {
                    var input = Console.ReadLine().Split();

                    switch (input[0])
                    {
                        case "add":
                            Service.Add(input[1]);
                            break;
                        case "edit":
                            Service.Edit(input[1]);
                            break;
                        case "afisfac":
                            Service.Show();
                            break;
                        case "del":
                            Service.Delete();
                            break;
                        case "afisnum":
                            Service.ShowSubjects();
                            break;
                        case "afismin":
                            Service.GetMin();
                            break;
                        case "afisnone":
                            Service.ShowIfNone();
                            break;
                        case "stat":
                            Service.ShowStat();
                            break;
                        default:
                            return;



                    }



                }




            }

        }



    }
}
