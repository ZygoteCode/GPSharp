using Newtonsoft.Json;
using System;

public class TestData
{
    [JsonProperty("tg")]
    public string COVIDVariant { get; set; }

    [JsonProperty("tt")]
    public string TestType { get; set; }

    [JsonProperty("nm")]
    public string TestName { get; set; }

    [JsonProperty("ma")]
    public string TestDeviceIdentifier { get; set; }

    [JsonProperty("sc")]
    public DateTime TestSampleCollection { get; set; }

    [JsonProperty("tr")]
    public string TestResult { get; set; }

    [JsonProperty("tc")]
    public string TestingCentre { get; set; }

    [JsonProperty("co")]
    public string CountryCode { get; set; }

    [JsonProperty("is")]
    public string CertificateIssuer { get; set; }

    [JsonProperty("ci")]
    public string CertificateIdentifier { get; set; }

    public bool IsPositive()
    {
        return TestResult == "260373001";
    }

    public bool IsNegative()
    {
        return TestResult == "260415000";
    }

    public bool IsAntiGen()
    {
        return TestDeviceIdentifier == "1232";
    }

    public bool IsMolecular()
    {
        return TestDeviceIdentifier != "1232";
    }

    public TestResult GetTestResult()
    {
        return IsPositive() ? global::TestResult.POSITIVE : global::TestResult.NEGATIVE;
    }

    public TestType GetTestType()
    {
        return IsAntiGen() ? global::TestType.ANTIGEN : global::TestType.MOLECULAR;
    }
}