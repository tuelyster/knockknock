using knockknock.readify.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Diagnostics;

namespace KnockKnockService
{
    public class KnockKnock : IRedPill
    {
        
        Guid IRedPill.WhatIsYourToken()
        {
            Trace.TraceInformation("WhatIsYourToken called");
            // Return dummy token for now
            return new Guid("00000000-0000-0000-0000-000000000000");

        }

        public long FibonacciNumber(long n)
        {
            Trace.TraceInformation("FibonacciNumber called with n = " + n);
            // Start with 0 and then add 1 for the first iteration
            if (Math.Abs(n) > 92)
                throw new ArgumentOutOfRangeException("Return value will not fit in Int64");
            long fibo = 0;
            long previousFibo = 1;
            for (int i = 0; i < Math.Abs(n); i++)
            {
                long tempFibo = fibo + previousFibo;
                previousFibo = fibo;
                fibo = tempFibo;
            }
            if (n < 0 && n % 2 == 0)
            {
                fibo = fibo * -1;
            }
            Trace.TraceInformation("FibonacciNumber answered: " + fibo);
            return fibo;
        }

        public knockknock.readify.net.TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            Trace.TraceInformation("WhatShapeIsThis: a=" + a + ", b=" + b + ", c=" + c);
            // All sides must have a valid length
            if (a <= 0 || b <= 0 || c <= 0) return TriangleType.Error;

            // Find simple way to compare all sides with each other and count the number of matches. There are clever ways to do this generic but for three numbers we go quick and use simple 'if'
            int hits = 0;
            if (a == b) hits++;
            if (a == c) hits++;
            if (b == c) hits++;
            Trace.TraceInformation("WhatShapeIsThis found #hits: " + hits.ToString());

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
            Trace.TraceInformation("ReverseWords called with s = " + s);
            if (String.IsNullOrEmpty(s))
                throw new ArgumentNullException();
            s = s.Trim();
            string output = string.Join(" ", s.Split(' ').Select(x => new String(x.Reverse().ToArray())).ToArray());
            Trace.TraceInformation("ReverseWords answers: '" + output + "'");
            return output;
        }
    }
}
