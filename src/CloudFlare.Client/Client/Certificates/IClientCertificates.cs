using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Certificates;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Client.Certificates;

/// <summary>
/// Interface for interacting with client certificates
/// </summary>
public interface IClientCertificates
{
    /// <summary>
    /// Get all client certificates for a zone
    /// </summary>
    /// <param name="zoneId">The zone id</param>
    /// <param name="displayOptions">Display options</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of all client certificates</returns>
    Task<CloudFlareResult<IReadOnlyList<ClientCertificate>>> GetAsync(string zoneId, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a client certificate
    /// </summary>
    /// <param name="zoneId">The zone id</param>
    /// <param name="clientCertificateId">The client certificate id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The client certificate</returns>
    Task<CloudFlareResult<ClientCertificate>> GetDetailsAsync(string zoneId, string clientCertificateId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new client certificate.
    /// </summary>
    /// <param name="zoneId">The zone id</param>
    /// <param name="newClientCertificate">The new client certificate</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created client certificate</returns>
    Task<CloudFlareResult<ClientCertificate>> AddAsync(string zoneId, NewClientCertificate newClientCertificate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Revoke a client certificate
    /// </summary>
    /// <param name="zoneId">The zone id</param>
    /// <param name="clientCertificateId">The client certificate id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The revoked client certificate</returns>
    Task<CloudFlareResult<ClientCertificate>> RevokeAsync(string zoneId, string clientCertificateId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Reactivate a client certificate that is in pending_revocation state
    /// </summary>
    /// <param name="zoneId">The zone id</param>
    /// <param name="clientCertificateId">The client certificate id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The reactivated client certificate</returns>
    Task<CloudFlareResult<ClientCertificate>> ReactivateAsync(string zoneId, string clientCertificateId, CancellationToken cancellationToken = default);
}
