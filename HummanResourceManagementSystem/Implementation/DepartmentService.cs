using HummanResourceManagementSystem.Context;
using HummanResourceManagementSystem.DTOs.Departments.Request;
using HummanResourceManagementSystem.DTOs.Departments.Response;
using HummanResourceManagementSystem.Entities;
using HummanResourceManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HummanResourceManagementSystem.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HRMSDbContext _context;
        public DepartmentService(HRMSDbContext context)
        {
            this._context = context;
        }
        public async Task CreateDepartement(CreateDepartmentDTO input)
        {

            Department newInstance = new Department()
            {
                NameEn = input.NameEn,
                NameAr = input.NameAr,
                Image = input.Image
            };
            _context.Add(newInstance);
            _context.SaveChanges();
        }

        public async Task<List<DepartmentDTO>> GetDepartments()
        {

            var response = from department in _context.Departments
                           select new DepartmentDTO()
                           {
                               NameEn = department.NameEn + " - "+ department.NameAr,
                               IsActive = department.IsActive,
                               CreationDate = department.CreationDate.ToShortDateString()
                           };
            return await response.ToListAsync();
            //var result = _context.Departments.ToList(); // instead of select * from departments
            //List<DepartmentDTO> departments = new List<DepartmentDTO>();
            //foreach (var department in result)
            //{
            //    DepartmentDTO departmentDTO = new DepartmentDTO();
            //    departmentDTO.
            //    departmentDTO.
            //    departmentDTO.
            //    departments.Add(departmentDTO);
            //}
            //return departments;
        }

        public async Task UpdateDepartment(UpdateDepartmentDTO input)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == input.Id);
            department.NameEn = input.NameEn;
            department.NameAr = input.NameAr;
            department.Image = input.Image;
            department.IsActive = (bool)input.IsActive;

            _context.SaveChanges();




        }
    }
}
