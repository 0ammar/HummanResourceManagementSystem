using HummanResourceManagementSystem.DTOs.Contract.Request;

namespace HummanResourceManagementSystem.Interfaces
{
    public interface IContractService
    {
        Task CreateNewContractWithEmployee(CreateNewEmployeeDTO input);
    }
}
