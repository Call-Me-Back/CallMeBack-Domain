using Basics.Containers;
using Basics.Testing.Xunit;

using FullStackTraining.CallMeBack.Domain;

namespace FullStackTraining.CallMeBack.Tests.Shared
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
