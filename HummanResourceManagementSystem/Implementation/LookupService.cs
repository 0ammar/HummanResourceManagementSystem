using HummanResourceManagementSystem.Context;
using HummanResourceManagementSystem.DTOs.Lookups.Reponse;
using HummanResourceManagementSystem.DTOs.Lookups.Request;
using HummanResourceManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HummanResourceManagementSystem.Implementation
{
    public class LookupService : ILookupService
    {
        private readonly HRMSDbContext _context;
        public LookupService(HRMSDbContext context) {
            _context = context;
        
        }

        public async Task<List<LookupItemDTO>> GetLookupItemsByLookupType(int LookupTypeId)
        {
            var res = from li in _context.LookupItems
                      join lt in _context.LookupTypes
                      on li.LookupTypeId equals lt.Id
                      where li.LookupTypeId == LookupTypeId
                      select new LookupItemDTO
                      {
                          Id = li.Id,
                          Name = li.Name,
                          NameAr = li.NameAr,
                          CreationDate = li.CreationDate.ToShortDateString(),
                          IsActive = li.IsActive,
                          ParentNameAr = lt.NameAr,
                          ParentNameEn = lt.Name
                      };
            return await res.ToListAsync();
        }

        public async Task<List<LookupTypeDTO>> GetLookupTypes()
        {
            var res = from lt in _context.LookupTypes
                      select new LookupTypeDTO
                      {
                          Id = lt.Id,
                          Name = lt.Name,
                          NameAr = lt.NameAr,
                          CreationDate = lt.CreationDate.ToShortDateString(),
                          IsActive = lt.IsActive,
                      };
            return await res.ToListAsync();
        }

        public async Task UpdateLookupItem(UpdateLookupItemDTO input)
        {
            if(input != null)
            {
                //check if the item exisit
                var item = await (from li in _context.LookupItems where li.Id == input.Id select li)
                    .FirstOrDefaultAsync();
                if (item != null) {
                    if(!string.IsNullOrEmpty(input.Name))
                        item.Name = input.Name;
                    if (!string.IsNullOrEmpty(input.NameAr))
                        item.Name = input.Name;
                    if (input.IsActive != null)
                        item.IsActive = (bool)input.IsActive;
                    _context.LookupItems.Update(item);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"There is no Lookup Item With the Given Id : {input.Id}");
                }
            }
            else
            {
                throw new Exception("At Least Must Pass The Id Value");
            }
        }

        public async Task UpdateLookupTypeStatus(int Id, bool IsActive)
        {
            //Read Element From Db
            var lookupType = await _context.LookupTypes.FirstOrDefaultAsync(t => t.Id == Id);
            //var res = from lt in _context.LookupTypes where lt.Id == Id select lt;
            if (lookupType != null) { 
               //do update 
               lookupType.IsActive = IsActive;
                lookupType.ModificationDate = DateTime.Now;
                _context.Update(lookupType);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"There is no Lookup Type With the Given Id : {Id}");
            }
            
        }
    }
}
