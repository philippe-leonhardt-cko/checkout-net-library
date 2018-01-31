using Checkout.ApiServices.SharedModels;
using Checkout.Helpers;
using Checkout.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout
{
    /// <summary>
    /// Handles http requests and responses
    /// </summary>
    public sealed class ApiHttpClient
    {
        private HttpClientHandler requestHandler;
        private HttpClient httpClient;

        public ApiHttpClient()
        {
            ResetHandler();
        }

        public void ResetHandler()
        {
            if (requestHandler != null)
            {
                requestHandler.Dispose();
            }

            requestHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
                AllowAutoRedirect = false,
                UseDefaultCredentials = false,
                UseCookies = false
            };

            if (httpClient != null)
            {
                httpClient.Dispose();
            }

            httpClient = new HttpClient(requestHandler)
            {
                MaxResponseContentBufferSize = AppSettings.MaxResponseContentBufferSize,
                Timeout = TimeSpan.FromSeconds(AppSettings.RequestTimeout)
            };
            
            SetHttpRequestHeader("User-Agent",AppSettings.ClientUserAgentName);
            httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("Gzip"));
        }

        public void SetHttpRequestHeader(string name, string value)
        {
            if (httpClient.DefaultRequestHeaders.Contains(name))
            {
                httpClient.DefaultRequestHeaders.Remove(name);
            }

            if (value != null)
            { httpClient.DefaultRequestHeaders.Add(name, value); }
        }

        public string GetHttpRequestHeader(string name)
        {
            httpClient.DefaultRequestHeaders.TryGetValues(name, out IEnumerable<string> values);

            if (values != null && values.Any())
            { return values.First(); }

            return null;
        }


        public string callerSection = "";
        /// <summary>
        /// Submits a get request to the given web address with default content type e.g. text/plain
        /// </summary>
        public HttpResponse<T> GetRequest<T>(string requestUri, string authenticationKey, [CallerMemberName] string callerFunction = "")
        {
            var httpRequestMsg = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUri)
            };
            httpRequestMsg.Headers.Add("Accept", AppSettings.DefaultContentType);

            SetHttpRequestHeader("Authorization", authenticationKey);

            callerSection = callerFunction;

            return SendRequest<T>(httpRequestMsg).Result;
        }

        /// <summary>
        /// Submits a post request to the given web address
        /// </summary>
        public HttpResponse<T> PostRequest<T>(string requestUri, string authenticationKey, object requestPayload = null, [CallerMemberName] string callerFunction = "")
        {
            var httpRequestMsg = new HttpRequestMessage(HttpMethod.Post, requestUri);
            var requestPayloadAsString = GetObjectAsString(requestPayload);

            httpRequestMsg.Content = new StringContent(requestPayloadAsString, Encoding.UTF8, AppSettings.DefaultContentType);
            httpRequestMsg.Headers.Add("Accept", AppSettings.DefaultContentType);
            
            SetHttpRequestHeader("Authorization", authenticationKey);

            callerSection = callerFunction;

            return SendRequest<T>(httpRequestMsg, requestPayloadAsString).Result;
        }

        /// <summary>
        /// Submits a put request to the given web address
        /// </summary>
        public HttpResponse<T> PutRequest<T>(string requestUri, string authenticationKey, object requestPayload = null, [CallerMemberName] string callerFunction = "")
        {
            var httpRequestMsg = new HttpRequestMessage(HttpMethod.Put, requestUri);
            var requestPayloadAsString = GetObjectAsString(requestPayload);

            httpRequestMsg.Content = new StringContent(requestPayloadAsString, Encoding.UTF8, AppSettings.DefaultContentType);
            httpRequestMsg.Headers.Add("Accept", AppSettings.DefaultContentType);

            SetHttpRequestHeader("Authorization", authenticationKey);

            callerSection = callerFunction;

            return SendRequest<T>(httpRequestMsg, requestPayloadAsString).Result;
        }

        /// <summary>
        /// Submits a delete request to the given web address
        /// </summary>
        public HttpResponse<T> DeleteRequest<T>(string requestUri, string authenticationKey, [CallerMemberName] string callerFunction = "")
        {
            var httpRequestMsg = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(requestUri)
            };
            httpRequestMsg.Headers.Add("Accept", AppSettings.DefaultContentType);

            SetHttpRequestHeader("Authorization", authenticationKey);

            callerSection = callerFunction;

            return SendRequest<T>(httpRequestMsg).Result; 
        }

        /// <summary>
        /// Sends a http request with the given object. All headers should be set manually here e.g. content type=application/json
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private Task<HttpResponse<T>> SendRequest<T>(HttpRequestMessage request, string payload = null)
        {
            Task<HttpResponse<T>> response = null;
            HttpResponseMessage responseMessage = null;
            string responseAsString = null;
            string responseCode = null;

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                responseMessage = httpClient.SendAsync(request).Result; 
               
                responseCode = responseMessage.StatusCode.ToString();

                var responseContent = responseMessage.Content.ReadAsByteArrayAsync().Result;

                if (responseContent != null && responseContent.Length > 0)
                {
                    responseAsString = Encoding.UTF8.GetString(responseContent);

                    if (AppSettings.DebugMode)
                    {
                        Console.WriteLine(string.Format("\n<{0}>", callerSection));
                        Console.WriteLine(string.Format("\n** HttpRequest ** - Type {0}\n\n\t{1}", request.Method.ToString().ToUpper(), request.RequestUri));
                        if (payload != null)
                        {
                            Console.WriteLine(string.Format("\n** Payload **\n\n\t{0}\n", payload));
                        }
                        Console.WriteLine(string.Format("\n** HttpResponse ** - Status {0}\n\n\t{1}\n", responseMessage.StatusCode, responseAsString));
                        Console.WriteLine(string.Format("</{0}>\n", callerSection));
                        callerSection = "";
                    }
                }

                response = Task.FromResult(CreateHttpResponse<T>(responseAsString, responseMessage.StatusCode));
            }
            catch (Exception ex)
            {
                if (AppSettings.DebugMode)
                {
                    Console.WriteLine(string.Format(@"\n** Exception - HttpStatuscode:\n{0}**\n\n 
                        ** ResponseString {1}\n ** Exception Messages{2}\n ", (responseMessage != null ? responseMessage.StatusCode.ToString() : string.Empty), responseAsString, ExceptionHelper.FlattenExceptionMessages(ex)));
                }

                responseCode = "Exception" + ex.Message;

                throw;
            }
            finally
            {
                request.Dispose();
                ResetHandler();
            }

            return response;
        }

        private HttpResponse<T> CreateHttpResponse<T>(string responseAsString, HttpStatusCode httpStatusCode)
        {
            if (httpStatusCode == HttpStatusCode.OK && responseAsString != null)
            {
                return new HttpResponse<T>(GetResponseAsObject<T>(responseAsString))
                {
                    HttpStatusCode = httpStatusCode
                };
            }
            else if (responseAsString != null)
            {
                return new HttpResponse<T>(default(T))
                {
                    Error = GetResponseAsObject<ResponseError>(responseAsString),
                    HttpStatusCode = httpStatusCode
                };
            }

            return null;
        }

        private string GetObjectAsString(object requestModel)
        {
            return ContentAdaptor.ConvertToJsonString(requestModel);
        }

        private T GetResponseAsObject<T>(string responseAsString)
        {
            return ContentAdaptor.JsonStringToObject<T>(responseAsString);
        }

    }
}
