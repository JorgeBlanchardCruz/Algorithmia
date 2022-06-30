using System.Text.RegularExpressions;

var phrase = string.Empty;
do
{
    Console.Clear();
    Console.WriteLine("Palindromes");
    Console.WriteLine("Intro a phrase: ");
    phrase = Console.ReadLine();

    Console.WriteLine($"'{phrase}' {(IsPalindrome(phrase) ? string.Empty : "not ")}is palindrome");
    Console.ReadKey();

} while (phrase != "exit");



bool IsPalindrome(string? word)
{
    word = word.Replace(" ", string.Empty).ToLower();
    word = RemoveAccents(word);

    for (int currentIndex = 0; currentIndex < (word.Length / 2); currentIndex++)
    {
        int indexToCompare = (word.Length - 1) - currentIndex;
        if (word[currentIndex] != word[indexToCompare])
            return false;
    }

    return true;
}

string RemoveAccents(string inputString)
{
    Regex replace_a_Accents = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
    Regex replace_e_Accents = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
    Regex replace_i_Accents = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
    Regex replace_o_Accents = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
    Regex replace_u_Accents = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
    inputString = replace_a_Accents.Replace(inputString, "a");
    inputString = replace_e_Accents.Replace(inputString, "e");
    inputString = replace_i_Accents.Replace(inputString, "i");
    inputString = replace_o_Accents.Replace(inputString, "o");
    inputString = replace_u_Accents.Replace(inputString, "u");
    return inputString;
}