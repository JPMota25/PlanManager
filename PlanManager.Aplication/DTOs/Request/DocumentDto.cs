using PlanManager.Domain.Enums;

namespace PlanManager.Aplication.DTOs.Request;

public class DocumentDto {
	public DocumentDto(string identification, EDocumentType type) {
		Identification = identification;
		Type = type;
	}

	public DocumentDto() {

	}

	public string Identification { get; set; }
	public EDocumentType Type { get; set; }
}