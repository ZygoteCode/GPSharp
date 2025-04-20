using Newtonsoft.Json;
using System;

public class GreenPassData
{
    [JsonProperty("1")]
    public string CountryCode { get; set; }

    [JsonProperty("6")]
    public long StartTimestamp { get; set; }

    [JsonProperty("4")]
    public long EndTimestamp { get; set; }

    [JsonProperty("5")]
    public CertificateData CertificateData { get; set; }

    public DateTime GetStartTime()
    {
        return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(StartTimestamp).ToLocalTime();
    }

    public DateTime GetEndTime()
    {
        return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(EndTimestamp).ToLocalTime();
    }
}