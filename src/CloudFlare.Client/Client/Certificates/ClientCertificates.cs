using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Certificates;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client.Certificates;

/// <inheritdoc cref="IClientCertificates"/>
public class ClientCertificates : ApiContextBase<IConnection>, IClientCertificates
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientCertificates"/> class
    /// </summary>
    /// <param name="connection">Connection settings</param>
    public ClientCertificates(IConnection connection)
        : base(connection)
    {
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<IReadOnlyList<ClientCertificate>>> GetAsync(string zoneId, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
    {
        var parameters = new ParameterBuilder()
            .InsertValue(Filtering.Page, displayOptions?.Page)
            .InsertValue(Filtering.PerPage, displayOptions?.PerPage)
            .InsertValue(Filtering.Order, displayOptions?.Order);

        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{ClientCertificateEndpoints.Base}").AddParameters(parameters);
        return await Connection.GetAsync<IReadOnlyList<ClientCertificate>>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<ClientCertificate>> GetDetailsAsync(string zoneId, string clientCertificateId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{ClientCertificateEndpoints.Base}/{clientCertificateId}");
        return await Connection.GetAsync<ClientCertificate>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<ClientCertificate>> AddAsync(string zoneId, NewClientCertificate newClientCertificate, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{ClientCertificateEndpoints.Base}");
        return await Connection.PostAsync<ClientCertificate, NewClientCertificate>(requestUri, newClientCertificate, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<ClientCertificate>> RevokeAsync(string zoneId, string clientCertificateId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{ClientCertificateEndpoints.Base}/{clientCertificateId}");
        return await Connection.DeleteAsync<ClientCertificate>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<ClientCertificate>> ReactivateAsync(string zoneId, string clientCertificateId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{ClientCertificateEndpoints.Base}/{clientCertificateId}");
        return await Connection.PatchAsync<ClientCertificate, object>(requestUri, new { reactivate = true}, cancellationToken).ConfigureAwait(false);
    }
}
