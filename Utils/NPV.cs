using System;
namespace Utils;

public class NPV
{
	public static double[] NetCashFlow(float discountRate, double[] cashFlows)
	{
		discountRate = discountRate / 100;
		double discountFactor = 1;
		double[] netCashflow = new double[cashFlows.Length];
		for(int i=0; i<cashFlows.Length; i++)
		{
			discountFactor *= 1 / (1+discountRate);
			discountFactor = Math.Round(discountFactor, 3);
			netCashflow[i] = Math.Round((cashFlows[i] * discountFactor), 0);
		}
		return netCashflow;
	}
	public static double Compute(double originalInvestment, float discountRate, double[] cashFlows)
	{
		double[] netCashflows = NetCashFlow(discountRate, cashFlows);
		double result = Utils.Totaler(netCashflows) - originalInvestment;
		return result;
	}
}

			
