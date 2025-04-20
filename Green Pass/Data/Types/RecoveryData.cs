using Newtonsoft.Json;
using System;

public class RecoveryData
{
    [JsonProperty("tg")]
    public string COVIDVariant { get; set; }

    [JsonProperty("fr")]
    public DateTime FirstTest { get; set; }

    [JsonProperty("co")]
    public string CountryCode { get; set; }

    [JsonProperty("is")]
    public string CertificateIssuer { get; set; }

    [JsonProperty("df")]
    public DateTime CertificateValidFrom { get; set; }

    [JsonProperty("du")]
    public DateTime CertificateValidUntil { get; set; }

    [JsonProperty("ci")]
    public string CertificateIdentifier { get; set; }
}