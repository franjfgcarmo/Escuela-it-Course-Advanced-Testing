namespace Characteristics.Risk.ErraticTest.V1;

using System;
using System.Collections.Generic;

public class ShuffleTest
{
    [Fact]
    public void TestShuffle()
    {
        List<int> outputList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        Shuffle(outputList);
        int samePositionCount = 0;
        for (int index = 0; index < outputList.Count; index++)
        {
            if (outputList[index] == index)
            {
                samePositionCount++;
            }
        }
        Console.WriteLine("samePositionCount: " + samePositionCount);
        double samePositionPercent = (double)samePositionCount / outputList.Count;
        Assert.True(0.1 > samePositionPercent);
    }

    private void Shuffle(List<int> list)
    {
        Random random = new Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n--);
            int temp = list[n];
            list[n] = list[k];
            list[k] = temp;
        }
    }
}