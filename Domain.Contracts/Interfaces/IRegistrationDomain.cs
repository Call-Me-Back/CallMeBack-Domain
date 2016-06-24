using System.Collections.Generic;
using System.Threading.Tasks;

using FullStackTraining.CallMeBack.Domain.Contracts.Models;

namespace FullStackTraining.CallMeBack.Domain.Contracts.Interfaces
{
    public interface IRegistrationDomain
    {
        /// <summary>
        ///     Registers one or more callback numbers for the user.
        /// </summary>
        /// <param name="numbers">Collection of callback numbers to register.</param>
        /// <returns>Task object representing the action.</returns>
        Task RegisterCallbackNumbers(IEnumerable<CallbackNumber> numbers);

        /// <summary>
        ///     Searches for callback numbers for the user, given the specified criteria.
        /// </summary>
        /// <param name="criteria">The search criteria to apply.</param>
        /// <returns>Collection of matching callback numbers from the search.</returns>
        Task<CallbackNumberSearchResults> SearchCallbackNumbers(CallbackNumberSearchCriteria criteria);

        Task RegisterFavorites(IEnumerable<Favorite> favorites);

        Task<FavoriteSearchResults> SearchFavorites(FavoriteSearchCriteria criteria);
    }

    public static class RegistrationDomainExtensions
    {
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
