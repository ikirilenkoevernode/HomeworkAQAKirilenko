
namespace TestHomework15
{
    using FluentAssertions;
    using FluentAssertions.Execution;
    using System.Data;
    using System.Text.Json;
    using TestHomework15.DTO;
    using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

    public class TestUserDataHomework15
    {
        private RootDTO allUsers;
        [OneTimeSetUp]
        public void Setup()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "UsersData.json");
            string json = File.ReadAllText(path);
            allUsers = JsonSerializer.Deserialize<RootDTO>(json);
        }

        [Test]
        public void Test1_CheckUsersCountTen()
        {
            foreach (var user in allUsers.Data)
            {
                TestContext.WriteLine($" {user.Id}");
            }
            allUsers.Data.Should().NotBeNull();
            allUsers.Data.Should().HaveCount(10);
        }
        [Test]
        public void Test2_CheckFirstUserName()
        {
            TestContext.WriteLine($" {allUsers.Data[0].Profile.FullName}");
            allUsers.Data[0].Should().NotBeNull();
            allUsers.Data[0].Profile.FullName.Should().Be("Alice Johnson");
        }
        [Test]
        public void Test3_CheckUserUniqueId()
        {
            foreach (var user in allUsers.Data)
            {
                TestContext.WriteLine($" {user.Id}");
            }
            var allId = allUsers.Data
                .Select(x => x.Id)
                .ToList();
            allId.Should().OnlyHaveUniqueItems();
        }
        [Test]
        public void Test4_AtLeastOnePremium()
        {
            List<string> tags = [];
            foreach (var user in allUsers.Data)
            {
                foreach (var tag in user.Profile.Tags)
                {
                    TestContext.WriteLine($" {tag}");
                    tags.Add(tag.ToLower());
                }

            }
            tags.Should().Contain("premium");
        }
        [Test]
        public void Test5_CheckCitesNotNull()
        {
            foreach (var user in allUsers.Data)
            {
                TestContext.WriteLine($" {user.Profile.Address.City}");
                user.Profile.Address.City.Should().NotBeNull();

            }
        }
        [Test]
        public void Test6_CheckIfOneisFromStockholm()
        {
            List<string> cities = [];
            foreach (var user in allUsers.Data)
            {
                TestContext.WriteLine($" {user.Profile.Address.City}");
                cities.Add(user.Profile.Address.City.ToLower());
            }
            cities.Should().Contain("stockholm");
        }
        [Test]
        public void Test7_CheckUserAgeIsFrom18To60()
        {
            foreach (var user in allUsers.Data)
            {
                TestContext.WriteLine($" {user.Profile.Age}");
                user.Profile.Age.Should().BeInRange(18, 60);
            }
        }
        [Test]
        public void Test8_CheckAtLeastOneAdmin()
        {
            List<string> roles = [];
            foreach (var user in allUsers.Data)
            {
                foreach (var role in user.Roles)
                {
                    TestContext.WriteLine($" {role}");
                    roles.Add(role.ToLower());
                }

            }
            roles.Should().Contain("admin");
        }
        [Test]
        public void TestExtra3()
        {
            foreach (var user in allUsers.Data)
            {
                var geo = user.Profile.Address.Geo;
                TestContext.WriteLine($"{geo}");
                geo.Lat.Should().BeInRange(55, 69);
                geo.Lng.Should().BeInRange(11, 24);
            }
        }
        [Test]
        public void TestExtra4()
        {
            foreach (var user in allUsers.Data)
            {
                var street = user.Profile.Address.Street;
                street.Should().MatchRegex(@"\d+");
                street.Should().MatchRegex(@"^[A-Za-zА-Яа-яÅÄÖåäö]");
                street.Should().NotMatchRegex(@"^\d+$");
                TestContext.WriteLine($"{street}");
            }
        }
    }
}