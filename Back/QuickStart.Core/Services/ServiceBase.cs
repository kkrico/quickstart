using System;
using FluentValidation;
using FluentValidation.Results;
using QuickStart.Shared.Abstractions.Core.Bus;
using QuickStart.Shared.Abstractions.Core.Notifications;

namespace QuickStart.Core.Services
{
    public abstract class ServiceBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private const string DomainError = "DomainError";

        protected ServiceBase(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public ValidationResult Validar<TValidador, TParametro>(TParametro parametro, object[] args = null)
            where TValidador : AbstractValidator<TParametro>
        {
            var validator = (AbstractValidator<TParametro>) Activator.CreateInstance(typeof(TValidador), args);
            return validator.Validate(parametro);
        }

        protected void NotificarErros(ValidationResult message)
        {
            Notify(message);
        }


        protected T NotificarErros<T>(ValidationResult message)
        {
           Notify(message);

            return default(T);
        }

        private void Notify(ValidationResult message)
        {
            foreach (ValidationFailure error in message.Errors)
            {
                _mediatorHandler.RaiseEvent(new DomainNotification(DomainError, error.ErrorMessage));
            }
        }
    }
}