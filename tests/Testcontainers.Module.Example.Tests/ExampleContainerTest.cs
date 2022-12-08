namespace Testcontainers.Module.Example.Tests
{
  using Xunit;

  public sealed class ExampleContainerTest
  {
    private const string Username = "Foo";

    private const string Password = "Bar";

    [Fact]
    public void CreateCopyOfBuilderConfiguration()
    {
      var baseBuilder = new ExampleBuilder()
        .WithUsername(Username)
        .WithPassword(Password);

      var container1 = baseBuilder
        .WithPassword(string.Empty)
        .Build();

      var container2 = baseBuilder
        .Build();

      Assert.Equal(Username, container1.Username);
      Assert.Equal(Username, container2.Username);
      Assert.Equal(string.Empty, container1.Password);
      Assert.Equal(Password, container2.Password);
    }
  }
}
