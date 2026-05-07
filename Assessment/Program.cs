using System;
using System.Collections.Generic;

class SaleRecord
{
    public string Date;
    public string SKU;
    public double UnitPrice;
    public int Quantity;
    public double TotalPrice;
}

class Program
{
    public static void Main()
    {
        string data = @"Date,SKU,Unit Price,Quantity,Total Price
                        2019-01-01,Death by Chocolate,180,5,900
                        2019-01-01,Cake Fudge,150,1,150
                        2019-01-01,Cake Fudge,150,1,150
                        2019-01-01,Cake Fudge,150,3,450
                        2019-01-01,Death by Chocolate,180,1,180
                        2019-01-01,Vanilla Double Scoop,80,3,240
                        2019-01-01,Butterscotch Single Scoop,60,5,300
                        2019-01-01,Vanilla Single Scoop,50,5,250
                        2019-01-01,Cake Fudge,150,5,750
                        2019-01-01,Hot Chocolate Fudge,120,3,360
                        2019-01-01,Butterscotch Single Scoop,60,5,300
                        2019-01-01,Chocolate Europa Double Scoop,100,1,100
                        2019-01-01,Hot Chocolate Fudge,120,2,240
                        2019-01-01,Caramel Crunch Single Scoop,70,4,280
                        2019-01-01,Hot Chocolate Fudge,120,2,240
                        2019-01-01,Hot Chocolate Fudge,120,4,480
                        2019-01-01,Hot Chocolate Fudge,120,2,240
                        2019-01-01,Cafe Caramel,160,5,800
                        2019-01-01,Vanilla Double Scoop,80,4,320
                        2019-01-01,Butterscotch Single Scoop,60,3,180
                        2019-02-01,Butterscotch Single Scoop,60,3,180
                        2019-02-01,Vanilla Single Scoop,50,2,100
                        2019-02-01,Butterscotch Single Scoop,60,3,180
                        2019-02-01,Vanilla Double Scoop,80,1,80
                        2019-02-01,Death by Chocolate,180,2,360
                        2019-02-01,Cafe Caramel,160,2,320
                        2019-02-01,Pista Single Scoop,60,3,180
                        2019-02-01,Hot Chocolate Fudge,120,2,240
                        2019-02-01,Vanilla Single Scoop,50,3,150
                        2019-02-01,Vanilla Single Scoop,50,5,250
                        2019-02-01,Cake Fudge,150,1,150
                        2019-02-01,Vanilla Single Scoop,50,4,200
                        2019-02-01,Vanilla Double Scoop,80,3,240
                        2019-02-01,Cake Fudge,150,1,150
                        2019-02-01,Vanilla Double Scoop,80,5,400
                        2019-02-01,Hot Chocolate Fudge,120,5,600
                        2019-02-01,Vanilla Double Scoop,80,2,160
                        2019-02-01,Vanilla Double Scoop,80,3,240
                        2019-02-01,Hot Chocolate Fudge,120,5,600
                        2019-02-01,Cake Fudge,150,5,750
                        2019-03-01,Vanilla Single Scoop,50,5,250
                        2019-03-01,Cake Fudge,150,5,750
                        2019-03-01,Pista Single Scoop,60,1,60
                        2019-03-01,Butterscotch Single Scoop,60,2,120
                        2019-03-01,Vanilla Double Scoop,80,1,80
                        2019-03-01,Cafe Caramel,160,1,160
                        2019-03-01,Cake Fudge,150,5,750
                        2019-03-01,Trilogy,160,5,800
                        2019-03-01,Butterscotch Single Scoop,60,3,180
                        2019-03-01,Death by Chocolate,180,2,360
                        2019-03-01,Butterscotch Single Scoop,60,1,60
                        2019-03-01,Hot Chocolate Fudge,120,3,360
                        2019-03-01,Cake Fudge,150,2,300
                        2019-03-01,Cake Fudge,150,2,300
                        2019-03-01,Vanilla Single Scoop,50,4,100
                        2019-03-01,Cafe Caramel,160,0,160
                        2019-03-01,Cake Fudge,150,5,750
                        2019-03-01,Cafe Caramel,160,5,800
                        2019-03-01,Almond Fudge,150,1,150
                        2019-03-01,Cake Fudge,150,1,150";

        string[] lines = data.Split('\n');

        List<SaleRecord> validRecords = new List<SaleRecord>();
        List<string> invalidRecords = new List<string>();

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                continue;
            }

            string[] parts = lines[i].Split(',');

            if (parts.Length != 5)
            {
                invalidRecords.Add("Row " + i + " : Incorrect column count");
                continue;
            }

            string dateText = parts[0].Trim();
            string sku = parts[1].Trim();

            double unitPrice;
            int quantity;
            double totalPrice;

            bool isUnitPriceValid = double.TryParse(parts[2].Trim(), out unitPrice);
            bool isQuantityValid = int.TryParse(parts[3].Trim(), out quantity);
            bool isTotalPriceValid = double.TryParse(parts[4].Trim(), out totalPrice);

            DateTime parsedDate;
            bool isDateValid = DateTime.TryParse(dateText, out parsedDate);

            string errorMessage = "";

            if (!isDateValid)
            {
                errorMessage += "Malformed Date. ";
            }

            if (!isUnitPriceValid)
            {
                errorMessage += "Invalid Unit Price. ";
            }

            if (!isQuantityValid)
            {
                errorMessage += "Invalid Quantity. ";
            }

            if (!isTotalPriceValid)
            {
                errorMessage += "Invalid Total Price. ";
            }

            if (isQuantityValid && quantity < 1)
            {
                errorMessage += "Quantity < 1. ";
            }

            if (isUnitPriceValid && unitPrice < 0)
            {
                errorMessage += "Unit Price < 0. ";
            }

            if (isTotalPriceValid && totalPrice < 0)
            {
                errorMessage += "Total Price < 0. ";
            }

            if (isUnitPriceValid && isQuantityValid && isTotalPriceValid)
            {
                double expectedTotal = unitPrice * quantity;

                if (expectedTotal != totalPrice)
                {
                    errorMessage += "Unit Price * Quantity != Total Price. ";
                }
            }

            if (errorMessage != "")
            {
                invalidRecords.Add("Row " + i + " : " + errorMessage);
            }
            else
            {
                SaleRecord record = new SaleRecord();

                record.Date = dateText;
                record.SKU = sku;
                record.UnitPrice = unitPrice;
                record.Quantity = quantity;
                record.TotalPrice = totalPrice;

                validRecords.Add(record);
            }
        }

        Console.WriteLine("Valid Records: " + validRecords.Count);
        Console.WriteLine("Invalid Records: " + invalidRecords.Count);

        Console.WriteLine("\nValidation Errors:");

        for (int i = 0; i < invalidRecords.Count; i++)
        {
            Console.WriteLine(invalidRecords[i]);
        }

        double totalSales = 0;

        for (int i = 0; i < validRecords.Count; i++)
        {
            totalSales += validRecords[i].TotalPrice;
        }

        Console.WriteLine("\nTotal Sales Of Store: " + totalSales);

        Dictionary<string, double> monthSales = new Dictionary<string, double>();

        for (int i = 0; i < validRecords.Count; i++)
        {
            string month = validRecords[i].Date.Substring(0, 7);

            if (monthSales.ContainsKey(month))
            {
                monthSales[month] += validRecords[i].TotalPrice;
            }
            else
            {
                monthSales.Add(month, validRecords[i].TotalPrice);
            }
        }

        Console.WriteLine("\nMonth-wise Sales Totals:");

        foreach (KeyValuePair<string, double> entry in monthSales)
        {
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }

        Dictionary<string, Dictionary<string, List<int>>> monthlyItemOrders =
            new Dictionary<string, Dictionary<string, List<int>>>();

        for (int i = 0; i < validRecords.Count; i++)
        {
            string month = validRecords[i].Date.Substring(0, 7);
            string sku = validRecords[i].SKU;
            int quantity = validRecords[i].Quantity;

            if (!monthlyItemOrders.ContainsKey(month))
            {
                monthlyItemOrders.Add(month, new Dictionary<string, List<int>>());
            }

            if (!monthlyItemOrders[month].ContainsKey(sku))
            {
                monthlyItemOrders[month].Add(sku, new List<int>());
            }

            monthlyItemOrders[month][sku].Add(quantity);
        }

        Console.WriteLine("\nMost Popular Item Each Month:");

        foreach (KeyValuePair<string, Dictionary<string, List<int>>> monthEntry in monthlyItemOrders)
        {
            string curMonth = monthEntry.Key;

            string popularItem = "";
            int highestQuantity = 0;

            int minOrder = 0;
            int maxOrder = 0;
            double avgOrder = 0;

            foreach (KeyValuePair<string, List<int>> itemEntry in monthEntry.Value)
            {
                string curSku = itemEntry.Key;
                List<int> orders = itemEntry.Value;

                int totalQuantity = 0;

                for (int j = 0; j < orders.Count; j++)
                {
                    totalQuantity += orders[j];
                }

                if (totalQuantity > highestQuantity)
                {
                    highestQuantity = totalQuantity;
                    popularItem = curSku;

                    minOrder = orders[0];
                    maxOrder = orders[0];

                    int sum = 0;

                    for (int k = 0; k < orders.Count; k++)
                    {
                        if (orders[k] < minOrder)
                        {
                            minOrder = orders[k];
                        }

                        if (orders[k] > maxOrder)
                        {
                            maxOrder = orders[k];
                        }

                        sum += orders[k];
                    }

                    avgOrder = (double)sum / orders.Count;
                }
            }

            Console.WriteLine(
                curMonth +
                " -> " +
                popularItem +
                " | Total Qty: " + highestQuantity +
                " | Min Order: " + minOrder +
                " | Max Order: " + maxOrder +
                " | Avg Order: " + avgOrder.ToString("0.00")
            );
        }
        Dictionary<string, Dictionary<string, double>> monthlyRevenue =
            new Dictionary<string, Dictionary<string, double>>();

        for (int i = 0; i < validRecords.Count; i++)
        {
            string month = validRecords[i].Date.Substring(0, 7);
            string sku = validRecords[i].SKU;
            double revenue = validRecords[i].TotalPrice;

            if (!monthlyRevenue.ContainsKey(month))
            {
                monthlyRevenue.Add(month, new Dictionary<string, double>());
            }

            if (!monthlyRevenue[month].ContainsKey(sku))
            {
                monthlyRevenue[month].Add(sku, 0);
            }

            monthlyRevenue[month][sku] += revenue;
        }

        Console.WriteLine("\nHighest Revenue Item Each Month:");

        foreach (KeyValuePair<string, Dictionary<string, double>> monthEntry in monthlyRevenue)
        {
            string currentMonth = monthEntry.Key;

            string topItem = "";
            double highestRevenue = 0;

            foreach (KeyValuePair<string, double> itemEntry in monthEntry.Value)
            {
                string currentSku = itemEntry.Key;
                double currentRevenue = itemEntry.Value;

                if (currentRevenue > highestRevenue)
                {
                    highestRevenue = currentRevenue;
                    topItem = currentSku;
                }
            }

            Console.WriteLine(
                currentMonth +
                " -> " +
                topItem +
                " | Revenue: " +
                highestRevenue
            );
        }
        Dictionary<string, Dictionary<string, double>> itemMonthlyRevenue =
            new Dictionary<string, Dictionary<string, double>>();

        for (int i = 0; i < validRecords.Count; i++)
        {
            string month = validRecords[i].Date.Substring(0, 7);
            string sku = validRecords[i].SKU;
            double revenue = validRecords[i].TotalPrice;

            if (!itemMonthlyRevenue.ContainsKey(sku))
            {
                itemMonthlyRevenue.Add(sku, new Dictionary<string, double>());
            }

            if (!itemMonthlyRevenue[sku].ContainsKey(month))
            {
                itemMonthlyRevenue[sku].Add(month, 0);
            }

            itemMonthlyRevenue[sku][month] += revenue;
        }

        Console.WriteLine("\nMonth-to-Month Growth Per Item:");

        foreach (KeyValuePair<string, Dictionary<string, double>> itemEntry in itemMonthlyRevenue)
        {
            string sku = itemEntry.Key;

            List<string> months = new List<string>();

            foreach (KeyValuePair<string, double> monthEntry in itemEntry.Value)
            {
                months.Add(monthEntry.Key);
            }

            months.Sort();

            Console.WriteLine("\n" + sku);

            for (int i = 1; i < months.Count; i++)
            {
                string previousMonth = months[i - 1];
                string currentMonth = months[i];

                double previousRevenue = itemEntry.Value[previousMonth];
                double currentRevenue = itemEntry.Value[currentMonth];

                double growth = 0;

                if (previousRevenue != 0)
                {
                    growth =
                        ((currentRevenue - previousRevenue) / previousRevenue) * 100;
                }

                Console.WriteLine(
                    previousMonth +
                    " -> " +
                    currentMonth +
                    " : " +
                    growth.ToString("0.00") +
                    "%"
                );
            }
        }
    }
}
/*
1) What was the most complex part of the assignment for you personally and why?

The most complex part was calculating the month-to-month growth percentage for each 
item because it required grouping revenue by item and month, sorting the months correctly, 
and comparing previous and current month revenues carefully without using LINQ or databases.

2) Describe a bug you expect to hit while implementing this and how you would debug it.

One possible bug is incorrect growth percentage calculations due to missing month data or division by zero. 
I would debug this by printing intermediate values such as previous revenue, current revenue, and item names to verify calculations step by step.

3) Does your solution handle larger data sets without any performance implications?

Yes, the solution is designed using dictionaries and lists for efficient lookups and grouping operations. 
It should handle larger datasets reasonably well, although memory usage and processing time may increase with extremely large files.
*/