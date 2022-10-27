namespace UI
{
    internal class InputValidator
    {
        internal static bool IsValidInt(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

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