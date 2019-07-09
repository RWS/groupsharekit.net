using System;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Tests.Integration
{
    public static class Helper
    {
        public static Uri BaseUri => new Uri("http://cljvmaelvedi01");
        public static string TestOrganization => Helper.GetVariable("GROUPSHAREKIT_TESTORGANIZATION");

        public static string GetVariable(string key)
        {
            // by default it gets a process variable. Allow getting user as well
            return Environment.GetEnvironmentVariable(key) ??
                Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.User);
        }

        public static async Task<IGroupShareClient> GetGroupShareClient()
        {
            var groupShareUser = "sa";
            var groupSharePassword = "sa";
            var groupShareBearerId = "Bearer AAIAAB17HjKR1wEDjbJnL9oK9zq5lNjwoPjiYQ-QBjzHA6X6F4G_SajezkEyoWJo7TnSvVr9EhEOw5Mu9nZHsXeAVm5TAvPH3tP3yc5_9gFOTsoiLS4Cc0Y9_HeViNuMxnLRBOqjlt1WHZ6fMgjeWfWs5r5PO1ri-ohvVKbG3EZHYBDKI166VIsHX5I85vw4VlHi606bUizkVlcWxq4Hvf_cbavM6GA2rUopnoxaXmFuaWVjXg_VuBC1SBxR0u9g8sSO15KXHT9HnX9LO5Z5bhcCTYB0UVPB7acO6T7DBsOBPuxDd67Rs20Z8GXqyZ8CM_k8JuGbE2cwAKl0kebFkEOkMu2pSh1j01xjUM9lqokjO9M1Oz1wfQ14__HT65jeWJLWjsJoHpGoeQiBaly2TFfXptn2hbr6HcbnkM1U9i3F_OJYrfqIlNVI4XsOBk2K6wneSSEK9w9oRnba_JSeHGFWeb_q-3sxw4j-FKfy-KfzLLBCtE2gmWhFPzrKCBLCJ9mNSTpS2osPC0tBLUfmy7P15EDUi0Q_gIHz3a6gULvVVHAafI02YubOZrO1jG8MjZ9RVTY7sZcAZDwI4gko-wWwYLjHPD9034SF7rARhH8g7sm9VFNfhL2XkdEDGgAE0dGBPYd61H1_wm7QMHT6jsDA_gfGY9PBsjwj9MejnLrDPp3ipAIAAAACAABA_I6SvJ_A0SCAiOm4xVHI3k74x633ASi8fRb1bn-2WI5kHp2Do61ElDLTE5wxtRSzr66zoaplrPvrzbdor28BP2JzRDKHfjjGotsBp4yf3SLcWrbjAWA7KWhsmenHg09an073dAZviT6aZ27hrrMh8ZqXkwJjgA2oBfJfEBLtFmy3FlMrM9F68KHPmKutriEOJKPS2-1rftKPjbaKwdPsjQCMYCS-xIzsmtObgD2I01z06ox8akjcnWuqlao5DE8fDcnVhdfpgJJp2rWbfI5sS0ISQMbjGfrnk2gvmNBwahIEJvtba25_9B2X8dDkL8UXFfRmDbeVHyxoNnaxcuqeRWgWKLMn_94yQCLok7fQfPAGCqE5qywo1i9aAXC95zG6sCWTIybrbxVs75DBXJt-HU2z3tlFhk1N1sDBxPXYAaWP19MnqXr0trC9ceSJkL-3AetXt87uHbwrm5gn3M8ilspLi9QmNbXKqs3fRullLl34lk214VNDhnWhGWE0ZAECg7Pkq6e5EOdv7pnA7h4JctKUSRDc7l5FXPfWl5hfz-bCkLoW2r6M5nQihi2oT7orREtP6frTE4ibOX9aQn2Ol5ZXrgIfcuytlAI5YXITlX16NfoDJKdqgy3ghVsY9FvSa4f4526GZlVkBFzyDPz6mHJ5Z7Vec0MPS3ZszgwmaZUlrHN7wXfoe0Gbw3M9BavrDx9VyYfpbXSnrb1TDo_kRZ0TWfWlDIsGDbGWYlBHMhmqf-jDW2K5chPWolToMhwm0hQZGDvdkCNLdCgmKNvglnenlUiHGq-tusmLA2Od3gP98wG_XU2ROBC6sOdXquh0Jefo9cn0F9_5egNzKOHW4rj6wgMkNkU5sPJwzfKmWChuN1ZC-qGQTU8jM2BgghI";

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