System.Runtime.CompilerServices.Unsafe Polyfill for .NET Framework 4.0
========

[![Nuget](https://img.shields.io/nuget/dt/RS.System.Runtime.CompilerServices.Unsafe)](https://www.nuget.org/packages/RS.System.Runtime.CompilerServices.Unsafe)
[![Azure DevOps builds (main)](https://img.shields.io/azure-devops/build/NightOwl888/RS.Polyfills/4/main)](https://dev.azure.com/NightOwl888/RS.Polyfills/_build?definitionId=4&_a=summary)
[![GitHub](https://img.shields.io/github/license/NightOwl888/RS.Polyfills)](https://github.com/NightOwl888/RS.Polyfills/blob/main/LICENSE)
[![GitHub Sponsors](https://img.shields.io/badge/-Sponsor-fafbfc?logo=GitHub%20Sponsors)](https://github.com/sponsors/NightOwl888)

提供 System.Runtime.CompilerServices.Unsafe 类，该类提供了用于操作指针的泛型低级功能。

常用类型：
- System.Runtime.CompilerServices.Unsafe

------------

此包为 .NET Framework 4.0 添加了对 System.Runtime.CompilerServices.Unsafe 的支持。

这是使用 .NET Core 6.0.28 中的 System.Runtime.CompilerServices.Unsafe 源代码编译的。所有测试均已通过。

这并非 System.Runtime.CompilerServices.Unsafe 6.0.0 的升级版本，仅仅是为 `net40` 目标添加对 System.Runtime.CompilerServices.Unsafe 6.0.0 中所有现有 API 的支持。建议在较新版本的 .NET 上使用 System.Runtime.CompilerServices.Unsafe 的正式版本。

## 与 net40 以上目标上的 System.Runtime.CompilerServices.Unsafe 的互操作

由于 `net40` 运行时已经多年未获支持，您很可能在较新的运行时上使用此库。但您可能与目标为 System.Runtime.CompilerServices.Unsafe 的其他组件进行互操作，这默认情况下会导致类型冲突。

在这种情况下，建议从编译中移除 System.Runtime.CompilerServices.Unsafe，并在其位置添加 RS.System.Runtime.CompilerServices.Unsafe。将以下内容添加到您的 `.csproj` 或 `.vbproj` 文件中。此示例用于 `net452`。

```xml
  <ItemGroup Condition=" '$(TargetFramework)' == 'net452' ">
    <!-- ExcludeAssets=compile 从引用中移除依赖项。
         ExcludeAssets=runtime 从构建输出中移除依赖项。 -->
    <PackageReference Include="System.Runtime.CompilerServices.Unsafe"
                      Version="6.0.0"
                      ExcludeAssets="compile;runtime" />
    <PackageReference Include="RS.System.Runtime.CompilerServices.Unsafe"
                      Version="4.0.0" />
  </ItemGroup>
  </ItemGroup>
```

> **注意：** 此方法仅支持 SDK 风格的项目。

对于具有 `net40` 目标的传递依赖项（即未被直接引用的依赖项），请考虑[强制使用特定的目标框架](https://duanenewman.net/blog/post/forcing-a-specific-target-platform-with-packagereference/)。

## 致谢

如果您发现此库有用，请在 [GitHub](https://github.com/NightOwl888/RS.Polyfills) 上为我们点个星，并考虑赞助我们，以便我们能继续为您带来这样的优秀免费工具。这真的会有很大的帮助！

[![GitHub Sponsors](https://img.shields.io/badge/-Sponsor-fafbfc?logo=GitHub%20Sponsors)](https://github.com/sponsors/NightOwl888)
