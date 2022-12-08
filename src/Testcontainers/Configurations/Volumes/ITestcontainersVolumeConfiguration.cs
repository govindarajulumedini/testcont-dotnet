namespace DotNet.Testcontainers.Configurations
{
  /// <summary>
  /// A Docker volume configuration.
  /// </summary>
  public interface ITestcontainersVolumeConfiguration : IResourceConfiguration
  {
    /// <summary>
    /// Gets the name.
    /// </summary>
    string Name { get; }
  }
}
