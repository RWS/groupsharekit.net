using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response.TwoFactorAuthentication;
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

        /// <summary>
        /// Gets the Two-Factor Authentication global setting.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task<bool> GetRequireTwoFaGlobalSetting()
        {
            return await ApiConnection.Get<bool>(ApiUrls.TwoFaGlobalSettings(), null);
        }

        /// <summary>
        /// Gets the Two-Factor Authentication settings for a user.
        /// </summary>
        /// <returns><see cref="UserTwoFaSettings"/></returns>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task<UserTwoFaSettings> GetUserTwoFaSettings(Guid userId)
        {
            return await ApiConnection.Get<UserTwoFaSettings>(ApiUrls.TwoFaSettings(userId), null);
        }

        /// <summary>
        /// Deletes the Two-Factor Authentication settings for a user.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task ResetTwoFa(Guid userId)
        {
            await ApiConnection.Delete(ApiUrls.TwoFaSettings(userId));
        }

        /// <summary>
        /// Creates and persists the Two-Factor Authentication settings for a user.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task<CreateTwoFaSettingsResponse> CreateTwoFaSettings(Guid userId)
        {
            return await ApiConnection.Post<CreateTwoFaSettingsResponse>(ApiUrls.TwoFaSettings(userId));
        }

        /// <summary>
        /// Updates the Enabled flag of the Two-Factor Authentication settings for a user. 
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task SetTwoFaStatus(Guid userId, bool enabled)
        {
            await ApiConnection.Put(ApiUrls.SetTwoFaStatus(userId, enabled));
        }

        /// <summary>
        /// Gets the Two-Factor Authentication status for a user.
        /// </summary>
        /// <returns><see cref="UserTwoFaEnforcementStatus"/></returns>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task<UserTwoFaEnforcementStatus> GetTwoFaEnforcementStatus(Guid userId)
        {
            return await ApiConnection.Get<UserTwoFaEnforcementStatus>(ApiUrls.UserTwoFaEnforcementStatus(userId), null);
        }

        /// <summary>
        /// Gets the Two-Factor Authentication status for multiple users.
        /// </summary>
        /// <returns>A list of <see cref="UserTwoFaEnforcementStatus"/> objects.</returns>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task<List<UserTwoFaEnforcementStatus>> GetTwoFaEnforcementStatuses(List<Guid> userIds)
        {
            Ensure.ArgumentNotNull(userIds, "userIds");

            return await ApiConnection.Post<List<UserTwoFaEnforcementStatus>>(ApiUrls.UsersTwoFaEnforcementStatuses(userIds), userIds, "application/json");
        }

        /// <summary>
        /// Sets the Two-Factor Authentication enforcement status for a user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="require2FA">A boolean value indicating whether 2FA should be enforced (true) or not (false) for the user.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks> 
        public async Task SetTwoFaEnforcementStatus(Guid userId, bool require2FA)
        {
            await ApiConnection.Put(ApiUrls.SetTwoFaEnforcementStatus(userId, require2FA));
        }



    }
}
