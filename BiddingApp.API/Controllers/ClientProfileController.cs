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
    public class ClientProfileController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ClientProfileController(IMediator mediator, IMapper mapper, ILogger<ClientProfileController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientProfileDTO dto)
        {
            var command = _mapper.Map<CreateClientProfileCommand>(dto);
            var created = await _mediator.Send(command);
            return Ok(created);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientProfiles()
        {
            var query = new GetClientsQuery();
            var result = await _mediator.Send(query);
            var clients = _mapper.Map<List<ClientProfileGetDTO>>(result);
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientProfileById(int id)
        {
            var query = new GetClientProfileByIDQuery { ClientProfileId = id };
            var result = await _mediator.Send(query);

            var client = _mapper.Map<ClientProfileDTO>(result);

            if(client == null)
            {
                return NotFound("Client not found!");
            }
            return Ok(client);
        }

        [HttpGet("/api/ClientProfile/{id}/products-own")]
        public async Task<IActionResult> GetClientProducts(int id)
        {
            var query = new GetProductsByClientIDQuery
            {
                ClientID = id
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("/api/ClientProfile/{id}/reviews")]
        public async Task<IActionResult> GetClientReviews(int id)
        {
            var query = new GetClientReviewsQuery
            {
                ClientId = id
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("/api/ClientProfile/{id}/products-own/page-number/{pageNumber}/count/{count}")]
        public async Task<IActionResult> GetClientProductsByPage(int id, int pageNumber, int count)
        {
            var query = new GetClientProductsByPageQuery
            {
                ClientID = id,
                PageNumber = pageNumber,
                Index = count
            };
            var result = await _mediator.Send(query);
            if(result == null)
            {
                return NotFound("Client not found!");
            }
            if(result.Count == 0)
            {
                return NotFound("Page not found!");
            }
            return Ok(result);
        }
        [HttpGet("/api/ClientProfile/{id}/notifications/page-number/{pageNumber}/count/{count}")]
        public async Task<IActionResult> GetClientNotificationsByPage(int id, int pageNumber, int count)
        {
            var query = new GetClientNotificationsByPageQuery
            {
                ClientID = id,
                PageNumber = pageNumber,
                Index = count
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound("Client not found!");
            }
            if (result.Count == 0)
            {
                return NotFound("Page not found!");
            }
            return Ok(result);
        }
        [HttpGet("/api/ClientProfile/{id}/notifications")]
        public async Task<IActionResult> GetClientNotifications(int id)
        {
            var query = new GetNotificationsByClientQuery
            {
                ClientID = id
            };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound("Client not found!");
            }
            return Ok(result);
        }

        [HttpGet("/api/ClientProfile/{id}/reviews/page-number/{pageNumber}/count/{count}")]
        public async Task<IActionResult> GetClientReviewsByPage(int id, int pageNumber, int count)
        {
            var query = new GetClientReviewsByPageQuery
            {
                ClientID = id,
                PageNumber = pageNumber,
                Index = count
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound("Client not found!");
            }
            if (result.Count == 0)
            {
                return NotFound("Page not found!");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientProfilePutDTO dto)
        {

            var command = new UpdateClientCommand
            {
                ClientName = dto.ClientName,
                ClientProfileId = id,
                Balance = dto.Balance,
                ProfilePhotoURL = dto.ProfilePhotoURL
            };

            var result = await _mediator.Send(command);

            if(result == null)
            {
                return NotFound("Client not found!");
            }

            return Ok(command);
        }

        [HttpPut("{id}/product/{productId}/offer/{sum}")]
        public async Task<IActionResult> MakeOffer(int id, int productId, double sum)
        {
            var command = new MakeOfferCommand
            {
                ClientId = id,
                ProductId = productId,
                sum = sum
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound();
            }
            var commandProd = new GetProductByIDQuery
            { 
                ProductId = result.ProductId 
            };
            var product = await _mediator.Send(commandProd);
            if(product.ClientProfileId != null)
            {
                var command3 = new CreateClientNotificationCommand
                {
                    ClientID = (int)product.ClientProfileId,
                    ProductID = product.ProductId,
                    Text = $"Lost product: {result.ProductName}, {sum}$!",
                    Title = "Product sold!",
                    Good = true
                };
                var check3 = await _mediator.Send(command3);
                if (check3 == null)
                {
                    _logger.LogError($"Notification doesn't sent for product with id {result.ProductId}!");
                }
                else
                {
                    _logger.LogInformation($"Notification for product with id {result.ProductId} sent to client with id {result.ClientProfileId}!");
                }
            }
            var command2 = new CreateCompanyNotificationCommand
            {
                CompanyID = (int)result.CompanyProfileId,
                ProductID = result.ProductId,
                Text = $"You have an offert for the product: {result.ProductName}, {sum}$!",
                Title = "Product sold!",
                Good = true
            };
            var check2 = await _mediator.Send(command2);
            if (check2 == null)
            {
                _logger.LogError($"Notification doesn't sent for product with id {result.ProductId}!");
            }
            else
            {
                _logger.LogInformation($"Notification for product with id {result.ProductId} sent to company with id {result.CompanyProfileId}!");
            }
            var toReturn = _mapper.Map<GetProductDTO>(result);
            return Ok(toReturn);
        }

        [HttpPut("{id}/funds/{cardNumber}")]
        public async Task<IActionResult> AddFunds(int id, string cardNumber, [FromBody] AddFundsDTO dto)
        {
            var command = new AddFundsCommand
            {
                ClientProfileId = id,
                Sum = dto.Sum,
                CardNumber = cardNumber,
                CVC = dto.CVC,
                PIN = dto.Pin
            };
            var result = await _mediator.Send(command);

            if(result == null)
            {
                return NotFound("Client or card not found!");
            }
            var toReturn = _mapper.Map<ClientProfileGetDTO>(result);
            return Ok(toReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientProfile(int id)
        {
            var command = new DeleteClientProfileCommand
            {
                ClientProfileId = id
            };
            var result = await _mediator.Send(command);

            if(result == null)
            {
                return NotFound("Client not found!");
            }

            return NoContent();
        }
    }

}
