namespace ORS.Apps.Authors.Entities;

public record Author(
    Company Company,
    Requisites Requisites
);

public record Company(
    string Name,
    string Phone,
    int Tin,
    int Ifut
);

public record Requisites(
    string Bank,
    string BankCode,
    string Account
);