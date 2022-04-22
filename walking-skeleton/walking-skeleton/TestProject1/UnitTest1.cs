using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var foo = new WebApplicationFactory<Program>();
            var bar = foo.CreateClient();

            var baz = await bar.GetAsync("/");
            var boo = await baz.Content.ReadAsStringAsync();

            Assert.AreEqual("Hello World", boo);
        }
    }
}