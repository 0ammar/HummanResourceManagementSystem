using HummanResourceManagementSystem.DTOs.Departments.Request;
using HummanResourceManagementSystem.DTOs.Departments.Response;

namespace HummanResourceManagementSystem.Interfaces
{
    public interface IDepartmentService
    {
        Task CreateDepartement(CreateDepartmentDTO input);
        Task UpdateDepartment(UpdateDepartmentDTO input);
        Task<List<DepartmentDTO>> GetDepartments();
    }
}
