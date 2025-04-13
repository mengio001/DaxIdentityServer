using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using QuizTower.IDP.PasswordValidators;
using QuizTower.IDP.Entities;

namespace QuizTower.IDP.Test
{
    [TestFixture]
    public class ForbiddenPasswordValidatorTest
    {
        private AspNetUser user;
        private ForbiddenPasswordValidator<AspNetUser> validator;

        // Arrange
        [SetUp]
        public void Setup()
        {
            user = new AspNetUser
            {
                UserName = "Username@test.nl",
                Email = "Email@test.nl"
            };

            validator = CreateValidator();
        }

        [Test]
        public void PasswordBlackListTest()
        {
            // Act
            Assert.Multiple(async () =>
            {
                // Assert
                await AssertInvalidPassword(validator, user, "something with username@test.nl");
                await AssertInvalidPassword(validator, user, "something with test");
                await AssertInvalidPassword(validator, user, "something with admin");
                await AssertInvalidPassword(validator, user, "something with password");
                await AssertInvalidPassword(validator, user, "InvalidPassword123!");
            });
        }

        [Test]
        public void PasswordWhiteListTest()
        {
            // Act
            Assert.Multiple(async () =>
            {
                // Assert
                await AssertValidPassword(validator, user, "AbC-XyZ-123!");
                await AssertValidPassword(validator, user, "AnotherValidPass1!");
            });
        }

        private static async Task AssertValidPassword(IPasswordValidator<AspNetUser> validator, AspNetUser user, string password)
        {
            var result = await validator.ValidateAsync(null, user, password);
            Assert.That(result.Succeeded, Is.True);
        }

        private static async Task AssertInvalidPassword(IPasswordValidator<AspNetUser> validator, AspNetUser user, string password)
        {
            var result = await validator.ValidateAsync(null, user, password);
            Assert.That(result.Succeeded, Is.False);
        }

        private static ForbiddenPasswordValidator<AspNetUser> CreateValidator()
        {
            return new ForbiddenPasswordValidator<AspNetUser>();
        }
    }
}