
namespace TestHomework15
{
    using FluentAssertions;
    using FluentAssertions.Execution;
    using System.Data;
    using System.Text.Json;
    using TestHomework15.DTO;
    using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
    using HelpClasses;
    public class TestUserDataHomework15
    {
        private List<UserInfo> Users = [];

        [OneTimeSetUp]

        public void Setup()
        {
            var json = FileReader.ReadFile("Resources/UsersData.json");
            Users = JsonSerializer.Deserialize<RootDTO>(json).Data;       
        }

        [Test]
        public void Test1_CheckUsersCountTen()
        {
            foreach (var user in Users)
            {
                TestContext.WriteLine($" {user.Id}");
            }
            Users.Should().NotBeNull();
            Users.Should().HaveCount(10);
        }
        [Test]
        public void Test2_CheckFirstUserName()
        {
            var firstUser = Users.First();
            TestContext.WriteLine($" {firstUser.Profile.FullName}");
            firstUser.Should().NotBeNull();
            firstUser.Profile.FullName.Should().Be("Alice Johnson");
        }
        [Test]
        public void Test3_CheckUserUniqueId()
        {

            var ids = Users.Select(u => u.Id).ToList();
            foreach (var id in ids)
            {
                TestContext.WriteLine($" {id}");
            }
            ids.Should().OnlyHaveUniqueItems();
        }
        [Test]
        public void Test4_AtLeastOnePremium()
        {
            var premiumUsers = Users.Where(u => u.Profile.Tags.Contains("premium")).ToList();
            premiumUsers.Should().NotBeEmpty();
        }
        [Test]
        public void Test5_CheckCitesNotNull()
        {
            var cities = Users.Select(u => u.Profile.Address.City).ToList();
            cities.Should().OnlyContain(c => !string.IsNullOrWhiteSpace(c));
        }
        [Test]
        public void Test6_CheckIfOneisFromStockholm()
        {
            var stockholmUser = Users.FirstOrDefault(u => u.Profile.Address.City == "Stockholm");
            stockholmUser.Should().NotBeNull();
        }
        [Test]
        public void Test7_CheckUserAgeIsFrom18To60()
        {
            var ages = Users.Select(u => u.Profile.Age).ToList();
            foreach (var age in ages)
            {
                TestContext.WriteLine($" {age}");
            }
            ages.Should().OnlyContain(age => age >= 18 && age <= 60);
        }
        [Test]
        public void Test8_CheckAtLeastOneAdmin()
        {
            var admins = Users.Where(u => u.Roles.Contains("admin")).ToList();
            admins.Should().NotBeEmpty();
        }
        [Test]
        public void TestExtra3()
        {
            foreach (var user in Users)
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
            foreach (var user in Users)
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