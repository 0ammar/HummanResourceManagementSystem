using HummanResourceManagementSystem.Context;
using HummanResourceManagementSystem.DTOs.Employee.Request;
using HummanResourceManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HummanResourceManagementSystem.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HRMSDbContext _context;
        public EmployeeService(HRMSDbContext context)
        {
            _context = context;

        }

        public async Task UpdateEmployeeMainInfo(UpdateEmployeeDTO input)
        {
            if (input != null)
            {
                //check if the item exisit
                var item = await (from li in _context.Persons where li.Id == input.Id select li)
                    .FirstOrDefaultAsync();
                if (item != null)
                {
                    if (!string.IsNullOrEmpty(input.FirstName))
                        item.FirstName = input.FirstName;
                    if (!string.IsNullOrEmpty(input.LastName))
                        item.LastName = input.LastName;
                    if (input.NationalSSNID != null)
                        item.NationalSSNID = input.NationalSSNID;
                    if (input.MiddleName != null)
                        item.MiddleName = input.MiddleName;
                    if (input.Email != null)
                        item.Email = input.Email;
                    if (input.Phone != null)
                        item.Phone = input.Phone;
                    _context.Persons.Update(item);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"There is no Employee With the Given Id : {input.Id}");
                }
            }
            else
            {
                throw new Exception("At Least Must Pass The Id Value");
            }
        }

        public async Task UpdateEmployeePassword(UpdateEmployeePasswordDTO input)
        {
            if (input != null)
            {
                var item = await (from li in _context.Persons where li.Id == input.Id select li)
                   .FirstOrDefaultAsync();
                if (item != null)
                {
                    if(!string.IsNullOrEmpty(input.Password))
                        item.Password = input.Password;
                    _context.Persons.Update(item);
                    await _context.SaveChangesAsync();
                }
                else
                {

                    throw new Exception($"There is no Employee With the Given Id : {input.Id}");
                }
            }
            else
            {
                throw new Exception("At Least Must Pass The Id Value");
            }
        }
        public async Task UpdateEmployeeActivationStatus(int Id, bool IsActive)
        {
            //Read Element From Db
            var person = await _context.Persons.FirstOrDefaultAsync(t => t.Id == Id);
            if (person != null)
            {
                //do update 
                person.IsActive = IsActive;
                person.ModificationDate = DateTime.Now;
                _context.Update(person);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"There is no Person With the Given Id : {Id}");
            }

        }
    }
}
