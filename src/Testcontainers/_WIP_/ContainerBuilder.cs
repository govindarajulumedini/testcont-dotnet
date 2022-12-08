namespace DotNet.Testcontainers.Builders
{
  using System;
  using DotNet.Testcontainers.Configurations;
  using DotNet.Testcontainers.Containers;
  using JetBrains.Annotations;

  /// <inheritdoc cref="ContainerBuilder{TBuilderEntity,TContainerEntity,TConfigurationEntity}" />
  [PublicAPI]
  public sealed class ContainerBuilder : ContainerBuilder<ContainerBuilder, ITestcontainersContainer, IContainerConfiguration>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContainerBuilder" /> class.
    /// </summary>
    public ContainerBuilder()
      : this(new ContainerConfiguration())
    {
    }

    private ContainerBuilder(IContainerConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    /// <inheritdoc />
    public override ITestcontainersContainer Build()
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    protected override ContainerBuilder Clone(IResourceConfiguration resourceConfiguration)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    protected override ContainerBuilder Clone(IContainerConfiguration resourceConfiguration)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    protected override ContainerBuilder Merge(IContainerConfiguration next, IContainerConfiguration previous)
    {
      throw new NotImplementedException();
    }
  }
}
