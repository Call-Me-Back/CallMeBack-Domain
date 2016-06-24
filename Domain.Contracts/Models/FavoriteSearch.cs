using System.Collections.Generic;

using Basics.Models;

namespace FullStackTraining.CallMeBack.Domain.Contracts.Models
{
    public sealed class FavoriteSearchCriteria : SearchCriteria<FavoriteFilterField, FavoriteSortField>
    {
        public string Notes { get; set; }
    }

    public enum FavoriteFilterField
    {
        Name,
        Number
    }

    public enum FavoriteSortField
    {
        Name,
        Number
    }

    public sealed class FavoriteSearchResults : SearchResults<Favorite>
    {
        public FavoriteSearchResults(IReadOnlyList<Favorite> data, int totalCount) : base(data, totalCount)
        {
        }

        public FavoriteSearchResults(IEnumerable<Favorite> data, int totalCount) : base(data, totalCount)
        {
        }
    }
}