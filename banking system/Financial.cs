using account_system;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace banking_system
{
    internal class Financial{
        public void forecast(Info us) {
            string oath = @"C:\Users\DELL\source\repos\banking system\banking system\oshika.json";
            string purse = System.IO.File.ReadAllText(oath);

            List<Info> listoa = JsonConvert.DeserializeObject<List<Info>>(purse);

            string duo = @"C:\Users\DELL\source\repos\banking system\banking system\account.json";
            String dip = System.IO.File.ReadAllText(duo);
            List<account> nice = JsonConvert.DeserializeObject<List<account>>(dip);

            int accountcount = 0;


            foreach (var item in listoa)

            {
                

                
                if (item.UserType == "customer")
                {
                    Console.WriteLine("Username:"+ " " + item.Username);

                    accountcount++;
                    Console.WriteLine("Account no:" + nice.Where(e => e.UserId == item.UserId).Count());
                    List<account> usersaccount=nice.Where(e=>e.UserId== item.UserId).ToList();

                    decimal plus = 0;
                    decimal balanceafterayear=0;
                    decimal totalbalanceafterayear=0;
                    

                    foreach (var sim in usersaccount)
                    {
                        if (sim.UserId == item.UserId)
                        {
                            plus += sim.Balance;

                        }

                        //double princamt, rate, interest, total_amt;
                        //Console.Write("Enter The Loan Amount : ");
                        //princamt = Convert.ToDouble(Console.ReadLine());
                        //Console.Write("Enter The Number of Years : ");
                        //year = Convert.ToInt16(Console.ReadLine());
                        //Console.Write("Enter the Rate Of Interest : ");
                        //rate = Convert.ToDouble(Console.ReadLine());
                        //interest = princamt * year * rate / 100;
                        //Console.ReadLine();
                        if (sim.Account_type == "Saving account")
                        {
                            balanceafterayear = sim.Balance + (sim.Balance * 1 * sim.Interest_rateorOverdraft_limit)/100;
                        }
                        else
                        {
                            balanceafterayear = sim.Balance;
                        }

                        totalbalanceafterayear = balanceafterayear + totalbalanceafterayear;
                        

                    }
                    Console.WriteLine("Total Balance: "+plus);
                    Console.WriteLine("Balance after a year: "+totalbalanceafterayear);


                    

                    
                    


                }
                Console.WriteLine(" ");
                //Console.WriteLine(plus);







            }
            

            //List<account> nun = nice.Where(h => h.UserId == us.UserId).ToList();
            //Console.WriteLine(nice.Count);



           

        }

    }
}