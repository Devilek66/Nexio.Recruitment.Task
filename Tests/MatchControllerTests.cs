using Moq;
using Nexio.Recruitment.Task.Controllers;
using Nexio.Recruitment.Task.Models;
using Nexio.Recruitment.Task.Models.ViewModels;
using Nexio.Recruitment.Task.Services.ServicesInterfaces;
using System;
using System.Web;
using System.Web.Mvc;
using Xunit;

namespace Tests
{
    public class MatchControllerTests
    {
        private const string Man = "Man";
        private const string Woman = "Woman";
        private const string Result = "Result";
        private readonly MatchController _matchController;
        private readonly Mock<IPairingService> _mockPairingService;
        private readonly Mock<HttpSessionStateBase> _mockSession;
        private readonly Mock<ControllerContext> _mockContext;

        private PersonViewModel _examplePerson = new PersonViewModel
        {
            Name = "Aleksander",
            BirthDate = new DateTime(1993,11,3),
            Height = 170,
            EyeColor = EyeColorEnum.Niebieskie,
        };

        public MatchControllerTests()
        {
            _mockContext = new Mock<ControllerContext>();
            _mockSession = new Mock<HttpSessionStateBase>();
            _mockSession.SetupSet<PersonViewModel>(x => x[Man] = It.IsAny<PersonViewModel>());
            _mockSession.SetupGet(s => s[Man]).Returns(_examplePerson);
            _mockSession.SetupSet<PersonViewModel>(x => x[Woman] = It.IsAny<PersonViewModel>());
            _mockSession.SetupGet(s => s[Woman]).Returns(_examplePerson);
            _mockPairingService = new Mock<IPairingService>();
            _mockPairingService.Setup(x => x.DoTheyMatch(It.IsAny<PersonViewModel>(), It.IsAny<PersonViewModel>())).Returns(true);
            _matchController = new MatchController(_mockPairingService.Object);
            _mockContext.Setup(p => p.HttpContext.Session).Returns(_mockSession.Object);
            _matchController.ControllerContext = _mockContext.Object;
        }

        [Fact]
        public void Man_Action_Should_Return_RedirectToRouteResult_With_Value_Equal_Result()
        {
            RedirectToRouteResult result = _matchController.Man(_examplePerson) as RedirectToRouteResult;
            Assert.True(result.RouteValues.ContainsKey("action"));
            Assert.True(result.RouteValues.ContainsValue(Result));
        }

        [Fact]
        public void Woman_POST_Should_Return_RedirectToRouteResult_With_Value_Equal_Man()
        {
            RedirectToRouteResult result = _matchController.Woman(_examplePerson) as RedirectToRouteResult;
            Assert.True(result.RouteValues.ContainsKey("action"));
            Assert.True(result.RouteValues.ContainsValue(Man));
        }

        [Fact]
        public void Result_Should_Invoke_Service_Once_And_Return_ResultViewModel()
        {
            ViewResult result = _matchController.Result() as ViewResult;
            Assert.Equal(typeof(ResultViewModel), result.Model.GetType());
            _mockPairingService.Verify(x => x.DoTheyMatch(It.IsAny<PersonViewModel>(), It.IsAny<PersonViewModel>()), Times.Once);
        }
    }
}
