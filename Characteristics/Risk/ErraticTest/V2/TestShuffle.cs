namespace Characteristics.Risk.ErraticTest.V2;

using System;
using System.Collections.Generic;
using System.Linq;

public class ShuffleTest
{
    private const int MaxLong = 10;

    [Fact]
    public void TestShuffleTest()
    {
        TestShuffle(new int[] { 0 });
        TestShuffle(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
        TestShuffle(new int[] { 0, 1, 2, 3, 3, 3, 4, 5, 6, 7, 8, 8 });
    }

    private void TestShuffle(int[] values)
    {
        foreach (int value in values)
        {
            Assert.True(value < MaxLong);
        }

        List<int> list = values.ToList();
        int[] expectedItemTimes = ItemTimes(list);
        Shuffle(list);
        int[] resultItemTimes = ItemTimes(list);
        Assert.Equal(expectedItemTimes, resultItemTimes);
    }

    private int[] ItemTimes(List<int> list)
    {
        int[] itemTimes = new int[MaxLong];
        foreach (int value in list)
        {
            itemTimes[value]++;
        }

        return itemTimes;
    }

    private void Shuffle(List<int> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = rng.Next(n--);
            int temp = list[n];
            list[n] = list[k];
            list[k] = temp;
        }
    }
}