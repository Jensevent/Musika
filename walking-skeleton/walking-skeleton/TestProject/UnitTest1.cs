using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Xunit;

namespace TestProject
{
    [TestClass]
    public class UnitTest1 : WebApplicationFactory<Program>
    {
        

        [Fact]
        public async void TestMethod1()
        {
            // Arrange
            var webAppFactory = new UnitTest1();
            HttpClient httpClient = webAppFactory.CreateClient();

            // Act
            var response = await httpClient.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public async void b()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(true);
        }
    }
}