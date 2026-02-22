// See https://aka.ms/new-console-template for more information

using Utils;

class Program
{
	static void Main()
	{
		double[] cashFlows = {240000, 160000, 80000, 40000, 40000};
		double II = 280000;
		double pbp = PBP.Compute(II, cashFlows);
		Console.WriteLine("PBP is "+ pbp);
		double npv = NPV.Compute(II, 10, cashFlows);
		Console.WriteLine("NPV is " + npv);
		double pi = PI.Compute(cashFlows, 10, II);
		Console.WriteLine("PI is " + pi);
	}
}
