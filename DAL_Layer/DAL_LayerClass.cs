using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL_Layer.Models;

namespace DAL_Layer
{
    public class DAL_LayerClass
    {
        //string connString = "Initial Catalog=ProductDB;Data Source=DESKTOP-9N6VPIL;Integrated Security=true;";
        string connString = ConfigurationManager.AppSettings["ProductDBConnectionString"];
        public DataSet GetEmployees()
        {
            DataSet ds = new DataSet();

            try
            {
                using(SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand("MyTest", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Employees - " + ex.Message.ToString());
            }
        }

        public int AddEmployee(Employee employee)
        {
            string connString = ConfigurationManager.AppSettings["ProductDBConnectionString"];
            try
            {
                using(SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("addEmployee", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = new SqlParameter("@name", SqlDbType.NVarChar);
                    parameters[1] = new SqlParameter("@job", SqlDbType.NVarChar);
                    parameters[2] = new SqlParameter("@salary", SqlDbType.Money);

                    parameters[0].Value = employee.Name;
                    parameters[1].Value = employee.Job;
                    parameters[2].Value = employee.Salary;

                    if (parameters != null)
                    {
                        SqlParameter p = null;
                        foreach (SqlParameter sqlP in parameters)
                        {
                            p = sqlP;
                            if (p != null)
                            {
                                if (p.Direction == ParameterDirection.InputOutput ||
                                   p.Direction == ParameterDirection.Input && p.Value == null)
                                {
                                    p.Value = DBNull.Value;
                                }
                                command.Parameters.Add(p);
                            }
                        }
                    }
                    var result = command.ExecuteNonQuery();
                    command.CommandTimeout = 6000;
                    connection.Close();
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error occured while retrieving Employees - " + ex.Message.ToString());
            }

        }

    }
}
