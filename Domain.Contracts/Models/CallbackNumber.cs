using System.Collections.ObjectModel;

namespace FullStackTraining.CallMeBack.Domain.Contracts.Models
{
    public sealed class CallbackNumber : DomainModel
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }

    public sealed class CallbackNumberCollection : Collection<CallbackNumber>
    {
    }
}
