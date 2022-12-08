namespace DotNet.Testcontainers.Builders
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;
  using Docker.DotNet.Models;
  using DotNet.Testcontainers.Configurations;
  using DotNet.Testcontainers.Containers;
  using DotNet.Testcontainers.Images;
  using DotNet.Testcontainers.Networks;
  using DotNet.Testcontainers.Volumes;
  using JetBrains.Annotations;

  /// <summary>
  /// This class represents the fluent Testcontainers builder. Each change creates a new instance of <see cref="ContainerBuilder{TBuilderEntity,TContainerEntity,TConfigurationEntity}" />.
  /// With this behaviour we can reuse previous configured configurations and create similar Testcontainers with only little effort.
  /// </summary>
  /// <example>
  /// <code>
  ///   var builder = new TestcontainersBuilder&lt;TestcontainersContainer&gt;()
  ///     .WithName(&quot;nginx&quot;)
  ///     .WithImage(&quot;nginx&quot;)
  ///     .WithEntrypoint(&quot;...&quot;)
  ///     .WithCommand(&quot;...&quot;);
  ///   <br />
  ///   var http = builder
  ///     .WithPortBinding(80, 08)
  ///     .Build();
  ///   <br />
  ///   var https = builder
  ///     .WithPortBinding(443, 443)
  ///     .Build();
  /// </code>
  /// </example>
  /// <typeparam name="TBuilderEntity">The builder entity.</typeparam>
  /// <typeparam name="TContainerEntity">The container entity.</typeparam>
  /// <typeparam name="TConfigurationEntity">The configuration entity.</typeparam>
  [PublicAPI]
  public abstract class ContainerBuilder<TBuilderEntity, TContainerEntity, TConfigurationEntity> : AbstractBuilder<TBuilderEntity, TContainerEntity, TConfigurationEntity>, ITestcontainersBuilder<TBuilderEntity, TContainerEntity>
    where TContainerEntity : ITestcontainersContainer
    where TConfigurationEntity : IContainerConfiguration
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContainerBuilder{TBuilderEntity,TContainerEntity,TConfigurationEntity}" /> class.
    /// </summary>
    /// <param name="dockerResourceConfiguration">The Docker resource configuration.</param>
    protected ContainerBuilder(TConfigurationEntity dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity ConfigureContainer(Action<TContainerEntity> moduleConfiguration)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithImage(string image)
    {
      return this.WithImage(new DockerImage(image));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithImage(IDockerImage image)
    {
      return this.Clone(new ContainerConfiguration(image: image));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithImagePullPolicy(Func<ImagesListResponse, bool> imagePullPolicy)
    {
      return this.Clone(new ContainerConfiguration(imagePullPolicy: imagePullPolicy));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithName(string name)
    {
      return this.Clone(new ContainerConfiguration(name: name));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithHostname(string hostname)
    {
      return this.Clone(new ContainerConfiguration(hostname: hostname));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithMacAddress(string macAddress)
    {
      return this.Clone(new ContainerConfiguration(macAddress: macAddress));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithWorkingDirectory(string workingDirectory)
    {
      return this.Clone(new ContainerConfiguration(workingDirectory: workingDirectory));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithEntrypoint(params string[] entrypoint)
    {
      return this.Clone(new ContainerConfiguration(entrypoint: entrypoint));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithCommand(params string[] command)
    {
      return this.Clone(new ContainerConfiguration(command: command));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithEnvironment(string name, string value)
    {
      var environments = new Dictionary<string, string> { { name, value } };
      return this.WithEnvironment(environments);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithEnvironment(IReadOnlyDictionary<string, string> environments)
    {
      return this.Clone(new ContainerConfiguration(environments: environments));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithExposedPort(int port)
    {
      return this.WithExposedPort(port.ToString(CultureInfo.InvariantCulture));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithExposedPort(string port)
    {
      var exposedPorts = new Dictionary<string, string> { { port, port } };
      return this.Clone(new ContainerConfiguration(exposedPorts: exposedPorts));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithPortBinding(int port, bool assignRandomHostPort = false)
    {
      return this.WithPortBinding(port.ToString(CultureInfo.InvariantCulture), assignRandomHostPort);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithPortBinding(int hostPort, int containerPort)
    {
      return this.WithPortBinding(hostPort.ToString(CultureInfo.InvariantCulture), containerPort.ToString(CultureInfo.InvariantCulture));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithPortBinding(string port, bool assignRandomHostPort = false)
    {
      var hostPort = assignRandomHostPort ? "0" : port;
      return this.WithPortBinding(hostPort, port);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithPortBinding(string hostPort, string containerPort)
    {
      // TODO: How to append `.WithExposedPort(containerPort)`?
      var portBindings = new Dictionary<string, string> { { containerPort, hostPort } };
      return this.Clone(new ContainerConfiguration(portBindings: portBindings));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithResourceMapping(string source, string destination)
    {
      return this.WithResourceMapping(new FileResourceMapping(source, destination));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithResourceMapping(byte[] resourceContent, string destination)
    {
      return this.WithResourceMapping(new BinaryResourceMapping(resourceContent, destination));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithResourceMapping(IResourceMapping resourceMapping)
    {
      var resourceMappings = new Dictionary<string, IResourceMapping> { { resourceMapping.Target, resourceMapping } };
      return this.Clone(new ContainerConfiguration(resourceMappings: resourceMappings));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithMount(string source, string destination)
    {
      return this.WithBindMount(source, destination);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithMount(string source, string destination, AccessMode accessMode)
    {
      return this.WithBindMount(source, destination, accessMode);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithMount(IMount mount)
    {
      var mounts = new[] { mount };
      return this.Clone(new ContainerConfiguration(mounts: mounts));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithBindMount(string source, string destination)
    {
      return this.WithBindMount(source, destination, AccessMode.ReadWrite);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithBindMount(string source, string destination, AccessMode accessMode)
    {
      return this.WithMount(new BindMount(source, destination, accessMode));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithVolumeMount(string source, string destination)
    {
      return this.WithVolumeMount(source, destination, AccessMode.ReadWrite);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithVolumeMount(string source, string destination, AccessMode accessMode)
    {
      return this.WithVolumeMount(new DockerVolume(source), destination, accessMode);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithVolumeMount(IDockerVolume source, string destination)
    {
      return this.WithVolumeMount(source, destination, AccessMode.ReadWrite);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithVolumeMount(IDockerVolume source, string destination, AccessMode accessMode)
    {
      return this.WithMount(new VolumeMount(source, destination, accessMode));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithTmpfsMount(string destination)
    {
      return this.WithTmpfsMount(destination, AccessMode.ReadWrite);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithTmpfsMount(string destination, AccessMode accessMode)
    {
      return this.WithMount(new TmpfsMount(destination, accessMode));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithNetwork(string id, string name)
    {
      return this.WithNetwork(new DockerNetwork(id, name));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithNetwork(IDockerNetwork dockerNetwork)
    {
      var networks = new[] { dockerNetwork };
      return this.Clone(new ContainerConfiguration(networks: networks));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithNetworkAliases(params string[] networkAliases)
    {
      return this.WithNetworkAliases(networkAliases.AsEnumerable());
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithNetworkAliases(IEnumerable<string> networkAliases)
    {
      return this.Clone(new ContainerConfiguration(networkAliases: networkAliases));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithAutoRemove(bool autoRemove)
    {
      return this.Clone(new ContainerConfiguration(autoRemove: autoRemove));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithPrivileged(bool privileged)
    {
      return this.Clone(new ContainerConfiguration(privileged: privileged));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithRegistryAuthentication(string registryEndpoint, string username, string password)
    {
      return this.Clone(new ContainerConfiguration(dockerRegistryAuthenticationConfiguration: new DockerRegistryAuthenticationConfiguration(registryEndpoint, username, password)));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithOutputConsumer(IOutputConsumer outputConsumer)
    {
      return this.Clone(new ContainerConfiguration(outputConsumer: outputConsumer));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithWaitStrategy(IWaitForContainerOS waitStrategy)
    {
      return this.Clone(new ContainerConfiguration(waitStrategies: waitStrategy.Build()));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithCreateContainerParametersModifier(Action<CreateContainerParameters> parameterModifier)
    {
      var parameterModifiers = new[] { parameterModifier };
      return this.Clone(new ContainerConfiguration(parameterModifiers: parameterModifiers));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithStartupCallback(Func<IRunningDockerContainer, CancellationToken, Task> startupCallback)
    {
      return this.Clone(new ContainerConfiguration(startupCallback: startupCallback));
    }

    /// <summary>
    /// Clones the Docker resource builder configuration.
    /// </summary>
    /// <param name="resourceConfiguration">The Docker resource configuration.</param>
    /// <returns>A configured instance of <typeparamref name="TBuilderEntity" />.</returns>
    protected abstract TBuilderEntity Clone(IContainerConfiguration resourceConfiguration);
  }
}
