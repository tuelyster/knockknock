﻿using knockknock.readify.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KnockKnockService
{
    public class KnockKnock : IRedPill
    {
        
        Guid IRedPill.WhatIsYourToken()
        {
            // Return dummy token for now
            return new Guid("00000000-0000-0000-0000-000000000000");

        }

        public long FibonacciNumber(long n)
        {
            // Start with 0 and then add 1 for the first iteration
            long fibo = 0;
            long previousFibo = 1;
            for (int i = 0; i < n; i++)
            {
                long tempFibo = fibo + previousFibo;
                previousFibo = fibo;
                fibo = tempFibo;
            }
            return fibo;
        }

        public knockknock.readify.net.TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            // All sides must have a valid length
            if (a <= 0 || b <= 0 || c <= 0) return TriangleType.Error;

            // Find simple way to compare all sides with each other and count the number of matches. There are clever ways to do this generic but for three numbers we go quick and use simple 'if'
            int hits = 0;
            if (a == b) hits++;
            if (a == c) hits++;
            if (b == c) hits++;
            switch (hits)
            {
                case 0:
                    return TriangleType.Scalene;
                case 1: 
                    return TriangleType.Isosceles;
                case 3:
                    return TriangleType.Equilateral;
                default:
                    return TriangleType.Error; // Not possible but always good to have the error case covered if someone changes the function in the future.
            }
        }

        public string ReverseWords(string s)
        {
            if (String.IsNullOrEmpty(s))
                return "";

            return string.Join(" ", s.Split(' ').Select(x => new String(x.Reverse().ToArray())).ToArray());
        }
    }
}