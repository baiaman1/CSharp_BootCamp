# Life on credit

“As my father used to say: "There are two sure ways to lose a friend, one is to borrow, the other to lend.”

**― Patrick Rothfuss, The Name of the Wind**

### What new I learn:

- Environment.GetCommandLineArgs();
- DateTime and its methods
- CultureInfo (en-GB, N2, d)




| Payment no. | Payment date | Payment | Principal debt | Interest | Remaining debt  |
|---|---|---|---|---|---|
 
input: 
- The loan amount, 
- Annual percentage rate, 
- Number of months of the loan.

**Total monthly payment**

```math

\frac{Loan \; ammount*i*(1+i)^n}{(1+i)^n-1}

```

n — number of months, when the loan is paid

i — the interest rate on the loan per month.

**Interest rate on the loan per month:**

```math

i = Annual \; percentage \; rate /12/100

```

**Monthly payment interest:**

```math

\frac{Total \; debt \; balance*Annual \; percentage \; rate * DaysOfThePeriod}{100*Days \; per \; year}

```

The total debt balance is the amount of the principal debt as of the settlement date.

The number of days of the period is the difference in days between the "Current payment date" and the date of the previous payment.

We assume that you pay off the loan on the 1st day of each month, starting from the next. It's important to consider leap years! The **System.DateTime**  methods will help you with this and other operations with dates and times. In total, there will be as many such months as you took out the loan for (the input argument).

The monthly payment (_Payment_) consists of the part going to the repayment of the principal debt (_Principal debt_), and the part going to the payment of interest on the loan (_Interest_). The formulas for calculating the Amount of the monthly payment (_Payment_) and the Interest of the monthly payment (_Interest_) are given in the loan agreement above. For mathematical calculations, use the tools of the **System.Math** library. Now, knowing them, you can calculate the _Principal Debt_.

The _Remaining debt_ for each month is also easy to determine: we simply gradually subtract the monthly payment from the total loan amount. **Loops** and **increment operators** will help you here. Note that if this is the last month of the loan and the balance of the debt is non-zero, you just need to increase the monthly payment and the amount going to pay the debt in the schedule. So we’ll pay the loan off in time.

The last step is to bring everything into a nice and convenient table.

### Input parameters

| Argument | Type | Description |
|---|---|---|
| sum |double | Loan amount, RUB |
|rate | double | Annual percentage rate, % |
|term|int|Number of months of the loan|

### Output format

The data should be ordered by month (in ascending order).

#### The user specified incorrect data
```
Something went wrong. Check your input and retry.
```
#### Examples of launching an application from the project folder
```
$ dotnet run 1000000 12 10
1       06/01/2021      105,582.08      95,390.30       10,191.78       904,609.70
2       07/01/2021      105,582.08      96,659.90       8,922.18        807,949.81
3       08/01/2021      105,582.08      97,347.63       8,234.45        710,602.18
4       09/01/2021      105,582.08      98,339.77       7,242.30        612,262.40
5       10/01/2021      105,582.08      99,543.32       6,038.75        512,719.08
6       11/01/2021      105,582.08      100,356.56      5,225.52        412,362.52
7       12/01/2021      105,582.08      101,514.94      4,067.14        310,847.58
8       01/01/2022      105,582.08      102,413.99      3,168.09        208,433.60
9       02/01/2022      105,582.08      103,457.77      2,124.31        104,975.83
10      03/01/2022      105,942.18      104,975.83      966.35          0.00
```
```
$ dotnet run 55000 10 20
1       06/01/2021      2,996.95        2,529.82        467.12        52,470.18
2       07/01/2021      2,996.95        2,565.68        431.26        49,904.49
3       08/01/2021      2,996.95        2,573.10        423.85        47,331.39
4       09/01/2021      2,996.95        2,594.95        401.99        44,736.44
5       10/01/2021      2,996.95        2,629.25        367.70        42,107.19
6       11/01/2021      2,996.95        2,639.32        357.62        39,467.87
7       12/01/2021      2,996.95        2,672.55        324.39        36,795.32
8       01/01/2022      2,996.95        2,684.44        312.51        34,110.88
9       02/01/2022      2,996.95        2,707.24        289.71        31,403.64
10      03/01/2022      2,996.95        2,756.04        240.90        28,647.60
11      04/01/2022      2,996.95        2,753.64        243.31        25,893.97
12      05/01/2022      2,996.95        2,784.12        212.83        23,109.85
13      06/01/2022      2,996.95        2,800.67        196.28        20,309.18
14      07/01/2022      2,996.95        2,830.02        166.92        17,479.16
15      08/01/2022      2,996.95        2,848.49        148.45        14,630.66
16      09/01/2022      2,996.95        2,872.69        124.26        11,757.98
17      10/01/2022      2,996.95        2,900.30        96.64         8,857.67
18      11/01/2022      2,996.95        2,921.72        75.23         5,935.96
19      12/01/2022      2,996.95        2,948.16        48.79         2,987.80
20      01/01/2023      3,013.18        2,987.80        25.38         0.00
```
