using System.Collections.Generic;

using Basics.Testing.Xunit;

using FullStackTraining.CallMeBack.Domain.Contracts;

namespace FullStackTraining.CallMeBack.Domain.UnitTests.Infrastructure
{
    public sealed class UserContextFixture : UserContextFixtureBase
    {
        protected override IEnumerable<string> GetAdminPermissions()
        {
            yield return Permissions.RegisterCallbackNumbers;
            yield return Permissions.SearchCallbackNumbers;

            yield return Permissions.RegisterFavorites;
            yield return Permissions.SearchFavorites;
        }

        protected override IEnumerable<string> GetUserPermissions()
        {
            yield return Permissions.SearchCallbackNumbers;
            yield return Permissions.SearchFavorites;
        }
    }
}
