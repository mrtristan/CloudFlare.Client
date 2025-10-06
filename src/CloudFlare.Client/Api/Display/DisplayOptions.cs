using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Display;

/// <summary>
/// Display options
/// </summary>
public class DisplayOptions : UnOrderableDisplayOptions
{
    /// <summary>
    /// Direction to order
    /// </summary>
    [JsonProperty("order")]
    public OrderType? Order { get; set; }
}
