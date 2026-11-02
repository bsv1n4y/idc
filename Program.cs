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
                AnsiConsole.MarkupLine("[red][[+]] You have selected Accounting Rate of Return[/]");
                AnsiConsole.Markup("[yellow]Enter the number of years: [/]");
                year = int.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow]Enter the value of original Investment: [/]");
                initialInvestment = double.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow]Enter the value of scrap value: [/]");
                double scrapValue = double.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow]Enter the value of working capital: [/]");
                double workingCapital = double.Parse(Console.ReadLine());
                AnsiConsole.MarkupLine("[red][[-]] What is the nature of the income [/]");
                AnsiConsole.Markup("[yellow] 1.Income after Tax and Depreciation\n 2.Income before Depreciation and Tax\n 3.Income before Tax and after Depreciation\n[/] \t [green]Enter your choice [[Default: 1]]: [/]");
                string? i_input = Console.ReadLine();
                string i_choice = string.IsNullOrWhiteSpace(i_input)
                  ? "1"
                  : i_input.Trim();
                int int_choice = int.Parse(i_choice);
                if (int_choice == 1)
                {
                  AnsiConsole.Markup("[yellow]Enter Income after depn and after tax: [/]");
                  for (int i = 0; i < year; i++)
                  {
                    cashFlows[i] = double.Parse(Console.ReadLine());
                  }
                  result = ARR.Compute(year, cashFlows, initialInvestment, scrapValue, workingCapital);
                  return result;

                } else if (int_choice == 2)
                {
                  AnsiConsole.Markup("[yellow]What is the life of the depreciable asset: [/]");
                  int life = int.Parse(Console.ReadLine());
                  AnsiConsole.Markup("[yellow]What is the tax rate: [/]");
                  float tax = float.Parse(Console.ReadLine());
                  AnsiConsole.Markup("[yellow]Enter Income before depn and tax: [/]");
                  for (int i = 0; i < year; i++)
                  {
                    cashFlows[i] = double.Parse(Console.ReadLine());
                  }
                  result = ARR.Compute(year, cashFlows, tax, life, initialInvestment, scrapValue, workingCapital);
                  return result;
                } else if (int_choice == 3)
                {
                    AnsiConsole.Markup("[yellow]What is the life of the depreciable asset: [/]");
                    int life = int.Parse(Console.ReadLine());
                    AnsiConsole.Markup("[yellow]Enter Income before depn and after tax: [/]");
                    for (int i = 0; i < year; i++)
                    {
                      cashFlows[i] = double.Parse(Console.ReadLine());
                    }
                    result = ARR.Compute(year, cashFlows, life, initialInvestment, scrapValue, workingCapital);
                    return result;
                } else
                {
                  AnsiConsole.MarkupLine("[red][[-]] You have entered wrong option available options are '1', '2' and '3'");
                  return -1;
                }
                  break;
            case 3:
                AnsiConsole.MarkupLine("[red][[+]] You have selected Internal Rate of Return[/]");
                AnsiConsole.Markup("[yellow] Enter the value for lower trial rate: [/]");
                float ltr = float.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow] Enter the value of higher trial rate: [/]");
                float htr = float.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow] Enter the value of original Investment: [/]");
                initialInvestment = double.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow] Enter the number of years: [/]");
                year = int.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow] Enter the cashFlows: [/]");
                for (int i = 0; i < year; i++)
                {
                    cashFlows[i] = double.Parse(Console.ReadLine());
                }
                result = IRR.Compute(ltr, htr, cashFlows, initialInvestment);
                return result;
                break;
            case 4:
                AnsiConsole.MarkupLine("[red][[+]] You have selected Profitability Index[/]");
                AnsiConsole.Markup("[yellow] Enter the value of years: [/]");
                year = int.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow] Enter the value for original Investment: [/]");
                initialInvestment = double.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow] Enter the value of discount rate: [/]");
                float discRate = float.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow] Enter the cash Flows: [/]");
                for (int i = 0; i < year; i++)
                {
                    cashFlows[i] = double.Parse(Console.ReadLine());
                }
                result = PI.Compute(cashFlows, discRate, initialInvestment);
                return result;
                break;
            case 5:
                AnsiConsole.MarkupLine("[red][[+]] You have selected Net Present Value[/]");
                AnsiConsole.Markup("[yellow] Enter the number of years: [/]");
                year = int.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow] Enter the value of original Investment: [/]");
                initialInvestment = double.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow] Enter the value of discount rate: [/]");
                float discountRate = float.Parse(Console.ReadLine());
                AnsiConsole.Markup("[yellow] Enter the cash Flows: [/]");
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
