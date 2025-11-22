using FluentValidation;
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
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            var validatorTypes = assembly.GetTypes()
                .Where(t => 
                            t.BaseType?.IsGenericType == true &&
                            t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>)
                      )
                .Where(t =>  
                            t.BaseType.FullName.Contains("Query", StringComparison.OrdinalIgnoreCase) ||
                            t.BaseType.FullName.Contains("Command", StringComparison.OrdinalIgnoreCase)
                      );

            Assert.NotNull(validatorTypes);
            Assert.NotEmpty(validatorTypes);

            foreach (var validatorType in validatorTypes)
            {
                var modelType = validatorType.BaseType?.GetGenericArguments().First();
                Assert.NotNull(modelType);

                var stringProperties = modelType.GetProperties()
                    .Where(p => p.PropertyType == typeof(string));

                foreach (var property in stringProperties)
                {
                    var hasLengthRule = validatorType.GetMethods()
                        .Any(m => m.Name == "RuleFor" && m.GetParameters()
                            .Any(p => p.ParameterType == typeof(Func<,>)
                                && p.ParameterType.GenericTypeArguments[1] == typeof(string)));

                    Assert.True(hasLengthRule, $"{property.Name} in {modelType.Name} must have a max length rule.");
                }
            }
        }
    }
}
