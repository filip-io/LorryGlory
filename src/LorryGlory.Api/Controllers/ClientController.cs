using LorryGlory.Api.Helpers;
using LorryGlory.Api.Models;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
