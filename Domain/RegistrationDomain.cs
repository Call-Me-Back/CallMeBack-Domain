using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Basics;
using Basics.Domain;

using FullStackTraining.CallMeBack.Domain.Contracts;
using FullStackTraining.CallMeBack.Domain.Contracts.Interfaces;
using FullStackTraining.CallMeBack.Domain.Contracts.Models;
using FullStackTraining.CallMeBack.Repository.Contracts;

namespace FullStackTraining.CallMeBack.Domain
{
    /// <summary>
    /// Handles registration
    /// </summary>
    public sealed class RegistrationDomain : BaseDomain, IRegistrationDomain
    {
        private readonly IRegistrationRepository _repository;

        public RegistrationDomain(IRegistrationRepository repository)
        {
            _repository = repository;
        }

        async Task<CallbackNumberCollection> IRegistrationDomain.GetCallbackNumbers(IEnumerable<Guid> ids)
        {
            User.Demand(Permissions.SearchCallbackNumbers);
            return await _repository.GetCallbackNumbers(ids);
        }

        async Task IRegistrationDomain.RegisterCallbackNumbers(IEnumerable<CallbackNumber> numbers)
        {
            User.Demand(Permissions.RegisterCallbackNumbers);
            await _repository.RegisterCallbackNumbers(numbers);
        }

        async Task<CallbackNumberSearchResults> IRegistrationDomain.SearchCallbackNumbers(
            CallbackNumberSearchCriteria criteria)
        {
            User.Demand(Permissions.SearchCallbackNumbers);
            return await _repository.SearchCallbackNumbers(criteria);
        }

        async Task IRegistrationDomain.RegisterFavorites(IEnumerable<Favorite> favorites)
        {
            User.Demand(Permissions.RegisterFavorites);
            await _repository.RegisterFavorites(favorites);
        }

        async Task<FavoriteSearchResults> IRegistrationDomain.SearchFavorites(FavoriteSearchCriteria criteria)
        {
            User.Demand(Permissions.SearchFavorites);
            return await _repository.SearchFavorites(criteria);
        }
    }
}
