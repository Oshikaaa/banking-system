
using account_system;
using Newtonsoft.Json;
using System;
using System.ComponentModel.Design;
using System.Security.Principal;
using System.Text;

namespace banking_system
{
    class Program
    {
        static void Main(string[] args)
        {
            //string file = @"C:\Users\DELL\source\repos\banking system\banking system\ad.json";
            //string ile =File.ReadAllText(file);
            //List<admin> user= JsonConvert.DeserializeObject<List<admin>>(ile);
            //admin authenticatedadmin = new admin();

            string filepath = @"C:\Users\DELL\source\repos\banking system\banking system\oshika.json";
            string read = File.ReadAllText(filepath);
            //var Info = JsonConvert.DeserializeObject<List<Info>>(read);


            string path = @"C:\Users\DELL\source\repos\banking system\banking system\account.json";
            string oshika = File.ReadAllText(path);

            List<Info> users = JsonConvert.DeserializeObject<List<Info>>(read);

            Info authenticateduser = new Info();

            //List<account> type = JsonConvert.DeserializeObject<List<account>>(oshika);
            //account authenticatedtype = new account();

            while (true)
            {
                Console.WriteLine("Enter Username");
                string username = Console.ReadLine();
                Console.WriteLine("Enter Password");
                string password = Console.ReadLine();

                bool isauthenticated = false;
                foreach (var items in users)
                {

                    if (items.Username == username && items.Password == password)
                    {
                        Console.WriteLine(items.Username + " is logged in");
                        isauthenticated = true;
                        authenticateduser = items;
                        break;

                    }

                }

                if (isauthenticated == false)
                {
                    Console.WriteLine("Invalid Username or Password");
                    continue;
                }
                break;
            }
           
            if (authenticateduser.UserType == "customer")
            {
                Console.WriteLine("Please select an option" + "\n" + "1-View Account" + "\n" + "2-View Summary" + "\n" + "3-Quit" + "\n" + "Enter a number to select your option");
                //int user = Console.ReadLine();






                int intTemp = Convert.ToInt32(Console.ReadLine());



                switch (intTemp)
                {
                    case 1:
                        viewaccount va = new viewaccount();
                        va.ShowAccounts(authenticateduser);
                        break;

                    case 2:
                        viewsummary vi = new viewsummary();
                        vi.Showsummary(authenticateduser);
                        break;

                    case 3:
                        Console.WriteLine("Quit");
                        break;

                    default:
                        Console.WriteLine("choose any one");
                        break;
                }


                
            }
            if (authenticateduser.UserType == "admin")
            {
                Console.WriteLine("Please select an option: \n" + "1- Customer Summary \n" + "2- Financial Forecast \n" + "3- Transfer Money\n" + "4- Account Management");
                //int option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter a number to select: ");
                int more = Convert.ToInt32(Console.ReadLine());


                switch (more)
                {
                    case 1:
                        customer_summary cus = new customer_summary();
                        cus.alisha(authenticateduser);
                         
                        


                            break;
                    case 2:
                        Financial fin = new Financial();
                        fin.forecast(authenticateduser);
                        break;

                    case 3:
                        Console.WriteLine("Transfer Money");
                        break;
                    default:
                        Console.WriteLine("Choose any one:");
                        break;
                }
            }
           


        }

        //private static int List<T>(string jsonaccount)
        //{
        //    throw new NotImplementedException();
        //}



    }

}
                


    
        
    
         



     



