using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FullStackTraining.CallMeBack.Domain.Contracts.Models;

namespace FullStackTraining.CallMeBack.Repository.Contracts
{
    public interface IRegistrationRepository
    {
        Task<CallbackNumberCollection> GetCallbackNumbers(IEnumerable<Guid> ids);
        Task RegisterCallbackNumbers(IEnumerable<CallbackNumber> numbers);
        Task<CallbackNumberSearchResults> SearchCallbackNumbers(CallbackNumberSearchCriteria criteria);

        Task RegisterFavorites(IEnumerable<Favorite> favorites);
        Task<FavoriteSearchResults> SearchFavorites(FavoriteSearchCriteria criteria);
    }
}