using MyCalculator = Calculator.BusinessLogic.Calculator;

MyCalculator calc = new MyCalculator();
const string expression = "3^2 + 12";
double result = calc.Calculate("3^2 + 12,5");
Console.WriteLine($"{expression} = {result}");
Console.ReadKey();
