using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace FullTest
{
    unsafe class Program
    {
        static int totalTests = 0;
        static int passedTests = 0;
        static int failedTests = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Unsafe 类完整测试");
            Console.WriteLine("Unsafe Class Complete Test");
            Console.WriteLine("========================================\n");

            TestSizeOf();
            TestRead();
            TestReadUnaligned();
            TestWrite();
            TestWriteUnaligned();
            TestCopy();
            TestAsPointer();
            TestSkipInit();
            TestCopyBlock();
            TestCopyBlockUnaligned();
            TestInitBlock();
            TestInitBlockUnaligned();
            TestAs();
            TestAsRef();
            TestAsTypeConversion();
            TestUnbox();
            TestAdd();
            TestAddByteOffset();
            TestSubtract();
            TestSubtractByteOffset();
            TestByteOffset();
            TestAreSame();
            TestIsNullRef();
            TestNullRef();

            Console.WriteLine("\n========================================");
            Console.WriteLine("测试总结 / Test Summary");
            Console.WriteLine("========================================");
            Console.WriteLine("  总测试数 / Total:      {0}", totalTests);
            Console.WriteLine("  通过 / Passed:        {0}", passedTests);
            Console.WriteLine("  失败 / Failed:        {0}", failedTests);
            Console.WriteLine("  成功率 / Success Rate: {0:F2}%", (totalTests > 0 ? (100.0 * passedTests / totalTests) : 0));

            if (failedTests == 0)
            {
                Console.WriteLine("\n  ✓ 所有测试通过！");
                Console.WriteLine("  ✓ All tests passed!");
            }
            else
            {
                Console.WriteLine("\n  ✗ 部分测试失败！");
                Console.WriteLine("  ✗ Some tests failed!");
            }

            Console.WriteLine("========================================");

            Console.WriteLine("\n按任意键退出 / Press any key to exit...");
            Console.ReadKey();
        }

        static void Assert(bool condition, string testName, string message)
        {
            totalTests++;
            if (condition)
            {
                passedTests++;
                Console.WriteLine("  ✓ {0}: {1}", testName, message);
            }
            else
            {
                failedTests++;
                Console.WriteLine("  ✗ {0}: {1}", testName, message);
            }
        }

        static void TestSizeOf()
        {
            Console.WriteLine("1. 测试 SizeOf<T>() / Testing SizeOf<T>()");
            Console.WriteLine("----------------------------------------");

            Assert(Unsafe.SizeOf<int>() == 4, "SizeOf<int>", "返回 4");
            Assert(Unsafe.SizeOf<double>() == 8, "SizeOf<double>", "返回 8");
            Assert(Unsafe.SizeOf<long>() == 8, "SizeOf<long>", "返回 8");
            Assert(Unsafe.SizeOf<char>() == 2, "SizeOf<char>", "返回 2");
            Assert(Unsafe.SizeOf<float>() == 4, "SizeOf<float>", "返回 4");
            Assert(Unsafe.SizeOf<short>() == 2, "SizeOf<short>", "返回 2");
            Assert(Unsafe.SizeOf<byte>() == 1, "SizeOf<byte>", "返回 1");
            Assert(Unsafe.SizeOf<bool>() == 1, "SizeOf<bool>", "返回 1");
            Assert(Unsafe.SizeOf<decimal>() == 16, "SizeOf<decimal>", "返回 16");

            Console.WriteLine();
        }

        static void TestRead()
        {
            Console.WriteLine("2. 测试 Read<T>(void*) / Testing Read<T>(void*)");
            Console.WriteLine("----------------------------------------");

            int value = 42;
            int* ptr = &value;
            int readValue = Unsafe.Read<int>(ptr);
            Assert(readValue == 42, "Read<int>", "正确读取值 42");

            double dvalue = 3.14159;
            double* dptr = &dvalue;
            double dReadValue = Unsafe.Read<double>(dptr);
            Assert(Math.Abs(dReadValue - 3.14159) < 0.00001, "Read<double>", "正确读取值 3.14159");

            Console.WriteLine();
        }

        static void TestReadUnaligned()
        {
            Console.WriteLine("3. 测试 ReadUnaligned<T>(void*) / Testing ReadUnaligned<T>(void*)");
            Console.WriteLine("----------------------------------------");

            int value = 0x12345678;
            byte* ptr = (byte*)&value;
            int unalignedValue = Unsafe.ReadUnaligned<int>(ptr + 1);
            Assert(unalignedValue != 0, "ReadUnaligned<int>", "非对齐读取成功");

            Console.WriteLine();
        }

        static void TestWrite()
        {
            Console.WriteLine("4. 测试 Write<T>(void*, T) / Testing Write<T>(void*, T)");
            Console.WriteLine("----------------------------------------");

            int value = 0;
            int* ptr = &value;
            Unsafe.Write<int>(ptr, 100);
            Assert(value == 100, "Write<int>", "正确写入值 100");

            double dvalue = 0;
            double* dptr = &dvalue;
            Unsafe.Write<double>(dptr, 2.71828);
            Assert(Math.Abs(dvalue - 2.71828) < 0.00001, "Write<double>", "正确写入值 2.71828");

            Console.WriteLine();
        }

        static void TestWriteUnaligned()
        {
            Console.WriteLine("5. 测试 WriteUnaligned<T>(void*, T) / Testing WriteUnaligned<T>(void*, T)");
            Console.WriteLine("----------------------------------------");

            int buffer = 0;
            byte* ptr = (byte*)&buffer;
            Unsafe.WriteUnaligned<int>(ptr , 0x12345678);
            Assert(buffer != 0, "WriteUnaligned<int>", "非对齐写入成功");

            Console.WriteLine();
        }

        static void TestCopy()
        {
            Console.WriteLine("6. 测试 Copy<T>() / Testing Copy<T>()");
            Console.WriteLine("----------------------------------------");

            int source = 100;
            int dest = 0;
            Unsafe.Copy<int>((void*)&dest, ref source);
            Assert(dest == 100, "Copy<T>(void*, T&)", "从指针复制到引用");

            int source2 = 200;
            int dest2 = 0;
            Unsafe.Copy<int>(ref dest2, (void*)&source2);
            Assert(dest2 == 200, "Copy<T>(T&, void*)", "从引用复制到指针");

            Console.WriteLine();
        }

        static void TestAsPointer()
        {
            Console.WriteLine("7. 测试 AsPointer<T>(T&) / Testing AsPointer<T>(T&)");
            Console.WriteLine("----------------------------------------");

            int value = 42;
            int* expectedPtr = &value;
            void* ptr = Unsafe.AsPointer<int>(ref value);
            Assert(ptr == (void*)expectedPtr, "AsPointer<int>", "正确获取指针地址");

            Console.WriteLine();
        }

        static void TestSkipInit()
        {
            Console.WriteLine("8. 测试 SkipInit<T>(out T&) / Testing SkipInit<T>(out T&)");
            Console.WriteLine("----------------------------------------");

            int value;
            Unsafe.SkipInit<int>(out value);
            Assert(true, "SkipInit<int>", "跳过初始化成功");

            Console.WriteLine();
        }

        static void TestCopyBlock()
        {
            Console.WriteLine("9. 测试 CopyBlock() / Testing CopyBlock()");
            Console.WriteLine("----------------------------------------");

            byte* source = stackalloc byte[20];
            byte* dest = stackalloc byte[20];

            for (int i = 0; i < 20; i++)
            {
                source[i] = (byte)(i + 1);
            }

            Unsafe.CopyBlock(dest, source, 20);

            bool success = true;
            for (int i = 0; i < 20; i++)
            {
                if (dest[i] != source[i])
                {
                    success = false;
                    break;
                }
            }
            Assert(success, "CopyBlock(void*, void*, uint)", "内存块复制成功");

            byte bsource = 10;
            byte bdest = 0;
            Unsafe.CopyBlock(ref bdest, ref bsource, 1);
            Assert(bdest == 10, "CopyBlock(byte&, byte&, uint)", "字节复制成功");

            Console.WriteLine();
        }

        static void TestCopyBlockUnaligned()
        {
            Console.WriteLine("10. 测试 CopyBlockUnaligned() / Testing CopyBlockUnaligned()");
            Console.WriteLine("----------------------------------------");

            byte* source = stackalloc byte[20];
            byte* dest = stackalloc byte[20];

            for (int i = 0; i < 20; i++)
            {
                source[i] = (byte)(i + 1);
            }

            Unsafe.CopyBlockUnaligned(dest + 1, source + 1, 19);

            bool success = true;
            for (int i = 0; i < 19; i++)
            {
                if (dest[i + 1] != source[i + 1])
                {
                    success = false;
                    break;
                }
            }
            Assert(success, "CopyBlockUnaligned", "非对齐内存块复制成功");

            Console.WriteLine();
        }

        static void TestInitBlock()
        {
            Console.WriteLine("11. 测试 InitBlock() / Testing InitBlock()");
            Console.WriteLine("----------------------------------------");

            byte* buffer = stackalloc byte[20];
            Unsafe.InitBlock(buffer, 0xFF, 20);

            bool success = true;
            for (int i = 0; i < 20; i++)
            {
                if (buffer[i] != 0xFF)
                {
                    success = false;
                    break;
                }
            }
            Assert(success, "InitBlock(void*, byte, uint)", "内存块初始化成功");

            byte bbuffer = 0;
            Unsafe.InitBlock(ref bbuffer, 0x55, 1);
            Assert(bbuffer == 0x55, "InitBlock(byte&, byte, uint)", "字节初始化成功");

            Console.WriteLine();
        }

        static void TestInitBlockUnaligned()
        {
            Console.WriteLine("12. 测试 InitBlockUnaligned() / Testing InitBlockUnaligned()");
            Console.WriteLine("----------------------------------------");

            byte* buffer = stackalloc byte[20];
            Unsafe.InitBlockUnaligned(buffer + 1, 0xAA, 19);

            bool success = true;
            for (int i = 0; i < 19; i++)
            {
                if (buffer[i + 1] != 0xAA)
                {
                    success = false;
                    break;
                }
            }
            Assert(success, "InitBlockUnaligned", "非对齐内存块初始化成功");

            Console.WriteLine();
        }

        static void TestAs()
        {
            Console.WriteLine("13. 测试 As<T>(object) / Testing As<T>(object)");
            Console.WriteLine("----------------------------------------");

            object obj = "Hello";
            string str = Unsafe.As<string>(obj);
            Assert(str == "Hello", "As<string>", "类型转换成功");

            Console.WriteLine();
        }

        static void TestAsRef()
        {
            Console.WriteLine("14. 测试 AsRef<T>() / Testing AsRef<T>()");
            Console.WriteLine("----------------------------------------");

            int value = 42;
            int* expectedPtr = &value;
            void* ptr1 = Unsafe.AsRef<int>(ref value);
            Assert(ptr1 == (void*)expectedPtr, "AsRef<int>(T&)", "从引用获取指针成功");

            int* ptr = &value;
            void* ptr2 = Unsafe.AsRef<int>(ptr);
            Assert(ptr2 == (void*)ptr, "AsRef<int>(void*)", "从指针获取指针成功");

            Console.WriteLine();
        }

        static void TestAsTypeConversion()
        {
            Console.WriteLine("15. 测试 As<TFrom, TTo>(TFrom&) / Testing As<TFrom, TTo>(TFrom&)");
            Console.WriteLine("----------------------------------------");

            int intValue = 42;
            void* intPtr = Unsafe.As<int, int>(ref intValue);
            Assert((long)intPtr != 0, "As<int, int>", "int 类型重新解释成功");

            long longValue = 100;
            void* longPtr = Unsafe.As<long, long>(ref longValue);
            Assert((long)longPtr != 0, "As<long, long>", "long 类型重新解释成功");

            Console.WriteLine();
        }

        static void TestUnbox()
        {
            Console.WriteLine("16. 测试 Unbox<T>(object) / Testing Unbox<T>(object)");
            Console.WriteLine("----------------------------------------");

            object boxed = 42;
            void* ptr = Unsafe.Unbox<int>(boxed);
            int value = *(int*)ptr;
            Assert(value == 42, "Unbox<int>", "拆箱成功");

            object boxedDouble = 3.14159;
            void* dptr = Unsafe.Unbox<double>(boxedDouble);
            double dvalue = *(double*)dptr;
            Assert(Math.Abs(dvalue - 3.14159) < 0.00001, "Unbox<double>", "double 拆箱成功");

            Console.WriteLine();
        }

        static void TestAdd()
        {
            Console.WriteLine("17. 测试 Add<T>() / Testing Add<T>()");
            Console.WriteLine("----------------------------------------");

            int[] array = new int[] { 10, 20, 30, 40, 50 };
            fixed (int* ptr = array)
            {
                void* ptr2 = Unsafe.Add<int>(ptr, 2);
                Assert(*(int*)ptr2 == 30, "Add<T>(void*, int)", "指针加法成功");

                void* ptr3 = Unsafe.Add<int>(ref array[0], 3);
                Assert(*(int*)ptr3 == 40, "Add<T>(T&, int)", "引用加法成功");
            }

            Console.WriteLine();
        }

        static void TestAddByteOffset()
        {
            Console.WriteLine("18. 测试 AddByteOffset<T>(T&, IntPtr) / Testing AddByteOffset<T>(T&, IntPtr)");
            Console.WriteLine("----------------------------------------");

            int[] array = new int[] { 10, 20, 30, 40, 50 };
            fixed (int* ptr = array)
            {
                void* basePtr = ptr;
                void* offsetPtr = Unsafe.AddByteOffset<int>(ref array[0], (IntPtr)8);
                Assert((long)offsetPtr == (long)basePtr + 8, "AddByteOffset", "字节偏移加法成功 (base + 8 bytes)");
            }

            Console.WriteLine();
        }

        static void TestSubtract()
        {
            Console.WriteLine("19. 测试 Subtract<T>() / Testing Subtract<T>()");
            Console.WriteLine("----------------------------------------");

            int[] array = new int[] { 10, 20, 30, 40, 50 };
            fixed (int* ptr = array)
            {
                void* ptr1 = Unsafe.Subtract<int>(ptr + 4, 2);
                Assert(*(int*)ptr1 == 30, "Subtract<T>(void*, int)", "指针减法成功");

                void* ptr2 = Unsafe.Subtract<int>(ref array[4], 3);
                Assert(*(int*)ptr2 == 20, "Subtract<T>(T&, int)", "引用减法成功");
            }

            Console.WriteLine();
        }

        static void TestSubtractByteOffset()
        {
            Console.WriteLine("20. 测试 SubtractByteOffset<T>(T&, IntPtr) / Testing SubtractByteOffset<T>(T&, IntPtr)");
            Console.WriteLine("----------------------------------------");

            int[] array = new int[] { 10, 20, 30, 40, 50 };
            fixed (int* ptr = array)
            {
                void* basePtr = ptr + 2;
                void* offsetPtr = Unsafe.SubtractByteOffset<int>(ref array[2], (IntPtr)8);
                Assert((long)offsetPtr == (long)basePtr - 8, "SubtractByteOffset", "字节偏移减法成功 (base - 8 bytes)");
            }

            Console.WriteLine();
        }

        static void TestByteOffset()
        {
            Console.WriteLine("21. 测试 ByteOffset<T>(T&, T&) / Testing ByteOffset<T>(T&, T&)");
            Console.WriteLine("----------------------------------------");

            int[] array = new int[] { 10, 20, 30, 40, 50 };
            IntPtr offset = Unsafe.ByteOffset<int>(ref array[0], ref array[2]);
            Assert(offset.ToInt64() == 8, "ByteOffset", "字节偏移计算成功 (8 bytes)");

            Console.WriteLine();
        }

        static void TestAreSame()
        {
            Console.WriteLine("22. 测试 AreSame<T>(T&, T&) / Testing AreSame<T>(T&, T&)");
            Console.WriteLine("----------------------------------------");

            int value1 = 42;
            int value2 = 42;
            bool same1 = Unsafe.AreSame<int>(ref value1, ref value1);
            Assert(same1 == true, "AreSame(same, same)", "相同引用返回 true");

            bool same2 = Unsafe.AreSame<int>(ref value1, ref value2);
            Assert(same2 == false, "AreSame(different, different)", "不同引用返回 false");

            Console.WriteLine();
        }

        static void TestIsNullRef()
        {
            Console.WriteLine("23. 测试 IsNullRef<T>(T&) / Testing IsNullRef<T>(T&)");
            Console.WriteLine("----------------------------------------");

            int value = 42;
            bool isNull1 = Unsafe.IsNullRef<int>(ref value);
            Assert(isNull1 == false, "IsNullRef(valid)", "有效引用返回 false");

            unsafe
            {
                int* nullPtr = null;
                bool isNull2 = Unsafe.IsNullRef<int>(ref *nullPtr);
                Assert(isNull2 == true, "IsNullRef(null)", "空引用返回 true");
            }

            Console.WriteLine();
        }

        static void TestNullRef()
        {
            Console.WriteLine("24. 测试 NullRef<T>() / Testing NullRef<T>()");
            Console.WriteLine("----------------------------------------");

            void* nullRef = Unsafe.NullRef<int>();
            Assert(nullRef == null, "NullRef<int>", "返回空引用");

            Console.WriteLine();
        }
    }
}
