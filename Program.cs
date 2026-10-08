using System;
using System.Text;

namespace Lab02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            const decimal Commission = 0.5m;
            var depositType = "Строковий депозит";

            int contractNumber = 12_025;
            string depositorName = "Тарас";
            decimal depositAmount = 25_000.00m;
            decimal annualRate = 0m;
            int termMonths = 12;
            decimal topUp = 2_000.00m;
            bool capitalization = false;
            char currency = '₴';
            byte payments = 12;
            float bonusRate = 1.5f;

            Console.WriteLine("=== ДАНІ ДЕПОЗИТУ ===");
            Console.WriteLine($"{"Змінна",-18} {"Тип",-10} {"Байтів",7} Значення");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"{"contractNumber",-18} {contractNumber.GetType().Name,-10} {sizeof(int),7} {contractNumber}");
            Console.WriteLine($"{"depositorName",-18} {depositorName.GetType().Name,-10} {"змінний",7} {depositorName}");
            Console.WriteLine($"{"depositAmount",-18} {depositAmount.GetType().Name,-10} {sizeof(decimal),7} {depositAmount:C}");
            Console.WriteLine($"{"annualRate",-18} {annualRate.GetType().Name,-10} {sizeof(decimal),7} {annualRate:F2}");
            Console.WriteLine($"{"termMonths",-18} {termMonths.GetType().Name,-10} {sizeof(int),7} {termMonths}");
            Console.WriteLine($"{"topUp",-18} {topUp.GetType().Name,-10} {sizeof(decimal),7} {topUp:C}");
            Console.WriteLine($"{"capitalization",-18} {capitalization.GetType().Name,-10} {sizeof(bool),7} {capitalization}");
            Console.WriteLine($"{"currency",-18} {currency.GetType().Name,-10} {sizeof(char),7} {currency}");
            Console.WriteLine($"{"payments",-18} {payments.GetType().Name,-10} {sizeof(byte),7} {payments}");

            Console.WriteLine();
            Console.WriteLine($"Межі int: {int.MinValue} ... {int.MaxValue}");
            Console.WriteLine($"Межі byte: {byte.MinValue} ... {byte.MaxValue}");
            Console.WriteLine($"default(int) = {default(int)}");
            Console.WriteLine($"default(decimal) = {default(decimal)}");
            Console.WriteLine($"default(bool) = {default(bool)}");
            Console.WriteLine($"default(char) = '{default(char)}'");

            Console.WriteLine();
            Console.Write("Введіть річну ставку, %: ");
            string input = Console.ReadLine();
            bool parsed = decimal.TryParse(input, out annualRate);
            Console.WriteLine($"Розпізнано ввід: {parsed}");
            Console.WriteLine($"Річна ставка: {annualRate:F2}%");

            decimal interest = depositAmount * annualRate / 100m * termMonths / 12m;
            decimal finalAmount = depositAmount + topUp + interest;

            int wholeInterest = (int)interest;
            decimal implicitInterest = wholeInterest;
            int convertedInterest = Convert.ToInt32(interest);

            Console.WriteLine();
            Console.WriteLine("=== ПЕРЕТВОРЕННЯ ТИПІВ ===");
            Console.WriteLine($"Дохід: {interest:F2} {currency}");
            Console.WriteLine($"Неявне int -> decimal: {implicitInterest:F2} ({implicitInterest.GetType().Name})");
            Console.WriteLine($"Явне (int): {wholeInterest} ({wholeInterest.GetType().Name})");
            Console.WriteLine($"Convert.ToInt32: {convertedInterest} ({convertedInterest.GetType().Name})");

            int tooLarge = 300;
            byte overflowByte = (byte)tooLarge;
            Console.WriteLine($"300 -> byte: {overflowByte} (втрата даних!)");

            try
            {
                byte checkedByte = checked((byte)tooLarge);
            }
            catch (OverflowException)
            {
                Console.WriteLine("checked: System.OverflowException");
            }

            Console.WriteLine();
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║              БАНКІВСЬКИЙ ДЕПОЗИТ              ║");
            Console.WriteLine("╠════════════════════════════════════════════════╣");
            Console.WriteLine($"║ Договір: {contractNumber:D5}".PadRight(49) + "║");
            Console.WriteLine($"║ Вкладник: {depositorName}".PadRight(49) + "║");
            Console.WriteLine($"║ Вклад: {depositAmount:C}".PadRight(49) + "║");
            Console.WriteLine($"║ Ставка: {annualRate / 100:P1}".PadRight(49) + "║");
            Console.WriteLine($"║ Строк: {termMonths:N0} міс.".PadRight(49) + "║");
            Console.WriteLine($"║ Поповнення: {topUp:C}".PadRight(49) + "║");
            Console.WriteLine($"║ Дохід: {interest:C}".PadRight(49) + "║");
            Console.WriteLine($"║ До отримання: {finalAmount:C}".PadRight(49) + "║");
            Console.WriteLine($"║ Капіталізація: {capitalization}".PadRight(49) + "║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");

            Console.WriteLine();
            Console.WriteLine($"F2: {annualRate:F2}%");
            Console.WriteLine($"N0: {finalAmount:N0} {currency}");
            Console.WriteLine($"C: {finalAmount:C}");
            Console.WriteLine($"P1: {annualRate / 100:P1}");
            Console.WriteLine($"D5: {contractNumber:D5}");
        }
    }
}
