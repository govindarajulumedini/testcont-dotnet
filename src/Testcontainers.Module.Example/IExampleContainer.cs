namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Containers;
  using JetBrains.Annotations;

  [PublicAPI]
  public interface IExampleContainer : ITestcontainersContainer
  {
    [PublicAPI]
    string Username { get; }

    [PublicAPI]
    string Password { get; }
  }
}
