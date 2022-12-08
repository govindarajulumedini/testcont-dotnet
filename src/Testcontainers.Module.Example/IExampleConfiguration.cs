namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Configurations;

  public interface IExampleConfiguration : IContainerConfiguration
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
