using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Certificates;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Test.Helpers;
using CloudFlare.Client.Test.TestData;
using FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace CloudFlare.Client.Test.Certificates;

public class ClientCertificatesUnitTests
{
    private readonly WireMockServer _wireMockServer;
    private readonly ConnectionInfo _connectionInfo;

    public ClientCertificatesUnitTests()
    {
        _wireMockServer = WireMockServer.Start();
        _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
    }

    [Fact]
    public async Task TestCreateClientCertificateAsync()
    {
        var clientCertificate = ClientCertificatesTestData.ClientCertificates.First();
        var newClientCertificate = new NewClientCertificate
        {
            Csr = clientCertificate.Csr,
            ValidityDays = clientCertificate.ValidityDays
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/zones/test-zone-id/{ClientCertificateEndpoints.Base}").UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(clientCertificate)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var result = await client.Zones.ClientCertificates.AddAsync("test-zone-id", newClientCertificate);

        result.Result.Should().BeEquivalentTo(clientCertificate, x => x.Excluding(y => y.IssuedOn).Excluding(y => y.ExpiresOn));
    }

    [Fact]
    public async Task TestGetClientCertificatesAsync()
    {
        var clientCertificates = ClientCertificatesTestData.ClientCertificates;
        var displayOptions = new DisplayOptions { Page = 1, PerPage = 20 };

        _wireMockServer
            .Given(Request.Create().WithPath($"/zones/test-zone-id/{ClientCertificateEndpoints.Base}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(clientCertificates)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var result = await client.Zones.ClientCertificates.GetAsync("test-zone-id", displayOptions);

        result.Result.Should().BeEquivalentTo(clientCertificates, x => x.Excluding(y => y.IssuedOn).Excluding(y => y.ExpiresOn));
    }

    [Fact]
    public async Task TestGetClientCertificateDetailsAsync()
    {
        var clientCertificate = ClientCertificatesTestData.ClientCertificates.First();

        _wireMockServer
            .Given(Request.Create().WithPath($"/zones/test-zone-id/{ClientCertificateEndpoints.Base}/{clientCertificate.Id}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(clientCertificate)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var result = await client.Zones.ClientCertificates.GetDetailsAsync("test-zone-id", clientCertificate.Id);

        result.Result.Should().BeEquivalentTo(clientCertificate, x => x.Excluding(y => y.IssuedOn).Excluding(y => y.ExpiresOn));
    }

    [Fact]
    public async Task TestRevokeClientCertificateAsync()
    {
        var clientCertificate = ClientCertificatesTestData.ClientCertificates.First();
        clientCertificate.Status = CloudFlare.Client.Enumerators.ClientCertificateStatus.PendingRevocation;

        _wireMockServer
            .Given(Request.Create().WithPath($"/zones/test-zone-id/{ClientCertificateEndpoints.Base}/{clientCertificate.Id}").UsingDelete())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(clientCertificate)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var result = await client.Zones.ClientCertificates.RevokeAsync("test-zone-id", clientCertificate.Id);

        result.Result.Should().BeEquivalentTo(clientCertificate, x => x.Excluding(y => y.IssuedOn).Excluding(y => y.ExpiresOn));
    }

    [Fact]
    public async Task TestReactivateClientCertificateAsync()
    {
        var clientCertificate = ClientCertificatesTestData.ClientCertificates.First();
        clientCertificate.Status = CloudFlare.Client.Enumerators.ClientCertificateStatus.Active;

        _wireMockServer
            .Given(Request.Create().WithPath($"/zones/test-zone-id/{ClientCertificateEndpoints.Base}/{clientCertificate.Id}").UsingPatch())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(clientCertificate)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var result = await client.Zones.ClientCertificates.ReactivateAsync("test-zone-id", clientCertificate.Id);

        result.Result.Should().BeEquivalentTo(clientCertificate, x => x.Excluding(y => y.IssuedOn).Excluding(y => y.ExpiresOn));
    }
}
