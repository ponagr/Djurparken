class Misc
{
    public static bool ContainsInt(string value)
    {
        return value.Any(char.IsDigit);
    }
    public static bool IsEmpty(string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
    static string FirstCharUpper(string value)
    {
        return char.ToUpper(value[0]) + value.Substring(1).ToLower();
    }
    

}
