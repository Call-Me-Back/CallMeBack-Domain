using System.Threading.Tasks;

using Basics.Containers;
using Basics.Domain;
using Basics.Testing.Xunit;

using FullStackTraining.CallMeBack.Domain.Contracts.Interfaces;
using FullStackTraining.CallMeBack.Domain.Contracts.Models;
using FullStackTraining.CallMeBack.Domain.UnitTests.Infrastructure;

using Xunit;

namespace FullStackTraining.CallMeBack.Domain.IntegrationTests
{
    public sealed class RegistrationTests : BaseUserContextTest<ContainerFixture, UserContextFixture>
    {
        private readonly IRegistrationDomain _domain;

        public RegistrationTests(ContainerFixture containerFixture, UserContextFixture userContextFixture)
            : base(containerFixture, userContextFixture)
        {
            var domainFactory = containerFixture.Container.Resolve<IDomainFactory>();
            _domain = domainFactory.Get<IRegistrationDomain>(userContextFixture.AuthorizedAdmin);
        }

        [Fact]
        public async Task Can_register_callback_number()
        {
            await _domain.RegisterCallbackNumber(new CallbackNumber {
                Name = "Test Callback",
                Number = "12345678"
            });
        }
    }
}
