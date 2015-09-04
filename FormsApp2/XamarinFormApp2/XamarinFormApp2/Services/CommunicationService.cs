namespace XamarinFormApp2.Services
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using XamarinFormApp2.Commons;
    using XamarinFormApp2.Entities;
    using XamarinFormApp2.Extensions;
    using XamarinFormApp2.Interfaces;

    public class CommunicationService : ICommunicationService
    {
        /// <summary>
        /// The HTTP client.
        /// </summary>
        private readonly HttpClient httpClient;

        private readonly IJsonSerializer jsonSerializer;


        public CommunicationService(IJsonSerializer jsonSerializer)
        {
            this.jsonSerializer = jsonSerializer;

            this.httpClient = new HttpClient();
        }


        public async Task<NetworkResponse<TestData>> GetTestDataAsync()
        {

            var requestUri =
                new Uri("http://www.mocky.io/v2/55e6c13113cc83ec0dda068a");

            var request = this.GetRequest(HttpMethod.Get, requestUri);

            var result =
                await
                this.GetNetworkResponseAsync<TestData>(requestUri, request, this.jsonSerializer, true)
                    .ConfigureAwait(false);

            return result;
        }

        private HttpRequestMessage GetRequest(HttpMethod method, Uri requestUri)
        {
            var request = new HttpRequestMessage(method, requestUri);
            //request.Headers.Add(DeviceIdHeader, this.deviceInformationService.DeviceUniqueId);
            return request;
        }

        private async Task<NetworkResponse<TResponse>> GetNetworkResponseAsync<TResponse>(
            Uri requestUri,
            HttpRequestMessage request,
            ISerializer serializer,
            bool showActivity) where TResponse : class
        {
            NetworkResponse<TResponse> networkResponse = null;

            try
            {
                var response = await this.httpClient.SendAsync(request).ConfigureAwait(false);

                if (response == null)
                {
                    return null;
                }

                if (typeof(TResponse) == typeof(string))
                {
                    string responseString = null;
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    }

                    networkResponse = response.ToStringNetworkResponse<TResponse>(responseString);
                }
                else
                {
                    Stream responseStream = null;
                    if (response.IsSuccessStatusCode)
                    {
                        responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    }

                    // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                    if (typeof(TResponse) == typeof(Stream))
                    {
                        networkResponse = response.ToStreamNetworkResponse<TResponse>(responseStream);
                    }
                    else
                    {
                        networkResponse = response.ToDeserializedNetworkResponse<TResponse>(responseStream, serializer);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    string.Format(
                        "Error getting network response from {0}. Error: {1}",
                        requestUri.OriginalString,
                        ex.Message));

                return null;
            }
            finally
            {
                var statusCode = networkResponse == null ? null : networkResponse.StatusCode.ToString();
            }

            return networkResponse;
        }

        /// <summary>
        /// Gets the network response asynchronously.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="request">The request.</param>
        /// <param name="showActivity">if set to <c>true</c> show activity.</param>
        /// <returns>The task returning the network response.</returns>
        private async Task<NetworkResponse> GetNetworkResponseAsync(
            Uri requestUri,
            HttpRequestMessage request,
            bool showActivity)
        {
            HttpResponseMessage response = null;

            try
            {
                response = await this.httpClient.SendAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    string.Format(
                        "Error getting network response from {0}. Error: {1}",
                        requestUri.OriginalString,
                        ex.Message));

                return null;
            }
            finally
            {
                var statusCode = response == null ? null : response.StatusCode.ToString();
            }

            return response.ToNetworkResponse();
        }

        /// <summary>
        /// Gets the successful network response with the specified result.
        /// </summary>
        /// <typeparam name="T">The type of the response</typeparam>
        /// <param name="response">The response.</param>
        /// <returns>The successful network response with the specified result.</returns>
        private NetworkResponse<T> GetSuccessfulNetworkResponse<T>(T response) where T : class
        {
            return new NetworkResponse<T>(true, HttpStatusCode.OK, NetworkResponseStatus.Success, "OK", response);
        }
    }
}
