using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones;

/// <summary>
/// Zone filter
/// </summary>
public class ZoneFilter : DisplayOptions
{
    /// <summary>
    /// A domain name to filter zones by. This performs an exact match search.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Status of the zone
    /// </summary>
    [JsonProperty("status")]
    public ZoneStatus? Status { get; set; }

    /// <summary>
    /// Whether to match all search requirements or at least one (any/all)
    /// </summary>
    [JsonProperty("match")]
    public MatchType? Match { get; set; }

    /// <summary>
    /// An account name to filter zones by. This performs an exact match search.
    /// </summary>
    [JsonProperty("account.name")]
    public string AccountName { get; set; }

    /// <summary>
    /// Account identifier tag
    /// </summary>
    [JsonProperty("account.id")]
    public string AccountId { get; set; }

    /// <summary>
    /// Direction to order zones
    /// </summary>
    [JsonProperty("direction")]
    public OrderType? Direction { get; set; }
}
