using System.Collections.Generic;
using Xunit;

namespace FinalTask.utilities
{
    public static class TestDataProvider
    {
        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
            new object[] { "", "", "Username is required" },
            new object[] { "standard_user", "", "Password is required" },
            new object[] { "standard_user", "secret_sauce", "Swag Labs" }
            };
    }
}