using KinectApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services
{
    public class QuizService
    {
        public async Task<IEnumerable<Quiz>> GetQuizzes()
        {
            using (var client = NewApiClient())
            {
                HttpResponseMessage response = await client.GetAsync(ApiUri);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return await response.Content.ReadAsAsync<IEnumerable<Quiz>>();
            }
        }

        public async Task<Quiz> CreateQuiz(Quiz item)
        {
            using (var client = NewApiClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync<Quiz>(ApiUri, item);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return await response.Content.ReadAsAsync<Quiz>();
            }
        }

        public async Task UpdateQuiz(Quiz item)
        {
            using (var client = NewApiClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync<Quiz>(ApiUri, item);
            }
        }

        public async Task<Quiz> DeleteQuiz(Quiz item)
        {
            using (var client = NewApiClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{ApiUri}/{item.Id}");
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return await response.Content.ReadAsAsync<Quiz>();
            }
        }

        private HttpClient NewApiClient()
        {
            var apiClient = new HttpClient
            {
                BaseAddress = new Uri(QuizApiBaseAddress)
            };

            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return apiClient;
        }

        private const string ApiUri = "api/quiz/";

        private string QuizApiBaseAddress => ConfigurationManager.AppSettings["QuizApiBaseAddress"];
    }
}
