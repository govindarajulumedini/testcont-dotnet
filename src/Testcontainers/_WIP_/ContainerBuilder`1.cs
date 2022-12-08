namespace DotNet.Testcontainers.Builders
{
  using System;
  using DotNet.Testcontainers.Configurations;
  using DotNet.Testcontainers.Containers;
  using JetBrains.Annotations;

  /// <inheritdoc cref="ContainerBuilder{TBuilderEntity,TContainerEntity,TConfigurationEntity}" />
  [PublicAPI]
  public sealed class ContainerBuilder<TContainerEntity> : ContainerBuilder<ContainerBuilder<TContainerEntity>, TContainerEntity, IContainerConfiguration>
    where TContainerEntity : ITestcontainersContainer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContainerBuilder{TContainerEntity}" /> class.
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
    public override TContainerEntity Build()
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    protected override ContainerBuilder<TContainerEntity> Clone(IResourceConfiguration resourceConfiguration)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    protected override ContainerBuilder<TContainerEntity> Clone(IContainerConfiguration resourceConfiguration)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    protected override ContainerBuilder<TContainerEntity> Merge(IContainerConfiguration next, IContainerConfiguration previous)
    {
      throw new NotImplementedException();
    }
  }
}
