using FluentValidation;

namespace Guider.Application.UseCases.Appointments.Command.AddAppointment
{
    public class AddAppointmentCommandValidator : AbstractValidator<AddAppointmentCommand>
    {
        public AddAppointmentCommandValidator()
        {
            RuleFor(e => e.ConsultantId).GreaterThan(0);
            RuleFor(e => e.ClientId).GreaterThan(0);
            RuleFor(e => e.Duration).GreaterThanOrEqualTo(1);
            RuleFor(e => e.Date).GreaterThan(DateTime.Now);
        }
    }
}
