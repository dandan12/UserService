using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UserService.Controllers;
using UserService.Entities;
using UserService.Models;
using UserService.Repositories.Interface;
using UserService.Services.Interface;

namespace UserService.Tests
{
    public class UserControllerTests
    {
        private Mock<IPartnerRepository> _partnerRepository;
        private Mock<IUserService> _userService;
        public UserControllerTests()
        {
            _partnerRepository = new Mock<IPartnerRepository>();
            _userService = new Mock<IUserService>();
        }

        [Fact]
        public void Authenticate_should_return_unauthorized_when_invalid_username_or_password()
        {
            var request = new AuthenticateRequest()
            {
                Username = "invalid",
                Password = "invalid"
            };
            _partnerRepository
                .Setup(x => x.GetPartnerByCredential(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Partner)null);

            var controller = new UserController(_partnerRepository.Object, _userService.Object);
            var response = controller.Authenticate(request);
            Assert.IsType<UnauthorizedResult>(response);
        }

        [Fact]
        public void Authenticate_should_return_token()
        {
            var request = new AuthenticateRequest()
            {
                Username = "invalid",
                Password = "invalid"
            };

            var partner = GetPartner();
            _partnerRepository
                .Setup(x => x.GetPartnerByCredential(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(partner);

            var token = GetToken();
            _userService.Setup(x => x.GenerateToken(It.IsAny<Partner>())).Returns(token);

            var controller = new UserController(_partnerRepository.Object, _userService.Object);
            var response = controller.Authenticate(request);
            Assert.IsType<OkObjectResult>(response);

            var obj = response as OkObjectResult;
            Assert.IsType<TokenResponse>(obj?.Value);

            var tokenResponse = obj.Value as TokenResponse;
            tokenResponse.Should().BeEquivalentTo(token);
        }

        private Partner GetPartner()
        {
            return new Partner()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "name",
                Address = "address",
                ContactNumber = "contact number",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Password = "password",
                UrlCallback = "https://localhost:8000/callback",
                Username = "username"
            };
        }

        private TokenResponse GetToken()
        {
            return new TokenResponse()
            {
                AccessToken = "access_token",
                ExpiresIn = 60,
                TokenType = "type"
            };
        }
    }
}