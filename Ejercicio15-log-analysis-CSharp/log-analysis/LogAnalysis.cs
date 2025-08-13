public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string separator)
    {
        int pos = str.IndexOf(separator);
        return str.Substring(pos + separator.Length);
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string first, string second)
    {
        int pos1 = str.IndexOf(first) + first.Length;
        int pos2 = str.IndexOf(second);

        return str.Substring(pos1, pos2 - pos1);
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }


    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}