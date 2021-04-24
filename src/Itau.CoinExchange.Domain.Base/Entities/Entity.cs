using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;

namespace Itau.CoinExchange.Domain.Base.Entities
{
    public abstract class Entity<TId>
        where TId : struct
    {
        public TId Id { get; private set; }
        public bool Valid => ValidationResult?.IsValid ?? Validate();
        public ValidationResult ValidationResult { get; private set; }

        protected bool OnValidate<TValidator, TEntity>(TEntity entity, TValidator validator)
            where TValidator : AbstractValidator<TEntity>
            where TEntity : Entity<TId>
        {
            ValidationResult = validator.Validate(entity);
            return Valid;
        }

        protected bool OnValidate<TValidator, TEntity>(TEntity entity, TValidator validator, Func<AbstractValidator<TEntity>, TEntity, ValidationResult> validation)
            where TValidator : AbstractValidator<TEntity>
            where TEntity : Entity<TId>
        {
            ValidationResult = validation(validator, entity);
            return Valid;
        }

        protected void AddError(string errorMessage, ValidationResult validationResult = default)
        {
            ValidationResult.Errors.Add(new(default, errorMessage));
            validationResult?.Errors.ToList().ForEach(failure => ValidationResult.Errors.Add(failure));
        }

        protected abstract bool Validate();
    }
}