using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using apiconsume2.Models;
using System;

namespace apiconsume2.Repositories
{
    public class SBrewRepository
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerSettings _jsonSettings;

        public SBrewRepository()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://csadms.com/Devbox/DevboxAPI/api/PortfolioAPI/")
            };

            _jsonSettings = new JsonSerializerSettings
            {
                DateFormatString = "dd-MM-yyyy",
                Converters = new List<JsonConverter>
                {
                    new IsoDateTimeConverter { DateTimeFormat = "dd-MM-yyyy" }
                }
            };
        }

        public async Task<IEnumerable<SBrew>> GetSBrewsAsync(int pageno, int pagesize, int id = 0)
        {
            try
            {
                string requestUri;

                if (id > 0)
                {
                    // Fetch a single SBrew by ID
                    requestUri = $"NewPortfolioList/{id}";
                }
                else
                {
                    // Fetch a list of SBrews with pagination
                    requestUri = $"NewPortfolioList?pageno={pageno}&pagesize={pagesize}";
                }

                var response = await _httpClient.GetAsync(requestUri);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = $"Failed to get SBrews. Status code: {response.StatusCode}, Reason: {response.ReasonPhrase}";
                    throw new ApplicationException(errorMessage);
                }

                var responseData = await response.Content.ReadAsStringAsync();

                if (id > 0)
                {
                    // Deserialize single SBrew response
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<SBrew>>(responseData, _jsonSettings);
                    return apiResponse.Data != null ? new List<SBrew> { apiResponse.Data } : new List<SBrew>();
                }
                else
                {
                    // Deserialize list of SBrews response
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<SBrew>>>(responseData, _jsonSettings);
                    if (apiResponse == null)
                    {
                        throw new ApplicationException("Deserialized response was null.");
                    }

                    return apiResponse.Data;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("There was a problem retrieving the data from the server.", ex);
            }
            catch (JsonException ex)
            {
                throw new ApplicationException("There was a problem deserializing the data.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred.", ex);
            }
        }

        public async Task<SBrew> GetSBrewByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID provided. ID must be greater than zero.");
            }

            try
            {
                var requestUri = $"NewPortfolioList/{id}";
                var response = await _httpClient.GetAsync(requestUri);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = $"Failed to get SBrew by ID. Status code: {response.StatusCode}, Reason: {response.ReasonPhrase}";
                    throw new ApplicationException(errorMessage);
                }

                var responseData = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<SBrew>>(responseData, _jsonSettings);

                if (apiResponse == null)
                {
                    throw new ApplicationException("Deserialized response was null.");
                }

                return apiResponse.Data;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("There was a problem retrieving the data from the server.", ex);
            }
            catch (JsonException ex)
            {
                throw new ApplicationException("There was a problem deserializing the data.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred.", ex);
            }
        }
    }
}
