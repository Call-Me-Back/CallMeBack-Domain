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

        Task DeleteCallbackNumbers(IEnumerable<Guid> ids);

        Task RegisterFavorites(IEnumerable<Favorite> favorites);

        Task<FavoriteSearchResults> SearchFavorites(FavoriteSearchCriteria criteria);
    }

    public static class RegistrationDomainExtensions
    {
        public static async Task<CallbackNumber> GetCallbackNumber(this IRegistrationDomain domain, Guid id)
        {
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));
            return (await domain.GetCallbackNumbers(new[] { id }))?.FirstOrDefault();
        }

        public static Task RegisterCallbackNumber(this IRegistrationDomain domain, CallbackNumber number)
        {
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));
            if (number == null)
                throw new ArgumentNullException(nameof(number));
            return domain.RegisterCallbackNumbers(new[] {number});
        }

        public static Task DeleteCallbackNumber(this IRegistrationDomain domain, Guid id)
        {
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));
            return domain.DeleteCallbackNumbers(new[] { id });
        }

        public static Task DeleteCallbackNumbers(this IRegistrationDomain domain, IEnumerable<CallbackNumber> numbers)
        {
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));
            return domain.DeleteCallbackNumbers(numbers.Select(number => number.Id));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static Task DeleteCallbackNumber(this IRegistrationDomain domain, CallbackNumber number)
        {
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));
            if (number == null)
                throw new ArgumentNullException(nameof(number));
            return domain.DeleteCallbackNumbers(new[] { number.Id });
        }

        public static Task RegisterFavorite(this IRegistrationDomain domain, Favorite favorite)
        {
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));
            if (favorite == null)
                throw new ArgumentNullException(nameof(favorite));
            return domain.RegisterFavorites(new[] {favorite});
        }
    }
}
