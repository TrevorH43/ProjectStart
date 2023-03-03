using ProjectStart;

DepartmentDB departmentDB = new DepartmentDB();
Department department = departmentDB.GetDepartment(11);
Console.WriteLine(department);
Console.WriteLine("\n-----------------------------------------");
decimal deptNo = departmentDB.AddDepartment("CIS-254 TEST", "CIS-254 TEST");
Console.WriteLine($"Inserted Department Number: {deptNo}");
Console.WriteLine("\n-----------------------------------------");

List<Department> departments = departmentDB.GetAllDepartment();
foreach(Department dept in departments)
Console.WriteLine(dept);
Console.WriteLine("\n-----------------------------------------");