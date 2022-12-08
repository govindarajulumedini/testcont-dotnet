namespace DotNet.Testcontainers.Configurations
{
  using System.Collections.Generic;
  using DotNet.Testcontainers.Images;

  /// <summary>
  /// A Dockerfile configuration.
  /// </summary>
  public interface IImageFromDockerfileConfiguration : IResourceConfiguration
  {
    /// <summary>
    /// Gets a value indicating whether an existing image is removed or not.
    /// </summary>
    bool DeleteIfExists { get; }

    /// <summary>
    /// Gets the Dockerfile.
    /// </summary>
    string Dockerfile { get; }

    /// <summary>
    /// Gets the Dockerfile directory.
    /// </summary>
    string DockerfileDirectory { get; }

    /// <summary>
    /// Gets the Docker image.
    /// </summary>
    IDockerImage Image { get; }

    /// <summary>
    /// Gets a list of Docker build arguments.
    /// </summary>
    IReadOnlyDictionary<string, string> BuildArguments { get; }
  }
}
