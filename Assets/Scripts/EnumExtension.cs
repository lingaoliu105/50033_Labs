using System;

public static class EnumExtension
{
    public static T ParseEnum<T>(string input) where T : struct
    {
        // return the enum value given a string
        T enumValue;
        if (Enum.TryParse(input, true, out enumValue))
        {
            return enumValue;
        }
        return default(T);
    }

    public static int ParseEnumToInteger<T>(string input) where T : struct
    {
        // return the integer enum given a string
        T enumValue = ParseEnum<T>(input);
        if (Enum.IsDefined(typeof(T), enumValue))
        {
            return Convert.ToInt32(enumValue);
        }
        return -1;
    }

}