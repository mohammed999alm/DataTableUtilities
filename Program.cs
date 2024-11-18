using System;
using System.Data;


namespace DataTableUtilities
{
    internal class Program
    {

        static DataColumn GenerateDataColumn(string columnName, Type dataType, string columnCatption = "",
            bool AllowNull = true, bool readOnly = false, bool unique = false, bool autoIncreament = false, int seeds = 0, int increamentNumber = 1)
        {
            if (columnCatption == "")
            {
                columnCatption = columnName;
            }

            DataColumn column = new DataColumn();

            column.ColumnName = columnName;
            column.DataType = dataType;

            column.AutoIncrement = autoIncreament;

            if (autoIncreament)
            {
                column.AutoIncrementSeed = seeds;
                column.AutoIncrementStep = increamentNumber;
            }

            column.AllowDBNull = AllowNull;
            column.Unique = unique;
            column.ReadOnly = readOnly;
            column.Caption = columnCatption;

            return column;
        }


        static void AddColumnsToEmployeesTable(DataTable employees)
        {

            DataColumn dtID = GenerateDataColumn("ID", typeof(int), "EmployeeID", false, true, true, true, 1, 1);

            DataColumn dtFullName = GenerateDataColumn("FullName", typeof(string), "EmployeeName", false);

            DataColumn dtCountry = GenerateDataColumn("Country", typeof(string), "Country", false);

            DataColumn dtSalary = GenerateDataColumn("Salary", typeof(double), "Salary");

            DataColumn dtStartDate = GenerateDataColumn("StartDate", typeof(DateTime), "StartDate", false);

            DataColumn dtEndDate = GenerateDataColumn("EndDate", typeof(DateTime), "EndDate");


            employees.Columns.Add(dtID);
            employees.Columns.Add(dtFullName);
            employees.Columns.Add(dtCountry);
            employees.Columns.Add(dtSalary);
            employees.Columns.Add(dtStartDate);
            employees.Columns.Add(dtEndDate);

        }


        static void AddEmployeesRows(DataTable employee)
        {

            employee.Rows.Add(null, "Mohammed Almislaty", "Libya", 5500.50, new DateTime(), null);
            employee.Rows.Add(null, "Mohammed Abu-Hadhoud", "", 10000.50, new DateTime(2001, 6, 28), null);
            employee.Rows.Add(null, "Lina Ahmed", "Jordan", 2350, new DateTime(), null);
            employee.Rows.Add(null, "Maha Salem", "Egypt", 4500, new DateTime(), null);
            employee.Rows.Add(null, "Saleem Khaled", "Syria", 3400, new DateTime(), null);
            employee.Rows.Add(null, "Jamal Jamel", "Algeria", 5000, new DateTime(), null);
        }

        static void SetEmployeeTablePrimaryKey(DataTable employeeTable)
        {
            employeeTable.PrimaryKey = new[] { employeeTable.Columns["ID"] };
        }
        static void Main(string[] args)
        {
            DataTable employeeTable = new DataTable();

            AddColumnsToEmployeesTable(employeeTable);

            SetEmployeeTablePrimaryKey(employeeTable);

            AddEmployeesRows(employeeTable);

            foreach (DataRow row in employeeTable.Rows)
            {
                Console.WriteLine("ID : {0, -5}  | Full Name :  {1, -22}  | Country : {2, -12}  | " +
                              "Salary :  {3, -8}  | Start Date : {4, -9}  | End Date :  {5, -9}",
                               row["ID"], row["FullName"], row["Country"], row["Salary"],
                               DateTime.Parse(row["StartDate"].ToString()).ToShortDateString(),
                               row["EndDate"]);

            }

            Console.ReadKey();
        }
    }
}
