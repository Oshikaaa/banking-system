using account_system;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace banking_system
{
    internal class customer_summary
    {
        public void alisha(Info you)
        
        {
            string mero = @"C:\Users\DELL\source\repos\banking system\banking system\oshika.json";
            string ount = System.IO.File.ReadAllText(mero);

            List<Info> list = JsonConvert.DeserializeObject<List<Info>>(ount);

            string jes = @"C:\Users\DELL\source\repos\banking system\banking system\account.json";
            string sie = System.IO.File.ReadAllText(jes);
            List<account> listo = JsonConvert.DeserializeObject<List<account>>(sie);

            

            //List<Info> all = list.Where(a => a.UserType == you.);
            //*/*/**.Where(a => a.Us= you.UserType).ToList();*/*/*/*/
            //foreach (Info info in all) { 
            //}

            //foreach (var item in list) {
            //    if (item.UserType == "customer") {
            //        Console.WriteLine("Username:" + " "  + item.Username);
            //        Console.WriteLine("Address:" + " " + item.Address);
                    
                    

                
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid");
            //    }

                foreach (var rahul in listo)
                {

                    Console.WriteLine("UserId:" + " " + rahul.UserId);
                    if (rahul.Account_type == "Current account")

                    {
                        Console.WriteLine("Interest:" + " " + rahul.Interest_rateorOverdraft_limit);
                        Console.WriteLine("Balance:" + " " + rahul.Balance);
                    }

                    else
                    {
                        Console.WriteLine("Interest:" + " " + rahul.Interest_rateorOverdraft_limit);
                        Console.WriteLine(rahul.Balance);
                    }
                Console.WriteLine(" ");


                }
                
              
            

            //foreach (var item in listo)
            //{
            //    if (item.Account_type == )
            //}
         





        }
    }
}
