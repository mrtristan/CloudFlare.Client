﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Exceptions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Interfaces;
using CloudFlare.Client.Models;
using Newtonsoft.Json;

namespace CloudFlare.Client
{
    public class CloudFlareClient : ICloudFlareClient
    {
        #region Fields

        private readonly HttpClient _httpClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="emailAddress">Email address</param>
        /// <param name="globalApiKey">CloudFlare Global API Key</param>
        public CloudFlareClient(string emailAddress, string globalApiKey)
        {
            if (string.IsNullOrEmpty(emailAddress)
                || string.IsNullOrEmpty(globalApiKey))
            {
                throw new AuthenticationException();
            }

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.cloudflare.com/client/v4/")
            };

            _httpClient.DefaultRequestHeaders.Add("X-Auth-Email", emailAddress);
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Key", globalApiKey);
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion

        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type = null, string name = "", string content = "", int? page = null, int? perPage = null, OrderType? order = null, bool? match = null)
        {
            var parameterBuilder = new StringBuilder();
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.DnsRecordType, type);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Name, name);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Content, content);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Page, page);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.PerPage, perPage);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Order, order);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Match, match);

            var parameterString = parameterBuilder.Length != 0 ? parameterBuilder.ToString() : "";

            try
            {
                var response = await _httpClient.GetAsync($"zones/{zoneId}/dns_records/{parameterString}");
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<IEnumerable<DnsRecord>>>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
        }

        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl = null, int? priority = null,
            bool? proxied = null)
        {
            try
            {
                var newDnsRecord = new DnsRecord()
                {
                    Content = content,
                    Type = type,
                    Name = name,
                    Ttl = ttl ?? 1,
                    Priority = priority ?? 0,
                    Proxied = proxied
                };
                
                var response = await _httpClient.PostAsJsonAsync($"zones/{zoneId}/dns_records/", newDnsRecord);
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<DnsRecord>>();
                }


                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
        }
    }
}
