using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Display;

/// <summary>
/// Unorderable display options
/// </summary>
public class UnOrderableDisplayOptions
{
    /// <summary>
    /// Page number of paginated result
    /// </summary>
    [JsonProperty("page")]
    public int? Page { get; set; }

    /// <summary>
    /// Number of elements per pages
    /// </summary>
    [JsonProperty("per_page")]
    public int? PerPage { get; set; }
}
