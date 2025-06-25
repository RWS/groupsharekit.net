using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class TwoFactorAuthenticationClient : ApiClient, ITwoFactorAuthenticationClient
    {
        public TwoFactorAuthenticationClient(IApiConnection apiConnection) : base(apiConnection)
        { 
        }

        public async Task<bool> GetRequireTwoFaGlobalSetting()
        {
            return await ApiConnection.Get<bool>(ApiUrls.TwoFaGlobalSettings(), null);
        }

        public async Task<UserTwoFaSettings> GetUserTwoFaSettings(Guid userId)
        {
            return await ApiConnection.Get<UserTwoFaSettings>(ApiUrls.TwoFaSettings(userId), null);
        }

        public async Task ResetTwoFa(Guid userId)
        {
            await ApiConnection.Delete(ApiUrls.TwoFaSettings(userId));
        }

        public async Task CreateTwoFaSettings(Guid userId)
        {
            await ApiConnection.Post(ApiUrls.TwoFaSettings(userId));
        }

        public async Task SetTwoFaStatus(Guid userId, bool enabled)
        {
            await ApiConnection.Put(ApiUrls.SetTwoFaStatus(userId, enabled));
        }

        public async Task<UserTwoFaEnforcementStatus> GetTwoFaEnforcementStatus(Guid userId)
        {
            return await ApiConnection.Get<UserTwoFaEnforcementStatus>(ApiUrls.UserTwoFaEnforcementStatus(userId), null);
        }

        public async Task<List<UserTwoFaEnforcementStatus>> GetTwoFaEnforcementStatuses(List<Guid> userIds)
        {
            Ensure.ArgumentNotNull(userIds, "userIds");

            return await ApiConnection.Post<List<UserTwoFaEnforcementStatus>>(ApiUrls.UsersTwoFaEnforcementStatuses(userIds), userIds, "application/json");
        }

        public async Task SetTwoFaEnforcementStatus(Guid userId, bool require2FA)
        {
            await ApiConnection.Put(ApiUrls.SetTwoFaEnforcementStatus(userId, require2FA));
        }



    }
}
