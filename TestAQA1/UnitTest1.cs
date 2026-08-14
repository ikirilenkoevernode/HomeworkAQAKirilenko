using System.Net.Http.Json;
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
            using HttpResponseMessage response = await client.GetAsync("users/2");
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
        [Test]
        public async Task Test3()
        {
            CreateUserRequestDTO request = new CreateUserRequestDTO
            {
                Name = "John Worker",
                Job = "QA ChillGuy"
            };

            using HttpResponseMessage response = await client.PostAsJsonAsync("users", request);
            string jsonPost = await response.Content.ReadAsStringAsync();
            CreateUserResponseTest3DTO userResponse = JsonSerializer.Deserialize<CreateUserResponseTest3DTO>(jsonPost);
        }
        [Test]
        public async Task Test4()
        {
            CreateUserRequestDTO request = new CreateUserRequestDTO
            {
                Name = "John Worker",
                Job = "QA Amongusuv"
            };

            using HttpResponseMessage response = await client.PutAsJsonAsync("users/2", request);
            response.EnsureSuccessStatusCode();

        }
        [Test]
        public async Task Test5()
        {
            using HttpResponseMessage response = await client.DeleteAsync("users/2");

            response.EnsureSuccessStatusCode();
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}
