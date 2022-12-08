namespace DotNet.Testcontainers.Configurations
{
  using System;
  using System.Collections.Generic;
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Containers;
  using JetBrains.Annotations;

  /// <inheritdoc cref="IResourceConfiguration" />
  [PublicAPI]
  public class ResourceConfiguration : IResourceConfiguration
  {
    public ResourceConfiguration(
      IDockerEndpointAuthenticationConfiguration dockerEndpointAuthenticationConfiguration = null,
      IReadOnlyDictionary<string, string> labels = null)
    {
      this.DockerEndpointAuthConfig = dockerEndpointAuthenticationConfiguration;
      this.Labels = labels;
      this.SessionId = labels != null && labels.TryGetValue(ResourceReaper.ResourceReaperSessionLabel, out var resourceReaperSessionId) && Guid.TryParseExact(resourceReaperSessionId, "D", out var sessionId) ? sessionId : Guid.Empty;
    }

    protected ResourceConfiguration(IResourceConfiguration resourceConfiguration)
      : this(resourceConfiguration, new ResourceConfiguration())
    {
    }

    protected ResourceConfiguration(IResourceConfiguration next, IResourceConfiguration previous)
    {
      this.DockerEndpointAuthConfig = BuildConfiguration.Combine(next.DockerEndpointAuthConfig, previous.DockerEndpointAuthConfig);
      this.Labels = BuildConfiguration.Combine(next.Labels, previous.Labels);
      this.SessionId = BuildConfiguration.Combine(next.SessionId, previous.SessionId);
    }

    /// <inheritdoc />
    public Guid SessionId { get; }

    /// <inheritdoc />
    public IDockerEndpointAuthenticationConfiguration DockerEndpointAuthConfig { get; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, string> Labels { get; }
  }
}
