using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class CertificateData
{
    [JsonProperty("dob")]
    public DateTime DateOfBirthday { get; set; }

    [JsonProperty("ver")]
    public string SchemaVersion { get; set; }

    [JsonProperty("nam")]
    public PersonalData PersonalData { get; set; }

    [JsonProperty("v")]
    public List<VaccinationData> VaccinationData { get; set; }

    [JsonProperty("r")]
    public List<RecoveryData> RecoveryData { get; set; }

    [JsonProperty("t")]
    public List<TestData> TestData { get; set; }
}