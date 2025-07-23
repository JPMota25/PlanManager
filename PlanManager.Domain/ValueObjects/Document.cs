using Flunt.Validations;
using PlanManager.Domain.Enums;

namespace PlanManager.Domain.ValueObjects;

public class Document : ValueObject {
	public string Identification { get; private set; }
	public EDocumentType Type { get; private set; }

	public Document(string identification, EDocumentType type) {
		Identification = identification.Replace("-", "").Replace(".", "").Replace(" ", "").Replace("/", "");
		Type = type;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Document>().Requires().IsNotNullOrWhiteSpace(Identification, "Identification needs to be provided")
			.IsTrue(IsValidDocument(Identification, Type), "Invalid document");
		AddNotifications(contract);
	}

	private static bool IsValidDocument(string identification, EDocumentType type) {
		switch (type) {
			case EDocumentType.Person when identification.Length == 11:
			case EDocumentType.Company when identification.Length == 14:
				return true;
			default:
				return false;
		}
	}
}