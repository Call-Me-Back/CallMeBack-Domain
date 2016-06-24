using Basics.Containers;
using Basics.Domain;
using Basics.Testing.Xunit;

using FullStackTraining.CallMeBack.Domain.UnitTests.Infrastructure;

namespace FullStackTraining.CallMeBack.Domain.UnitTests
{
    public partial class PermissionTest : BaseUserContextTest<ContainerFixture, UserContextFixture>
	{
        private readonly IDomainFactory _domainFactory;

        public PermissionTest(ContainerFixture containerFixture, UserContextFixture userContextFixture)
            : base(containerFixture, userContextFixture)
        {
            _domainFactory = containerFixture.Container.Resolve<IDomainFactory>();
        }
	}
}