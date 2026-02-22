using System;
namespace Utils
{
	public class IRR
	{
		public static double Compute(float lowTrialrate, float highTrialrate, double[] defaultIncome, double originalInvestment)
		{
			double[] lowTrialamount = NPV.NetCashFlow(lowTrialrate, defaultIncome);
			double[] highTrialamount = NPV.NetCashFlow(highTrialrate, defaultIncome);
			double totalLowtrial = Utils.Totaler(lowTrialamount);
			double totalHightrial = Utils.Totaler(highTrialamount);
			double result;
			result = lowTrialrate + ((totalLowtrial-originalInvestment)/(totalLowtrial-totalHightrial)) * (highTrialrate - lowTrialrate);
			result = Math.Round(result, 2);
			return result;
		}
	}
}
