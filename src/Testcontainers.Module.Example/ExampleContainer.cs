namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Containers;
  using Microsoft.Extensions.Logging;

  internal sealed class ExampleContainer : TestcontainersContainer, IExampleContainer
  {
    public ExampleContainer(IExampleConfiguration configuration, ILogger logger)
      : base(configuration, logger)
    {
      this.Username = configuration.Username;
      this.Password = configuration.Password;
    }

    public string Username { get; }

    public string Password { get; }
  }
}
