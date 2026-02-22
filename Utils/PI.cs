using System;
namespace Utils
{
	public class PI
	{
		public static double Compute(double[] cashFlows, float discountRate, double originalInvestment)
		{
			double npv = NPV.Compute(originalInvestment, discountRate, cashFlows);
			double result = Math.Round((npv / originalInvestment * 100), 2);
			return result;
		}
	}
}

