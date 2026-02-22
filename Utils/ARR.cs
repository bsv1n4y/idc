using System;
namespace Utils
{
	public class ARR
	{
		public static double Compute(double[] incomeAfterdt, double originalInvestment, double scrapValue,double workingCapital)
		{
			double averageIncome;
			double totalIncome = 0;
			for(int i=0; i<incomeAfterdt.Length; i++)
			{
				totalIncome += incomeAfterdt[i];
			}
			averageIncome = totalIncome / (incomeAfterdt.Length);
			double averageInvestment = ((originalInvestment - scrapValue) / 2 ) + workingCapital + scrapValue;
			double result = averageIncome / averageInvestment * 100;
			result = Math.Round(result, 2);
			return result;
		}

		public static double Compute(double[] incomeBeforedt, double taxRate, int life, double originalInvestment, double scrapValue, double workingCapital)
		{
			double[] incomeAfterdepn = new double[incomeBeforedt.Length];
			double[] incomeAftertax = new double[incomeBeforedt.Length];
			double tax;
			double depreciation = Utils.Depreciation(originalInvestment, scrapValue, life);
			for(int i=0; i<incomeBeforedt.Length; i++)
			{
				incomeAfterdepn[i] = incomeBeforedt[i] - depreciation;
				tax = incomeAfterdepn[i] * taxRate / 100;
				incomeAftertax[i] = incomeAfterdepn[i] - tax;
			}
			double result = Compute(incomeAftertax, originalInvestment, scrapValue, workingCapital);
			return result;
		}

			
		public static double Compute(double[] incomeBeforetaxAfterdepn, int life, double originalInvestment, double scrapValue, double workingCapital)
		{
			double depreciation = Utils.Depreciation(originalInvestment, scrapValue, life);
			double[] incomeAfterdepn = new double[incomeBeforetaxAfterdepn.Length];
			for(int i=0; i<incomeBeforetaxAfterdepn.Length; i++)
			{
				incomeAfterdepn[i] = incomeBeforetaxAfterdepn[i] - depreciation;
			}
			double result = Compute(incomeAfterdepn, originalInvestment, scrapValue, workingCapital);
			return result;
		}
	}
}

	



