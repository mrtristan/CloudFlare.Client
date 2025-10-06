using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones;

/// <summary>
/// Zone tenant information
/// </summary>
public class ZoneTenant
{
    /// <summary>
    /// Tenant identifier
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// The name of the Tenant account
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
}
