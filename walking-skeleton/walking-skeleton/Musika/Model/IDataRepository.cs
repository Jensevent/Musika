﻿
namespace Musika.Model
{
    public interface IDataRepository
    {
        List<Employee> AddEmployee(Employee employee);
        List<Employee> GetEmployees();
        Employee PutEmployee(Employee employee);
        Employee GetEmployee(string id);

        Boolean CheckDbConn();
    }
}