using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface ITwoFactorAuthenticationClient
    {
        /// <summary>
        /// Gets the Two-Factor Authentication global setting.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        Task<bool> GetRequireTwoFaGlobalSetting();

        /// <summary>
        /// Gets the Two-Factor Authentication settings for a user.
        /// </summary>
        /// <returns><see cref="UserTwoFaSettings"/></returns>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        Task<UserTwoFaSettings> GetUserTwoFaSettings(Guid userId);

        /// <summary>
        /// Deletes the Two-Factor Authentication settings for a user.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        Task ResetTwoFa(Guid userId);

        /// <summary>
        /// Creates and persists the Two-Factor Authentication settings for a user.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        Task CreateTwoFaSettings(Guid userId);

        /// <summary>
        /// Updates the Enabled flag of the Two-Factor Authentication settings for a user. 
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        Task SetTwoFaStatus(Guid userId, bool enabled);

        /// <summary>
        /// Gets the Two-Factor Authentication status for a user.
        /// </summary>
        /// <returns><see cref="UserTwoFaEnforcementStatus"/></returns>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        Task<UserTwoFaEnforcementStatus> GetTwoFaEnforcementStatus(Guid userId);

        /// <summary>
        /// Gets the Two-Factor Authentication status for multiple users.
        /// </summary>
        /// <returns>A list of <see cref="UserTwoFaEnforcementStatus"/> objects.</returns>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        Task<List<UserTwoFaEnforcementStatus>> GetTwoFaEnforcementStatuses(List<Guid> userIds);

        /// <summary>
        /// Sets the Two-Factor Authentication enforcement status for a user.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        Task SetTwoFaEnforcementStatus(Guid userId, bool require2FA);
    }
}
