﻿namespace DotNet.Testcontainers.Configurations
{
  using System.Collections.Generic;

  /// <inheritdoc cref="ITestcontainersNetworkConfiguration" />
  internal sealed class TestcontainersNetworkConfiguration : ResourceConfiguration, ITestcontainersNetworkConfiguration
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TestcontainersNetworkConfiguration" /> class.
    /// </summary>
    /// <param name="resourceConfiguration">The Docker resource configuration.</param>
    public TestcontainersNetworkConfiguration(IResourceConfiguration resourceConfiguration)
      : base(resourceConfiguration)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestcontainersNetworkConfiguration" /> class.
    /// </summary>
    /// <param name="dockerEndpointAuthenticationConfiguration">The Docker endpoint authentication configuration.</param>
    /// <param name="name">The name.</param>
    /// <param name="driver">The driver.</param>
    /// <param name="labels">A list of labels.</param>
    /// <param name="options">A list of options.</param>
    public TestcontainersNetworkConfiguration(
      IDockerEndpointAuthenticationConfiguration dockerEndpointAuthenticationConfiguration = null,
      string name = null,
      NetworkDriver driver = default,
      IReadOnlyDictionary<string, string> labels = null,
      IReadOnlyDictionary<string, string> options = null)
      : base(dockerEndpointAuthenticationConfiguration, labels)
    {
      this.Name = name;
      this.Driver = driver;
      this.Options = options;
    }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public NetworkDriver Driver { get; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, string> Options { get; }
  }
}
