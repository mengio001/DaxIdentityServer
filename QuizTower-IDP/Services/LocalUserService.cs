using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizTower.IDP.DbContexts;
using QuizTower.IDP.Entities;

namespace QuizTower.IDP.Services
{
    public class LocalUserService : ILocalUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<AspNetUser> _passwordHasher;
        private readonly UserManager<AspNetUser> _userManager;

        public LocalUserService(ApplicationDbContext context, IPasswordHasher<AspNetUser> passwordHasher, UserManager<AspNetUser> userManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task<AspNetUser> FindUserByExternalProviderAsync(string provider, string providerIdentityKey)
        {
            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (string.IsNullOrWhiteSpace(providerIdentityKey))
            {
                throw new ArgumentNullException(nameof(providerIdentityKey));
            }

            var userLogin = await _context.AspNetUserLogins.Include(ul => ul.AspNetUser)
                .FirstOrDefaultAsync(ul => ul.Provider == provider && ul.ProviderIdentityKey == providerIdentityKey);

            return userLogin?.AspNetUser;
        }

        public AspNetUser AutoProvisionUser(string provider,
            string providerIdentityKey,
            IEnumerable<Claim> claims)
        {
            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (string.IsNullOrWhiteSpace(providerIdentityKey))
            {
                throw new ArgumentNullException(nameof(providerIdentityKey));
            }

            if (claims is null)
            {
                throw new ArgumentNullException(nameof(claims));
            }

            var user = new AspNetUser()
            {
                Active = true,
                Subject = Guid.NewGuid().ToString()
            };

            foreach (var claim in claims)
            {
                user.Claims.Add(new AspNetUserClaim()
                {
                    Type = claim.Type,
                    Value = claim.Value
                });
            }

            user.Logins.Add(new AspNetUserLogin()
            {
                Provider = provider,
                ProviderIdentityKey = providerIdentityKey
            });

            _context.AspNetUsers.Add(user);
            return user;
        }

        public async Task<AspNetUser> GetUserByEmailAsync(string email)
        {
            if (email is null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            return await _context.AspNetUsers.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddExternalProviderToUser(
            string subject,
            string provider,
            string providerIdentityKey)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (string.IsNullOrWhiteSpace(providerIdentityKey))
            {
                throw new ArgumentNullException(nameof(providerIdentityKey));
            }

            var user = await GetUserBySubjectAsync(subject);
            user.Logins.Add(new AspNetUserLogin()
            {
                Provider = provider,
                ProviderIdentityKey = providerIdentityKey
            });
        }

        public async Task<bool> IsUserActive(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                return false;
            }

            var user = await GetUserBySubjectAsync(subject);

            if (user == null)
            {
                return false;
            }

            return user.Active;
        }

        public async Task<(bool, string?)> ValidateCredentialsAsync(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                return (false, null);
            }

            var user = await GetUserByUserNameAsync(userName);

            if (user == null)
            {
                return (false, null);
            }

            if (!user.Active)
            {
                return (false, "InActive");
            }

            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return ((verificationResult == PasswordVerificationResult.Success), null);
        }

        public async Task<AspNetUser> GetUserByUserNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            return await _context.AspNetUsers
                 .FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<IEnumerable<AspNetUserClaim>> GetUserClaimsBySubjectAsync(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            return await _context.AspNetUserClaims.Where(u => u.AspNetUser.Subject == subject).ToListAsync();
        }

        public async Task<AspNetUser> GetUserBySubjectAsync(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            return await _context.AspNetUsers.FirstOrDefaultAsync(u => u.Subject == subject);
        }

        public async Task AddUserAsync(AspNetUser aspNetUserToAdd, string password)
        {
            if (aspNetUserToAdd == null)
            {
                throw new ArgumentNullException(nameof(aspNetUserToAdd));
            }

            if (_context.AspNetUsers.Any(u => u.UserName == aspNetUserToAdd.UserName))
            {
                throw new Exception("Username must be unique");
            }

            if (_context.AspNetUsers.Any(u => u.Email == aspNetUserToAdd.Email))
            {
                throw new Exception("Email must be unique");
            }

            aspNetUserToAdd.SecurityCode = Convert.ToBase64String(RandomNumberGenerator.GetBytes(128));
            aspNetUserToAdd.SecurityCodeExpirationDate = DateTime.UtcNow.AddHours(1);

            var result = await _userManager.CreateAsync(aspNetUserToAdd, password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            // Note: UserManager.CreateAsync() handles password hashing and add AspNetUser to the DbContext, no need to hash or add AspNetUsers manually.
            //// hash & salt the password
            //aspNetUserToAdd.Password = _passwordHasher.HashPassword(aspNetUserToAdd, password);
            //_context.AspNetUsers.Add(aspNetUserToAdd);
        }

        public async Task<bool> ActivateUserAsync(string securityCode)
        {
            if (string.IsNullOrWhiteSpace(securityCode))
            {
                throw new ArgumentNullException(nameof(securityCode));
            }

            // find a user with this security code as an active security code.  
            var user = await _context.AspNetUsers.FirstOrDefaultAsync(u =>
                u.SecurityCode == securityCode &&
                u.SecurityCodeExpirationDate >= DateTime.UtcNow);

            if (user == null)
                return false;

            user.Active = true;
            user.SecurityCode = null;

            var query = @$"declare @outId INT, @aspNetUser nvarchar(200) = '{user.UserName}';
                    INSERT INTO [TOQ].[User] 
	                    ([CREATED]
	                    ,[CREATEDBY]
	                    ,[CHANGED]
	                    ,[CHANGEDBY]
	                    ,[ConcurrencyStamp]
	                    ,[IsDeleted]
	                    ,[ValidFrom]
	                    ,[ValidUntil])
                    VALUES
	                    (getdate()
	                    ,@aspNetUser
	                    ,getdate()
	                    ,@aspNetUser
	                    ,NEWID()
	                    ,cast(0 as bit)
	                    ,CAST(DATEADD(DAY, 0, GETDATE()) AS DateTime)
	                    ,CAST(DATEADD(YEAR, 1, GETDATE()) AS DateTime));
                    SET @outId = SCOPE_IDENTITY();

                    INSERT INTO [TOQ].[AccountLinkPath] 
	                    ([UserName]
	                    ,[IdentityProviderId]
	                    ,[UserId]
	                    ,[AspNetUserId]
	                    ,[SubjectId])
                    VALUES
	                    (@aspNetUser
	                    ,1
	                    ,@outId
	                    ,'{user.Id}'
	                    ,'{user.Subject}');";

            await ((ApplicationDbContext)_context).Database.ExecuteSqlRawAsync(query);
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
