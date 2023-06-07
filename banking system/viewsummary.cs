using account_system;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace banking_system
{
    internal class viewsummary
    {
        public void Showsummary (Info sum )
        {
            string path = @"C:\\Users\\DELL\\source\\repos\\banking system\\banking system\\account.json";
            string acc = System.IO.File.ReadAllText (path);

            List<account> listofall = JsonConvert.DeserializeObject<List<account>>(acc);

            List<account> accounts= listofall.Where(e=>e.UserId == sum.UserId).ToList();

            Console.WriteLine(accounts.Count);

            Console.WriteLine(sum.Address);
            decimal add=0;
            foreach(var items in accounts) {
                add = add + items.Balance;
            

                
           

            }
            Console.WriteLine(add);

        }

        //public void Showbalance (Info bal ) 
        
        //{
        //    string flow = @"C:\Users\DELL\source\repos\banking system\banking system\account.cs";
        //    string count = System.IO.File.ReadAllText (flow);
        //    List<Bala> listall = JsonConvert.DeserializeObject<List<account>>(count);
        //    List<account> counts = listall.Where(e)




        //}
        

    }
}
