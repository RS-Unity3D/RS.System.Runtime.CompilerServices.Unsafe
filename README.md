# RS.System.Runtime.CompilerServices.Unsafe for .NET 2.0
System.Runtime.CompilerServices.Unsafe Polyfill for .NET Framework 2.0/ .NET Framework 3.5/ .NET Framework 4.0
## Overview / 概述

This is a .NET 2.0/.NET3.5/.NET4.0 compatible implementation of `System.Runtime.CompilerServices.Unsafe` class using IL (Intermediate Language). It provides generic, low-level functionality for manipulating pointers and memory.

这是使用 IL（中间语言）实现的 `System.Runtime.CompilerServices.Unsafe` 类的 .NET 2.0 兼容实现。它提供了用于操作指针和内存的通用低级功能。
提供 System.Runtime.CompilerServices.Unsafe 类，该类提供了用于操作指针的泛型低级功能,所有测试均已通过。

常用类型：
- System.Runtime.CompilerServices.Unsafe
## 与 net40 以上目标上的 System.Runtime.CompilerServices.Unsafe 的互操作

由于 `net20/net35/net40` 运行时已经多年未获支持，您很可能在较新的运行时上使用此库。但您可能与目标为 System.Runtime.CompilerServices.Unsafe 的其他组件进行互操作，这默认情况下会导致类型冲突。
在这种情况下，建议从编译中移除 System.Runtime.CompilerServices.Unsafe，并在其位置添加 RS.System.Runtime.CompilerServices.Unsafe.dll对于的.net版本。
## Features / 特性

- **.NET 2.0/.NET 3.5/.NET 4.0 compatible** / 兼容 .NET 2.0/ .NET 3.5 /.NET 4.0
- **IL-based implementation** / 基于 IL 的实现
- **Pointer manipulation** / 指针操作
- **Memory operations** / 内存操作
- **Type casting** / 类型转换
- **Same API as .NET 4.0+** / 与 .NET 4.0+ 相同的 API

## Implementation Details / 实现细节

### Why IL? / 为什么使用 IL？

1. **Generic method support** / 泛型方法支持
   - IL supports generic methods with pointers / IL 支持带指针的泛型方法
   - C# doesn't allow pointer generics in .NET 2.0 / C# 在 .NET 2.0 中不允许指针泛型

2. **Direct IL instructions** / 直接 IL 指令
   - Uses `cpblk` and `initblk` for block operations / 使用 `cpblk` 和 `initblk` 进行块操作
   - More efficient than C# loops / 比 C# 循环更高效

3. **Aggressive inlining** / 激进内联
   - All methods marked with `aggressiveinlining` / 所有方法标记为 `aggressiveinlining`
   - Zero runtime overhead / 零运行时开销

## Supported Methods / 支持的方法

### Read Operations / 读取操作

| Method | Description |
|---------|-------------|
| `Read<T>(void* source)` | Read value from pointer / 从指针读取值 |
| `ReadUnaligned<T>(void* source)` | Read value without alignment assumption / 在不假定对齐的情况下读取值 |

### Write Operations / 写入操作

| Method | Description |
|---------|-------------|
| `Write<T>(void* destination, T value)` | Write value to pointer / 将值写入指针 |
| `WriteUnaligned<T>(void* destination, T value)` | Write value without alignment assumption / 在不假定对齐的情况下写入值 |

### Copy Operations / 复制操作

| Method | Description |
|---------|-------------|
| `Copy<T>(void* destination, ref T source)` | Copy value to pointer / 将值复制到指针 |
| `Copy<T>(ref T destination, void* source)` | Copy value from pointer / 从指针复制值 |

### Pointer Operations / 指针操作

| Method | Description |
|---------|-------------|
| `AsPointer<T>(ref T value)` | Get pointer to reference / 获取指向引用的指针 |
| `AsRef<T>(void* source)` | Get reference from pointer / 从指针获取引用 |
| `AsRef<T>(ref T source)` | Get reference from reference / 从引用获取引用 |
| `As<TFrom, TTo>(ref TFrom source)` | Reinterpret reference as different type / 将引用重新解释为不同类型 |
| `As<T>(object o)` | Reinterpret object as different type / 将对象重新解释为不同类型 |
| `Unbox<T>(object box)` | Get reference to boxed value / 获取对装箱值的引用 |

### Arithmetic Operations / 算术操作

| Method | Description |
|---------|-------------|
| `Add<T>(ref T source, int elementOffset)` | Add element offset to reference / 将元素偏移量添加到引用 |
| `Add<T>(T* source, int elementOffset)` | Add element offset to pointer / 将元素偏移量添加到指针 |
| `Add<T>(ref T source, IntPtr elementOffset)` | Add element offset using IntPtr / 使用 IntPtr 添加元素偏移量 |
| `AddByteOffset<T>(ref T source, IntPtr byteOffset)` | Add byte offset to reference / 将字节偏移量添加到引用 |
| `Subtract<T>(ref T source, int elementOffset)` | Subtract element offset from reference / 从引用减去元素偏移量 |
| `Subtract<T>(T* source, int elementOffset)` | Subtract element offset from pointer / 从指针减去元素偏移量 |
| `Subtract<T>(ref T source, IntPtr elementOffset)` | Subtract element offset using IntPtr / 使用 IntPtr 减去元素偏移量 |
| `SubtractByteOffset<T>(ref T source, IntPtr byteOffset)` | Subtract byte offset from reference / 从引用减去字节偏移量 |

### Offset Operations / 偏移操作

| Method | Description |
|---------|-------------|
| `ByteOffset<T>(ref T origin, ref T target)` | Calculate byte offset between references / 计算引用之间的字节偏移量 |
| `AreSame<T>(ref T left, ref T right)` | Check if references point to same location / 检查引用是否指向相同位置 |

### Size Operations / 大小操作

| Method | Description |
|---------|-------------|
| `SizeOf<T>()` | Get size of type / 获取类型大小 |

### Initialization Operations / 初始化操作

| Method | Description |
|---------|-------------|
| `SkipInit<T>(out T value)` | Skip definite assignment / 跳过明确赋值 |

### Block Operations / 块操作

| Method | Description |
|---------|-------------|
| `CopyBlock(void* destination, void* source, uint byteCount)` | Copy bytes using cpblk / 使用 cpblk 复制字节 |
| `CopyBlock(ref byte destination, ref byte source, uint byteCount)` | Copy bytes using cpblk / 使用 cpblk 复制字节 |
| `CopyBlockUnaligned(void* destination, void* source, uint byteCount)` | Copy bytes unaligned / 不对齐复制字节 |
| `CopyBlockUnaligned(ref byte destination, ref byte source, uint byteCount)` | Copy bytes unaligned / 不对齐复制字节 |
| `InitBlock(void* startAddress, byte value, uint byteCount)` | Initialize bytes using initblk / 使用 initblk 初始化字节 |
| `InitBlock(ref byte startAddress, byte value, uint byteCount)` | Initialize bytes using initblk / 使用 initblk 初始化字节 |
| `InitBlockUnaligned(void* startAddress, byte value, uint byteCount)` | Initialize bytes unaligned / 不对齐初始化字节 |
| `InitBlockUnaligned(ref byte startAddress, byte value, uint byteCount)` | Initialize bytes unaligned / 不对齐初始化字节 |

### Null Reference Operations / 空引用操作

| Method | Description |
|---------|-------------|
| `IsNullRef<T>(ref T source)` | Check if reference is null / 检查引用是否为空 |
| `NullRef<T>()` | Get null reference / 获取空引用 |

## Building / 构建

### Prerequisites / 前提条件

- .NET Framework 2.0(3.5) SDK/.NET Framework 4.0 SDK
- IL Assembler (ilasm.exe) - included with .NET Framework SDK
- MSBuild

### Using MSBuild / 使用 MSBuild

```bash
# Debug build / Debug 构建
msbuild RS.System.Runtime.CompilerServices.Unsafe.Net20.ilproj /p:Configuration=Debug
msbuild RS.System.Runtime.CompilerServices.Unsafe.Net35.ilproj /p:Configuration=Debug
msbuild RS.System.Runtime.CompilerServices.Unsafe.Net40.ilproj /p:Configuration=Debug
# Release build / Release 构建
msbuild RS.System.Runtime.CompilerServices.Unsafe.Net20.ilproj /p:Configuration=Release
msbuild RS.System.Runtime.CompilerServices.Unsafe.Net35.ilproj /p:Configuration=Release
msbuild RS.System.Runtime.CompilerServices.Unsafe.Net40.ilproj /p:Configuration=Release
```

### Using Visual Studio / 使用 Visual Studio

1. Open `RS.System.Runtime.CompilerServices.Unsafe.Net20.ilproj`/`RS.System.Runtime.CompilerServices.Unsafe.Net35.ilproj`/`RS.System.Runtime.CompilerServices.Unsafe.Net40.ilproj` in Visual Studio
2. Select "Release" configuration
3. Click "Build" > "Build Solution"

### Manual IL Assembly / 手动 IL 汇编

```bash
# Debug build / Debug 构建
ilasm.exe /QUIET /DLL /DEBUG /OUTPUT=bin\Debug\RS.System.Runtime.CompilerServices.Unsafe.dll System.Runtime.CompilerServices.Unsafe.il

# Release build / Release 构建
ilasm.exe /QUIET /DLL /OUTPUT=bin\Release\RS.System.Runtime.CompilerServices.Unsafe.dll System.Runtime.CompilerServices.Unsafe.il
```

## Usage Examples / 使用示例

### Basic Pointer Operations / 基础指针操作

```csharp
using System.Runtime.CompilerServices;

unsafe
{
    int value = 42;
    int* ptr = &value;

    // Read value / 读取值
    int readValue = Unsafe.Read<int>(ptr);

    // Write value / 写入值
    Unsafe.Write<int>(ptr, 100);
}
```

### Type Reinterpretation / 类型重新解释

```csharp
unsafe
{
    double d = 3.14;
    long l = Unsafe.As<double, long>(ref d);
    Console.WriteLine($"Long representation: {l}");
}
```

### Memory Block Operations / 内存块操作

```csharp
unsafe
{
    byte[] source = new byte[100];
    byte[] destination = new byte[100];

    fixed (byte* srcPtr = source)
    fixed (byte* destPtr = destination)
    {
        // Copy block using cpblk / 使用 cpblk 复制块
        Unsafe.CopyBlock(destPtr, srcPtr, (uint)source.Length);

        // Initialize block using initblk / 使用 initblk 初始化块
        Unsafe.InitBlock(destPtr, 0xFF, (uint)destination.Length);
    }
}
```

### Pointer Arithmetic / 指针算术

```csharp
unsafe
{
    int[] array = new int[10];
    fixed (int* ptr = array)
    {
        // Add element offset / 添加元素偏移量
        ref int element = ref Unsafe.Add<int>(ref array[0], 5);
        element = 42;

        // Calculate byte offset / 计算字节偏移量
        IntPtr offset = Unsafe.ByteOffset<int>(ref array[0], ref element);
        Console.WriteLine($"Byte offset: {offset}");
    }
}
```

## Output / 输出

After building, the following files are generated:

构建后，将生成以下文件：

```
bin\Debug\
  RS.System.Runtime.CompilerServices.Unsafe.dll
  RS.System.Runtime.CompilerServices.Unsafe.pdb

bin\Release\
  RS.System.Runtime.CompilerServices.Unsafe.dll
```

## Using in Your Project / 在项目中使用

### Reference the Assembly / 引用程序集

#### In .csproj / 在 .csproj 文件中

```xml
<Reference Include="RS.System.Runtime.CompilerServices.Unsafe">
  <HintPath>path\to\bin\Debug\RS.System.Runtime.CompilerServices.Unsafe.dll</HintPath>
</Reference>
```

#### In Visual Studio / 在 Visual Studio 中

1. Right-click "References" in your project
2. Select "Add Reference..."
3. Browse to `RS.System.Runtime.CompilerServices.Unsafe.dll`
4. Add the reference

### Import Namespace / 导入命名空间

```csharp
using System.Runtime.CompilerServices;
```

### Enable Unsafe Code / 启用不安全代码

Your project must allow unsafe code:

```xml
<PropertyGroup>
  <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
</PropertyGroup>
```

## Requirements / 要求

- .NET Framework 2.0 SDK
- IL Assembler (ilasm.exe)
- MSBuild 4.0 or higher
- C# compiler with unsafe code support

## Compatibility / 兼容性

| .NET Version | Status |
|--------------|--------|
| .NET Framework 2.0 | ✅ Compatible |
| .NET Framework 3.5 | ✅ Compatible |
| .NET Framework 4.0+ | ✅ Compatible |

## Differences from C# Implementation / 与 C# 实现的区别

### Advantages of IL Implementation / IL 实现的优势

1. **True generic methods** / 真正的泛型方法
   - Supports `T*` as parameter type / 支持 `T*` 作为参数类型
   - C# doesn't allow this in .NET 2.0 / C# 在 .NET 2.0 中不允许这样做

2. **Direct IL instructions** / 直接 IL 指令
   - Uses `cpblk` and `initblk` / 使用 `cpblk` 和 `initblk`
   - More efficient than C# loops / 比 C# 循环更高效

3. **Aggressive inlining** / 激进内联
   - Zero overhead method calls / 零开销方法调用
   - Better performance / 更好的性能

## Limitations / 限制

1. **Unsafe code required** / 需要不安全代码
   - All methods must be called from unsafe contexts / 所有方法必须在 unsafe 上下文中调用

2. **IL knowledge needed for modifications** / 修改需要 IL 知识
   - Understanding IL is helpful for understanding the code / 理解 IL 有助于理解代码

## Troubleshooting / 故障排除

### "ilasm.exe not found" / 找不到 ilasm.exe

Ensure .NET Framework SDK is installed and the path is correct.

确保安装了 .NET Framework SDK 并且路径正确。

```xml
<PropertyGroup>
  <IlasmPath>C:\Windows\Microsoft.NET\Framework\v2.0.50727\ilasm.exe</IlasmPath>
</PropertyGroup>
```

### Build fails with IL errors / IL 构建错误

Check that:
- IL syntax is correct / IL 语法正确
- Generic parameters are properly defined / 泛型参数正确定义
- External assembly references are correct / 外部程序集引用正确

## License / 许可证

MIT License

## Notes / 说明

This implementation uses IL to provide the same API surface as `System.Runtime.CompilerServices.Unsafe` in .NET 4.0+. The IL code is optimized and uses native IL instructions for maximum performance.

此实现使用 IL 提供与 .NET 4.0+ 中 `System.Runtime.CompilerServices.Unsafe` 相同的 API 表面。IL 代码经过优化，使用原生 IL 指令以获得最大性能。

## Related Projects / 相关项目

- [RS.Memory.Unsafe](../RS.System.Runtime.CompilerServices.Unsafe/) - .NET 2.0+ csharp code implementation
- [RS.PowerThreadPool](../PowerThreadPool/) - Thread pool library using this implementation
