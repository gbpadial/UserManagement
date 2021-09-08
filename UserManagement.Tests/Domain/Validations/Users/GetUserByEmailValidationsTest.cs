using FluentValidation.Results;
using UserManagement.Domain.Queries.Users.GetUserByEmail;
using UserManagement.Domain.Validations.Users;
using Xunit;

namespace UserManagement.Tests.Domain.Validations.Users
{
    public class GetUserByEmailValidationsTest
    {
        [Fact(DisplayName = "Valid Email: teste@teste.com")]
        public void ValidEmail()
        {
            GetUserByEmailRequestValidator validator = new GetUserByEmailRequestValidator();
            GetUserByEmailRequest request = new GetUserByEmailRequest
            {
                Email = "teste@teste.com",
            };

            ValidationResult result = validator.Validate(request);
            Assert.True(result.IsValid);
        }
    }
}
