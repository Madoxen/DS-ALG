using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Algorithms.Lib.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

[TestClass]
public class SortingTests
{

    private static Random rand = new Random();

    private readonly int[] smallTestIntegerArray;
    private readonly int[] bigTestIntegerArray;


    private readonly TestElement[] smallTestObjectArray;
    private readonly TestElement[] bigTestObjectArray;


    public SortingTests()
    {
        //allocate memory
        smallTestIntegerArray = new int[1000];
        bigTestIntegerArray = new int[100000];
        smallTestObjectArray = new TestElement[1000];
        bigTestObjectArray = new TestElement[100000];

        //Generate data
        FillWithRandomIntegers(smallTestIntegerArray);
        FillWithRandomIntegers(bigTestIntegerArray);
        for (int i = 0; i < smallTestObjectArray.Length; i++)
        {
            TestElement e = new TestElement();
            e.a = rand.Next();
            e.b = rand.Next();
            smallTestObjectArray[i] = e;
        }
        for (int i = 0; i < bigTestObjectArray.Length; i++)
        {
            TestElement e = new TestElement();
            e.a = rand.Next();
            e.b = rand.Next();
            bigTestObjectArray[i] = e;
        }

    }

    [TestMethod]
    public void TestAllSorts()
    {
        List<ISort> sorts = new List<ISort>()
        {
            new MergeSort(),
            new ShellSort(),
            new HeapSort(),
            new QuickSort(),
            new BubbleSort(),
        };

        foreach (ISort s in sorts)
        {
            Debug.WriteLine("Testing: " + s.GetType().ToString());
            TestSort(s);
        }
    }


    [TestMethod]
    public void TestCountingSort()
    {
        CountingSort cs = new CountingSort();
        int[] a = new int[1000];
        int[] b = new int[100000];
        Array.Copy(smallTestIntegerArray, a, smallTestIntegerArray.Length);
        Array.Copy(bigTestIntegerArray, b, bigTestIntegerArray.Length);

        cs.Sort(a);
        Assert.IsTrue(CheckSort(a, (x, y) => x.CompareTo(y)));
        cs.Sort(b);
        Assert.IsTrue(CheckSort(b, (x, y) => x.CompareTo(y)));
    }

    public void TestSort(ISort sort)
    {
        int[] a = new int[1000];
        int[] b = new int[100000];
        TestElement[] c = new TestElement[1000];
        TestElement[] d = new TestElement[100000];

        Array.Copy(smallTestIntegerArray, a, smallTestIntegerArray.Length);
        Array.Copy(bigTestIntegerArray, b, bigTestIntegerArray.Length);
        Array.Copy(smallTestObjectArray, c, smallTestObjectArray.Length);
        Array.Copy(bigTestObjectArray, d, bigTestObjectArray.Length);

        sort.Sort<int>(a, (x, y) => x.CompareTo(y));
        Assert.IsTrue(CheckSort(a, (x, y) => x.CompareTo(y)));

        sort.Sort<int>(b, (x, y) => x.CompareTo(y));
        Assert.IsTrue(CheckSort(b, (x, y) => x.CompareTo(y)));

        int CompareTestElements(TestElement x, TestElement y)
        {
            if (x.a == y.a) return 0;
            if (x.a > y.a) return 1;
            if (x.a < y.a) return -1;

            return 0;
        }

        sort.Sort<TestElement>(c, (x, y) => CompareTestElements(x, y));
        Assert.IsTrue(CheckSort(c, (x, y) => CompareTestElements(x, y)));

        sort.Sort<TestElement>(d, (x, y) => CompareTestElements(x, y));
        Assert.IsTrue(CheckSort(d, (x, y) => CompareTestElements(x, y)));
    }




    private class TestElement
    {
        public int a;
        public int b;
    }

    private void FillWithRandomIntegers(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rand.Next();
        }
    }

    private bool CheckSort<T>(T[] arr, Func<T, T, int> comparison)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (comparison(arr[i], arr[i + 1]) > 0)
            {
                Debug.WriteLine(arr[i].ToString() + "|||" + arr[i + 1].ToString());
                return false;
            }

        }
        return true;
    }

}