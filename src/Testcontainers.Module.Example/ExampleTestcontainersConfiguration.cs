namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Configurations;
  using JetBrains.Annotations;

  /// <inheritdoc cref="IExampleTestcontainersConfiguration" />
  [PublicAPI]
  public class ExampleTestcontainersConfiguration : TestcontainersConfiguration, IExampleTestcontainersConfiguration
  {
    public ExampleTestcontainersConfiguration(
      string username = null,
      string password = null)
    {
      this.Username = username;
      this.Password = password;
    }

    public ExampleTestcontainersConfiguration(IDockerResourceConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    public ExampleTestcontainersConfiguration(ITestcontainersConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    public ExampleTestcontainersConfiguration(IExampleTestcontainersConfiguration dockerResourceConfiguration)
      : this(dockerResourceConfiguration, new ExampleTestcontainersConfiguration())
    {
    }

    public ExampleTestcontainersConfiguration(IExampleTestcontainersConfiguration next, IExampleTestcontainersConfiguration previous)
      : base(next, previous)
    {
      this.Username = BuildConfiguration.Combine(next.Username, previous.Username);
      this.Password = BuildConfiguration.Combine(next.Password, previous.Password);
    }

    /// <inheritdoc />
    public string Username { get; }

    /// <inheritdoc />
    public string Password { get; }
  }
}
