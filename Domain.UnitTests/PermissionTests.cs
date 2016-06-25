using System;
using System.Diagnostics;
using System.Security;
using System.Threading.Tasks;

using Basics.Domain;
using Basics.Testing.Xunit;

using FullStackTraining.CallMeBack.Domain.Contracts.Interfaces;
using FullStackTraining.CallMeBack.Domain.UnitTests.Infrastructure;
using FullStackTraining.CallMeBack.Repository.Contracts;

using NSubstitute;

using Xunit;
using Xunit.Abstractions;

namespace FullStackTraining.CallMeBack.Domain.UnitTests
{
    public sealed class XUnitOutputTraceListener : TraceListener
    {
        private readonly ITestOutputHelper _output;

        /// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.TraceListener" /> class.</summary>
        public XUnitOutputTraceListener(ITestOutputHelper output)
        {
            _output = output;
        }

        /// <summary>When overridden in a derived class, writes the specified message to the listener you create in the derived class.</summary>
        /// <param name="message">A message to write. </param>
        public override void Write(string message)
        {
            _output.WriteLine(message);
        }

        /// <summary>When overridden in a derived class, writes a message to the listener you create in the derived class, followed by a line terminator.</summary>
        /// <param name="message">A message to write. </param>
        public override void WriteLine(string message)
        {
            _output.WriteLine(message);
        }
    }

    public sealed class PermissionTests : IClassFixture<UserContextFixture>
    {
        private readonly UserContextFixture _user;
        private readonly IBaseDomain _baseDomain;
        private readonly IRegistrationDomain _registrationDomain;

        public PermissionTests(UserContextFixture userContextFixture, ITestOutputHelper output)
        {
            Trace.Listeners.Add(new XUnitOutputTraceListener(output));
            _user = userContextFixture;
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            _registrationDomain = new RegistrationDomain(registrationRepository);
            _baseDomain = (IBaseDomain)_registrationDomain;
        }

        [Theory(DisplayName = "Authorized users can register callback number")]
        [InlineData(UserTypes.AuthorizedAdmin)]
        public async Task Can_register_callback_number(UserTypes userType)
        {
            Trace.WriteLine("Testing");
            _baseDomain.User = _user[userType];
            await _registrationDomain.RegisterCallbackNumber(null);
        }

        [Theory]
        [InlineData(UserTypes.UnauthorizedAdmin)]
        [InlineData(UserTypes.AuthorizedUser)]
        [InlineData(UserTypes.UnauthorizedUser)]
        public async Task Cannot_register_callback_numbers(UserTypes userType)
        {
            _baseDomain.User = _user[userType];
            await Assert.ThrowsAsync<SecurityException>(() =>
                _registrationDomain.RegisterCallbackNumber(null));
        }

        [Theory]
        [InlineData(UserTypes.AuthorizedAdmin)]
        [InlineData(UserTypes.AuthorizedUser)]
        public async Task Can_search_callback_numbers(UserTypes userType)
        {
            _baseDomain.User = _user[userType];
            await _registrationDomain.SearchCallbackNumbers(null);
        }

        [Theory]
        [InlineData(UserTypes.UnauthorizedAdmin)]
        [InlineData(UserTypes.UnauthorizedUser)]
        public async Task Cannot_search_callback_numbers(UserTypes userType)
        {
            _baseDomain.User = _user[userType];
            await Assert.ThrowsAsync<SecurityException>(() =>
                _registrationDomain.SearchCallbackNumbers(null));
        }

        [Theory]
        [InlineData(UserTypes.AuthorizedAdmin)]
        public async Task Can_register_favorite(UserTypes userType)
        {
            _baseDomain.User = _user[userType];
            await _registrationDomain.RegisterFavorite(null);
        }

        [Theory]
        [InlineData(UserTypes.UnauthorizedAdmin)]
        [InlineData(UserTypes.AuthorizedUser)]
        [InlineData(UserTypes.UnauthorizedUser)]
        public async Task Cannot_register_favorite(UserTypes userType)
        {
            _baseDomain.User = _user[userType];
            await Assert.ThrowsAsync<SecurityException>(() =>
                _registrationDomain.RegisterFavorites(null));
        }

        [Theory]
        [InlineData(UserTypes.AuthorizedAdmin)]
        [InlineData(UserTypes.AuthorizedUser)]
        public async Task Can_search_favorites(UserTypes userType)
        {
            _baseDomain.User = _user[userType];
            await _registrationDomain.SearchFavorites(null);
        }

        [Theory]
        [InlineData(UserTypes.UnauthorizedAdmin)]
        [InlineData(UserTypes.UnauthorizedUser)]
        public async Task Cannot_search_favorites(UserTypes userType)
        {
            _baseDomain.User = _user[userType];
            await Assert.ThrowsAsync<SecurityException>(() =>
                _registrationDomain.SearchFavorites(null));
        }
    }
}
