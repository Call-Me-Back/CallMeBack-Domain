using Basics.Containers;
using Basics.Testing.Xunit;

namespace FullStackTraining.CallMeBack.Domain.UnitTests.Infrastructure
{
    public sealed class ContainerFixture : ContainerFixtureBase
    {
        public ContainerFixture() : base(Registration)
        {
        }

        private static void Registration(IContainerBuilder builder)
        {
            ContainerSetup.Setup(builder);
        }
    }
}
