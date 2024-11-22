using LorryGlory.Api.Helpers;
using LorryGlory.Api.Models;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Api.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [ApiController]
    [Route("api/company")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }

        [Authorize(Policy ="SuperAdminPolicy")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<CompanyDto>>>> GetAllAsync()
        {
            try
            {
                var companies = await _companyService.GetAllAsync();
                return ResponseHelper.HandleSuccess(_logger, companies,
                    companies.Any() ? "Companies retrieved successfully" : "No companies exist");
            }
            catch (InvalidOperationException ex)
            {
                return ResponseHelper.HandleBadRequest<IEnumerable<CompanyDto>>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<CompanyDto>>(_logger, ex);
            }
        }

        [Authorize(Policy = "SuperAdminPolicy")] // open up for admins but only their own company!
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<CompanyDto>>> GetByIdAsync(Guid id)
        {
            try
            {
                var company = await _companyService.GetByIdAsync(id);
                if (company == null)
                {
                    return ResponseHelper.HandleNotFound<CompanyDto>(_logger, $"Company with ID: {id} not found");
                }
                return ResponseHelper.HandleSuccess(_logger, company, $"Company with ID: {id} retrieved successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<CompanyDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<CompanyDto>(_logger, ex);
            }
        }
        
        [Authorize(Policy = "SuperAdminPolicy")] 
        [HttpPost]
        public async Task<ActionResult<ApiResponse<CompanyDto>>> CreateAsync(CompanyCreateDto companyCreateDto)
        {
            try
            {
                var newCompany = await _companyService.CreateAsync(companyCreateDto);
                return ResponseHelper.HandleSuccess(_logger, newCompany, "Company created successfully");
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException<CompanyDto>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<CompanyDto>(_logger, ex);
            }
        }

        [Authorize(Policy = "SuperAdminPolicy")] // open up for admins but only their own company!
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<CompanyDto>>> UpdateAsync(Guid id, [FromBody] CompanyUpdateDto companyUpdateDto)
        {
            try
            {
                if (id != companyUpdateDto.TenantId)
                    return ResponseHelper.HandleBadRequest<CompanyDto>(_logger, "ID in URL does not match ID in request body");

                var updatedCompany = await _companyService.UpdateAsync(companyUpdateDto);
                return ResponseHelper.HandleSuccess(_logger, updatedCompany, "Company updated successfully");
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException<CompanyDto>(_logger, ex);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<CompanyDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<CompanyDto>(_logger, ex);
            }
        }

        [Authorize(Policy = "SuperAdminPolicy")] 
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<CompanyDto>>> DeleteAsync(Guid id)
        {
            try
            {
                var deletedCompany = await _companyService.DeleteAsync(id);
                return ResponseHelper.HandleSuccess(_logger, deletedCompany, $"Company with ID: {id} was successfully deleted.");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<CompanyDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<CompanyDto>(_logger, ex);
            }
        }
    }
}
