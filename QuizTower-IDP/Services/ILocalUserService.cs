using System.Security.Claims;
using QuizTower.IDP.Entities;

namespace QuizTower.IDP.Services
{
    public interface ILocalUserService
    {
        Task<AspNetUser> GetUserByEmailAsync(string email);

        Task AddExternalProviderToUser(
            string subject,
            string provider,
            string providerIdentityKey);

        Task<AspNetUser> FindUserByExternalProviderAsync(
            string provider,
            string providerIdentityKey);
        
        public AspNetUser AutoProvisionUser(string provider,
            string providerIdentityKey,
            IEnumerable<Claim> claims);

        Task<(bool, string?)> ValidateCredentialsAsync(
             string userName,
             string password);

        Task<IEnumerable<AspNetUserClaim>> GetUserClaimsBySubjectAsync(
            string subject);

        Task<AspNetUser> GetUserByUserNameAsync(
            string userName);

        Task<AspNetUser> GetUserBySubjectAsync(
            string subject);

        Task AddUserAsync(AspNetUser aspNetUserToAdd, string password);

        Task<bool> IsUserActive(string subject);

        Task<bool> ActivateUserAsync(string securityCode);

        Task<bool> SaveChangesAsync();
    }
}
