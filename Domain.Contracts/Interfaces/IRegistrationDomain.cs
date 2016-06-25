using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FullStackTraining.CallMeBack.Domain.Contracts.Models;

namespace FullStackTraining.CallMeBack.Domain.Contracts.Interfaces
{
    public interface IRegistrationDomain
    {
        Task<CallbackNumberCollection> GetCallbackNumbers(IEnumerable<Guid> ids);

        /// <summary>
        ///     Searches for callback numbers for the user, given the specified criteria.
        /// </summary>
        /// <param name="criteria">The search criteria to apply.</param>
        /// <returns>Collection of matching callback numbers from the search.</returns>
        Task<CallbackNumberSearchResults> SearchCallbackNumbers(CallbackNumberSearchCriteria criteria);

        /// <summary>
        ///     Registers one or more callback numbers for the user.
        /// </summary>
        /// <param name="numbers">Collection of callback numbers to register.</param>
        /// <returns>Task object representing the action.</returns>
        Task RegisterCallbackNumbers(IEnumerable<CallbackNumber> numbers);

        Task RegisterFavorites(IEnumerable<Favorite> favorites);

        Task<FavoriteSearchResults> SearchFavorites(FavoriteSearchCriteria criteria);
    }

    public static class RegistrationDomainExtensions
    {
        public static async Task<CallbackNumber> GetCallbackNumber(this IRegistrationDomain domain, Guid id)
        {
            return (await domain.GetCallbackNumbers(new[] { id }))?.FirstOrDefault();
        }

        public static async Task RegisterCallbackNumber(this IRegistrationDomain domain, CallbackNumber number)
        {
            await domain.RegisterCallbackNumbers(new[] {number});
        }

        public static async Task RegisterFavorite(this IRegistrationDomain domain, Favorite favorite)
        {
            await domain.RegisterFavorites(new[] {favorite});
        }
    }
}
