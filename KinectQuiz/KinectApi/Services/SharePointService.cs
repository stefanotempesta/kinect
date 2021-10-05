using KinectApi.Models;
using Microsoft.Office365.SharePoint.CoreServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KinectApi.Services
{
    public class SharePointService
    {
        public async Task<IEnumerable<Quiz>> GetQuizzes(string accessToken)
        {
            string requestUrl = SiteUrl + "/_api/Web/Lists/GetByTitle('Kinect Quiz')/Items";

            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage response = await client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return await response.Content.ReadAsAsync<IEnumerable<Quiz>>();
            }
        }

        private HttpClient NewApiClient()
        {
            var apiClient = new HttpClient
            {
                BaseAddress = new Uri(SiteUrl)
            };

            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/atom+xml"));

            return apiClient;
        }

        public string SiteUrl => ConfigurationManager.AppSettings["SharePointSiteUrl"];
    }
}
