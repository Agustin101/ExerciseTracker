namespace UI
{
    internal class InputValidator
    {
        internal static bool IsValidString(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            foreach (char c in input)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }

            return true;
        }
    }
}