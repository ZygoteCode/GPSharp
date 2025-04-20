using Newtonsoft.Json;
using System;

public class PersonalData
{
    [JsonProperty("fn")]
    public string Surname { get; set; }

    [JsonProperty("fnt")]
    public string StandardisedSurname { get; set; }

    [JsonProperty("gn")]
    public string Forename { get; set; }

    [JsonProperty("gnt")]
    public string StandardisedForename { get; set; }
}