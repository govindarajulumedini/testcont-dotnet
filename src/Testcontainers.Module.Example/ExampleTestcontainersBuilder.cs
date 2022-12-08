namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Configurations;
  using JetBrains.Annotations;
  using Microsoft.Extensions.Logging.Abstractions;

  [PublicAPI]
  public sealed class ExampleTestcontainersBuilder : TestcontainersBuilder<ExampleTestcontainersBuilder, IExampleTestcontainers, IExampleTestcontainersConfiguration>
  {
    public ExampleTestcontainersBuilder()
      : base(new ExampleTestcontainersConfiguration())
    {
    }

    private ExampleTestcontainersBuilder(IExampleTestcontainersConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    public ExampleTestcontainersBuilder WithUsername(string username)
    {
      return this.Merge(new ExampleTestcontainersConfiguration(username: username), this.DockerResourceConfiguration);
    }

    public ExampleTestcontainersBuilder WithPassword(string password)
    {
      return this.Merge(new ExampleTestcontainersConfiguration(password: password), this.DockerResourceConfiguration);
    }

    public override IExampleTestcontainers Build()
    {
      return new ExampleTestcontainers(this.DockerResourceConfiguration, NullLogger.Instance);
    }

    protected override ExampleTestcontainersBuilder Clone(IDockerResourceConfiguration dockerResourceConfiguration)
    {
      // Receives a configuration update from one of the base class implementations. The configuration update only contains properties from either one of the base class configuration types.
      // If we merge the configurations immediately we will lose any properties that are unknown by the base configuration:
      // E.g. for IDockerResourceConfiguration ⨉ IExampleTestcontainersConfiguration we will lose username and password. Due to immutable data we can only merge the same types.
      return this.Merge(new ExampleTestcontainersConfiguration(dockerResourceConfiguration), this.DockerResourceConfiguration);
    }

    protected override ExampleTestcontainersBuilder Clone(ITestcontainersConfiguration dockerResourceConfiguration)
    {
      // Receives a configuration update from one of the base class implementations. The configuration update only contains properties from either one of the base class configuration types.
      // If we merge the configurations immediately we will lose any properties that are unknown by the base configuration:
      // E.g. for ITestcontainersConfiguration ⨉ IExampleTestcontainersConfiguration we will lose username and password. Due to immutable data we can only merge the same types.
      return this.Merge(new ExampleTestcontainersConfiguration(dockerResourceConfiguration), this.DockerResourceConfiguration);
    }

    protected override ExampleTestcontainersBuilder Merge(IExampleTestcontainersConfiguration next, IExampleTestcontainersConfiguration previous)
    {
      return new ExampleTestcontainersBuilder(new ExampleTestcontainersConfiguration(next, previous));
    }
  }
}
