using HummanResourceManagementSystem.Context;
using HummanResourceManagementSystem.DTOs.Contract.Request;
using HummanResourceManagementSystem.Entities;
using HummanResourceManagementSystem.Interfaces;

namespace HummanResourceManagementSystem.Implementation
{
    public class ContractService : IContractService
    {
        private readonly HRMSDbContext _context;
        public ContractService(HRMSDbContext context)
        {
            _context = context;
        }
        public async Task CreateNewContractWithEmployee(CreateNewEmployeeDTO input)
        {
            
            if(input != null)
            {
                //Create Employee 
                //Validation Places  for person & Contract 
                Person person = new Person()
                {
                    FirstName = input.FirstName,
                    MiddleName = input.MiddleName,
                    LastName = input.LastName,
                    BirthDate = input.BirthDate,    
                    DepartmentId = input.DepartmentId,
                    Email = input.Email,
                    NationalSSNID = input.NationalSSNID,
                    IdentityImagePath = input.IdentityImagePath,
                    CreationDate = DateTime.Now,
                    InterviewDate = input.InterviewDate,
                    NationalityId = input.NationalityId,
                    Password = new Guid().ToString(),
                    PersonalImagePath = "",
                    Phone = input.Phone,
                    UserTypeId = 8,
                    ResumePath = ""
                };
                await _context.AddAsync(person);
                await _context.SaveChangesAsync();
                //Create Contract Must Complete After Add New Person 
                if(person.Id > 0)
                {
                    EmployeeContract employeeContract = new EmployeeContract()
                    {
                        Conditions = input.Conditions,  
                        DurationInYears = input.DurationInYears,
                        Heading = input.Heading,
                        EndDate = input.EndDate,
                        ContractTypeId = input.ContractTypeId,  
                        PersonId = person.Id,
                        PositionTypeId = input.PositionTypeId,
                        Responsibility = input.Responsibility,
                        Salary = input.Salary,
                        Title = input.Title,
                        StartingDate = input.StartingDate
                    };
                    await _context.AddAsync(employeeContract);
                    await _context.SaveChangesAsync();
                    if (employeeContract.Id <= 0)
                    {
                        //Remove For The Person
                        _context.Persons.Remove(person);
                        await _context.SaveChangesAsync();
                        throw new Exception("Failed To Create Contract");
                    }
                      
                }
                else
                {
                    throw new Exception("Failed To Create New Person");
                }

            }
            else
            {
                throw new Exception("All Fileds Are Required");
            }
        }


    }
}
