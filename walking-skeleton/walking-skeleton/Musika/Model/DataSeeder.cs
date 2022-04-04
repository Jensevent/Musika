namespace Musika.Model
{
    public class DataSeeder
    {
        private readonly EmployeeDbContext employeeDbContext;

        public DataSeeder(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        public void Seed()
        {
            if (!employeeDbContext.Employees.Any())
            {
                var employees = new List<Employee>()
                {
                    new Employee()
                    {
                        Name = "Ingrid",
                        Citzenschip = "Danish",
                        EmployeeId = "1"
                    },
                    new Employee()
                    {
                        Name = "Albert",
                        Citzenschip = "French",
                        EmployeeId = "2"
                    },
                    new Employee()
                    {
                        Name = "Victor",
                        Citzenschip = "Australian",
                        EmployeeId= "3"
                    }
                };

                employeeDbContext.Employees.AddRange(employees);
                employeeDbContext.SaveChanges();
            }
        }
    }
}
