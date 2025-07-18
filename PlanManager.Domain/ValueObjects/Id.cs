namespace PlanManager.Domain.ValueObjects;

public class Id : ValueObject {
	public string Identifier { get; private set; }

	public Id(string identifier) {
		Identifier = identifier;
	}

	public static Id New() {
		return new Id(Guid.NewGuid().ToString("N")[..11]);
	}

	public static Id Empty => new(Guid.Empty.ToString("N")[..11]);

	public override string ToString() {
		return Identifier;
	}
}