using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;
using Xunit;

namespace PlanManager.Tests.Entities.Profiles;

public class PersonTest
{
    private Person CreateValidPerson(
        EDocumentType type = EDocumentType.Person,
        string? document = null,
        bool hasHouseNumber = true,
        string? houseNumber = "123",
        string zipcode = "01002-030") // 8 dígitos após sanitizar
    {
        // Docs padrão válidos por tipo
        document ??= type == EDocumentType.Person
            ? "123.456.789-01"        // 11 dígitos
            : "11.222.333/0001-81";  // 14 dígitos

        return new Person(
            firstName: "John",
            lastName: "Doe",
            email: "john.doe@email.com",
            document: document,
            type: type,
            countryCode: "+55",
            ddd: " (11) ",
            numberWithDigit: "99999-8888",
            neighboorhood: "Centro",
            houseNumber: houseNumber,
            hasHouseNumber: hasHouseNumber,
            complement: "Apto 12",
            street: "Rua das Flores",
            city: "SaoPaulo",
            state: "Sao Paulo",
            country: "Brasil",
            zipcode: zipcode
        );
    }

    [Fact]
    public void Constructor_WithValidData_ShouldBeValid_AndSanitizeFields()
    {
        var person = CreateValidPerson();

        Assert.True(person.IsValid);

        // Sanitização esperada pelo construtor
        Assert.Equal("12345678901", person.Document);
        Assert.Equal("55", person.CountryCode);
        Assert.Equal("11", person.DDD);
        Assert.Equal("999998888", person.NumberWithDigit);
        Assert.Equal("01002030", person.Zipcode);
    }

    [Fact]
    public void Constructor_WithInvalidEmail_ShouldBeInvalid()
    {
        var person = new Person(
            firstName: "John",
            lastName: "Doe",
            email: "invalid-email",
            document: "12345678901",
            type: EDocumentType.Person,
            countryCode: "55",
            ddd: "11",
            numberWithDigit: "999998888",
            neighboorhood: "Centro",
            houseNumber: "123",
            hasHouseNumber: true,
            complement: "Apto 12",
            street: "Rua",
            city: "SaoPaulo",
            state: "Sao Paulo",
            country: "Brasil",
            zipcode: "01002030"
        );

        Assert.False(person.IsValid);
        Assert.Contains(person.Notifications.Select(n => n.Message), m => m.Contains("Invalid email", StringComparison.OrdinalIgnoreCase));
    }

    [Theory]
    [InlineData(EDocumentType.Person, "1234567890")]        // 10 dígitos (inválido p/ pessoa)
    [InlineData(EDocumentType.Company, "1122233300018")]   // 13 dígitos (inválido p/ empresa)
    public void Constructor_WithInvalidDocumentLength_ShouldBeInvalid(EDocumentType type, string identification)
    {
        var person = new Person(
            firstName: "John",
            lastName: "Doe",
            email: "john@doe.com",
            document: identification,
            type: type,
            countryCode: "55",
            ddd: "11",
            numberWithDigit: "999998888",
            neighboorhood: "Centro",
            houseNumber: "123",
            hasHouseNumber: true,
            complement: "Apto 12",
            street: "Rua",
            city: "SaoPaulo",
            state: "Sao Paulo",
            country: "Brasil",
            zipcode: "01002030"
        );

        Assert.False(person.IsValid);
        Assert.Contains(person.Notifications.Select(n => n.Message), m => m.Contains("Invalid document", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void Constructor_CompanyDocumentWith14Digits_ShouldBeValid()
    {
        var person = CreateValidPerson(EDocumentType.Company, "11.222.333/0001-81");
        Assert.True(person.IsValid);
        Assert.Equal("11222333000181", person.Document); // sanitizado
    }

    [Fact]
    public void HouseNumber_IsRequired_WhenHasHouseNumberTrue()
    {
        var person = CreateValidPerson(hasHouseNumber: true, houseNumber: null);

        Assert.False(person.IsValid);
        Assert.Contains(person.Notifications.Select(n => n.Message), m => m.Contains("Insert a house number", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void HouseNumber_IsOptional_WhenHasHouseNumberFalse()
    {
        var person = CreateValidPerson(hasHouseNumber: false, houseNumber: null);
        Assert.True(person.IsValid);
    }

    [Fact]
    public void SetName_ShouldRevalidate_AndFail_WhenFirstNameTooShort()
    {
        var person = CreateValidPerson();
        Assert.True(person.IsValid);

        person.SetName("Jo", "Doe"); // 2 chars (mín. 3)
        Assert.False(person.IsValid);
        Assert.Contains(person.Notifications.Select(n => n.Key), k => k.Equals("firstName"));
    }

    [Fact]
    public void SetName_ShouldRevalidate_AndFail_WhenLastNameTooShort()
    {
        var person = CreateValidPerson();
        Assert.True(person.IsValid);

        person.SetName("John", "Li"); // 2 chars (mín. 3 no código)
        Assert.False(person.IsValid);
        Assert.Contains(person.Notifications.Select(n => n.Key), k => k.Equals("lastName"));
    }

    [Fact]
    public void SetAddress_ShouldSanitizeZipcode_AndStayValid()
    {
        var person = CreateValidPerson();
        Assert.True(person.IsValid);

        person.SetAddress(
            neighboorhood: "Centro",
            houseNumber: "45",
            hasHouseNumber: true,
            complement: "Bloco B",
            street: "Rua X",
            city: "SaoPaulo",
            state: "Sao Paulo",
            country: "Brasil",
            zipcode: "01311-000" // vira 01311000 (8 dígitos)
        );

        Assert.True(person.IsValid);
        Assert.Equal("01311000", person.Zipcode);
    }

    [Fact]
    public void SetAddress_WithInvalidZipcodeLength_ShouldFail()
    {
        var person = CreateValidPerson();
        Assert.True(person.IsValid);

        person.SetAddress(
            neighboorhood: "Centro",
            houseNumber: "45",
            hasHouseNumber: true,
            complement: "Bloco B",
            street: "Rua X",
            city: "SaoPaulo",
            state: "Sao Paulo",
            country: "Brasil",
            zipcode: "12345-67" // 7 dígitos após sanitizar
        );

        Assert.False(person.IsValid);
        Assert.Contains(person.Notifications.Select(n => n.Key), k => k.Equals("Address.Zipcode"));
    }

    [Fact]
    public void Complement_MaxLengthExceeded_ShouldFail()
    {
        var longComplement = new string('x', 151); // regra no código usa 0..150
        var person = CreateValidPerson();
        Assert.True(person.IsValid);

        person.SetAddress(
            neighboorhood: "Centro",
            houseNumber: "123",
            hasHouseNumber: true,
            complement: longComplement,
            street: "Rua A",
            city: "SaoPaulo",
            state: "Sao Paulo",
            country: "Brasil",
            zipcode: "01002-030"
        );

        Assert.False(person.IsValid);
        Assert.Contains(person.Notifications.Select(n => n.Key), k => k.Equals("complement"));
    }

    [Fact]
    public void SetPhone_DoesNotSanitize_ButRemainsValid()
    {
        var person = CreateValidPerson();
        Assert.True(person.IsValid);

        person.SetPhone("+55", "(11)", "99999-8888");

        // Continua válido (não há validação de telefone no Validate)
        Assert.True(person.IsValid);

        // Observação: ao contrário do construtor, SetPhone não sanitiza
        Assert.Equal("+55", person.CountryCode);
        Assert.Equal("(11)", person.DDD);
        Assert.Equal("99999-8888", person.NumberWithDigit);
    }

    [Fact]
    public void SetPersonStatus_ShouldChangeStatus()
    {
        var person = CreateValidPerson();
        Assert.Equal(EPersonStatus.Active, person.Status);

        person.SetPersonStatus(EPersonStatus.Inactive);
        Assert.Equal(EPersonStatus.Inactive, person.Status);
    }
}