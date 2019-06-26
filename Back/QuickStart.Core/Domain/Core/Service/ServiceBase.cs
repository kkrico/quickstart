using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using QuickStart.Core.Domain.Core.Bus;

namespace QuickStart.Core.Domain.Core.Service
{
    public abstract class ServiceBase
    {
        private readonly IMediatorHandlerNormalize _mediatorHandler;

        protected ServiceBase(IMediatorHandlerNormalize mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public ValidationResult Validar<TValidador, TParametro>(TParametro parametro,  object[] args)
            where TValidador : AbstractValidator<TParametro>
        {
            var validator = (AbstractValidator<TParametro>)Activator.CreateInstance(typeof(TValidador), args);
            return validator.Validate(parametro);
        }
    }
}
