static class LogLine
{
    public static string Message(string logLine)
    {
        // Divide en dos partes por ": "
        //string[] partes = logLine.Split(new string[] ": " , StringSplitOptions.None);
        //return partes[1];
        
        //Encuentra donde esta : y el espacio y se queda con lo que viene despues
        int pos = logLine.IndexOf(": ");
        return logLine.Substring(pos + 2).Trim();
    }

    public static string LogLevel(string logLine)
    {
        // Divide en dos partes por ": "
        //string[] partes = logLine.Split(new string[] ": " , StringSplitOptions.None);
        //en partes[0] => [WARNING]
        //return partes.Trim('[', ']').ToLower(); // "warning"

        int pos = logLine.IndexOf(']');
        return logLine.Substring(1, pos-1).ToLower(); //Te quitas el []
    }

    public static string Reformat(string logLine)
    {
        string message = Message(logLine);
        string level = LogLevel(logLine);
        return message + " (" + level + ')';        
    }
}
