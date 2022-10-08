using AutoMapper;
using BiddingApp.Aplication.Commands;
using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;
using BiddingApp.Validations;
using FluentValidation.Results;
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
            _logger.LogInformation("Create new client");

            if (!ModelState.IsValid)
            {
                _logger.LogError(ModelState.ToString());
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<CreateClientProfileCommand>(dto);
            var created = await _mediator.Send(command);
            var toReturn = _mapper.Map<ClientProfileGetDTO>(created);
            return Ok(toReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientProfiles()
        {
            _logger.LogInformation("Get all client profiles");
            var query = new GetClientsQuery();
            var result = await _mediator.Send(query);
            var clients = _mapper.Map<List<ClientProfileGetDTO>>(result);
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientProfileById(int id)
        {
            _logger.LogInformation($"Get client profile with id {id}");
            var query = new GetClientProfileByIDQuery { ClientProfileId = id };
            var result = await _mediator.Send(query);


            if(result == null)
            {
                _logger.LogError($"Client with id {id} not found");
                return NotFound("Client not found!");
            }
            var client = _mapper.Map<ClientProfileGetDTO>(result);
            return Ok(client);
        }

        [HttpGet("/api/ClientProfile/{id}/products-own")]
        public async Task<IActionResult> GetClientProducts(int id)
        {
            _logger.LogInformation($"Get products own by client with id {id}");
            var query = new GetProductsByClientIDQuery
            {
                ClientID = id
            };

            var result = await _mediator.Send(query);

            if(result == null)
            {
                _logger.LogInformation($"Client with id {id} not found");
                return NotFound("Client not found");
            }
            var toReturn = _mapper.Map<List<GetProductDTO>>(result);
            return Ok(toReturn);
        }
        [HttpGet("/api/ClientProfile/{id}/reviews")]
        public async Task<IActionResult> GetClientReviews(int id)
        {
            _logger.LogInformation($"Get reviews written by client with id {id}");
            var query = new GetClientReviewsQuery
            {
                ClientId = id
            };
            var result = await _mediator.Send(query);
            if(result == null)
            {
                _logger.LogError($"Client with id {id} not found");
                return NotFound("Client not found!");
            }
            var toReturn = _mapper.Map<List<GetReviewDTO>>(result);
            return Ok(toReturn);
        }

        [HttpGet("/api/ClientProfile/{id}/products-own/page-number/{pageNumber}/count/{count}")]
        public async Task<IActionResult> GetClientProductsByPage(int id, int pageNumber, int count)
        {
            _logger.LogInformation($"Get products by page for client with id {id}");
            var query = new GetClientProductsByPageQuery
            {
                ClientID = id,
                PageNumber = pageNumber,
                Index = count
            };
            var result = await _mediator.Send(query);
            if(result == null)
            {
                _logger.LogError("Client not found");
                return NotFound("Client not found!");
            }
            if(result.Count == 0)
            {
                _logger.LogError("Page not found!");
                return NotFound("Page not found!");
            }
            var toReturn = _mapper.Map<List<GetProductDTO>>(result);
            return Ok(toReturn);
        }
        [HttpGet("/api/ClientProfile/{id}/notifications/page-number/{pageNumber}/count/{count}")]
        public async Task<IActionResult> GetClientNotificationsByPage(int id, int pageNumber, int count)
        {
            _logger.LogInformation($"Get notifications by page for client with id {id}");
            var query = new GetClientNotificationsByPageQuery
            {
                ClientID = id,
                PageNumber = pageNumber,
                Index = count
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                _logger.LogError($"Client with id {id} not found");
                return NotFound("Client not found!");
            }
            if (result.Count == 0)
            {
                _logger.LogError($"Page no {pageNumber} not found");
                return NotFound("Page not found!");
            }
            var toReturn = _mapper.Map<List<GetClientNotificationDTO>>(result);
            return Ok(toReturn);
        }

        [HttpGet("/api/ClientProfile/{id}/notifications")]
        public async Task<IActionResult> GetClientNotifications(int id)
        {
            _logger.LogInformation($"Get notifications for client with id {id}");
            var query = new GetNotificationsByClientQuery
            {
                ClientID = id
            };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogError($"Client with id {id} not found");
                return NotFound("Client not found!");
            }
            var toReturn = _mapper.Map<List<GetClientNotificationDTO>>(result);
            return Ok(toReturn);
        }

        [HttpGet("/api/ClientProfile/{id}/reviews/page-number/{pageNumber}/count/{count}")]
        public async Task<IActionResult> GetClientReviewsByPage(int id, int pageNumber, int count)
        {
            _logger.LogInformation($"Get notification by page for client with id {id}");
            var query = new GetClientReviewsByPageQuery
            {
                ClientID = id,
                PageNumber = pageNumber,
                Index = count
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                _logger.LogError($"Client with id {id} not found");
                return NotFound("Client not found!");
            }
            if (result.Count == 0)
            {
                _logger.LogError($"Page no {pageNumber} not found");
                return NotFound("Page not found!");
            }
            var toReturn = _mapper.Map<List<GetReviewDTO>>(result);
            return Ok(toReturn);
        }

        [HttpGet("/api/ClientProfile/{id}/reviews/max-page-number/count/{count}")]
        public async Task<IActionResult> GetClientReviewsMaxPage(int id, int count)
        {
            _logger.LogInformation($"Get notification by page for client with id {id}");
            var query = new GetMaxPageReviewByClientIDQuery
            {
                ClientID = id,
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

        [HttpGet("/api/ClientProfile/{id}/notifications/max-page-number/count/{count}")]
        public async Task<IActionResult> GetClientNotificationsMaxPage(int id, int count)
        {
            _logger.LogInformation($"Get notification max page for client with id {id}");
            var query = new GetMaxPageClientNotificationQuery
            {
                ClientID = id,
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
        [HttpGet("/api/ClientProfile/{id}/products-own/max-page-number/count/{count}")]
        public async Task<IActionResult> GetClientProductsMaxPage(int id, int count)
        {
            _logger.LogInformation($"Get max page product for client with id {id}");
            var query = new GetMaxPageProductsOwnByClientIDQuery
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
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientProfilePutDTO dto)
        {
            _logger.LogInformation("Update client profile");
            var command = new UpdateClientCommand
            {
                ClientName = dto.ClientName,
                ClientProfileId = id,
                Balance = dto.Balance,
                ProfilePhotoURL = dto.ProfilePhotoURL
            };

            if (!ModelState.IsValid)
            {
                _logger.LogError(ModelState.ToString());
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(command);

            if(result == null)
            {
                _logger.LogError($"Client with id {id} not found");
                return NotFound("Client not found!");
            }

            return Ok(command);
        }

        [HttpPut("{id}/product/{productId}/offer/{sum}")]
        public async Task<IActionResult> MakeOffer(int id, int productId, double sum)
        {
            _logger.LogInformation($"Client with id {id} make offer for product with id {productId}");
            var command = new MakeOfferCommand
            {
                ClientId = id,
                ProductId = productId,
                sum = sum
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                _logger.LogError("Imposible to make offer");
                return NotFound();
            }
            var commandProd = new GetProductByIDQuery
            { 
                ProductId = result.ProductId 
            };
            var product = await _mediator.Send(commandProd);
            if(product.ClientProfileId != null)
            {
                _logger.LogInformation("Sent notification for client!");
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
            _logger.LogInformation($"Add money for client with id {id}");
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
                _logger.LogError("Client or card not found");
                return NotFound("Client or card not found!");
            }
            var toReturn = _mapper.Map<ClientProfileGetDTO>(result);
            return Ok(toReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientProfile(int id)
        {
            _logger.LogInformation($"Delete client with id {id}");
            var command = new DeleteClientProfileCommand
            {
                ClientProfileId = id
            };
            var result = await _mediator.Send(command);

            if(result == null)
            {
                _logger.LogError("Client not found");
                return NotFound("Client not found!");
            }

            return NoContent();
        }
    }

}
