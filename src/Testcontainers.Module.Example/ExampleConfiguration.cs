namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Configurations;
  using JetBrains.Annotations;

  /// <inheritdoc cref="IExampleConfiguration" />
  [PublicAPI]
  public class ExampleConfiguration : ContainerConfiguration, IExampleConfiguration
  {
    public ExampleConfiguration(
      string username = null,
      string password = null)
    {
      this.Username = username;
      this.Password = password;
    }

    public ExampleConfiguration(IResourceConfiguration resourceConfiguration)
      : base(resourceConfiguration)
    {
    }

    public ExampleConfiguration(IContainerConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    public ExampleConfiguration(IExampleConfiguration dockerResourceConfiguration)
      : this(dockerResourceConfiguration, new ExampleConfiguration())
    {
    }

    public ExampleConfiguration(IExampleConfiguration next, IExampleConfiguration previous)
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
