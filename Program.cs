// See https://aka.ms/new-console-template for more information

using Utils;

class Program
{
	static void Main()
	{
		double[] cashFlows = {4000, 4000, 4000, 4000, 4000};
		double result = IRR.Compute(7, 8, cashFlows, 16000);
		Console.WriteLine(result);
	}
}
