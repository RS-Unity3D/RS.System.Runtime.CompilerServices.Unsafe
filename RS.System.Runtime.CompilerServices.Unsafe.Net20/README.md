# Unsafe .NET 2.0 实现 / Unsafe .NET 2.0 Implementation

## 概述 / Overview

本项目为 .NET Framework 2.0 提供了 `System.Runtime.CompilerServices.Unsafe` 类的完整实现，包含 34 个静态方法，支持高性能的内存操作和指针运算。

This project provides a complete implementation of the `System.Runtime.CompilerServices.Unsafe` class for .NET Framework 2.0, including 34 static methods supporting high-performance memory operations and pointer arithmetic.

## 特性 / Features

- ✅ 完全兼容 .NET Framework 2.0
- ✅ 支持所有核心 Unsafe 方法
- ✅ 无反射包装，直接使用
- ✅ 高性能 IL 实现
- ✅ 支持 ref 和 void* 参数

## 编译和安装 / Build and Install

### 使用构建脚本 / Using Build Script

项目提供了构建脚本 `build.bat`，可以快速编译 Debug 和 Release 版本：

The project provides a build script `build.bat` for quick compilation of Debug and Release versions:

```bash
cd RS.System.Runtime.CompilerServices.Unsafe.Net20

# 编译所有版本 / Build all versions (default)
build.bat

# 仅编译 Debug 版本 / Build Debug version only
build.bat debug

# 仅编译 Release 版本 / Build Release version only
build.bat release

# 清理编译文件 / Clean compiled files
build.bat clean
```

### 手动编译 IL 程序集 / Manual IL Assembly Compilation

```bash
cd RS.System.Runtime.CompilerServices.Unsafe.Net20

# Debug 版本 / Debug version
C:\Windows\Microsoft.NET\Framework\v2.0.50727\ilasm.exe /dll /debug /out:RS.System.Runtime.CompilerServices.Unsafe.dll System.Runtime.CompilerServices.Unsafe.il

# Release 版本 / Release version
C:\Windows\Microsoft.NET\Framework\v2.0.50727\ilasm.exe /dll /out:RS.System.Runtime.CompilerServices.Unsafe.dll System.Runtime.CompilerServices.Unsafe.il
```

### 在项目中使用 / Use in Your Project

将编译好的 `RS.System.Runtime.CompilerServices.Unsafe.dll` 复制到您的项目目录，然后在项目中引用：

Copy the compiled `RS.System.Runtime.CompilerServices.Unsafe.dll` to your project directory and reference it:

```bash
csc.exe /reference:RS.System.Runtime.CompilerServices.Unsafe.dll YourProgram.cs
```

## API 文档 / API Documentation

### 类型大小 / Type Size

```csharp
int size = Unsafe.SizeOf<int>();  // 返回类型大小 / Returns type size
```

### 内存读写 / Memory Read/Write

```csharp
unsafe
{
    int value = 42;
    int* ptr = &value;

    // 读取内存 / Read memory
    int readValue = Unsafe.Read<int>(ptr);

    // 写入内存 / Write memory
    Unsafe.Write<int>(ptr, 100);

    // 非对齐读取 / Unaligned read
    int unaligned = Unsafe.ReadUnaligned<int>((byte*)ptr + 1);

    // 非对齐写入 / Unaligned write
    Unsafe.WriteUnaligned<int>((byte*)ptr + 1, 200);
}
```

### 内存块操作 / Memory Block Operations

```csharp
unsafe
{
    byte* source = stackalloc byte[100];
    byte* dest = stackalloc byte[100];

    // 复制内存块 / Copy memory block
    Unsafe.CopyBlock(dest, source, 100);

    // 初始化内存块 / Initialize memory block
    Unsafe.InitBlock(dest, 0xFF, 100);

    // 非对齐操作 / Unaligned operations
    Unsafe.CopyBlockUnaligned(dest, source, 100);
    Unsafe.InitBlockUnaligned(dest, 0xFF, 100);
}
```

### 指针运算 / Pointer Arithmetic

```csharp
unsafe
{
    int[] array = new int[] { 10, 20, 30, 40, 50 };
    fixed (int* ptr = array)
    {
        // 按元素偏移 / Offset by elements
        void* ptr2 = Unsafe.Add<int>(ptr, 2);           // ptr + 2 * sizeof(int)
        void* ptr1 = Unsafe.Subtract<int>(ptr + 3, 2);  // ptr + 3 - 2 * sizeof(int)

        // 按字节偏移 / Offset by bytes
        int first = array[0];
        void* ptrByte = Unsafe.AddByteOffset<int>(ref first, (IntPtr)8);

        // 字节偏移计算 / Calculate byte offset
        int offset = Unsafe.ByteOffset<int>(ref array[0], ref array[2]);
    }
}
```

### 类型转换 / Type Conversion

```csharp
unsafe
{
    // 获取指针 / Get pointer
    int value = 42;
    void* ptr = Unsafe.AsRef<int>(ref value);
    void* ptrFromPtr = Unsafe.AsRef<int>((int*)&value);

    // 类型转换 / Type cast
    int intValue = 0x12345678;
    void* intPtr = Unsafe.As<int, void>(ref intValue);

    // 拆箱 / Unbox
    object boxed = 42;
    void* unboxed = Unsafe.Unbox<int>(boxed);
}
```

### 引用比较 / Reference Comparison

```csharp
int[] array = new int[] { 10, 20, 30 };

// 检查是否为同一个引用 / Check if same reference
bool same = Unsafe.AreSame<int>(ref array[0], ref array[0]);

// 检查是否为空引用 / Check if null reference
bool isNull = Unsafe.IsNullRef<int>(ref *(int*)0);

// 获取空引用 / Get null reference
void* nullRef = Unsafe.NullRef<int>();
```

## 完整 API 列表 / Complete API List

| 方法 / Method | 描述 / Description |
|-------------|-------------------|
| `SizeOf<T>()` | 获取类型大小 / Get type size |
| `Read<T>(void*)` | 从指针读取值 / Read value from pointer |
| `ReadUnaligned<T>(void*)` | 非对齐读取 / Unaligned read |
| `Write<T>(void*, T)` | 写入值到指针 / Write value to pointer |
| `WriteUnaligned<T>(void*, T)` | 非对齐写入 / Unaligned write |
| `Copy<T>(void*, T&)` | 复制值 / Copy value |
| `Copy<T>(T&, void*)` | 复制值 / Copy value |
| `CopyBlock(void*, void*, uint)` | 复制内存块 / Copy memory block |
| `CopyBlock(byte&, byte&, uint)` | 复制内存块 / Copy memory block |
| `CopyBlockUnaligned(void*, void*, uint)` | 非对齐复制 / Unaligned copy |
| `CopyBlockUnaligned(byte&, byte&, uint)` | 非对齐复制 / Unaligned copy |
| `InitBlock(void*, byte, uint)` | 初始化内存块 / Initialize memory block |
| `InitBlock(byte&, byte, uint)` | 初始化内存块 / Initialize memory block |
| `InitBlockUnaligned(void*, byte, uint)` | 非对齐初始化 / Unaligned init |
| `InitBlockUnaligned(byte&, byte, uint)` | 非对齐初始化 / Unaligned init |
| `As<T>(object)` | 类型转换 / Type cast |
| `AsRef<T>(void*)` | 获取指针 / Get pointer |
| `AsRef<T>(T&)` | 获取指针 / Get pointer |
| `As<TFrom, TTo>(TFrom&)` | 类型转换 / Type cast |
| `Unbox<T>(object)` | 拆箱 / Unbox |
| `Add<T>(T&, int)` | 按元素偏移 / Offset by elements |
| `Add<T>(void*, int)` | 按元素偏移 / Offset by elements |
| `Add<T>(T&, IntPtr)` | 按元素偏移 / Offset by elements |
| `AddByteOffset<T>(T&, IntPtr)` | 按字节偏移 / Offset by bytes |
| `Subtract<T>(T&, int)` | 按元素偏移 / Offset by elements |
| `Subtract<T>(void*, int)` | 按元素偏移 / Offset by elements |
| `Subtract<T>(T&, IntPtr)` | 按元素偏移 / Offset by elements |
| `SubtractByteOffset<T>(T&, IntPtr)` | 按字节偏移 / Offset by bytes |
| `ByteOffset<T>(T&, T&)` | 计算字节偏移 / Calculate byte offset |
| `AreSame<T>(T&, T&)` | 检查是否相同 / Check if same |
| `IsNullRef<T>(T&)` | 检查是否为空 / Check if null |
| `NullRef<T>()` | 获取空引用 / Get null reference |
| `AsPointer<T>(T&)` | 获取指针 / Get pointer |
| `SkipInit<T>(T&)` | 跳过初始化 / Skip initialization |

## 示例程序 / Example Programs

### 测试程序 / Test Program

```bash
# 编译测试程序 / Compile test program
csc.exe /unsafe+ /reference:RS.System.Runtime.CompilerServices.Unsafe.dll /out:FullTest.exe FullTest.cs

# 运行测试 / Run tests
FullTest.exe
```

### 使用示例 / Usage Example

```bash
# 编译示例程序 / Compile example program
csc.exe /unsafe+ /reference:RS.System.Runtime.CompilerServices.Unsafe.dll /out:FullTest.exe FullTest.cs

# 运行示例 / Run examples
FullTest.exe
```

## 性能说明 / Performance Notes

- 所有方法都使用原生 IL 指令（sizeof, cpblk, initblk, ldobj, stobj）
- 无托管调用开销
- 适用于高性能场景（如游戏引擎、实时系统等）

All methods use native IL instructions (sizeof, cpblk, initblk, ldobj, stobj).
No managed call overhead.
Suitable for high-performance scenarios (game engines, real-time systems, etc.).

## 限制 / Limitations

- 需要 .NET Framework 2.0 或更高版本
- 需要启用 unsafe 代码编译选项
- 某些方法返回 void* 而不是 ref T（.NET 2.0 限制）

Requires .NET Framework 2.0 or higher.
Requires unsafe code compilation option.
Some methods return void* instead of ref T (.NET 2.0 limitation).

## 文件说明 / File Description

| 文件 / File | 描述 / Description |
|-----------|-------------------|
| `System.Runtime.CompilerServices.Unsafe.il` | Unsafe 类的 IL 源代码 / IL source code |
| `RS.System.Runtime.CompilerServices.Unsafe.dll` | 编译后的程序集 / Compiled assembly |
| `FullTest.cs` | 测试程序 / Test program |


## 许可证 / License

Apache-2.0 license 
