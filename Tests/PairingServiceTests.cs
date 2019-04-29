using Nexio.Recruitment.Task.Models;
using Nexio.Recruitment.Task.Models.ViewModels;
using Nexio.Recruitment.Task.Services;
using Nexio.Recruitment.Task.Services.ServicesInterfaces;
using System;
using Xunit;

namespace Tests
{
    public class PairingServiceTests
    {
        private const string Irrelevant = "Max";
        private readonly IPairingService _pairingService;

        public PairingServiceTests()
        {
            _pairingService = new PairingService();
        }

        [Theory]
        [InlineData("10/10/1999", "10/10/1990", 175, 160, EyeColorEnum.Zielone, EyeColorEnum.Zielone)]
        [InlineData("10/10/1999", "10/10/1995", 175, 170, EyeColorEnum.Niebieskie, EyeColorEnum.Niebieskie)]
        [InlineData("10/10/1999", "10/10/1999", 175, 160, EyeColorEnum.Szare, EyeColorEnum.Zielone)]
        public void PairingService_Should_Return_True(string manDateString, string womanDateString, int manHeight, int womanHeight, EyeColorEnum manEye, EyeColorEnum womanEye)
        {
            DateTime manDate = Convert.ToDateTime(manDateString);
            DateTime womanDate = Convert.ToDateTime(womanDateString);
            PersonViewModel man = new PersonViewModel {
                Name = Irrelevant,
                BirthDate = manDate,
                Height = manHeight,
                EyeColor = manEye,
            };
            PersonViewModel woman = new PersonViewModel {
                Name = Irrelevant,
                BirthDate = womanDate,
                Height = womanHeight,
                EyeColor = womanEye
            };
            bool result = _pairingService.DoTheyMatch(woman, man);
            Assert.True(result);
        }

        [Theory]
        [InlineData("10/10/1999", "10/10/1990", 160, 160, EyeColorEnum.Zielone, EyeColorEnum.Zielone)]
        [InlineData("10/10/1999", "10/10/1995", 175, 170, EyeColorEnum.Brązowe, EyeColorEnum.Niebieskie)]
        [InlineData("10/10/1999", "10/10/1990", 175, 160, EyeColorEnum.Szare, EyeColorEnum.Zielone)]
        public void PairingService_Should_Return_False(string manDateString, string womanDateString, int manHeight, int womanHeight, EyeColorEnum manEye, EyeColorEnum womanEye)
        {
            DateTime manDate = Convert.ToDateTime(manDateString);
            DateTime womanDate = Convert.ToDateTime(womanDateString);
            PersonViewModel man = new PersonViewModel
            {
                Name = Irrelevant,
                BirthDate = manDate,
                Height = manHeight,
                EyeColor = manEye,
            };
            PersonViewModel woman = new PersonViewModel
            {
                Name = Irrelevant,
                BirthDate = womanDate,
                Height = womanHeight,
                EyeColor = womanEye
            };
            bool result = _pairingService.DoTheyMatch(woman, man);
            Assert.False(result);
        }
    }
}
