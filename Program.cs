namespace PracticaControlFlujo;

using System;

// Class responsible for handling number input and processing
class NumberProcessor
{
  private int[] numbers;
  private int count;

  public NumberProcessor(int size)
  {
    numbers = new int[size];
    count = 0;
  }

  public void AddNumber(int number)
  {
    if (number >= 0 && count < numbers.Length)
    {
      numbers[count] = number;
      count++;
    }
  }

  public int GetSum()
  {
    int sum = 0;
    for (int i = 0; i < count; i++)
    {
      sum += numbers[i];
    }
    return sum;
  }

  public int GetHighest()
  {
    if (count == 0)
      throw new InvalidOperationException("No hay numeros en el arreglo.");

    int highest = numbers[0];
    for (int i = 1; i < count; i++)
    {
      if (numbers[i] > highest)
      {
        highest = numbers[i];
      }
    }
    return highest;
  }

  public int GetLowest()
  {
    if (count == 0)
      throw new InvalidOperationException("No numbers in the array.");

    int lowest = numbers[0];
    for (int i = 1; i < count; i++)
    {
      if (numbers[i] < lowest)
      {
        lowest = numbers[i];
      }
    }
    return lowest;
  }

  public bool HasNumbers()
  {
    return count > 0;
  }
}

// Main class to handle user input and interaction
class Program
{
  static void Main(string[] args)
  {
    Console.Write("Escriba cantidad de numeros a insertar: ");
    int size = int.Parse(Console.ReadLine());

    NumberProcessor numberProcessor = new NumberProcessor(size);
    int input;

    Console.WriteLine("Inserte numeros. Escriba uno negativo para parar");

    do
    {
      Console.Write("Inserte numero: ");
      input = int.Parse(Console.ReadLine());

      if (input >= 0)
      {
        numberProcessor.AddNumber(input);
      }
    } while (input >= 0 && numberProcessor.HasNumbers());

    if (numberProcessor.HasNumbers())
    {
      Console.WriteLine($"Suma de numeros: {numberProcessor.GetSum()}");
      Console.WriteLine($"Numero mas alto: {numberProcessor.GetHighest()}");
      Console.WriteLine($"Numero mas bajo: {numberProcessor.GetLowest()}");
    }
    else
    {
      Console.WriteLine("No fue ingresado ningun numero.");
    }
  }
}
