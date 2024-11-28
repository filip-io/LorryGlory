using LorryGlory.Api.Helpers;
using LorryGlory.Api.Models;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services;
using LorryGlory.Core.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace LorryGlory.Api.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClientService clientService, ILogger<ClientController> logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ClientDto>>>> GetAllAsync()
        {
            try
            {
                var client = await _clientService.GetAllAsync();
                return ResponseHelper.HandleSuccess(_logger, client,
                    client.Any() ? "Clients retrieved successfully" : "No client exist");
            }
            catch (InvalidOperationException ex)
            {
                return ResponseHelper.HandleBadRequest<IEnumerable<ClientDto>>(_logger, ex);
            }
            catch (DbException ex)
            {
                return ResponseHelper.HandleDatabaseError<IEnumerable<ClientDto>>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<ClientDto>>(_logger, ex);
            }
        }

        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ClientDto>>> CreateAsync(ClientCreateDto clientCreateDto)
        {
            try
            {
                // Extract TenantId from the authenticated user's claims
                var tenantIdClaim = User.Claims.FirstOrDefault(c => c.Type == "TenantId")?.Value;

                if (string.IsNullOrEmpty(tenantIdClaim) || !Guid.TryParse(tenantIdClaim, out var tenantId))
                {
                    return ResponseHelper.HandleException<ClientDto>(_logger, new Exception("TenantId is missing or invalid"));
                }

                var newClient = await _clientService.CreateAsync(clientCreateDto, tenantId);
                return ResponseHelper.HandleSuccess(_logger, newClient, "Client created successfully");
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException<ClientDto>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<ClientDto>(_logger, ex);
            }
        }
    }
}
