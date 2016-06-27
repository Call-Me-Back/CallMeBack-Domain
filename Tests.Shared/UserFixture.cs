using System.Collections.Generic;

using Basics.Testing.Xunit;

using static FullStackTraining.CallMeBack.Domain.Contracts.Permissions;

namespace FullStackTraining.CallMeBack.Tests.Shared
{
    public sealed class UserFixture : UserContextFixtureBase
    {
        protected override IEnumerable<string> GetAdminPermissions()
        {
            yield return RegisterCallbackNumbers;
            yield return SearchCallbackNumbers;

            yield return RegisterFavorites;
            yield return SearchFavorites;
        }

        protected override IEnumerable<string> GetUserPermissions()
        {
            yield return SearchCallbackNumbers;
            yield return SearchFavorites;
        }
    }
}
