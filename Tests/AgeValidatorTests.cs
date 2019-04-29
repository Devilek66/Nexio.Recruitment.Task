using Nexio.Recruitment.Task.CustomDataAnnotations;
using System;
using Xunit;

namespace Tests
{
    public class AgeValidatorTests
    {
        private readonly AgeValidator _ageValidator;
        public AgeValidatorTests()
        {
            _ageValidator = new AgeValidator();
        }

        [Fact]
        public void AgeValidator_Should_Return_True()
        {
            bool result = _ageValidator.IsValid(new DateTime(1990, 10, 10));
            Assert.True(result);
        }

        [Fact]
        public void AgeValidator_Should_Return_False()
        {
            bool result = _ageValidator.IsValid(new DateTime(2002, 10, 10));
            Assert.False(result);
        }
    }
}
