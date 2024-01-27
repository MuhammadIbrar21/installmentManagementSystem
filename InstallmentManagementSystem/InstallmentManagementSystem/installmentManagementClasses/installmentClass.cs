using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentManagementSystem.installmentManagementClasses
{
    class installmentClass
    {
        //Getter Setter Properties
        //Acts as Data Carrier in Our Application
        public int AccountNo { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string OfficialAddress { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int TotalAmount { get; set; }
        public int Advance { get; set; }
        public string G1Name { get; set; }
        public string G1Address { get; set; }
        public string G1PhoneNo { get; set; }
        public string G2Name { get; set; }
        public string G2Address { get; set; }
        public string G2PhoneNo { get; set; }

        static string connectionString = ConfigurationManager.ConnectionStrings["InstallmentManagementSystemDB"].ConnectionString;

        //Selecting Data from Database
        public DataTable Select()
        {
            //Step 1: Database connection
            SqlConnection con = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            try
            {
                //Step 2: Writing SQL Query

                string sql = "SELECT * FROM tbl_customer";

                //Creating cmd using sql and con

                SqlCommand cmd = new SqlCommand(sql, con);

                //creating SQL DataAdapter using cmd

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        //Inserting Data into Database

        public bool Insert(installmentClass c)
        {
            //Creating a default return type and setting its value to false
            bool isSuccess = false;

            //Step 1: Connect Database
            SqlConnection con = new SqlConnection(connectionString);
            try 
            {
                //Step 2: Create a SQL Query to insert Data
                string sql = "INSERT INTO tbl_customer (CustomerName, FatherName, ContactNo, Address, OfficialAddress, BrandName, ModelName, TotalAmount, Advance, G1Name, G1Address, G1PhoneNo, G2Name, G2Address, G2PhoneNo) VALUES (@CustomerName, @FatherName, @ContactNo, @Address, @OfficialAddress, @BrandName, @ModelName, @TotalAmount, @Advance, @G1Name, @G1Address, @G1PhoneNo, @G2Name, @G2Address, @G2PhoneNo)";
                //Creating SQL Command using sql and con
                SqlCommand cmd = new SqlCommand(sql, con);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@CustomerName", c.CustomerName);
                cmd.Parameters.AddWithValue("@FatherName", c.FatherName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@OfficialAddress", c.OfficialAddress);
                cmd.Parameters.AddWithValue("@BrandName", c.BrandName);
                cmd.Parameters.AddWithValue("@ModelName", c.ModelName);
                cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToInt32(c.TotalAmount));
                cmd.Parameters.AddWithValue("@Advance", Convert.ToInt32(c.Advance));
                cmd.Parameters.AddWithValue("@G1Name", c.G1Name);
                cmd.Parameters.AddWithValue("@G1Address", c.G1Address);
                cmd.Parameters.AddWithValue("@G1PhoneNo", c.G1PhoneNo);
                cmd.Parameters.AddWithValue("@G2Name", c.G2Name);
                cmd.Parameters.AddWithValue("@G2Address", c.G2Address);
                cmd.Parameters.AddWithValue("@G2PhoneNo", c.G2PhoneNo);

                //Connection Open Here
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query runs successfully then the value of rows will be greater than zero else its value will be 0
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }

        //Method to Update data in database from our application

        public bool Update(installmentClass c)
        {
            //Create a default return type and set its default value to false

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                //SQL to Update Data in our database
                string sql = "UPDATE tbl_customer SET CustomerName=@CustomerName, FatherName=@FatherName, ContactNo=@ContactNo, Address=@Address, OfficialAddress=@OfficialAddress, BrandName=@BrandName, ModelName=@ModelName, TotalAmount=@TotalAmount, Advance=@Advance, G1Name=@G1Name, G1Address=@G1Address, G1PhoneNo=@G1PhoneNo, G2Name=@G2Name, G2Address=@G2Address, G2PhoneNo=@G2PhoneNo WHERE AccountNo=@AccountNo";

                //Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, con);
                //Create Parameters to Add value
                cmd.Parameters.AddWithValue("@CustomerName", c.CustomerName);
                cmd.Parameters.AddWithValue("@FatherName", c.FatherName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@OfficialAddress", c.OfficialAddress);
                cmd.Parameters.AddWithValue("@BrandName", c.BrandName);
                cmd.Parameters.AddWithValue("@ModelName", c.ModelName);
                cmd.Parameters.AddWithValue("@TotalAmount", c.TotalAmount);
                cmd.Parameters.AddWithValue("@Advance", c.Advance);
                cmd.Parameters.AddWithValue("@G1Name", c.G1Name);
                cmd.Parameters.AddWithValue("@G1Address", c.G1Address);
                cmd.Parameters.AddWithValue("@G1PhoneNo", c.G1PhoneNo);
                cmd.Parameters.AddWithValue("@G2Name", c.G2Name);
                cmd.Parameters.AddWithValue("@G2Address", c.G2Address);
                cmd.Parameters.AddWithValue("@G2PhoneNo", c.G2PhoneNo);
                cmd.Parameters.AddWithValue("AccountNo", c.AccountNo);
                //Open Database connection
                con.Open();

                int rows = cmd.ExecuteNonQuery();
                //If the query run successfully then the value of rows will be greater than zero else its value will be zero
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }

        //Method to Delete Data from Database
        public bool Delete(installmentClass c)
        {
            //Create a default return value and set its value to false
            bool isSuccess = false;
            //Create SQL Connection
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                //SQL Query to Delete Data from Database
                string sql = "DELETE FROM tbl_customer WHERE AccountNo=@AccountNo";

                //Creating Sql Command 
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@AccountNo", c.AccountNo);
                //Open Connection
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                //If query run successfully then the value of rows is greater than zero else its value is zero
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }
    }
}
