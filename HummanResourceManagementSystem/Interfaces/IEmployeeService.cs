using HummanResourceManagementSystem.DTOs.Employee.Request;

namespace HummanResourceManagementSystem.Interfaces
{
    public interface IEmployeeService
    {
        Task UpdateEmployeeMainInfo(UpdateEmployeeDTO input);
        Task UpdateEmployeePassword(UpdateEmployeePasswordDTO input);
        Task UpdateEmployeeActivationStatus(int Id, bool IsActive);
    }
}
