

using System.Security;
using System.Threading.Tasks;

using Basics.Containers;
using Basics.Domain;
using Basics.Testing.Xunit;

using FullStackTraining.CallMeBack.Domain.Contracts.Interfaces;
using FullStackTraining.CallMeBack.Tests.Shared;

using Xunit;

namespace FullStackTraining.CallMeBack.Domain.UnitTests
{
    public partial class PermissionTest : BaseUserContextTest<ContainerFixture, UserFixture>
	{
        private readonly IDomainFactory _domainFactory;

        public PermissionTest(ContainerFixture containerFixture, UserFixture userFixture)
            : base(containerFixture, userFixture)
        {
            _domainFactory = containerFixture.Container.Resolve<IDomainFactory>();
        }
	}
}