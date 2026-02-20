// See https://aka.ms/new-console-template for more information

using Utils;

class Program
{
	static void Main()
	{
		double[] income = {90000, 75000, 60000, 50000, 40000};
		double result = ARR.Compute(income, 5, 400000, 50000, 50000);
		Console.WriteLine(result);
	}
}
