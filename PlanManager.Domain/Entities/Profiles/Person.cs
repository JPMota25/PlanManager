using Flunt.Validations;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.Profiles;

public class Person : Entity {
	public void SetPersonStatus(EPersonStatus status) {
		Status = status;
	}

	public void SetFullName(FullName fullName) {
		FullName = fullName;
		Validate();
	}

	public void SetEmail(Email email) {
		Email = email;
		Validate();
	}

	public void SetDocument(Document document) {
		Document = document;
		Validate();
	}

	public void SetPhone(Phone phone) {
		Phone = phone;
		Validate();
	}

	public void SetAddress(Address address) {
		Address = address;
		Validate();
	}

	public EPersonStatus Status { get; private set; }
	public FullName FullName { get; private set; }
	public Email Email { get; private set; }
	public Document Document { get; private set; }
	public Phone Phone { get; private set; }
	public Address Address { get; private set; }

	public Person() { }

	public Person(FullName fullName, Email email, Document document, Phone phone, Address address) {
		FullName = fullName;
		Email = email;
		Document = document;
		Phone = phone;
		Address = address;
		Status = EPersonStatus.Active;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Person>().IsTrue(Document.IsValid, "Person.Document", "Not a valid document");
		AddNotifications(Document.Notifications);
		contract.IsTrue(FullName.IsValid, "Person.FullName", "Not a valid full name");
		AddNotifications(FullName.Notifications);
		contract.IsTrue(Email.IsValid, "Person.Email", "Not a valid email");
		AddNotifications(Email.Notifications);
		contract.IsTrue(Phone.IsValid, "Person.Phone", "Not a valid phone");
		AddNotifications(Phone.Notifications);
		contract.IsTrue(Address.IsValid, "Person.Address", "Not a valid address");
		AddNotifications(Address.Notifications);
		AddNotifications(contract);
	}
}