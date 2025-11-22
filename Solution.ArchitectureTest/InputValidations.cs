using Application.User;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.ArchitectureTest
{
    public class InputValidations
    {
        [Fact]
        public void AllStringProperties_ShouldHaveMaxLengthRule()
        {
            var assembly = typeof(CreateUserCommandValidator).Assembly;

            var validatorTypes = assembly.GetTypes()
                .Where(t =>
                    t.BaseType?.IsGenericType == true &&
                    t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>))
                .ToList();

            foreach (var validatorType in validatorTypes)
            {
                var modelType = validatorType.BaseType!.GetGenericArguments()[0];

                if (!modelType.Name.EndsWith("Command", StringComparison.OrdinalIgnoreCase) &&
                    !modelType.Name.EndsWith("Query", StringComparison.OrdinalIgnoreCase))
                    continue;

                var stringProperties = modelType.GetProperties()
                    .Where(p => p.PropertyType == typeof(string))
                    .ToList();

                if (!stringProperties.Any())
                    continue;

                var validator = (IValidator)Activator.CreateInstance(validatorType)!;
                var descriptor = validator.CreateDescriptor();

                foreach (var property in stringProperties)
                {
                    var rules = descriptor.GetRulesForMember(property.Name)
                                ?? Enumerable.Empty<IValidationRule>();

                    var hasMaxLength = rules
                       .SelectMany(r => r.Components)
                       .Select(c => c.Validator)
                       .OfType<ILengthValidator>()
                       .Any(v => v.Max < int.MaxValue);

                    Assert.True(hasMaxLength,
                        $"{property.Name} in {modelType.Name} must have a max length rule.");
                }
            }
        }
    }
}

