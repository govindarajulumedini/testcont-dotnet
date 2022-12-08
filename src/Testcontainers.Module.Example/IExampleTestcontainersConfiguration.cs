namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Configurations;

  public interface IExampleTestcontainersConfiguration : ITestcontainersConfiguration
  {
    /// <summary>
    ///
    /// </summary>
    string Username { get; }

    /// <summary>
    ///
    /// </summary>
    string Password { get; }
  }
}
