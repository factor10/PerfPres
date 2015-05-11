﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JimmyPresentation
{
    public class TestClass
    {
        public decimal A;
        public decimal B;
        public decimal C;
        public decimal D;
        public decimal E;
        public decimal F;
        public decimal G;
        public decimal H;
    }

    [Serializable]
    public struct TestStruct
    {
        public decimal A;
        public decimal B;
        public decimal C;
        public decimal D;
        public decimal E;
        public decimal F;
        public decimal G;
        public decimal H;
    }

    public static class Hej
    {
        public static TestClass[] PlayClass()
        {
            var array = new TestClass[1000000];
            for (var i = 0; i < array.Length; i++)
                array[i] = new TestClass {H = i+100};
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].G = array[i + 1].H;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].F = array[i + 1].G;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].E = array[i + 1].F;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].D = array[i + 1].E;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].C = array[i + 1].D;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].B = array[i + 1].C;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].A = array[i + 1].B;
            return array;
        }

        public static TestStruct[] PlayStruct()
        {
            var array = new TestStruct[1000000];
            for (var i = 0; i < array.Length; i++)
                array[i].H = i+100;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].G = array[i + 1].H;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].F = array[i + 1].G;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].E = array[i + 1].F;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].D = array[i + 1].E;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].C = array[i + 1].D;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].B = array[i + 1].C;
            for (var i = array.Length - 2; i >= 0; i--)
                array[i].A = array[i + 1].B;
            return array;
        }

        public static void SaveTestStructArrayListToStream(List<TestStruct[]> list, BinaryWriter bw)
        {
            byte[] buffer = null;
            foreach( var x in list)
            {
                bw.Write(x.Length);
                var size = x.CopyToByteArray(ref buffer);
                bw.Write(buffer, 0, size);
            }
            bw.Write(0);
        }

        public static void LoadTestStructArrayListFromStream(List<TestStruct[]> list, BinaryReader br)
        {
            int length;
            while((length = br.ReadInt32())!=0)
            {
                var x = new TestStruct[length];
                var size = length*Marshal.SizeOf(typeof (TestStruct));
                x.CopyFromByteArray(br.ReadBytes(size));
                list.Add(x);
            }
        }

    }

}