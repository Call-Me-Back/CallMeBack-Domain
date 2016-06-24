namespace FullStackTraining.CallMeBack.Domain.Contracts.Models
{
    public sealed class Favorite : DomainModel
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Notes { get; set; }
    }
}