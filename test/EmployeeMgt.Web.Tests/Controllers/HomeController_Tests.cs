using System.Threading.Tasks;
using EmployeeMgt.Models.TokenAuth;
using EmployeeMgt.Web.Controllers;
using Shouldly;
using Xunit;

namespace EmployeeMgt.Web.Tests.Controllers
{
    public class HomeController_Tests: EmployeeMgtWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}