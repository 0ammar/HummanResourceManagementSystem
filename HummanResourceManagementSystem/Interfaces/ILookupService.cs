using HummanResourceManagementSystem.DTOs.Lookups.Reponse;
using HummanResourceManagementSystem.DTOs.Lookups.Request;

namespace HummanResourceManagementSystem.Interfaces
{
    public interface ILookupService
    {
        Task<List<LookupTypeDTO>> GetLookupTypes();
        Task UpdateLookupTypeStatus(int Id, bool IsActive);
        //Lookups 
        Task<List<LookupItemDTO>> GetLookupItemsByLookupType(int LookupTypeId);
        Task UpdateLookupItem(UpdateLookupItemDTO input );
    }
}
