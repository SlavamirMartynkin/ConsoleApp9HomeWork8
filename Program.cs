﻿using Microsoft.VisualBasic;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp8HomeWork7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Доработайте программу калькулятор реализовав выбор действий и вывод результатов на экран в цикле так 
             * чтобы калькулятор мог работать до тех пор пока пользователь не нажмет отмена (q) или введёт пустую строку*/


            string? action = "";

            ICalculator calculator = new Calculator();
            calculator.GotResult += Calculator_GotResult;
            Logger logger = new Logger();

            while (true)
            {
                try
                {
                    Console.Write("Введите число: ");
                    string? input = Console.ReadLine();
                    if (input.Equals("q") || input.Equals("")) return;

                    Console.Write("Введите арифметическое действие: ");
                    action = Console.ReadLine();

                    logger.AddLog(input, action);

                    if (input.Contains(',') || input.Contains('.'))
                    {
                        double number = ReadDouble(input);
                        switch (action)
                        {
                            case "+":
                                Console.WriteLine(number.GetType());
                                calculator.Sum(number);
                                break;
                            case "-":
                                calculator.Substract(number);
                                break;
                            case "*":
                                calculator.Multiply(number);
                                break;
                            case "/":
                                calculator.Divide(number);
                                break;
                            case "q":
                                return;
                            case "":
                                return;
                            default:
                                Console.WriteLine("Неверное действие!");
                                Console.WriteLine("Начните сначала.");
                                Console.WriteLine();
                                break;
                        }
                    }
                    else
                    {
                        int number = ReadInt(input);
                        switch (action)
                        {
                            case "+":
                                Console.WriteLine(number.GetType());
                                calculator.Sum(number);
                                break;
                            case "-":
                                calculator.Substract(number);
                                break;
                            case "*":
                                calculator.Multiply(number);
                                break;
                            case "/":
                                calculator.Divide(number);
                                break;
                            case "q":
                                return;
                            case "":
                                return;
                            default:
                                Console.WriteLine("Неверное действие!");
                                Console.WriteLine("Начните сначала.");
                                Console.WriteLine();
                                break;
                        }
                    }
                }
                catch (CalculateOperationCauseOverflowException ex)
                {
                    Console.WriteLine(logger.GetLog() + ex.Message);
                }
                catch (CalculatorDivideByZeroException ex)
                {
                    Console.WriteLine(logger.GetLog() + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(logger.GetLog() + ex.Message);
                }
            }

            static void Calculator_GotResult(object? sender, OperandChangedEventArgs e)
            {
                Console.WriteLine($"Ответ: {e.Operand}");
                Console.WriteLine();
            }

            static double ReadDouble(string? input)
            {
                double i;
                while (!double.TryParse(input, out i))
                {
                    Console.WriteLine("Это не число!");
                    Console.WriteLine("Введите число.");
                    input = Console.ReadLine();
                }
                return i;
            }
            static int ReadInt(string? input)
            {
                int i;
                while (!int.TryParse(input, out i))
                {
                    Console.WriteLine("Это не число!");
                    Console.WriteLine("Введите число.");
                    input = Console.ReadLine();
                }
                return i;
            }
        }
    }
}
