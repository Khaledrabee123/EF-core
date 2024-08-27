using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Net;
using System.Reflection.Emit;
using System.Transactions;
using static EF____CORE.CRUD;
namespace EF____CORE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string c;
        do
            {
                Console.WriteLine("1 ->  add    ");
                Console.WriteLine("2 ->  update  ");
                Console.WriteLine("3 ->  delete   ");
                int ch = Convert.ToInt32(Console.ReadLine());
                if (ch==1)
                {
                    add();
                }else if (ch == 2)
                {
                    update(); 
                }else if (ch == 3)
                {
                    delete();

                }
                else
                {
                    Console.WriteLine("invilid number");
                }


                Console.WriteLine("do you want any oppration  y/n");
                 c =Console.ReadLine();   





            } while (c=="y");








         











        }

       




    }
    
}
