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
            Assert.True(passwordComplexityRules.MinimumDigits == 1);
            Assert.True(passwordComplexityRules.MinimumPasswordLength == 3);
            Assert.True(passwordComplexityRules.MinimumLowercaseChars == 1);
            Assert.True(passwordComplexityRules.MinimumSpecialChars == 0);
            Assert.True(passwordComplexityRules.MinimumUppercaseChars == 1);
        }
    }
}
