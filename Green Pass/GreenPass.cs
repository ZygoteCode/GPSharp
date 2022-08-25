using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

public class GreenPass
{
    private string json;
    private GreenPassData data;

    public GreenPass(string json)
    {
        this.json = json;
        this.data = JsonConvert.DeserializeObject<GreenPassData>(json.Replace("}}}", "}}").Replace(",\"-260\":{\"1\":{", ",\"5\":{"));
    }

    private long GetTimestamp()
    {
        return ((DateTimeOffset)DateTime.UtcNow.ToUniversalTime()).ToUniversalTime().ToUnixTimeSeconds();
    }

    private static DateTime UnixTimestampToDateTime(double unixTime)
    {
        DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        long unixTimeStampInTicks = (long)(unixTime * TimeSpan.TicksPerSecond);
        return new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
    }

    public DateTime GetStartDate()
    {
        return UnixTimestampToDateTime(this.data.StartTimestamp).ToLocalTime();
    }

    public DateTime GetEndDate()
    {
        return UnixTimestampToDateTime(this.data.EndTimestamp).ToLocalTime();
    }

    public bool IsValid()
    {
        if (GetTimestamp() > GetEndTimestamp())
        {
            return false;
        }

        if (IsRecovery())
        {
            if (GetTimestamp() > ((DateTimeOffset)GetRecoveryData().CertificateValidUntil).ToUniversalTime().ToUnixTimeSeconds())
            {
                return false;
            }
        }

        if (IsTest())
        {
            if (GetTestData().IsPositive())
            {
                return false;
            }
            else if (GetTestData().IsAntiGen() && (GetTimestamp() > GetStartTimestamp() + 172800))
            {
                return false;
            }
            else if (GetTestData().IsMolecular() && (GetTimestamp() > GetStartTimestamp() + 259200))
            {
                return false;
            }
        }

        return true;
    }

    public bool IsSuperGreenPass()
    {
        if (IsRecovery())
        {
            return true;
        }

        if (!IsVaccination())
        {
            return false;
        }

        return this.data.CertificateData.VaccinationData[0].DosesNumber != 1;
    }

    public bool IsBooster()
    {
        if (!IsVaccination())
        {
            return false;
        }

        return this.data.CertificateData.VaccinationData[0].DosesNumber == 3;
    }

    public string GetJSON()
    {
        return this.json;
    }

    public GreenPassData GetData()
    {
        return this.data;
    }

    public string GetSurname()
    {
        return this.data.CertificateData.PersonalData.Surname;
    }

    public string GetStandardisedSurname()
    {
        return this.data.CertificateData.PersonalData.StandardisedSurname;
    }

    public string GetForename()
    {
        return this.data.CertificateData.PersonalData.Forename;
    }

    public string GetStandardisedForename()
    {
        return this.data.CertificateData.PersonalData.StandardisedForename;
    }

    public string GetCountryCode()
    {
        return this.data.CountryCode;
    }

    public long GetStartTimestamp()
    {
        return this.data.StartTimestamp;
    }

    public long GetEndTimestamp()
    {
        return this.data.EndTimestamp;
    }

    public DateTime GetDateOfBirthday()
    {
        return this.data.CertificateData.DateOfBirthday;
    }

    public string GetSchemaVersion()
    {
        return this.data.CertificateData.SchemaVersion;
    }

    public bool IsVaccination()
    {
        if (this.data.CertificateData.VaccinationData == null)
        {
            return false;
        }

        if (this.data.CertificateData.VaccinationData.Count != 1)
        {
            return false;
        }

        return true;
    }

    public bool IsTest()
    {
        if (this.data.CertificateData.TestData == null)
        {
            return false;
        }

        if (this.data.CertificateData.TestData.Count != 1)
        {
            return false;
        }

        return true;
    }

    public bool IsRecovery()
    {
        if (this.data.CertificateData.RecoveryData == null)
        {
            return false;
        }

        if (this.data.CertificateData.RecoveryData.Count != 1)
        {
            return false;
        }

        return true;
    }

    public GreenPassType GetGreenPassType()
    {
        if (IsVaccination())
        {
            return GreenPassType.GP_VACCINATION;
        }
        else if (IsTest())
        {
            return GreenPassType.GP_TEST;
        }

        return GreenPassType.GP_RECOVERY;
    }

    public CertificateData GetCertificateData()
    {
        return this.data.CertificateData;
    }

    public PersonalData GetPersonalData()
    {
        return this.data.CertificateData.PersonalData;
    }

    public RecoveryData GetRecoveryData()
    {
        if (!IsRecovery())
        {
            return null;
        }

        return this.data.CertificateData.RecoveryData[0];
    }

    public VaccinationData GetVaccinationData()
    {
        if (!IsVaccination())
        {
            return null;
        }

        return this.data.CertificateData.VaccinationData[0];
    }

    public TestData GetTestData()
    {
        if (!IsTest())
        {
            return null;
        }

        return this.data.CertificateData.TestData[0];
    }

    public string GetCOVIDVariant()
    {
        if (IsVaccination())
        {
            return this.data.CertificateData.VaccinationData[0].COVIDVariant;
        }
        else if (IsRecovery())
        {
            return this.data.CertificateData.RecoveryData[0].COVIDVariant;
        }

        return this.data.CertificateData.TestData[0].COVIDVariant;
    }

    public string GetCertificateIssuer()
    {
        if (IsVaccination())
        {
            return this.data.CertificateData.VaccinationData[0].CertificateIssuer;
        }
        else if (IsRecovery())
        {
            return this.data.CertificateData.RecoveryData[0].CertificateIssuer;
        }

        return this.data.CertificateData.TestData[0].CertificateIssuer;
    }

    public string GetCertificateIdentifier()
    {
        if (IsVaccination())
        {
            return this.data.CertificateData.VaccinationData[0].CertificateIdentifier;
        }
        else if (IsRecovery())
        {
            return this.data.CertificateData.RecoveryData[0].CertificateIdentifier;
        }

        return this.data.CertificateData.TestData[0].CertificateIdentifier;
    }

    public string GetCertificateCountryCode()
    {
        if (IsVaccination())
        {
            return this.data.CertificateData.VaccinationData[0].CountryCode;
        }
        else if (IsRecovery())
        {
            return this.data.CertificateData.RecoveryData[0].CountryCode;
        }

        return this.data.CertificateData.TestData[0].CountryCode;
    }
}