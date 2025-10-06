using System.Collections.Generic;
using CloudFlare.Client.Api.Certificates;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class ClientCertificatesTest
{
    [Fact]
    public void TestClientCertificateSerialization()
    {
        var sut = new ClientCertificate();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
        {
            "id", "certificate", "private_key", "csr", "issued_on", "expires_on", "validity_days", 
            "status", "serial_number", "common_name", "organization", "organizational_unit", 
            "country", "state", "locality"
        });
    }

    [Fact]
    public void TestNewClientCertificateSerialization()
    {
        var sut = new NewClientCertificate();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
        {
            "csr", "validity_days"
        });
    }

    [Fact]
    public void TestClientCertificateStatusSerialization()
    {
        JsonHelper.GetSerializedEnums<ClientCertificateStatus>().Should().BeEquivalentTo(new SortedSet<string>
        {
            "active", "pending_revocation", "revoked"
        });
    }
}
