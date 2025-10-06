using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Represents the field to order zones by
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ZoneOrder
{
    /// <summary>
    /// Order by name
    /// </summary>
    [EnumMember(Value = "name")]
    Name,

    /// <summary>
    /// Order by status
    /// </summary>
    [EnumMember(Value = "status")]
    Status,

    /// <summary>
    /// Order by account ID
    /// </summary>
    [EnumMember(Value = "account.id")]
    AccountId,

    /// <summary>
    /// Order by account name
    /// </summary>
    [EnumMember(Value = "account.name")]
    AccountName,

    /// <summary>
    /// Order by plan ID
    /// </summary>
    [EnumMember(Value = "plan.id")]
    PlanId
}
