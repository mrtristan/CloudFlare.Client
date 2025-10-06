using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.DnsRecord;

/// <summary>
/// Dns record filter
/// </summary>
public class DnsRecordFilter
{
    /// <summary>
    /// DNS record type
    /// </summary>
    [JsonProperty("type")]
    public DnsRecordType? Type { get; set; }

    /// <summary>
    /// DNS record name - exact value
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// DNS record name - exact value (alias for Name)
    /// </summary>
    [JsonProperty("name.exact")]
    public string NameExact { get; set; }

    /// <summary>
    /// DNS record name - contains substring
    /// </summary>
    [JsonProperty("name.contains")]
    public string NameContains { get; set; }

    /// <summary>
    /// DNS record name - starts with prefix
    /// </summary>
    [JsonProperty("name.startswith")]
    public string NameStartsWith { get; set; }

    /// <summary>
    /// DNS record name - ends with suffix
    /// </summary>
    [JsonProperty("name.endswith")]
    public string NameEndsWith { get; set; }

    /// <summary>
    /// DNS record content - exact value
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; set; }

    /// <summary>
    /// DNS record content - exact value (alias for Content)
    /// </summary>
    [JsonProperty("content.exact")]
    public string ContentExact { get; set; }

    /// <summary>
    /// DNS record content - contains substring
    /// </summary>
    [JsonProperty("content.contains")]
    public string ContentContains { get; set; }

    /// <summary>
    /// DNS record content - starts with prefix
    /// </summary>
    [JsonProperty("content.startswith")]
    public string ContentStartsWith { get; set; }

    /// <summary>
    /// DNS record content - ends with suffix
    /// </summary>
    [JsonProperty("content.endswith")]
    public string ContentEndsWith { get; set; }

    /// <summary>
    /// DNS record comment - exact value
    /// </summary>
    [JsonProperty("comment")]
    public string Comment { get; set; }

    /// <summary>
    /// DNS record comment - exact value (alias for Comment)
    /// </summary>
    [JsonProperty("comment.exact")]
    public string CommentExact { get; set; }

    /// <summary>
    /// DNS record comment - contains substring
    /// </summary>
    [JsonProperty("comment.contains")]
    public string CommentContains { get; set; }

    /// <summary>
    /// DNS record comment - starts with prefix
    /// </summary>
    [JsonProperty("comment.startswith")]
    public string CommentStartsWith { get; set; }

    /// <summary>
    /// DNS record comment - ends with suffix
    /// </summary>
    [JsonProperty("comment.endswith")]
    public string CommentEndsWith { get; set; }

    /// <summary>
    /// DNS record comment - present (any value)
    /// </summary>
    [JsonProperty("comment.present")]
    public bool? CommentPresent { get; set; }

    /// <summary>
    /// DNS record comment - absent (no value)
    /// </summary>
    [JsonProperty("comment.absent")]
    public bool? CommentAbsent { get; set; }

    /// <summary>
    /// DNS record tag - simple tag name or name:value pair
    /// </summary>
    [JsonProperty("tag")]
    public string Tag { get; set; }

    /// <summary>
    /// DNS record tag - present (any value)
    /// </summary>
    [JsonProperty("tag.present")]
    public string TagPresent { get; set; }

    /// <summary>
    /// DNS record tag - absent (no value)
    /// </summary>
    [JsonProperty("tag.absent")]
    public string TagAbsent { get; set; }

    /// <summary>
    /// DNS record tag - exact name:value pair
    /// </summary>
    [JsonProperty("tag.exact")]
    public string TagExact { get; set; }

    /// <summary>
    /// DNS record tag - contains substring in value
    /// </summary>
    [JsonProperty("tag.contains")]
    public string TagContains { get; set; }

    /// <summary>
    /// DNS record tag - starts with prefix in value
    /// </summary>
    [JsonProperty("tag.startswith")]
    public string TagStartsWith { get; set; }

    /// <summary>
    /// DNS record tag - ends with suffix in value
    /// </summary>
    [JsonProperty("tag.endswith")]
    public string TagEndsWith { get; set; }

    /// <summary>
    /// Whether the record is proxied
    /// </summary>
    [JsonProperty("proxied")]
    public bool? Proxied { get; set; }

    /// <summary>
    /// Whether to match all search requirements or at least one
    /// </summary>
    [JsonProperty("match")]
    public MatchType? Match { get; set; }

    /// <summary>
    /// Search term for general search
    /// </summary>
    [JsonProperty("search")]
    public string Search { get; set; }

    /// <summary>
    /// Tag match behavior
    /// </summary>
    [JsonProperty("tag_match")]
    public MatchType? TagMatch { get; set; }

    /// <summary>
    /// Page number of paginated results
    /// </summary>
    [JsonProperty("page")]
    public int? Page { get; set; }

    /// <summary>
    /// Number of records per page
    /// </summary>
    [JsonProperty("per_page")]
    public int? PerPage { get; set; }

    /// <summary>
    /// Field to order records by
    /// </summary>
    [JsonProperty("order")]
    public string Order { get; set; }

    /// <summary>
    /// Direction to order records
    /// </summary>
    [JsonProperty("direction")]
    public OrderType? Direction { get; set; }
}
