using System;
namespace Utils
{
	public class Utils
	{
		public static double Depreciation(double originalInvestment, double scrapValue, int life)
		{
			double depreciation = (originalInvestment - scrapValue) / life;
			return depreciation;
		}
		public static double Totaler(double[] cashFlows)
		{
			double total = 0;
			for(int i=0; i<cashFlows.Length; i++)
			{
				total += cashFlows[i];
			}
			return total;
		}

	}
}
