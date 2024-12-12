using HummanResourceManagementSystem.Context;
using HummanResourceManagementSystem.DTOs.Authantication.Request;
using HummanResourceManagementSystem.DTOs.Contract.Request;
using HummanResourceManagementSystem.DTOs.Departments.Request;
using HummanResourceManagementSystem.DTOs.Departments.Response;
using HummanResourceManagementSystem.DTOs.Employee.Request;
using HummanResourceManagementSystem.DTOs.Lookups.Request;
using HummanResourceManagementSystem.Helper;
using HummanResourceManagementSystem.Implementation;
using HummanResourceManagementSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

namespace HummanResourceManagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController] //C# Attributes
    public class AdminController : ControllerBase
    {
        private readonly IDepartmentService _service;
        private readonly ILookupService _lookupService;
        private readonly IContractService _contractService; 
        private readonly IEmployeeService _employeeService;
        private readonly IAuthanticationService _authanticationService;
        public AdminController(IDepartmentService service, ILookupService lookupService
            , IContractService contractService, IEmployeeService employeeService,
            IAuthanticationService authanticationService)
        {
            _service = service;
            _lookupService = lookupService;
            _contractService = contractService;
            _employeeService = employeeService;
            _authanticationService = authanticationService;
        }
        /// <summary>
        /// Get Depatments 
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetDepartment([FromHeader]string token)
        {
            Log.Information("Operation of Get Department Has Been Started");
            try
            {
                if (!await TokenHelper.ValidateToken(token,"Admin"))
                {
                    return Unauthorized("You Not Autharized For Get Department");
                }
                var responses = await _service.GetDepartments();
                Log.Information($"GetDepartments Return  {responses.Count} from DB");
                return responses.Count > 0 ? Ok(responses) : StatusCode(204, "No Avaiable Departments");
            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occured When Get Departments");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");
            }
        }
        /// <summary>
        /// GetLookupTypes
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetLookupTypes()
        {
            Log.Information("Operation of Get Lookup Types Has Been Started");
            try
            {
                var responses = await _lookupService.GetLookupTypes();
                Log.Information($"Lookup Types  Return  {responses.Count} from DB");
                return responses.Count > 0 ? Ok(responses) : StatusCode(204, "No Avaiable Lookup Types");
            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occured When Get Lookup Types");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");
            }
        }
        /// <summary>
        /// GetLookup Item By Selected Type
        /// </summary>
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetLookupItems([FromRoute] int Id)
        {
            Log.Information("Operation of Get Lookup Items Has Been Started");
            try
            {
                var responses = await _lookupService.GetLookupItemsByLookupType(Id);
                Log.Information($"Lookup Items  Return  {responses.Count} from DB");
                return responses.Count > 0 ? Ok(responses) : StatusCode(204, "No Avaiable Lookup Items");
            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occured When Get Lookup Items");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");
            }
        }
        /// <summary>
        /// Use This Endpoint To Create New Departmennt on The System 
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateNewDepartment([FromBody] CreateDepartmentDTO input)
        {
            Log.Information("Operation of Create New Department Has Been Started");
            try
            {
                await _service.CreateDepartement(input);
                Log.Information($"New Department Called {input.NameEn} was added to db");
                return StatusCode(201, "New Department Has Been Created");
            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occured When Create New Department");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");
            }

        }
        /// <summary>
        /// Use This Endpoint To Create New Contract on The System 
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateNewContract([FromBody] CreateNewEmployeeDTO input)
        {
            Log.Information("Operation of Create New Contract Has Been Started");
            try
            {
                await _contractService.CreateNewContractWithEmployee(input);
                Log.Information($"New Contract For Employee {input.FirstName }  {input.LastName} was added to db");
                return StatusCode(201, "New Contract Has Been Created");
            }
            catch (Exception ex)
            {
                Log.Error("An Error Was Occured When Create New Contract");
                Log.Error(ex.ToString());
                return StatusCode(500, $"Error : {ex.Message}");
            }

        }
        /// <summary>
        /// To Update  Department's data in System 
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentDTO dto)
        {
            Log.Information("Update Department Start Execution");
            try
            {
                await _service.UpdateDepartment(dto);
                Log.Information($" Department  Updated ");
                return StatusCode(200, "Updated successfully");
            }
            catch (Exception ex)
            {
                Log.Information($"An error occurred when create department ");
                Log.Error(ex.Message.ToString());

                return StatusCode(500, $"An error occurred {ex.Message}");
            }
        }
        /// <summary>
        /// To Update  Employee's data in System 
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeDTO dto)
        {
            Log.Information("Update Employee Start Execution");
            try
            {
                await _employeeService.UpdateEmployeeMainInfo(dto);
                Log.Information($" Employee  Updated ");
                return StatusCode(200, "Updated successfully");
            }
            catch (Exception ex)
            {
                Log.Information($"An error occurred when create Employee ");
                Log.Error(ex.Message.ToString());

                return StatusCode(500, $"An error occurred {ex.Message}");
            }
        }
        /// <summary>
        /// To Update  Employee's Password in System 
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateEmployeePassword([FromBody] UpdateEmployeePasswordDTO dto)
        {
            Log.Information("Update Employee Password Start Execution");
            try
            {
                await _employeeService.UpdateEmployeePassword(dto);
                Log.Information($" Employee Password Updated ");
                return StatusCode(200, "Updated successfully");
            }
            catch (Exception ex)
            {
                Log.Information($"An error occurred when update Employee Password");
                Log.Error(ex.Message.ToString());

                return StatusCode(500, $"An error occurred {ex.Message}");
            }
        }
        /// <summary>
        /// To Update  Employee Activation  data in System 
        /// </summary>
        [HttpPut]
        [Route("[action]/{Id}/{IsActive}")]
        public async Task<IActionResult> UpdateEmployeeActivation([FromRoute] int Id, [FromRoute] bool IsActive)
        {
            Log.Information("Update Employee Activation Start Execution");
            try
            {
                await _employeeService.UpdateEmployeeActivationStatus(Id, IsActive);
                Log.Information($" Employee Activation  Updated ");
                return StatusCode(200, "Updated successfully");
            }
            catch (Exception ex)
            {
                Log.Information($"An error occurred when update Employee Activation ");
                Log.Error(ex.Message.ToString());

                return StatusCode(500, $"An error occurred {ex.Message}");
            }
        }
        /// <summary>
        /// To Update  Lookup Type  data in System 
        /// </summary>
        [HttpPut]
        [Route("[action]/{Id}/{IsActive}")]
        public async Task<IActionResult> UpdateLookupType([FromRoute] int Id, [FromRoute] bool IsActive)
        {
            Log.Information("Update LookupType Start Execution");
            try
            {
                await _lookupService.UpdateLookupTypeStatus(Id, IsActive);
                Log.Information($" LookupType  Updated ");
                return StatusCode(200, "Updated successfully");
            }
            catch (Exception ex)
            {
                Log.Information($"An error occurred when update LookupType ");
                Log.Error(ex.Message.ToString());

                return StatusCode(500, $"An error occurred {ex.Message}");
            }
        }
        /// <summary>
        /// To Update  Lookup Item  data in System 
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateLookupItem([FromBody] UpdateLookupItemDTO input)
        {
            Log.Information("Update LookupItem Start Execution");
            try
            {
                await _lookupService.UpdateLookupItem(input);
                Log.Information($" LookupItem  Updated ");
                return StatusCode(200, "Lookup Item Updated successfully");
            }
            catch (Exception ex)
            {
                Log.Information($"An error occurred when update LookupItem ");
                Log.Error(ex.Message.ToString());

                return StatusCode(500, $"An error occurred {ex.Message}");
            }
        }
    }
}
