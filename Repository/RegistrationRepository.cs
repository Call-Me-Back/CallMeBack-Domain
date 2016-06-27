using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FullStackTraining.CallMeBack.Domain.Contracts.Models;
using FullStackTraining.CallMeBack.Repository.Contracts;

namespace FullStackTraining.CallMeBack.Repository
{
    public sealed class RegistrationRepository : IRegistrationRepository
    {
        Task<CallbackNumberCollection> IRegistrationRepository.GetCallbackNumbers(IEnumerable<Guid> ids)
        {
            throw new InvalidOperationException();
        }

        Task IRegistrationRepository.RegisterCallbackNumbers(IEnumerable<CallbackNumber> numbers)
        {
            return Task.FromResult(0);
        }

        Task<CallbackNumberSearchResults> IRegistrationRepository.SearchCallbackNumbers(CallbackNumberSearchCriteria criteria)
        {
            throw new System.NotImplementedException();
        }

        Task IRegistrationRepository.RegisterFavorites(IEnumerable<Favorite> favorites)
        {
            return Task.FromResult(0);
        }

        Task<FavoriteSearchResults> IRegistrationRepository.SearchFavorites(FavoriteSearchCriteria criteria)
        {
            throw new System.NotImplementedException();
        }
    }
}