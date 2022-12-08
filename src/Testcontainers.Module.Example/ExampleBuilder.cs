namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Configurations;
  using JetBrains.Annotations;
  using Microsoft.Extensions.Logging.Abstractions;

  [PublicAPI]
  public sealed class ExampleBuilder : ContainerBuilder<ExampleBuilder, IExampleContainer, IExampleConfiguration>
  {
    public ExampleBuilder()
      : base(new ExampleConfiguration())
    {
    }

    private ExampleBuilder(IExampleConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    public ExampleBuilder WithUsername(string username)
    {
      return this.Merge(new ExampleConfiguration(username: username), this.DockerResourceConfiguration);
    }

    public ExampleBuilder WithPassword(string password)
    {
      return this.Merge(new ExampleConfiguration(password: password), this.DockerResourceConfiguration);
    }

    public override IExampleContainer Build()
    {
      return new ExampleContainer(this.DockerResourceConfiguration, NullLogger.Instance);
    }

    protected override ExampleBuilder Clone(IResourceConfiguration resourceConfiguration)
    {
      // Receives a configuration update from the base class implementations. The configuration update only contains properties from the base class configuration types.
      // If we merge the configurations immediately we will lose any properties that are unknown by the base configuration:
      // E.g. for IResourceConfiguration ⨉ IExampleConfiguration we will lose username and password. Due to immutable data we can only merge the same types.
      return this.Merge(new ExampleConfiguration(resourceConfiguration), this.DockerResourceConfiguration);
    }

    protected override ExampleBuilder Clone(IContainerConfiguration resourceConfiguration)
    {
      // Receives a configuration update from the base class implementations. The configuration update only contains properties from the base class configuration types.
      // If we merge the configurations immediately we will lose any properties that are unknown by the base configuration:
      // E.g. for IContainerConfiguration ⨉ IExampleConfiguration we will lose username and password. Due to immutable data we can only merge the same types.
      return this.Merge(new ExampleConfiguration(resourceConfiguration), this.DockerResourceConfiguration);
    }

    protected override ExampleBuilder Merge(IExampleConfiguration next, IExampleConfiguration previous)
    {
      return new ExampleBuilder(new ExampleConfiguration(next, previous));
    }
  }
}
