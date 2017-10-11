﻿using System;

public class ProbStrategy : Strategy
{
    private Random rand;
    private int prevHandValue = 0;
    private int currentHandValue = 0;
    private int[][] history =
    {
        new int [] {1, 1, 1, },
        new int [] {1, 1, 1, },
        new int [] {1, 1, 1, },
    };
	public ProbStrategy(int seed)
	{
        rand = new Random(seed);
	}
    public Hand nextHand()
    {
        int bet = rand.Next(getSum(currentHandValue));
        int handvalue = 0;
        if (bet < history[currentHandValue][0])
        {
            handvalue = 0;
        }
        else if(bet < history[currentHandValue][0] + history[currentHandValue][1])
        {
            handvalue = 1;
        }
        else
        {
            handvalue = 2;
        }
        prevHandValue = currentHandValue;
        currentHandValue = handvalue;
        return Hand.getHand(handvalue);
    }
    private int getSum(int hv)
    {
        int sum = 0;
        for(int i=0; i<3; i++)
        {
            sum += history[hv][i];
        }
        return sum;
    }
    public void study(Boolean win)
    {
        if (win)
        {
            history[prevHandValue][currentHandValue]++;
        }
        else
        {
            history[prevHandValue][(currentHandValue + 1) % 3]++;
            history[prevHandValue][(currentHandValue + 2) % 3]++;
        }
    }
}
