using AutoMapper;
using BiddingApp.Aplication.Commands;
using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProfileController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CompanyProfileController(IMediator mediator, IMapper mapper, ILogger<CompanyProfileController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyProfileDTO dto)
        {
            _logger.LogInformation("Create company profile");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = _mapper.Map<CreateCompanyProfileCommand>(dto);
            var created = await _mediator.Send(command);
            var toReturn = _mapper.Map<GetCompanyProfileDTO>(created);
            return Ok(toReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyProfiles()
        {
            var query = new GetCompanyProfilesQuery();
            var result = await _mediator.Send(query);
            var toReturn = _mapper.Map<List<GetCompanyProfileDTO>>(result);
            return Ok(toReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyProfileById(int id)
        {
            _logger.LogInformation($"Get company with id {id}");
            var query = new GetCompanyProfileByIDQuery
            {
                CompanyProfileId = id
            };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogError("Company not found");
                return NotFound("Company not found!");
            }
            var toReturn = _mapper.Map<GetCompanyProfileDTO>(result);
            return Ok(toReturn);
        }

        [HttpGet("/api/CompanyProfile/{id}/products")]
        public async Task<IActionResult> GetCompanyProducts(int id)
        {
            _logger.LogInformation($"Get products for company with id {id}");
            var query = new GetCompanyProductsQuery
            {
                CompanyID = id
            };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogError("Company not found");
                return NotFound("Company not found!");
            }
            var toReturn = _mapper.Map<List<GetProductDTO>>(result);
            return Ok(toReturn);
        }
        [HttpGet("/api/CompanyProfile/{id}/notifications")]
        public async Task<IActionResult> GetCompanyNotifications(int id)
        {
            _logger.LogInformation($"Get notifications for company with id {id}");
            var query = new GetCompanyNotificationsQuery
            {
                CompanyID = id
            };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogError("Company not found!");
                return NotFound("Company not found!");
            }
            var toReturn = _mapper.Map<List<GetCompanyNotificationDTO>>(result);
            return Ok(toReturn);
        }
        [HttpGet("/api/CompanyProfile/{id}/products-own/page-number/{pageNumber}/count/{count}")]
        public async Task<IActionResult> GetCompanyProductsByPage(int id, int pageNumber, int count)
        {
            _logger.LogInformation($"Get products by page for company with id {id}");
            var query = new GetCompanyProductsByPageQuery
            {
                CompanyID = id,
                PageNumber = pageNumber,
                Index = count
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound("Company not found!");
            }
            if (result.Count == 0)
            {
                return NotFound("Page not found!");
            }
            var toReturn = _mapper.Map<List<GetProductDTO>>(result);
            return Ok(toReturn);
        }
        [HttpGet("/api/CompanyProfile/{id}/notifications/page-number/{pageNumber}/count/{count}")]
        public async Task<IActionResult> GetCompanyNotificationsByPage(int id, int pageNumber, int count)
        {
            var query = new GetCompanyNotificationsByPageNumberQuery
            {
                CompanyID = id,
                PageNumber = pageNumber,
                Index = count
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound("Company not found!");
            }
            if (result.Count == 0)
            {
                return NotFound("Page not found!");
            }
            var toReturn = _mapper.Map<List<GetCompanyNotificationDTO>>(result);
            return Ok(toReturn);
        }
        [HttpGet("/api/CompanyProfile/{id}/notifications/max-page-number/count/{count}")]
        public async Task<IActionResult> GetCompanyNotificationsMaxPage(int id, int count)
        {
            _logger.LogInformation($"Get notification max page for client with id {id}");
            var query = new GetMaxPageCompanyNotificationQuery
            {
                CompanyID = id,
                Index = count
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                _logger.LogError($"Client with id {id} not found");
                return NotFound("Client not found!");
            }
            return Ok(result);
        }

        [HttpGet("/api/CompanyProfile/{id}/products-own/max-page-number/count/{count}")]
        public async Task<IActionResult> GetClientReviewsMaxPage(int id, int count)
        {
            _logger.LogInformation($"Get notification by page for client with id {id}");
            var query = new GetMaxPageProductsOwnByCompanyIDQuery
            {
                CompanyID = id,
                Index = count
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                _logger.LogError($"Client with id {id} not found");
                return NotFound("Client not found!");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompanyBalance(int id, [FromBody] UpdateCompanyDTO dto)
        { 
            _logger.LogInformation("Update company profile");
            var command = new UpdateCompanyProfileCommand
            {
                CompanyProfileId = id,
                IBAN = dto.IBAN,
                ProfilePhotoURL = dto.ProfilePhotoURL,
                CompanyBalance = dto.CompanyBalance,
                CompanyName = dto.CompanyName
            };
            if (!ModelState.IsValid)
            {
                _logger.LogError(ModelState.ToString());
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NotFound("Company not found!");
            }
            var toReturn = _mapper.Map<GetCompanyProfileDTO>(result);
            return Ok(toReturn);
        }

        [HttpPut("{id}/CashOutProduct/{productId}")]
        public async Task<IActionResult> CashOutObject(int id, int productId)
        {
            _logger.LogInformation($"Company with id {id} cash out money from product");
            var command = new CashOutProductCommand
            {
                ProductId = productId,
                CompanyId = id
            };
            var result = await _mediator.Send(command);
            if(result == null)
            {
                _logger.LogError("Company or product not found");
                return NotFound();
            }
            var toReturn = _mapper.Map<GetProductDTO>(result);
            return Ok(toReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyProfile(int id)
        {
            _logger.LogInformation($"Delete company with id {id}");
            var command = new DeleteCompanyProfileCommand
            {
                CompanyId = id
            };
            var result = await _mediator.Send(command);
            if(result == null)
            {
                _logger.LogError("Company not found");
                return NotFound("Company not found!");
            }
            return NoContent();
        }
    }
}
