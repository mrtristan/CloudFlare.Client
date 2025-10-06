using System.Collections.Generic;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class ZoneMetaTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new ZoneMeta();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
        {
            "cdn_only", "custom_certificate_quota", "dns_only", "foundation_dns",
            "page_rule_quota", "phishing_detected", "step"
        });
    }
}
