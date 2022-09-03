using BiddingApp.Aplication;
using BiddingApp.Aplication.Commands;
using BiddingApp.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BiddingApp.API.Background
{
    public class BackgroundNotification : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;
        public BackgroundNotification(ILogger<BackgroundNotification> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope()) {
                    _logger.LogInformation("Start running background service!");
                    var date = DateTime.Now;
                    var time = TimeSpan.FromSeconds(30);
                    var date2 = date.Subtract(time);
                    var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                    var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    var result = await _unitOfWork.ProductRepository.GetAll();
                    var products = result.Where(x => x.FinalTime.CompareTo(date) <= 0 && x.FinalTime.CompareTo(date2) >= 0);
                    foreach(var product in products)
                    {
                        if(product.ClientProfileId != null)
                        {
                            var command = new CreateClientNotificationCommand
                            {
                                ClientID = (int)product.ClientProfileId,
                                ProductID = product.ProductId,
                                Text = $"You just bought {product.ProductName} for {product.ActualPrice * (1 - Product.BitConstant)}$!",
                                Title = "Bid won!",
                                Good = true
                            };
                            var check = await _mediator.Send(command);
                            if(check == null)
                            {
                                _logger.LogError($"Notification doesn't sent for product with id {product.ProductId}!");
                            }
                            else
                            {
                                _logger.LogInformation($"Notification for product with id {product.ProductId} sent to client with id {product.ClientProfileId}!");
                            }
                            var command2 = new CreateCompanyNotificationCommand
                            {
                                CompanyID = (int)product.CompanyProfileId,
                                ProductID = product.ProductId,
                                Text = $"You sell the product: {product.ProductName} for {product.ActualPrice * (1 - Product.BitConstant)}$!",
                                Title = "Product sold!",
                                Good = true
                            };
                            var check2 = await _mediator.Send(command2);
                            if (check2 == null)
                            {
                                _logger.LogError($"Notification doesn't sent for product with id {product.ProductId}!");
                            }
                            else
                            {
                                _logger.LogInformation($"Notification for product with id {product.ProductId} sent to company with id {product.CompanyProfileId}!");
                            }

                        }
                        else
                        {
                            var command2 = new CreateCompanyNotificationCommand
                            {
                                CompanyID = (int)product.CompanyProfileId,
                                ProductID = product.ProductId,
                                Text = $"Your product: {product.ProductName}, {product.ActualPrice * (1 - Product.BitConstant)} wasn't sold. You can repost this item!$!",
                                Title = "Product not sold!",
                                Good = false
                            };
                            var check2 = await _mediator.Send(command2);
                            if (check2 == null)
                            {
                                _logger.LogError($"Notification doesn't sent for product with id {product.ProductId}!");
                            }
                            else
                            {
                                _logger.LogInformation($"Notification for product with id {product.ProductId} sent to company with id {product.CompanyProfileId}!");
                            }
                        }
                    }
                    await Task.Delay(time, stoppingToken);
                }
            }
        }
    }
}
