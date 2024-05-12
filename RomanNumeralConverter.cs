using System; // Inkluderar System-namnrymden för att använda vissa standardklasser.
using System.Collections.Generic; // Inkluderar System.Collections.Generic-namnrymden för att använda Dictionary.
using System.Linq; // Inkluderar System.Linq-namnrymden för att använda LINQ-metoder.
using System.Text; // Inkluderar System.Text-namnrymden för att använda StringBuilder.

public class RomanNumeralConverter  // Klassen för att konvertera romerska siffror till heltal och vice versa.
{
    private static Dictionary<string, int> romanValues = new Dictionary<string, int>()  // En dictionary som kartlägger romerska siffror till deras motsvarande heltal.
    {
        {"I", 1}, {"II", 2}, {"III", 3}, {"IV", 4}, {"V", 5}, {"VI", 6}, {"VII", 7}, {"VIII", 8}, {"IX", 9}, {"X", 10}, {"L", 50}, {"C", 100}, {"D", 500}, {"M", 1000}, {"XXXI", 31}, {"CXLVIII", 148}, {"CCXCIV", 294},
        {"CCCXII", 312}, {"CDXXI", 421}, {"DXXVIII", 528}, {"DCXXI", 621}, {"DCCLXXXII", 782}, {"DCCCLXX", 870}, {"CMXLI", 941}, {"MXLIII", 1043}, {"MCX", 1110}, {"MCCXXVI", 1226}, {"MCCCI", 1301}, {"MCDLXXXV", 1485},
        {"MDIX", 1509}, {"MDCVII", 1607}, {"MDCCLIV", 1754}, {"MDCCCXXXII", 1832}, {"MCMXCIII", 1993}, {"MMLXXIV", 2074}, {"MMCLII", 2152}, {"MMCCXII", 2212}, {"MMCCCXLIII", 2343}, {"MMCDXCIX", 2499}, {"MMDLXXIV", 2574}, {"MMDCXLVI", 2646},
        {"MMDCCXXIII", 2723}, {"MMDCCCXCII", 2892}, {"MMCMLXXV", 2975}, {"MMMLI", 3051}, {"MMMCLXXXV", 3185}, {"MMMCCL", 3250}, {"MMMCCCXIII", 3313}, {"MMMCDVIII", 3408}, {"MMMDI", 3501}, {"MMMDCX", 3610}, {"MMMDCCXLIII", 3743}, {"MMMDCCCXLIV", 3844}, {"MMMDCCCLXXXVIII", 3888}, {"MMMCMXL", 3940}
    };

    private static Dictionary<string, string> subtractiveNotation = new Dictionary<string, string>()  // En dictionary för subtraktiv notation.
    {
        {"CM", "DCCCC"},
        {"CD", "CCCC"},
        {"XC", "LXXXX"},
        {"XL", "XXXX"},
        {"IX", "VIIII"},
        {"IV", "IIII"}
    };

    public static int FromRoman(string roman) // Metod för att konvertera romerska siffror till heltal.
    {
        if (string.IsNullOrEmpty(roman)) // Om inmatningen är tom eller null kastas ett ArgumentException.
        {
            throw new ArgumentException("Input cannot be empty.", nameof(roman));
        }

        int result = 0; // Variabel för att lagra det resulterande heltalet.
        int prevValue = 0; // Variabel för att hålla koll på föregående värde.

        foreach (char c in roman) // Loopar genom varje tecken i den romerska siffran.
        {
            string key = c.ToString(); // Konverterar tecknet till en sträng för att använda det som nyckel i dictionaryn.
            if (!romanValues.ContainsKey(key)) // Om tecknet inte finns i dictionaryn kastas ett ArgumentException.
            {
                throw new ArgumentException("Invalid Roman numeral character.");
            }

            int value = romanValues[key]; // Hämtar värdet från dictionaryn baserat på tecknet.

            if (value > prevValue) // Om det aktuella värdet är större än det föregående subtraheras det dubbla av föregående värde.
            {
                result += value - 2 * prevValue;
            }
            else // Annars adderas det aktuella värdet till resultatet.
            {
                result += value;
            }

            prevValue = value; // Uppdaterar föregående värde till det aktuella värdet.
        }

        return result; // Returnerar det resulterande heltalet.
    }


    public static string ToRoman(int number) // Metod för att konvertera heltal till romerska siffror.
    {
        if (number < 1 || number > 3999) // Om det angivna heltalet är utanför intervallet 1-3999 kastas ett ArgumentOutOfRangeException.
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Input must be between 1 and 3999.");
        }

        StringBuilder result = new StringBuilder(); // Skapar en StringBuilder för att bygga den resulterande romerska siffran.

        foreach (var kvp in romanValues.OrderByDescending(kv => kv.Value)) // Loopar genom dictionaryn, ordnad efter det motsvarande heltalet i fallande ordning.
        {
            while (number >= kvp.Value) // Loopar så länge det angivna heltalet är större än eller lika med det aktuella heltalet i dictionaryn.
            {
                result.Append(kvp.Key); // Lägger till den romerska siffran i resultatet.
                number -= kvp.Value; // Subtraherar det aktuella heltalet från det angivna heltalet.
            }
        }

        // Specialfall för subtraktiv notation
        foreach (var kvp in subtractiveNotation) // Loopar genom dictionaryn för subtraktiv notation.
        {
            while (result.ToString().Contains(kvp.Key)) // Loopar så länge resultatet innehåller den romerska siffran från subtraktiv notation.
            {
                int index = result.ToString().IndexOf(kvp.Key); // Hittar index för den romerska siffran.
                result = result.Remove(index, kvp.Key.Length).Insert(index, kvp.Value); // Ersätter den romerska siffran med dess motsvarighet i subtraktiv notation.
            }
        }

        // Tar bort överflödiga tecken
        foreach (var kvp in subtractiveNotation) // Loopar genom dictionaryn för subtraktiv notation.
        {
            while (result.ToString().Contains(kvp.Key)) // Loopar så länge resultatet innehåller den romerska siffran från subtraktiv notation.
            {
                int index = result.ToString().IndexOf(kvp.Key); // Hittar index för den romerska siffran.
                result = result.Remove(index + 1, kvp.Key.Length - 1); // Tar bort överflödiga tecken från den romerska siffran.
            }
        }

        return result.ToString(); // Returnerar den resulterande romerska siffran som en sträng.
    }

}
