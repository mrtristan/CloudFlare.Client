using System;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Certificates;

/// <summary>
/// Client Certificate for mTLS API Shield
/// </summary>
public class ClientCertificate
{
    /// <summary>
    /// Unique identifier for the client certificate.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// The client certificate. Will be newline-encoded.
    /// </summary>
    [JsonProperty("certificate")]
    public string Certificate { get; set; }

    /// <summary>
    /// The private key. Will be newline-encoded.
    /// </summary>
    [JsonProperty("private_key")]
    public string PrivateKey { get; set; }

    /// <summary>
    /// The Certificate Signing Request (CSR). Will be newline-encoded.
    /// </summary>
    [JsonProperty("csr")]
    public string Csr { get; set; }

    /// <summary>
    /// When the certificate was issued.
    /// </summary>
    [JsonProperty("issued_on")]
    [JsonConverter(typeof(DateTimeConverter), Constants.DateTimeFormat.CertificatesExpiresOn, true)]
    public DateTime? IssuedOn { get; set; }

    /// <summary>
    /// When the certificate will expire.
    /// </summary>
    [JsonProperty("expires_on")]
    [JsonConverter(typeof(DateTimeConverter), Constants.DateTimeFormat.CertificatesExpiresOn, true)]
    public DateTime? ExpiresOn { get; set; }

    /// <summary>
    /// The number of days the client certificate will be valid after the issued_on date.
    /// </summary>
    [JsonProperty("validity_days")]
    public int ValidityDays { get; set; }

    /// <summary>
    /// The status of the client certificate.
    /// </summary>
    [JsonProperty("status")]
    public ClientCertificateStatus Status { get; set; }

    /// <summary>
    /// The serial number of the client certificate.
    /// </summary>
    [JsonProperty("serial_number")]
    public string SerialNumber { get; set; }

    /// <summary>
    /// The common name of the client certificate.
    /// </summary>
    [JsonProperty("common_name")]
    public string CommonName { get; set; }

    /// <summary>
    /// The organization name of the client certificate.
    /// </summary>
    [JsonProperty("organization")]
    public string Organization { get; set; }

    /// <summary>
    /// The organizational unit of the client certificate.
    /// </summary>
    [JsonProperty("organizational_unit")]
    public string OrganizationalUnit { get; set; }

    /// <summary>
    /// The country of the client certificate.
    /// </summary>
    [JsonProperty("country")]
    public string Country { get; set; }

    /// <summary>
    /// The state/province of the client certificate.
    /// </summary>
    [JsonProperty("state")]
    public string State { get; set; }

    /// <summary>
    /// The locality of the client certificate.
    /// </summary>
    [JsonProperty("locality")]
    public string Locality { get; set; }
}
