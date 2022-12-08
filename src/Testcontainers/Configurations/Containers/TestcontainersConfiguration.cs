namespace DotNet.Testcontainers.Configurations
{
  using System;
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Docker.DotNet.Models;
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Containers;
  using DotNet.Testcontainers.Images;
  using DotNet.Testcontainers.Networks;
  using JetBrains.Annotations;

  /// <inheritdoc cref="ITestcontainersConfiguration" />
  [PublicAPI]
  public class TestcontainersConfiguration : DockerResourceConfiguration, ITestcontainersConfiguration
  {
    public TestcontainersConfiguration(
      IDockerRegistryAuthenticationConfiguration dockerRegistryAuthenticationConfiguration = null,
      IDockerImage image = null,
      Func<ImagesListResponse, bool> imagePullPolicy = null,
      string name = null,
      string hostname = null,
      string macAddress = null,
      string workingDirectory = null,
      IEnumerable<string> entrypoint = null,
      IEnumerable<string> command = null,
      IReadOnlyDictionary<string, string> environments = null,
      IReadOnlyDictionary<string, string> exposedPorts = null,
      IReadOnlyDictionary<string, string> portBindings = null,
      IReadOnlyDictionary<string, IResourceMapping> resourceMappings = null,
      IEnumerable<IMount> mounts = null,
      IEnumerable<IDockerNetwork> networks = null,
      IEnumerable<string> networkAliases = null,
      IOutputConsumer outputConsumer = null,
      IEnumerable<IWaitUntil> waitStrategies = null,
      IReadOnlyList<Action<CreateContainerParameters>> parameterModifiers = null,
      Func<ITestcontainersContainer, CancellationToken, Task> startupCallback = null,
      bool? autoRemove = null,
      bool? privileged = null)
    {
      this.AutoRemove = autoRemove;
      this.Privileged = privileged;
      this.DockerRegistryAuthConfig = dockerRegistryAuthenticationConfiguration;
      this.Image = image;
      this.ImagePullPolicy = imagePullPolicy;
      this.Name = name;
      this.Hostname = hostname;
      this.MacAddress = macAddress;
      this.WorkingDirectory = workingDirectory;
      this.Entrypoint = entrypoint;
      this.Command = command;
      this.Environments = environments;
      this.ExposedPorts = exposedPorts;
      this.PortBindings = portBindings;
      this.ResourceMappings = resourceMappings;
      this.Mounts = mounts;
      this.Networks = networks;
      this.NetworkAliases = networkAliases;
      this.OutputConsumer = outputConsumer;
      this.WaitStrategies = waitStrategies;
      this.ParameterModifiers = parameterModifiers;
      this.StartupCallback = startupCallback;
    }

    protected TestcontainersConfiguration(IDockerResourceConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    protected TestcontainersConfiguration(ITestcontainersConfiguration dockerResourceConfiguration)
      : this(dockerResourceConfiguration, new TestcontainersConfiguration())
    {
    }

    protected TestcontainersConfiguration(ITestcontainersConfiguration next, ITestcontainersConfiguration previous)
      : base(next, previous)
    {
      this.DockerRegistryAuthConfig = BuildConfiguration.Combine(next.DockerRegistryAuthConfig, previous.DockerRegistryAuthConfig);
      this.Image = BuildConfiguration.Combine(next.Image, previous.Image);
      this.ImagePullPolicy = BuildConfiguration.Combine(next.ImagePullPolicy, previous.ImagePullPolicy);
      this.Name = BuildConfiguration.Combine(next.Name, previous.Name);
      this.Hostname = BuildConfiguration.Combine(next.Hostname, previous.Hostname);
      this.MacAddress = BuildConfiguration.Combine(next.MacAddress, previous.MacAddress);
      this.WorkingDirectory = BuildConfiguration.Combine(next.WorkingDirectory, previous.WorkingDirectory);
      this.Entrypoint = BuildConfiguration.Combine(next.Entrypoint, previous.Entrypoint);
      this.Command = BuildConfiguration.Combine(next.Command, previous.Command);
      this.Environments = BuildConfiguration.Combine(next.Environments, previous.Environments);
      this.ExposedPorts = BuildConfiguration.Combine(next.ExposedPorts, previous.ExposedPorts);
      this.PortBindings = BuildConfiguration.Combine(next.PortBindings, previous.PortBindings);
      this.ResourceMappings = BuildConfiguration.Combine(next.ResourceMappings, previous.ResourceMappings);
      this.Mounts = BuildConfiguration.Combine(next.Mounts, previous.Mounts);
      this.Networks = BuildConfiguration.Combine(next.Networks, previous.Networks);
      this.NetworkAliases = BuildConfiguration.Combine(next.NetworkAliases, previous.NetworkAliases);
      this.OutputConsumer = BuildConfiguration.Combine(next.OutputConsumer, previous.OutputConsumer);
      this.WaitStrategies = BuildConfiguration.Combine(next.WaitStrategies, previous.WaitStrategies);
      this.ParameterModifiers = BuildConfiguration.Combine(next.ParameterModifiers, previous.ParameterModifiers);
      this.StartupCallback = BuildConfiguration.Combine(next.StartupCallback, previous.StartupCallback);
      this.AutoRemove = (next.AutoRemove.HasValue && next.AutoRemove.Value) || (previous.AutoRemove.HasValue && previous.AutoRemove.Value);
      this.Privileged = (next.Privileged.HasValue && next.Privileged.Value) || (previous.Privileged.HasValue && previous.Privileged.Value);
    }

    /// <inheritdoc />
    public bool? AutoRemove { get; }

    /// <inheritdoc />
    public bool? Privileged { get; }

    /// <inheritdoc />
    public IDockerRegistryAuthenticationConfiguration DockerRegistryAuthConfig { get; }

    /// <inheritdoc />
    public IDockerImage Image { get; }

    /// <inheritdoc />
    public Func<ImagesListResponse, bool> ImagePullPolicy { get; }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public string Hostname { get; }

    /// <inheritdoc />
    public string MacAddress { get; }

    /// <inheritdoc />
    public string WorkingDirectory { get; }

    /// <inheritdoc />
    public IEnumerable<string> Entrypoint { get; }

    /// <inheritdoc />
    public IEnumerable<string> Command { get; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, string> Environments { get; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, string> ExposedPorts { get; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, string> PortBindings { get; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, IResourceMapping> ResourceMappings { get; }

    /// <inheritdoc />
    public IEnumerable<IMount> Mounts { get; }

    /// <inheritdoc />
    public IEnumerable<IDockerNetwork> Networks { get; }

    /// <inheritdoc />
    public IEnumerable<string> NetworkAliases { get; }

    /// <inheritdoc />
    public IOutputConsumer OutputConsumer { get; }

    /// <inheritdoc />
    public IEnumerable<IWaitUntil> WaitStrategies { get; }

    /// <inheritdoc />
    public IReadOnlyList<Action<CreateContainerParameters>> ParameterModifiers { get; }

    /// <inheritdoc />
    public Func<ITestcontainersContainer, CancellationToken, Task> StartupCallback { get; }
  }
}
