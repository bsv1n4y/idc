using System;
namespace Utils
{
	public class ARR
	{
		public static double Compute(int year, double[] incomeAfterdt, double originalInvestment, double scrapValue,double workingCapital)
		{
			double averageIncome;
			double totalIncome = 0;
			for(int i=0; i<incomeAfterdt.Length; i++)
			{
				totalIncome += incomeAfterdt[i];
			}
			averageIncome = totalIncome / year;
			double averageInvestment = ((originalInvestment - scrapValue) / 2 ) + workingCapital + scrapValue;
			double result = averageIncome / averageInvestment * 100;
			result = Math.Round(result, 2);
			return result;
		}

		public static double Compute(int year, double[] incomeBeforedt, float taxRate, int life, double originalInvestment, double scrapValue, double workingCapital)
		{
			double[] incomeAfterdepn = new double[year];
			double[] incomeAftertax = new double[year];
			double tax;
			double depreciation = Utils.Depreciation(originalInvestment, scrapValue, life);
			for(int i=0; i<year; i++)
			{
				incomeAfterdepn[i] = incomeBeforedt[i] - depreciation;
				tax = incomeAfterdepn[i] * taxRate / 100;
				incomeAftertax[i] = incomeAfterdepn[i] - tax;
			}
			double result = Compute(year, incomeAftertax, originalInvestment, scrapValue, workingCapital);
			return result;
		}

			
		public static double Compute(int year, double[] incomeBeforetaxAfterdepn, int life, double originalInvestment, double scrapValue, double workingCapital)
		{
			double depreciation = Utils.Depreciation(originalInvestment, scrapValue, life);
			double[] incomeAfterdepn = new double[year];
			for(int i=0; i<year; i++)
			{
				incomeAfterdepn[i] = incomeBeforetaxAfterdepn[i] - depreciation;
			}
			double result = Compute(year, incomeAfterdepn, originalInvestment, scrapValue, workingCapital);
			return result;
		}
	}
}

	



