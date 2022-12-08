namespace DotNet.Testcontainers.Builders
{
  using System;
  using DotNet.Testcontainers.Configurations;
  using DotNet.Testcontainers.Containers;
  using JetBrains.Annotations;

  /// <inheritdoc cref="TestcontainersBuilder{TBuilderEntity, TContainerEntity, TConfigurationEntity}" />
  [PublicAPI]
  public sealed class TestcontainersBuilder : TestcontainersBuilder<TestcontainersBuilder, ITestcontainersContainer, ITestcontainersConfiguration>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TestcontainersBuilder" /> class.
    /// </summary>
    public TestcontainersBuilder()
      : this(new TestcontainersConfiguration())
    {
    }

    private TestcontainersBuilder(ITestcontainersConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    /// <inheritdoc />
    public override ITestcontainersContainer Build()
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    protected override TestcontainersBuilder Clone(IDockerResourceConfiguration dockerResourceConfiguration)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    protected override TestcontainersBuilder Clone(ITestcontainersConfiguration dockerResourceConfiguration)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    protected override TestcontainersBuilder Merge(ITestcontainersConfiguration next, ITestcontainersConfiguration previous)
    {
      throw new NotImplementedException();
    }
  }
}
