using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStart
{
    public class Department
    {
        /// <summary>
        /// Department ID - primary Key to Department Table
        /// </summary>
        public int DepartmentID { get; set; }
        /// <summary>
        /// Name, i.e., Department Name is not null
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Group name is not null
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// Date Department was modified
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// No argument Constructor
        /// </summary>
        public Department()
        {

        }
        /// <summary>
        /// All argument Constructor
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="departmentName"></param>
        /// <param name="groupName"></param>
        /// <param name="modifiedDate"></param>
        public Department(int departmentID, string departmentName, string groupName, DateTime modifiedDate)
        {
            DepartmentID = departmentID;
            DepartmentName = departmentName;
            GroupName = groupName;
            ModifiedDate = modifiedDate;
        }
        public override string ToString()
        {
            return $"DepartmentID = {DepartmentID}\nDepartmentName = {DepartmentName}\nGroupName = {GroupName}\nModifiedDate = {ModifiedDate}\n";
        }

    }
}
