namespace BlazorWebAssemblyApp.Tests
{
    public class VerifyConfigurationTests
    {
        [Fact]
        public async Task VerifyIsConfiguredCorrectly()
        {
            await VerifyChecks.Run();
        }
    }
}
