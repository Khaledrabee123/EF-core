using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF____CORE
{
    public class CRUD
    {

        public static void read()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.; Initial Catalog =pubs;Integrated security = true";
            SqlCommand command = new SqlCommand("select * from authors", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["au_id"]} +  {reader["au_fname"]}");
            }
            conn.Close();
        }
        public static void delete()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.; Initial Catalog =pubs;Integrated security = true";
            SqlCommand command;
            Console.WriteLine("delete user name ");

            command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DeleteAuthorById";
            command.Parameters.Add("@AuthorID", SqlDbType.NVarChar, 11);

            Console.WriteLine("enter id ");
            string id = Console.ReadLine();


            conn.Open();



            command.Parameters["@AuthorID"].Value = id;


            command.ExecuteNonQuery();
            conn.Close();

        }
        public static void update()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.; Initial Catalog =pubs;Integrated security = true";
            SqlCommand command;
            Console.WriteLine("UPDate user name ");

            command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AlterAuthorName";
            command.Parameters.Add("@NewAuthorLName", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@NewAuthorFName", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@AuthorID", SqlDbType.NVarChar, 11);



            Console.WriteLine("enter id and fname and lastname");
            string id = Console.ReadLine();
            string fname = Console.ReadLine();
            string lname = Console.ReadLine();


            conn.Open();


            // VALUES(@AuthorID, @FirstName, @LastName, @PhoneNumber, @Address, @City, @State, @ZipCode, @contract);


            command.Parameters["@NewAuthorLName"].Value = lname;

            command.Parameters["@NewAuthorFName"].Value = fname;

            command.Parameters["@AuthorID"].Value = id;



            int r = command.ExecuteNonQuery();
            conn.Close();

        }
        public static void add()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.; Initial Catalog =pubs;Integrated security = true";
            SqlCommand command;
            Console.WriteLine("add user  ");

            command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AddNewAuthor";

            // VALUES(@AuthorID, @FirstName, @LastName, @PhoneNumber, @Address, @City, @State, @ZipCode, @contract);
            command.Parameters.Add("@AuthorID", SqlDbType.NVarChar, 11);
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, 40);
            command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 12);
            command.Parameters.Add("@Address", SqlDbType.Char, 40);
            command.Parameters.Add("@City", SqlDbType.Char, 20);
            command.Parameters.Add("@State", SqlDbType.Char, 2);
            command.Parameters.Add("@ZipCode", SqlDbType.Char, 5);
            command.Parameters.Add("@contract", SqlDbType.Bit);


            Console.WriteLine("enter id and fname and lastname and phonenumber");
            string id = Console.ReadLine();
            string fname = Console.ReadLine();
            string lname = Console.ReadLine();
            string phone = Console.ReadLine();
            conn.Open();


            command.Parameters["@AuthorID"].Value = id;
            command.Parameters["@FirstName"].Value = fname;
            command.Parameters["@LastName"].Value = lname;
            command.Parameters["@PhoneNumber"].Value = phone;
            command.Parameters["@Address"].Value = null;
            command.Parameters["@City"].Value = null;
            command.Parameters["@State"].Value = null;
            command.Parameters["@ZipCode"].Value = null;
            command.Parameters["@contract"].Value = 1;

            int r = command.ExecuteNonQuery();
            conn.Close();

        }



    }
}
