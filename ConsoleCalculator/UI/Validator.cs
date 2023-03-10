using System.ComponentModel;

namespace UI;

public class Validator
{
    public static T Convert<T>(string prompt)
    {
        bool valid = false;
        string userInput;

        while (!valid)
        {
            userInput = Utility.GetUserInput(prompt);
            try
            {
                var convert = TypeDescriptor.GetConverter(typeof(T));
                if (convert != null)
                {
                    return (T)convert.ConvertFromString(userInput);
                }
                else
                {
                    return default;
                }
            }
            catch (InvalidOperationException e)
            {
                Utility.PrintMessage($"Invalid Option. Try again", false);
                throw;
            }
        }

        return default;
    }
}
