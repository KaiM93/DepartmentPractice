using System;
namespace BestBuyBestPractices
{
    public interface iDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();

        public void insertDepartment(string newDepartmentName);
    }
}

