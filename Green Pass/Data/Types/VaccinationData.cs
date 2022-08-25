using Newtonsoft.Json;
using System;

public class VaccinationData
{
    [JsonProperty("tg")]
    public string COVIDVariant { get; set; }

    [JsonProperty("vp")]
    public string VaccineType { get; set; }

    [JsonProperty("mp")]
    public string VaccineProduct { get; set; }

    [JsonProperty("ma")]
    public string MarketingAuthorization { get; set; }

    [JsonProperty("dn")]
    public int DosesNumber { get; set; }

    [JsonProperty("sd")]
    public int TotalDoses { get; set; }

    [JsonProperty("dt")]
    public DateTime VaccinationDate { get; set; }

    [JsonProperty("co")]
    public string CountryCode { get; set; }

    [JsonProperty("is")]
    public string CertificateIssuer { get; set; }

    [JsonProperty("ci")]
    public string CertificateIdentifier { get; set; }

    public string GetVaccineName()
    {
        switch (VaccineProduct)
        {
            case "EU/1/20/1528":
                return "Pfizer";
            case "EU/1/20/1507":
                return "Moderna";
            case "EU/1/21/1529":
                return "AstraZeneca";
            case "EU/1/20/1525":
                return "Johnson & Johnson";
            case "EU/1/21/1618":
                return "Novavax";
        }

        return null;
    }

    public VaccineBrand GetVaccineBrand()
    {
        switch (VaccineProduct)
        {
            case "EU/1/20/1528":
                return VaccineBrand.PFIZER;
            case "EU/1/20/1507":
                return VaccineBrand.MODERNA;
            case "EU/1/21/1529":
                return VaccineBrand.ASTRAZENECA;
            case "EU/1/20/1525":
                return VaccineBrand.JOHNSON_AND_JOHNSON;
            case "EU/1/21/1618":
                return VaccineBrand.NOVAVAX;
        }

        return VaccineBrand.UNKNOWN;
    }
}