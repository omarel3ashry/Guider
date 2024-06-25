using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace Guider.Application.UseCases.Payment.Command.UserPayment
{
    public class CreateOrUpdatePaymentIntentHandler : IRequestHandler<CreateOrUpdatePaymentIntentCommand, UserPaymentDto>
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Consultant> _consultantrepository;
        private readonly IMapper _mapper;
        public CreateOrUpdatePaymentIntentHandler(IConfiguration configuration,
                                                  IRepository<Consultant> consultantrepository,
                                                  IMapper mapper)
        {
            _configuration = configuration;
            _consultantrepository = consultantrepository;
            _mapper = mapper;
        }

        public async Task<UserPaymentDto> Handle(CreateOrUpdatePaymentIntentCommand request, CancellationToken cancellationToken)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
            //calculate the amount
            var consultant = await _consultantrepository.GetByIdAsync(request.ConsultantId);
            var amount = request.Duration * consultant.HourlyRate;
            if (amount < 0.50f) throw new ArgumentException("The amount must be at least 50 cents.");
            var paymentIntentService = new PaymentIntentService();
            PaymentIntent paymentIntent;
            if (string.IsNullOrEmpty(request.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(amount * 100),
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                paymentIntent = await paymentIntentService.CreateAsync(options);
                request.PaymentIntentId = paymentIntent.Id;
                request.ClientSecretKey = paymentIntent.ClientSecret;
            }
            else
            {
                var updateOptions = new PaymentIntentUpdateOptions
                {
                    Amount = (long)(amount * 100),
                };
                await paymentIntentService.UpdateAsync(request.PaymentIntentId, updateOptions);
            }

            return _mapper.Map<UserPaymentDto>(request);
        }
    }
}