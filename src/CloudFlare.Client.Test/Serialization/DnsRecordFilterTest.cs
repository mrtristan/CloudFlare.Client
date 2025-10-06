using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.DnsRecord;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class DnsRecordFilterTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new DnsRecordFilter
        {
            Type = DnsRecordType.A,
            Name = "example.com",
            NameExact = "www.example.com",
            NameContains = "example",
            NameStartsWith = "www",
            NameEndsWith = ".com",
            Content = "127.0.0.1",
            ContentExact = "127.0.0.1",
            ContentContains = "127.0",
            ContentStartsWith = "127.",
            ContentEndsWith = ".0.1",
            Comment = "Test comment",
            CommentExact = "Test comment",
            CommentContains = "Test",
            CommentStartsWith = "Test ",
            CommentEndsWith = " comment",
            CommentPresent = true,
            CommentAbsent = false,
            Tag = "team:DNS",
            TagPresent = "important",
            TagAbsent = "deprecated",
            TagExact = "team:DNS",
            TagContains = "team:D",
            TagStartsWith = "team:D",
            TagEndsWith = ":DNS",
            Proxied = true,
            Match = MatchType.All,
            Search = "test search",
            TagMatch = MatchType.Any,
            Page = 1,
            PerPage = 20,
            Order = "name",
            Direction = OrderType.Asc
        };

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
        {
            "type", "name", "name.exact", "name.contains", "name.startswith", "name.endswith",
            "content", "content.exact", "content.contains", "content.startswith", "content.endswith",
            "comment", "comment.exact", "comment.contains", "comment.startswith", "comment.endswith",
            "comment.present", "comment.absent",
            "tag", "tag.present", "tag.absent", "tag.exact", "tag.contains", "tag.startswith", "tag.endswith",
            "proxied", "match", "search", "tag_match", "page", "per_page", "order", "direction"
        });
    }
}
