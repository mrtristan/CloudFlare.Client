using System.Collections.Generic;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class ZoneFilterTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new ZoneFilter();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
        {
            "name", "status", "match", "account.name", "account.id", 
            "page", "per_page", "order", "direction"
        });
    }
}
