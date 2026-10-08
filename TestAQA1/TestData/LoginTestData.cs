using System.Text.Json;
using NUnit.Framework;

namespace TestAQA.Tests.TestData;

public static class LoginTestData
{
    public static IEnumerable<TestCaseData> ValidUsers()
    {
        var path = Path.Combine(
            TestContext.CurrentContext.TestDirectory,
            "TestData",
            "users.json");

        var json = File.ReadAllText(path);

        var users = JsonSerializer.Deserialize<List<UserData>>(json)
                    ?? throw new Exception("Users data was not loaded");

        foreach (var user in users)
        {
            yield return new TestCaseData(user.Username, user.Password)
                .SetName($"Login with {user.Username}");
        }
    }
}