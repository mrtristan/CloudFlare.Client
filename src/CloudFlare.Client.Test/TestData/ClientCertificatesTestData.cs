using System.Collections.Generic;
using CloudFlare.Client.Api.Certificates;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData;

public static class ClientCertificatesTestData
{
    public static IReadOnlyList<ClientCertificate> ClientCertificates => new List<ClientCertificate>
    {
        new()
        {
            Id = "client-cert-1",
            Certificate = "-----BEGIN CERTIFICATE-----\nMIIBkTCB+wIJAKoK/heBjcOuMA0GCSqGSIb3DQEBCwUAMBQxEjAQBgNVBAMMCWxv\nY2FsaG9zdDAeFw0yMzAxMDEwMDAwMDBaFw0yNDAxMDEwMDAwMDBaMBQxEjAQBgNV\nBAMMCWxvY2FsaG9zdDBZMBMGByqGSM49AgEGCCqGSM49AwEHA0IABKxXvC8s8Q\n-----END CERTIFICATE-----",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\nMIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQg...\n-----END PRIVATE KEY-----",
            Csr = "-----BEGIN CERTIFICATE REQUEST-----\nMIIBkTCB+wIJAKoK/heBjcOuMA0GCSqGSIb3DQEBCwUAMBQxEjAQBgNVBAMMCWxv\nY2FsaG9zdDAeFw0yMzAxMDEwMDAwMDBaFw0yNDAxMDEwMDAwMDBaMBQxEjAQBgNV\nBAMMCWxvY2FsaG9zdDBZMBMGByqGSM49AgEGCCqGSM49AwEHA0IABKxXvC8s8Q\n-----END CERTIFICATE REQUEST-----",
            IssuedOn = new System.DateTime(2023, 1, 1, 0, 0, 0, System.DateTimeKind.Utc),
            ExpiresOn = new System.DateTime(2024, 1, 1, 0, 0, 0, System.DateTimeKind.Utc),
            ValidityDays = 365,
            Status = ClientCertificateStatus.Active,
            SerialNumber = "1234567890",
            CommonName = "localhost",
            Organization = "Test Organization",
            OrganizationalUnit = "IT Department",
            Country = "US",
            State = "CA",
            Locality = "San Francisco"
        },
        new()
        {
            Id = "client-cert-2",
            Certificate = "-----BEGIN CERTIFICATE-----\nMIIBkTCB+wIJAKoK/heBjcOuMA0GCSqGSIb3DQEBCwUAMBQxEjAQBgNVBAMMCWxv\nY2FsaG9zdDAeFw0yMzAxMDEwMDAwMDBaFw0yNDAxMDEwMDAwMDBaMBQxEjAQBgNV\nBAMMCWxvY2FsaG9zdDBZMBMGByqGSM49AgEGCCqGSM49AwEHA0IABKxXvC8s8Q\n-----END CERTIFICATE-----",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\nMIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQg...\n-----END PRIVATE KEY-----",
            Csr = "-----BEGIN CERTIFICATE REQUEST-----\nMIIBkTCB+wIJAKoK/heBjcOuMA0GCSqGSIb3DQEBCwUAMBQxEjAQBgNVBAMMCWxv\nY2FsaG9zdDAeFw0yMzAxMDEwMDAwMDBaFw0yNDAxMDEwMDAwMDBaMBQxEjAQBgNV\nBAMMCWxvY2FsaG9zdDBZMBMGByqGSM49AgEGCCqGSM49AwEHA0IABKxXvC8s8Q\n-----END CERTIFICATE REQUEST-----",
            IssuedOn = new System.DateTime(2023, 1, 1, 0, 0, 0, System.DateTimeKind.Utc),
            ExpiresOn = new System.DateTime(2024, 1, 1, 0, 0, 0, System.DateTimeKind.Utc),
            ValidityDays = 365,
            Status = ClientCertificateStatus.PendingRevocation,
            SerialNumber = "0987654321",
            CommonName = "api.example.com",
            Organization = "Example Corp",
            OrganizationalUnit = "Security",
            Country = "US",
            State = "NY",
            Locality = "New York"
        }
    };
}
