using System.Text.Json;

namespace TestAQA1
{
    public class Tests
    {
        private static HttpClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://reqres.in/api/")
            };
            client.DefaultRequestHeaders.Add("x-api-key", "free_user_3Hs5R7VxAD3zzrYAcdt3Anqc5bY");             // free_user_3Hs5R7VxAD3zzrYAcdt3Anqc5bY

        }
        [Test]
        public async Task Test1()
        {
            using HttpResponseMessage response = await client.GetAsync("users/25");
            response.EnsureSuccessStatusCode();
        }
        [Test]
        public async Task Test2()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            string jsonGet = await response.Content.ReadAsStringAsync();
            UserResponseDTO userResponse = JsonSerializer.Deserialize<UserResponseDTO>(jsonGet);
            UserDataDTO user = userResponse.Data;
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}
