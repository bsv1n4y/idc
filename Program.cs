using Utils;
using Spectre.Console;

class Program
{
    static void Main()
    {
        while (true)
        {
        int choice = welcomeScreen();
        double result = methodSelector(choice);
        AnsiConsole.MarkupLine("[green][[+]] The result is [/]" + result);
        Console.WriteLine();
        AnsiConsole.MarkupLine("[red][[+]] Press any key to continue...[/]");
        Console.ReadKey(intercept: true);
        Console.Clear();
        }
    }
    static int welcomeScreen()
    {
        AnsiConsole.MarkupLine("[green][[+]] Welcome to Investment Decision Planner[/]");
        AnsiConsole.MarkupLine("[red]Select any method to compute[/]");
        AnsiConsole.Markup("[yellow] 1.PBP\n 2.ARR\n 3.IRR\n 4.PI\n 5.NPV\n[/] [red]6.Exit[/] \t [green]Enter your choice: [/]");
        string choice1 = Console.ReadLine();
        int choice = int.Parse(choice1);
        Console.Clear();
        return choice;
    }
    static double methodSelector(int choice)
    {
        double result;
        double initialInvestment;
        double[] cashFlows = new double[20];
        int year;
        switch (choice)
        {
            case 1:
                AnsiConsole.MarkupLine("[red][[+]] You have selected PayBackPeriod[/]");
                AnsiConsole.Markup("[yellow]Enter the number of years: [/]");
                year = int.Parse(Console.ReadLine());
                AnsiConsole.Markup("[red][[-]] Is cashflow same for all the years (y/n): [/]");
                string c = Console.ReadLine();
                AnsiConsole.Markup("[yellow]Enter the value of initial Investment: [/]");
                initialInvestment = double.Parse(Console.ReadLine());
                if (c == "y" || c == "yes")
                {
                  AnsiConsole.Markup("[yellow]Enter the cashflow: [/]");
                  double s_cashFlow = float.Parse(Console.ReadLine());
                  result = PBP.Compute(initialInvestment, s_cashFlow);
                  return result;
                }
                else if (c == "n" || c == "no")
                {
                  AnsiConsole.Markup("[yellow]Enter the cashFlows: [/]");
                  for (int i = 0; i < year; i++)
                  {
                    cashFlows[i] = double.Parse(Console.ReadLine());
                  }
                  result = PBP.Compute(initialInvestment, cashFlows);
                  return result;
                }
                else
                {
                  AnsiConsole.MarkupLine("[red][[-]] You have entered wrong option, available options are 'y' for yes and 'n' for no[/]");
                  return -1;
                }
                break;
            case 2:
                Console.WriteLine("You have selected Accounting Rate of Return");
                Console.Write("Enter the number of years: ");
                year = int.Parse(Console.ReadLine());
                Console.Write("Enter the value of original Investment: ");
                initialInvestment = double.Parse(Console.ReadLine());
                Console.Write("Enter the value of scrap value: ");
                double scrapValue = double.Parse(Console.ReadLine());
                Console.Write("Enter the value of working capital: ");
                double workingCapital = double.Parse(Console.ReadLine());
                Console.Write("Enter Income after depn and after tax: ");
                for (int i = 0; i < year; i++)
                {
                    cashFlows[i] = double.Parse(Console.ReadLine());
                }
                result = ARR.Compute(cashFlows, initialInvestment, scrapValue, workingCapital);
                return result;
                break;
            case 3:
                Console.WriteLine("You have selected Internal Rate of Return");
                Console.Write("Enter the value for lower trial rate: ");
                float ltr = float.Parse(Console.ReadLine());
                Console.Write("Enter the value of higher trial rate: ");
                float htr = float.Parse(Console.ReadLine());
                Console.Write("Enter the value of original Investment: ");
                initialInvestment = double.Parse(Console.ReadLine());
                Console.Write("Enter the number of years: ");
                year = int.Parse(Console.ReadLine());
                Console.Write("Enter the cashFlows: ");
                for (int i = 0; i < year; i++)
                {
                    cashFlows[i] = double.Parse(Console.ReadLine());
                }
                result = IRR.Compute(ltr, htr, cashFlows, initialInvestment);
                return result;
                break;
            case 4:
                Console.WriteLine("You have selected Profitability Index");
                Console.Write("Enter the value of years: ");
                year = int.Parse(Console.ReadLine());
                Console.Write("Enter the value for original Investment: ");
                initialInvestment = double.Parse(Console.ReadLine());
                Console.Write("Enter the value of discount rate: ");
                float discRate = float.Parse(Console.ReadLine());
                Console.Write("Enter the cash Flows: ");
                for (int i = 0; i < year; i++)
                {
                    cashFlows[i] = double.Parse(Console.ReadLine());
                }
                result = PI.Compute(cashFlows, discRate, initialInvestment);
                return result;
                break;
            case 5:
                Console.WriteLine("You have selected Net Present Value");
                Console.Write("Enter the number of years: ");
                year = int.Parse(Console.ReadLine());
                Console.Write("Enter the value of original Investment: ");
                initialInvestment = double.Parse(Console.ReadLine());
                Console.Write("Enter the value of discount rate: ");
                float discountRate = float.Parse(Console.ReadLine());
                Console.Write("Enter the cash Flows: ");
                for (int i = 0; i < year; i++)
                {
                    cashFlows[i] = double.Parse(Console.ReadLine());
                }
                result = NPV.Compute(initialInvestment, discountRate, cashFlows);
                return result;
                break;
            case 6:
                AnsiConsole.MarkupLine("[red][[-]] You have selected to exit the app[/]");
                Environment.Exit(0);
                return 0;
                break;
            default:
                return 0;
                break;
        }

    }
}
