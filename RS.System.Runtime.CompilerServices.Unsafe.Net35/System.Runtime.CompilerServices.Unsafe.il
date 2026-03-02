// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// Metadata version: v2.0.50727
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
  .ver 2:0:0:0
}

.assembly RS.System.Runtime.CompilerServices.Unsafe
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 )
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                   63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 05 31 2E 30 2E 30 2E 30 00 )
  .custom instance void [mscorlib]System.Reflection.AssemblyInformationalVersionAttribute::.ctor(string) = ( 01 00 05 31 2E 30 2E 30 2E 30 00 )
  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 29 52 53 2E 53 79 73 74 65 6D 2E   // ..)RS.System.
                                                                                              52 75 6E 74 69 6D 65 2E 43 6F 6D 70 69 6C 65 72   // Runtime.Compiler
                                                                                              53 65 72 76 69 63 65 73 2E 55 6E 73 61 66 65 00   // Services.Unsafe.
                                                                                              00 )
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 42 53 79 73 74 65 6D 2E 52 75 6E 74 69 6D   // ..BSystem.Runtim
                                                                                                    65 2E 43 6F 6D 70 69 6C 65 72 53 65 72 76 69 63   // e.CompilerServic
                                                                                                    65 73 2E 55 6E 73 61 66 65 20 70 6F 6C 79 66 69   // es.Unsafe polyfi
                                                                                                    6C 6C 20 66 6F 72 20 2E 4E 45 54 20 33 2E 35 00 ) // ll for .NET 3.5.
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 0F 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ..Copyright ..
                                                                                                  32 30 32 34 00 )                            // 2024.
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 0C 52 53 2E 50 6F 6C 79 66 69 6C 6C 73 00 00 ) // ...RS.Polyfills..
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 0C 52 53 2E 50 6F 6C 79 66 69 6C 6C 73 00 00 ) // ...RS.Polyfills..
  .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 00 00 00 )
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module System.Runtime.CompilerServices.Unsafe.dll
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003
.corflags 0x00000001

.namespace System.Runtime.CompilerServices
{
  .class public abstract auto ansi sealed beforefieldinit Unsafe
         extends [mscorlib]System.Object
  {
    .method public hidebysig static !!T Read<T>(void* source) cil managed
    {
          .maxstack 1
          ldarg.0
          ldobj !!T
          ret
    }

    .method public hidebysig static !!T ReadUnaligned<T>(void* source) cil managed
    {
          .maxstack 1
          ldarg.0
          unaligned. 0x1
          ldobj !!T
          ret
    }

    .method public hidebysig static !!T ReadUnaligned<T>(uint8& source) cil managed
    {
          .maxstack 1
          ldarg.0
          unaligned. 0x1
          ldobj !!T
          ret
    }



    .method public hidebysig static void Write<T>(void* destination, !!T 'value') cil managed
    {
          .maxstack 2
          ldarg.0
          ldarg.1
          stobj !!T
          ret
    }

    .method public hidebysig static void WriteUnaligned<T>(void* destination, !!T 'value') cil managed
    {
          .maxstack 2
          ldarg.0
          ldarg.1
          unaligned. 0x01
          stobj !!T
          ret
    }

    .method public hidebysig static void WriteUnaligned<T>(uint8& destination, !!T 'value') cil managed
    {
          .maxstack 2
          ldarg.0
          ldarg.1
          unaligned. 0x01
          stobj !!T
          ret
    }



    .method public hidebysig static void Copy<T>(void* destination, !!T& source) cil managed
    {
          .maxstack 2
          ldarg.0
          ldarg.1
          ldobj !!T
          stobj !!T
          ret
    }

    .method public hidebysig static void Copy<T>(!!T& destination, void* source) cil managed
    {
          .maxstack 2
          ldarg.0
          ldarg.1
          ldobj !!T
          stobj !!T
          ret
    }

    .method public hidebysig static void* AsPointer<T>(!!T& 'value') cil managed
    {
          .maxstack 1
          ldarg.0
          conv.u
          ret
    }

    .method public hidebysig static void SkipInit<T>([out] !!T& 'value') cil managed
    {
          .maxstack 0
          ret
    }

    .method public hidebysig static int32 SizeOf<T>() cil managed
    {
          .maxstack 1
          sizeof !!T
          ret
    }

    .method public hidebysig static void CopyBlock(void* destination, void* source, uint32 byteCount) cil managed
    {
          .maxstack 3
          ldarg.0
          ldarg.1
          ldarg.2
          cpblk
          ret
    }

    .method public hidebysig static void CopyBlock(uint8& destination, uint8& source, uint32 byteCount) cil managed
    {
          .maxstack 3
          ldarg.0
          ldarg.1
          ldarg.2
          cpblk
          ret
    }

    .method public hidebysig static void CopyBlockUnaligned(void* destination, void* source, uint32 byteCount) cil managed
    {
          .maxstack 3
          ldarg.0
          ldarg.1
          ldarg.2
          unaligned. 0x1
          cpblk
          ret
    }

    .method public hidebysig static void CopyBlockUnaligned(uint8& destination, uint8& source, uint32 byteCount) cil managed
    {
          .maxstack 3
          ldarg.0
          ldarg.1
          ldarg.2
          unaligned. 0x1
          cpblk
          ret
    }

    .method public hidebysig static void InitBlock(void* startAddress, uint8 'value', uint32 byteCount) cil managed
    {
          .maxstack 3
          ldarg.0
          ldarg.1
          ldarg.2
          initblk
          ret
    }

    .method public hidebysig static void InitBlock(uint8& startAddress, uint8 'value', uint32 byteCount) cil managed
    {
          .maxstack 3
          ldarg.0
          ldarg.1
          ldarg.2
          initblk
          ret
    }

    .method public hidebysig static void InitBlockUnaligned(void* startAddress, uint8 'value', uint32 byteCount) cil managed
    {
          .maxstack 3
          ldarg.0
          ldarg.1
          ldarg.2
          unaligned. 0x1
          initblk
          ret
    }

    .method public hidebysig static void InitBlockUnaligned(uint8& startAddress, uint8 'value', uint32 byteCount) cil managed
    {
          .maxstack 3
          ldarg.0
          ldarg.1
          ldarg.2
          unaligned. 0x1
          initblk
          ret
    }

    .method public hidebysig static !!T As<class T>(object o) cil managed
    {
          .maxstack 1
          ldarg.0
          ret
    }

    .method public hidebysig static void* AsRef<T>(void* source) cil managed
    {
          .maxstack 1
          ldarg.0
          ret
    }

    .method public hidebysig static void* AsRef<T>(!!T& source) cil managed
    {
          .maxstack 1
          ldarg.0
          conv.u
          ret
    }

    .method public hidebysig static void* As<TFrom, TTo>(!!TFrom& source) cil managed
    {
          .maxstack 1
          ldarg.0
          conv.u
          ret
    }

    .method public hidebysig static void* Unbox<T>(object 'box') cil managed
    {
          .maxstack 1
          ldarg.0
          unbox !!T
          ret
    }

    .method public hidebysig static void* Add<T>(!!T& source, int32 elementOffset) cil managed
    {
          .maxstack 3
          ldarg.0
          conv.u
          ldarg.1
          sizeof !!T
          conv.i
          mul
          add
          conv.u
          ret
    }

    .method public hidebysig static void* Add<T>(void* source, int32 elementOffset) cil managed
    {
          .maxstack 3
          ldarg.0
          ldarg.1
          sizeof !!T
          conv.i
          mul
          add
          ret
    }

  .method public hidebysig static void* Add<T>(void* source, native int elementOffset) cil managed
    {
          .maxstack 3
          ldarg.0
          ldarg.1
          sizeof !!T
          mul
          add
          ret
    }



    .method public hidebysig static void* Add<T>(!!T& source, native int elementOffset) cil managed
    {
          .maxstack 3
          ldarg.0
          conv.u
          ldarg.1
          sizeof !!T
          mul
          add
          conv.u
          ret
    }

    .method public hidebysig static void* AddByteOffset<T>(!!T& source, native int byteOffset) cil managed
    {
          .maxstack 2
          ldarg.0
          conv.u
          ldarg.1
          add
          conv.u
          ret
    }

    .method public hidebysig static void* Subtract<T>(!!T& source, int32 elementOffset) cil managed
    {
          .maxstack 3
          ldarg.0
          conv.u
          ldarg.1
          sizeof !!T
          conv.i
          mul
          sub
          conv.u
          ret
    }

    .method public hidebysig static void* Subtract<T>(void* source, int32 elementOffset) cil managed
    {
          .maxstack 3
          ldarg.0
          ldarg.1
          sizeof !!T
          conv.i
          mul
          sub
          ret
    }

  .method public hidebysig static void* Subtract<T>(void* source, native int elementOffset) cil managed
    {
          .maxstack 3
          ldarg.0
          ldarg.1
          sizeof !!T
          mul
          sub
          ret
    }



    .method public hidebysig static void* Subtract<T>(!!T& source, native int elementOffset) cil managed
    {
          .maxstack 3
          ldarg.0
          conv.u
          ldarg.1
          sizeof !!T
          mul
          sub
          conv.u
          ret
    }

    .method public hidebysig static void* SubtractByteOffset<T>(!!T& source, native int byteOffset) cil managed
    {
          .maxstack 2
          ldarg.0
          conv.u
          ldarg.1
          sub
          conv.u
          ret
    }

    .method public hidebysig static native int ByteOffset<T>(!!T& origin, !!T& target) cil managed
    {
          .maxstack 2
          ldarg.1
          conv.u
          ldarg.0
          conv.u
          sub
          ret
    }

    .method public hidebysig static bool AreSame<T>(!!T& left, !!T& right) cil managed
    {
          .maxstack 2
          ldarg.0
          ldarg.1
          ceq
          ret
    }

    .method public hidebysig static bool IsNullRef<T>(!!T& source) cil managed
    {
          .maxstack 1
          ldarg.0
          ldc.i4.0
          ceq
          ret
    }

    .method public hidebysig static void* NullRef<T>() cil managed
    {
          .maxstack 1
          ldc.i4.0
          conv.u
          ret
    }
  }
}
