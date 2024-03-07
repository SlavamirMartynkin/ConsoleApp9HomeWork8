namespace ConsoleApp8HomeWork7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Доработайте программу калькулятор реализовав выбор действий и вывод результатов на экран в цикле так 
             * чтобы калькулятор мог работать до тех пор пока пользователь не нажмет отмена (q) или введёт пустую строку*/
            
            
            double number = 0;
            string? action = "";
            

            ICalculator calculator = new Calculator();
            calculator.GotResult += Calculator_GotResult;

            while (number != null)
            {
                Console.Write("Введите число: ");                
                string? input = Console.ReadLine();
                if (input.Equals("q") || input.Equals("")) return;
                
                number = ReadDouble(input);

                Console.Write("Введите арифметическое действие: ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "+":
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

        private static void Calculator_GotResult(object? sender, OperandChangedEventArgs e)
        {
            Console.WriteLine($"Ответ: {e.Operand}");
            Console.WriteLine();
        }

        private static double ReadDouble(string? input)
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
    }
}
