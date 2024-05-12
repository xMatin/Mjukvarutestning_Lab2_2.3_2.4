using System; // Inkluderar System-namnrymden för att använda Console-klassen.

public class Program // Huvudklassen för programmet.
{
    public static void Main(string[] args) // Huvudmetoden som körs när programmet startar.
    {
        Console.WriteLine("Välkommen till Roman Numeral Converter!"); // Skriver ut en välkomstmeddelande till användaren.

        while (true) // Loop för att hålla programmet igång tills användaren väljer att avsluta.
        {
            Console.WriteLine("\nVälj ett alternativ:"); // Skriver ut alternativ för användaren.
            Console.WriteLine("1. Konvertera till romerska siffror");
            Console.WriteLine("2. Konvertera från romerska siffror");
            Console.WriteLine("3. Avsluta programmet");

            Console.Write("Ange ditt val (1/2/3): "); // Ber användaren ange sitt val.
            string choice = Console.ReadLine(); // Läser in användarens val.

            switch (choice) // Väljer vilken funktion som ska köras baserat på användarens val.
            {
                case "1":
                    ConvertToRoman(); // Anropar metoden för att konvertera till romerska siffror.
                    break;
                case "2":
                    ConvertFromRoman(); // Anropar metoden för att konvertera från romerska siffror.
                    break;
                case "3":
                    Console.WriteLine("Tack för att du använt Roman Numeral Converter. Hejdå!"); // Skriver ett avslutningsmeddelande och avslutar programmet.
                    return;
                default:
                    Console.WriteLine("Ogiltigt val. Var god försök igen."); // Meddelande vid ogiltigt val.
                    break;
            }
        }
    }

    public static void ConvertToRoman() // Metod för att konvertera till romerska siffror.
    {
        Console.Write("Ange ett heltal (1-3999): "); // Ber användaren ange ett heltal.
        int number = int.Parse(Console.ReadLine()); // Läser in det angivna heltalet.

        try
        {
            string romanNumeral = RomanNumeralConverter.ToRoman(number); // Försöker konvertera det angivna heltalet till romerska siffror.
            Console.WriteLine($"Romerska siffror för {number}: {romanNumeral}"); // Skriver ut resultatet.
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message); // Hanterar undantaget om det angivna heltalet är utanför det tillåtna området.
        }
    }

    public static void ConvertFromRoman() // Metod för att konvertera från romerska siffror.
    {
        Console.Write("Ange en romersk siffra: "); // Ber användaren ange en romersk siffra.
        string romanNumeral = Console.ReadLine(); // Läser in den angivna romerska siffran.

        try
        {
            int number = RomanNumeralConverter.FromRoman(romanNumeral); // Försöker konvertera den angivna romerska siffran till ett heltal.
            Console.WriteLine($"Nummer för den romerska siffran {romanNumeral}: {number}"); // Skriver ut resultatet.
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message); // Hanterar undantaget om den angivna romerska siffran innehåller ogiltiga tecken.
        }
    }
}
