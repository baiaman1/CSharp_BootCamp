﻿
using System.Globalization;

void calc() {
    // string[] args = Environment.GetCommandLineArgs();
    if (args.Length != 3) {
        System.Console.WriteLine("Something went wrong. Check your input and retry.");
    }
    else {
        double sum = double.Parse(args[0]);
        double rate = double.Parse(args[1]);
        int term = int.Parse(args[2]);

        DateTime currentDate = new DateTime(2021, 05, 01);
        DateTime nextMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
        int dInYear, dInMonth, num = 1;
        double i, princ, payment, interes, totalDebt = sum;
        i = rate/12/100;
        payment = sum * i * Math.Pow((1+i), term)/(Math.Pow(1+i, term)-1);
        while (num <= term) {
            dInYear = DateTime.IsLeapYear(currentDate.Year) ? 366 : 365;
            dInMonth = DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month);
            nextMonth = nextMonth.AddMonths(1);
            
            interes = totalDebt * rate * dInMonth / (100*dInYear);
            princ = payment-interes;
            totalDebt = totalDebt-princ;
            if (num==term) {
                payment+=totalDebt;
                totalDebt = 0;
                princ = payment-interes;
            }
        
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");

            Console.Write($"{num} \t  ");
            Console.Write($"{nextMonth.ToString("d", culture)} \t  ");
            Console.Write($"{payment.ToString("N2",culture)}   \t  ");
            Console.Write($"{princ.ToString("N2",culture)}  \t ");
            Console.Write($"{interes.ToString("N2",culture)}  \t ");
            Console.Write($"{totalDebt.ToString("N2",culture)} ");
            Console.WriteLine("\t");
            num++;
        }
    }

}

calc();

