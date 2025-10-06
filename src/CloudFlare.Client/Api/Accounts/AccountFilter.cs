using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Accounts;

/// <summary>
/// Account filter
/// </summary>
public class AccountFilter
{
    /// <summary>
    /// Name of the account
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Page number of paginated results
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// Maximum number of results per page
    /// </summary>
    public int? PerPage { get; set; }

    /// <summary>
    /// Direction to order results
    /// </summary>
    public OrderType? Direction { get; set; }
}
