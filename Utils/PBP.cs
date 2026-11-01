using System;
namespace Utils
{
    public class PBP
    {
        public static double Compute(double initialInvestment, double cashFlow) // This is for future gui implementation
        {
            return Math.Round((initialInvestment / cashFlow), 2);
        }
        public static double Compute(double initialInvestment, double[] cashFlows)
        {
            double cumulativeCashflow = 0;
            for (int i = 0; i < cashFlows.Length; i++)
            {
                cumulativeCashflow += cashFlows[i];
                if (cumulativeCashflow >= initialInvestment)
                {
                    double previousCumulative = cumulativeCashflow - cashFlows[i];
                    double unrecoveredAmount = initialInvestment - previousCumulative;
                    double fraction = unrecoveredAmount / cashFlows[i];
                    fraction = Math.Round(fraction, 2);
                    return i + fraction; // Coz array starts with 0, gotta add 1
                }
            }
            return -1;
        }
    }
}
