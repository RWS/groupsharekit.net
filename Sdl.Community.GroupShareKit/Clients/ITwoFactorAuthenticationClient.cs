using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface ITwoFactorAuthenticationClient
    {
        Task<bool> GetRequireTwoFaGlobalSetting();

        Task<UserTwoFaSettings> GetUserTwoFaSettings(Guid userId);

        Task ResetTwoFa(Guid userId);

        Task CreateTwoFaSettings(Guid userId);

        Task SetTwoFaStatus(Guid userId, bool enabled);

        Task<UserTwoFaEnforcementStatus> GetTwoFaEnforcementStatus(Guid userId);

        Task<List<UserTwoFaEnforcementStatus>> GetTwoFaEnforcementStatuses(List<Guid> userIds);

        Task SetTwoFaEnforcementStatus(Guid userId, bool require2FA);
    }
}
