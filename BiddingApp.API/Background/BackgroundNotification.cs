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
                    var date = DateTime.Now;
                    _logger.LogError(date.ToString());
                    var time = TimeSpan.FromSeconds(30);
                    var date2 = date.Subtract(time);
                    _logger.LogInformation(date2.ToString());
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
                        }
                    }
                    _logger.LogError(products.Count().ToString());
                    await Task.Delay(time, stoppingToken);
                }
            }
        }
    }
}
