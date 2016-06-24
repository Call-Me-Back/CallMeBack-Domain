using System.Collections.Generic;

using Basics.Models;

namespace FullStackTraining.CallMeBack.Domain.Contracts.Models
{
    public sealed class CallbackNumberSearchCriteria : SearchCriteria<CallbackNumberFilterField, CallbackNumberSortField>
    {
    }

    public enum CallbackNumberFilterField
    {
        Name,
        Number
    }

    public enum CallbackNumberSortField
    {
        Name,
        Number
    }

    public sealed class CallbackNumberSearchResults : SearchResults<CallbackNumber>
    {
        public CallbackNumberSearchResults(IReadOnlyList<CallbackNumber> data, int totalCount) : base(data, totalCount)
        {
        }

        public CallbackNumberSearchResults(IEnumerable<CallbackNumber> data, int totalCount) : base(data, totalCount)
        {
        }
    }
}