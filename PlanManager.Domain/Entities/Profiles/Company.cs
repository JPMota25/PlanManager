using Flunt.Notifications;
using Flunt.Validations;

namespace PlanManager.Domain.Entities.Profiles
{
    public class Company : Entity
    {

        private void Validate()
        {
            var contract = new Contract<Notification>().Requires();
            contract = contract.IsNotNullOrWhiteSpace(IdPerson, "Company.IdPerson", "IdPerson is required");
            AddNotifications(contract);
        }
        public Company(string idPerson) : base(true)
        {
            IdPerson = idPerson;
            Validate();
        }

        public string IdPerson { get; private set; }
        public Person? Person { get; set; }

        protected Company()
        {

        }
    }
}
