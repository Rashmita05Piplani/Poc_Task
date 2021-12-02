using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Poc_task.Models
{
    public class EmployeeDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        private void CreateConnection()
        {
           // string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;


            // string cs = ConfigurationManager.ConnectionStrings["dbcs"].ToString();
            //try
            //{   
            //   // var settings = ConfigurationManager.ConnectionStrings;
            //    //string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            //    //con = new SqlConnection(cs);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}



        }
        //string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public bool AddEmployee(Employee emp )
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("InsertIntoEmployee", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@firstname", emp.FirstName);
           cmd.Parameters.AddWithValue("@lastname", emp.LastName);
           cmd.Parameters.AddWithValue("@age", emp.Age);
           cmd.Parameters.AddWithValue("@empcode", emp.EmpCode);
           cmd.Parameters.AddWithValue("@email", emp.Email);
           cmd.Parameters.AddWithValue("@sex", emp.Sex);
           con.Open();
           int successfull= cmd.ExecuteNonQuery();
            con.Close();
            if(successfull>0)
            {
                return true;
            }
            else
            {
                return false;
            }
           


        }
        public List<Employee> GetEmployees()
        {
            // CreateConnection();
            SqlConnection con = new SqlConnection(cs);
         
           // con = new SqlConnection(cs);
            List<Employee> EmployeesList = new List<Employee>();
            
            SqlCommand cmd = new SqlCommand("ViewRecords", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee emp = new Employee();
                emp.FirstName = dr.GetValue(1).ToString();
                emp.LastName = dr.GetValue(2).ToString();
                emp.Age = Convert.ToInt32(dr.GetValue(3).ToString());
                emp.EmpCode = dr.GetValue(4).ToString();
                emp.Sex = dr.GetValue(5).ToString();
                emp.Email = dr.GetValue(6).ToString();
                EmployeesList.Add(emp);

            }
            con.Close();
            return EmployeesList;
        }
        public bool DeleteEmployee(string empcode)
            
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("DeleteRecords", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empcode", empcode);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

    }
}
