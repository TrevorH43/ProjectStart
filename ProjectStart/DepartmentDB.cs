using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStart
{
    /// <summary>
    /// handles access to/from database for the humanresources.department table
    /// </summary>
    public class DepartmentDB
    {
        SqlConnection connection = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;



        /// <summary>
        /// Retrieve the specifc department based on the primary key of human resources department table
        /// DepartmentID unique table primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetDepartment(int id)
        {
            Department department = new Department();
            try
            {
                if (connection == null)
                {
                    connection = ConnectionFactory.getInstance().getConnection();
                }
                string sqlStatement = @"

                 SELECT departmentID,
                 Name,
                 GroupName,
                ModifiedDate
                FROM AdventureWorks2019.HumanResources.Department
                WHERE DepartmentID = @1";
                cmd = new SqlCommand(sqlStatement, connection);
                cmd.Parameters.AddWithValue("@1", id);

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    department = new Department();
                    department.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                    department.DepartmentName = reader["Name"].ToString();
                    department.GroupName = reader["GroupName"].ToString();
                    department.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return department;
        }

        public List<Department> GetAllDepartment()
        {
         List<Department> departments = new List<Department>();
            Department department = null;
            try
            {
                if (connection == null)
                {
                    connection = ConnectionFactory.getInstance().getConnection();
                }
                string sqlStatement = @"

                 SELECT departmentID,
                 Name,
                 GroupName,
                ModifiedDate
                FROM AdventureWorks2019.HumanResources.Department";
                cmd = new SqlCommand(sqlStatement, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    department = PopulateDepartmentFromDB();
                    departments.Add(department);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return departments;
        }

        private Department PopulateDepartmentFromDB()
        {
            Department department = new Department();
            department.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
            department.DepartmentName = reader["Name"].ToString();
            department.GroupName = reader["GroupName"].ToString();
            department.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
            return department;
        }
        /// <summary>
        /// Adds a department to the department table
        /// </summary>
        /// <param name="name">name of the department</param>
        /// <param name="groupName">groupname of the department</param>
        /// <returns>Returns the newly inserted departmentID</returns>

        public decimal AddDepartment(String name, String groupName)
        {
            decimal deptNo = 0;
            int rowsAffected = 0;
            DateTime currentDate = DateTime.Now;
            try
            {
                if (connection == null)
                {
                    connection = ConnectionFactory.getInstance().getConnection();
                }
                string sqlStatement = @"

                 INSERT INTO AdventureWorks2019.HumanResources.Department(Name, GroupName, ModifiedDate)
                VALUES (@1, @2, @3)";
                cmd = new SqlCommand(sqlStatement, connection);
                cmd.Parameters.AddWithValue("@1", name);
                cmd.Parameters.AddWithValue("@2", groupName);
                cmd.Parameters.AddWithValue("@3", currentDate);
                rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    sqlStatement = @"SELECT IDENT_CURRENT('AdventureWorks2019.HumanResources.Department')
                AS RESULT";
                    cmd = new SqlCommand(sqlStatement, connection);
                    deptNo = (decimal)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return deptNo;
        }

        /// <summary>
        /// Dispose of the class resources
        /// </summary>
        public void Dispose()
        {
            reader.DisposeAsync();
            cmd.Dispose();
            connection.Dispose();
        }

    }
}
