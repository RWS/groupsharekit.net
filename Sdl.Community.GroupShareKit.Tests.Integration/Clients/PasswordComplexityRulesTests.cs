using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class PasswordComplexityRulesTests
    {
        [Fact]
        public async Task PasswordComplexityRules()
        {
            var groupShareClient = Helper.GsClient;

            var passwordComplexityRules = await groupShareClient.PasswordComplexityRules.GetPasswordConstraints();
            Assert.Equal(1, passwordComplexityRules.MinimumDigits);
            Assert.Equal(3, passwordComplexityRules.MinimumPasswordLength);
            Assert.Equal(1, passwordComplexityRules.MinimumLowercaseChars);
            Assert.Equal(0, passwordComplexityRules.MinimumSpecialChars);
            Assert.Equal(1, passwordComplexityRules.MinimumUppercaseChars);
        }
    }
}
