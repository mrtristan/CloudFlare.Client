using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Client Certificate Status
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ClientCertificateStatus
{
    /// <summary>
    /// Active
    /// </summary>
    [EnumMember(Value = "active")]
    Active,

    /// <summary>
    /// Pending Reactivation
    /// </summary>
    [EnumMember(Value = "pending_reactivation")]
    PendingReactivation,

    /// <summary>
    /// Pending Revocation
    /// </summary>
    [EnumMember(Value = "pending_revocation")]
    PendingRevocation,

    /// <summary>
    /// Revoked
    /// </summary>
    [EnumMember(Value = "revoked")]
    Revoked
}
