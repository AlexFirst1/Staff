using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StaffArtsofte.Models
{
    public class EmployeeDAL
    {
        string connectionString = "Data Source = (local); Database=EmployeeDB; Persist Security Info=false; MultipleActiveResultSets=True; Trusted_Connection=True;";

        public IEnumerable<EmployeeInfo> GetAllEmployee()
        {
            List<EmployeeInfo> empList = new List<EmployeeInfo>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmployeeInfo emp = new EmployeeInfo();
                    emp.ID = Convert.ToInt32(dr["ID"].ToString());
                    emp.Name = dr["Name"].ToString();
                    emp.Surname = dr["Surname"].ToString();
                    emp.Age = Convert.ToInt32(dr["Age"].ToString());
                    emp.Department = dr["Department"].ToString();
                    emp.Language = dr["Language"].ToString();

                    empList.Add(emp);
                }
                con.Close();
            }
            return empList;
        }

        public void AddEmployee(EmployeeInfo emp)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO Employee Values (@Age,@Name,@Surname,@Department,@Language)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Age", emp.Age);
                    sqlCmd.Parameters.AddWithValue("@Name", emp.Name);
                    sqlCmd.Parameters.AddWithValue("@Surname", emp.Surname);                    
                    sqlCmd.Parameters.AddWithValue("@Department", emp.Department);
                    sqlCmd.Parameters.AddWithValue("@Language", emp.Language);
                    sqlCmd.ExecuteNonQuery();
                }
                catch { }
            }
        }

        public void UpdateEmployee(EmployeeInfo emp)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE Employee SET Age=@Age,Name=@Name,Surname=@Surname,Department=@Department,Language=@Language Where Id=@Id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Id", emp.ID);
                    sqlCmd.Parameters.AddWithValue("@Age", emp.Age);
                    sqlCmd.Parameters.AddWithValue("@Name", emp.Name);
                    sqlCmd.Parameters.AddWithValue("@Surname", emp.Surname);                   
                    sqlCmd.Parameters.AddWithValue("@Department", emp.Department);
                    sqlCmd.Parameters.AddWithValue("@Language", emp.Language);
                    sqlCmd.ExecuteNonQuery();
                }
                catch { }
            }
        }

        public void DeleteEmployee(int? Id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Employee Where Id=@Id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Id", Id);

                sqlCmd.ExecuteNonQuery();
            }
        }

        public EmployeeInfo GetEmployeeById(int? Id)
        {
            EmployeeInfo model = new EmployeeInfo();
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Employee WHERE Id = @Id";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Id", Id);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count == 1)
            {
                model.ID = Convert.ToInt32(dtbl.Rows[0][0].ToString());
                model.Age = Convert.ToInt32(dtbl.Rows[0][1].ToString());
                model.Name = Convert.ToString(dtbl.Rows[0][2].ToString());
                model.Surname = Convert.ToString(dtbl.Rows[0][3].ToString());               
                model.Department = Convert.ToString(dtbl.Rows[0][4].ToString());
                model.Language = Convert.ToString(dtbl.Rows[0][5].ToString());
                return model;
            }
            else
                return new EmployeeInfo();
        }
    }
}
