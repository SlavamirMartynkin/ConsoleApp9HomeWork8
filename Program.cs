namespace Lesson_005_Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Задача 1 Спроектируем интерфейс калькулятора, поддерживающего простые арифметические действия,
               хранящего результат и также способного выводить информацию о результате  при помощи события*/
            ICalculator calculator = new Calculator();
            calculator.GotResult += Calculator_GotResult;
            calculator.Sum(5);
            calculator.Divide(5);
            calculator.Multiply(5);
            calculator.Substract(5);
            calculator.CancelLast();
        }

        private static void Calculator_GotResult(object? sender, OperandChangedEventArgs e)
        {
            Console.WriteLine(e.Operand);
        }
    }
}
