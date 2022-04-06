namespace Musika.Model
{
    public class DataRepository : IDataRepository
    {
        private readonly EmployeeDbContext db;


        public DataRepository(EmployeeDbContext db)
        {
            this.db = db;
        }

        public List<Employee> GetEmployees() => db.Employees.ToList();

        public Employee PutEmployee(Employee employee)
        {
            db.Employees.Update(employee);
            db.SaveChanges();
            return db.Employees.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();
        }

        public List<Employee> AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return db.Employees.ToList();
        }

        public Employee GetEmployee(string Id)
        {
            return db.Employees.Where(x => x.EmployeeId == Id).FirstOrDefault();
        }

        public Boolean CheckDbConn()
        {
            return db.Database.CanConnect();
        }
    }
}
