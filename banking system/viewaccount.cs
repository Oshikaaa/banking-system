using account_system;
using Newtonsoft.Json;
using System.Reflection.Metadata;

namespace banking_system
{
    internal class viewaccount
    {
        public void ShowAccounts(Info user)



        {
            string accountfilepath = @"C:\Users\DELL\source\repos\banking system\banking system\account.json";
            string jsonaccount = System.IO.File.ReadAllText(accountfilepath);

            List<account> listofallaccount = JsonConvert.DeserializeObject<List<account>>(jsonaccount);

            List<account> loginuseraccount = listofallaccount.Where(g=>g.UserId==user.UserId).ToList();




            //string accountfile = @"C:\Users\DELL\source\repos\banking system\banking system\oshika.json";
            //string jasonuser = System.IO.File.ReadAllText(accountfile);

            //List<Info> listofalluser = JsonConvert.DeserializeObject<List<Info>>(jasonuser);


            //Info userName = listofalluser.Where(a => a.Username == user.Username).SingleOrDefault();
            //Console.WriteLine(userName.Username);


            foreach(var todelete in  loginuseraccount)
            {
                listofallaccount.Remove(todelete);
            }

             
            Console.WriteLine("Account List-----");
            int total_count = 1;

            foreach (var item in loginuseraccount)
            {


                Console.WriteLine(total_count.ToString() + " " + item.Account_type.ToString() + ": " + item.Balance.ToString());
                total_count = total_count + 1;
                //Console.WriteLine("Enter a number to select your option: ");

              
            }

            Console.WriteLine("Enter a number: ");
            //string number = Console.ReadLine();
            int selected = Convert.ToInt32(Console.ReadLine());

            account selectedaccount = loginuseraccount[selected - 1];
            transaction(selectedaccount,user);

            loginuseraccount[selected - 1] = selectedaccount;
            

            listofallaccount.AddRange(loginuseraccount);
            WriteAccount(listofallaccount);




        }
  



        public void WriteAccount(List<account> accounts)
        {

            string accountfilepath = @"C:\Users\DELL\source\repos\banking system\banking system\account.json";
            string deser=JsonConvert.SerializeObject(accounts);
            File.WriteAllText(accountfilepath, deser);
        }
        //int select_option = Convert.ToInt32(Console.ReadLine());


        //if (select_option == 1)
        //{ Console.WriteLine("");
        //}

        public void transaction(account selectedaccount, Info user)
        {
            Console.WriteLine("You selected" + " " + selectedaccount.Account_type + " " + selectedaccount.Balance.ToString());
            Console.WriteLine("Please select an option: \n" + "1- Deposit \n" + "2- Withdraw\n" + "3- Go back");
            Console.WriteLine("Enter a number to select your option:");
            //string name = Console.ReadLine();

            int deposit = Convert.ToInt16(Console.ReadLine());
            switch (deposit)
            {
                case 1: 
                    Console.WriteLine("Enter a number to deposit: ");
                    int balance = Convert.ToInt16(Console.ReadLine());
                    selectedaccount.Balance = balance + selectedaccount.Balance ;
                    Console.WriteLine("Your total balance is"+ " " + selectedaccount.Balance);
                    


                    break;
                
                case 2:
                    withdraw(selectedaccount);
                    

                    break;

                case 3:
                    ShowAccounts(user);
                    break;
                     
                default:
                        Console.WriteLine("choose any one: ");
                    break;

            }

        }
        public void withdraw(account withdrawl)

        {
           
            Console.WriteLine("Enter a number to withdraw: ");
            int Input_Balance = Convert.ToInt16(Console.ReadLine());
           


            //if (withdrawl.Account_type == "Saving account")
            //{
                
            //    withdrawl.Balance -= Input_Balance;
               
            //}
            //else
            //{
            //    if(Input_Balance <= withdrawl.Balance)
            //    {
            //        withdrawl.Balance -= Input_Balance;
            //    }
            //    else
            //    {
            //        decimal bal = Input_Balance - withdrawl.Balance;
            //        withdrawl.Balance = 0;
            //        withdrawl.Interest_rateorOverdraft_limit = withdrawl.Interest_rateorOverdraft_limit - bal;
            //    }
            //}

            //return true;
            ////else
            //{
            //   Console.WriteLine("Insufficient Balance");  
            //}
            //Console.WriteLine("Your balance is" +" " +  withdrawl.Balance.ToString());

            if (withdrawl.Account_type == "Saving Account")
            {
                if (withdrawl.Balance >= Input_Balance)
                {
                    decimal newbalance = withdrawl.Balance - Input_Balance;
                    Console.WriteLine("Your balance is" + " " +  newbalance);
                }
                else
                {
                    Console.WriteLine("You have insufficient balance in your account");
                }
            }

            else
            {
                decimal withdrawableaboutn = withdrawl.Balance + withdrawl.Interest_rateorOverdraft_limit;
                if(withdrawableaboutn >= Input_Balance)
                {
                    if(withdrawl.Balance >= Input_Balance)
                    {
                        withdrawl.Balance=withdrawl.Balance - Input_Balance;
                        Console.WriteLine("Your balance is" + " " + withdrawl.Balance);
                    }
                    else
                    {

                        withdrawl.Interest_rateorOverdraft_limit=Input_Balance-withdrawl.Balance;
                        withdrawl.Balance = 0;
                        Console.WriteLine("Your balance is" + " " + withdrawl.Balance);

                    }
                }

                else
                {
                    Console.WriteLine("You have insufficient balance");
                }
               
              
            }
        }












    }
}
