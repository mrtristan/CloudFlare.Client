using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Certificates;

/// <summary>
/// New Client Certificate for mTLS API Shield
/// </summary>
public class NewClientCertificate
{
    /// <summary>
    /// The Certificate Signing Request (CSR). Must be newline-encoded.
    /// </summary>
    [JsonProperty("csr")]
    public string Csr { get; set; }

    /// <summary>
    /// The number of days the client certificate will be valid after the issued_on date.
    /// </summary>
    [JsonProperty("validity_days")]
    public int ValidityDays { get; set; }
}
