using System;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Tests.Integration
{
    public static class Helper
    {
        public static Uri BaseUri => new Uri("http://gs2017dev.sdl.com/");
        public static string TestOrganization => Helper.GetVariable("GROUPSHAREKIT_TESTORGANIZATION");

        public static string groupShareUserOne = Helper.GetVariable("GROUPSHAREKIT_USERNAME");
        public static string groupSharePasswordOne = Helper.GetVariable("GROUPSHAREKIT_PASSWORD");

        public static string GetVariable(string key)
        {
            // by default it gets a process variable. Allow getting user as well
            return Environment.GetEnvironmentVariable(key) ??
                Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.User);
        }

        public static async Task<IGroupShareClient> GetGroupShareClient()
        {
            var groupShareUser = Helper.GetVariable("GROUPSHAREKIT_USERNAME");
            var groupSharePassword = Helper.GetVariable("GROUPSHAREKIT_PASSWORD");
            //var groupShareBearerId = "Bearer AAIAAITFor2ElfRG5beUcf1NY-21uZgjCE2wGvmF6SNP6B6G8yvSTb9rtEZx318EVde4NAFdh5T9NIPe4-Fv8rI6krUDv0xw0XsaNHtMEDwCk2vd1lpIPbQPAMHp1jouKtMVQXdF4Q8p_mv66WU79vctnFpVTYeY6uH_s4oSVCMRJpyNsbnyX5EvhA4-h0jT0KGwW0ghQupIZEUhDBCRpgrS5U8SmREiYhcfqbvec0fgGO_hkSi8kVofrMnISenlVS-iurCfUp9Vq07GutpijJtwt6sfwtD_ISGcn3emgPUGyt7v0U2GlxHlfmjcE1CDlRHVYsM2zdMMx2ikBaEUDh0HRTLe4UpImdVtvTkvA23qBhPQrEOQAT92VaSmMIW6NRM14Mby9t2kV8huUdjxr_rP69Tmi6uFovqtejmMnRCr5Apd7Rya5qGSECAwzAIrPt97KcD0eN2g13me6z1yx1QyvVB0XTDDAhqB3Wq9R1q0eSxpQUESxUMA31MUX9uPgybHgmXen158VRt9nUnH9drLz9qvhmV5ToKsdOgv6NV4ELRpsF41EM3ISr25RMdyZGwi2otZozCNa1VhHooV3bEY-e4fiI65YwXafJDNeM3FJNdLYbmdopwJ5TbrZcF5RDVLPafPBfKk899k6cwA3hEmMEmIjwaArhaGHZW20FKZ35L2tAIAAAACAABOP-h8_qknygIuXh1-320cJlA7e5si75-3wRlhJEj-CYGahiOeXKqvwDzcQodioIzNTlvsdujKFtvlqi2iayhDeynKoE3ILI3-pI-XC_RaQ1ItzTBiMo3YUJdWFE7xhbG6lZq5TCUTY9Ci-nZMAIrj5r99Wn9QoD2a_YWQMDnOtJcEL512M2SNK-0Ng5beeDljis6XiFy8ObfSoHH020-O9hNcfDMeQbbGRahT6PIlWP8ugQJ17ygvJmAIo7dCV3rBO_6pCpLnyxZ6GJ_Y5L1ipaI_hf3RUuJCg2WVTnO-AnDPzF1rmKAG9CV0JBN9ylGG6EXQCmmNaVOldvV9sXFxrd4uBk9sfSwK6QEQpluTmmrTnTYKZVLHf4zQ0mvQoj0no9lOUNdz6EJdrS2sQpKcdlMbAbVOsJenH134w8KQ34Ccwn1BqGVstCIslTLGEDnIXrGzvKarvFX6UyvwWGdXXhJjlQwISCrmmrrd76u9NCv9I6ddqYB_dogcg_zAkh6ai8aokhitS4aadTAbMjyJ-5YmltBua6gA8j9ts_cYwybtj707_s-87EVaELOg8slyhGwKQAkyOebzG1j-T1aIOUdJjl0hzdtoHzpQo_8jQ4IW5O8mUE2sr4x_H0zu1PdnYFBmWvkCXBrqOjJYJ4my6Ie8gr47JakcxeylHzYPae3Ab-1NNOvKY-YJaY3QHbscVISEKCOjffV0osw3OGSCe_3S53tuNZO5y8x6_82I40XA499OGIbVtWp6khqfGyQSY5PLEV2lUcvzp6XLgWSA8eoqb2siwEf48Hgf_6anpS4Rc7VTViCrPQEvD7phHzTY0A__Nt7lfHs1hGk5RUW5K-iRZi8GRFJL29tLAVwOpKldarMn-3VjGgMDTpjp7Ny9EPl2DHWDpDHc0wal0nWC";

            var groupShareBearerId = Helper.GetVariable("GROUPSHAREKIT_BEARERID");

            var token = await GroupShareClient.GetRequestToken(
                groupShareUser,
                groupSharePassword,
                BaseUri,
                GroupShareClient.AllScopes);

            var gsClient = await GroupShareClient.AuthenticateClient(
                token,
                groupShareUser,
                groupSharePassword,
                groupShareBearerId,
                BaseUri,
                GroupShareClient.AllScopes);

            return gsClient;
        }
    }
}