namespace pregunta2;
using System;

class Person
{
  public string FirstName { get; private set; }
  public string LastName { get; private set; }
  public DateTime BirthDate { get; private set; }

  public Person(string firstName, string lastName, DateTime birthDate)
  {
    FirstName = firstName;
    LastName = lastName;
    BirthDate = birthDate;
  }

  public int GetAge()
  {
    DateTime today = DateTime.Now;
    int age = today.Year - BirthDate.Year;

    if (today < BirthDate.AddYears(age)) // q fecha de nacimiento sea del presente
    {
      age--;
    }

    return age;
  }

  public string GetFullName()
  {
    return $"{FirstName} {LastName}";
  }
}

class PeopleManager
{
  private Person[] people;
  private int count;

  public PeopleManager(int size)
  {
    people = new Person[size];
    count = 0;
  }

  public void AddPerson(Person person)
  {
    if (count < people.Length)
    {
      people[count] = person;
      count++;
    }
    else
    {
      Console.WriteLine("Limite de personas alcanzado");
    }
  }

  public void ShowPeopleInfo()
  {
    for (int i = 0; i < count; i++)
    {
      Console.WriteLine($"Nombre: {people[i].GetFullName()}, Edad: {people[i].GetAge()}");
    }
  }
}

// Class responsible for input validation
class InputValidator
{
  // Method to validate integer input
  public static int GetValidIntegerInput(string message)
  {
    int validInteger;
    bool isValid;
    do
    {
      Console.Write(message);
      isValid = int.TryParse(Console.ReadLine(), out validInteger) && validInteger > 0;

      if (!isValid)
      {
        Console.WriteLine("Entrada invalida. Por favor inserta un entero positivo.");
      }

    } while (!isValid);

    return validInteger;
  }

  // Method to validate string input (non-empty)
  public static string GetValidStringInput(string message)
  {
    string input;
    do
    {
      Console.Write(message);
      input = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(input))
      {
        Console.WriteLine("Entrada invalida. Por favor inserta una cadena de caracteres valida.");
      }

    } while (string.IsNullOrWhiteSpace(input));

    return input;
  }

  // Method to validate date input
  public static DateTime GetValidDateInput(string message)
  {
    DateTime validDate;
    bool isValid;
    do
    {
      Console.Write(message);
      isValid = DateTime.TryParse(Console.ReadLine(), out validDate);

      if (!isValid || validDate > DateTime.Now)
      {
        Console.WriteLine("Entrada invalida, por favor inserta una fecha en el formato aaaa-mm-dd.");
        isValid = false;
      }

    } while (!isValid);

    return validDate;
  }
}

// Main class to handle user input and interaction
class Program
{
  static void Main(string[] args)
  {
    int size = InputValidator.GetValidIntegerInput("Cuanta gente deseas insertar? ");

    PeopleManager peopleManager = new PeopleManager(size);

    for (int i = 0; i < size; i++)
    {
      Console.WriteLine($"\nInsertando detalles para persona {i + 1}:");

      string firstName = InputValidator.GetValidStringInput("Inserte nombre: ");
      string lastName = InputValidator.GetValidStringInput("Inserte apellido: ");
      DateTime birthDate = InputValidator.GetValidDateInput("Inserte fecha de nacimiento (aaaa-mm-dd): ");

      Person person = new Person(firstName, lastName, birthDate);
      peopleManager.AddPerson(person);
    }

    Console.WriteLine("\nInformacion de gente:");
    peopleManager.ShowPeopleInfo();
  }
}
