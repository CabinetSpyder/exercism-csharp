public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return new Dictionary<int, string>{};        
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {

        Dictionary<int, string> prefixes = new Dictionary<int, string>
        {
        {1, "United States of America"},
        {55, "Brazil"},
        {91, "India"}
        };
        return prefixes;
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        var aux = new Dictionary<int, string>
        {
            {countryCode, countryName}
        };

        return aux;  
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;        
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if(existingDictionary.TryGetValue(countryCode, out string? value))
        {
            return value;
        }else
        {
            return "";
        }
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.ContainsKey(countryCode);
    }

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if(CheckCodeExists(existingDictionary, countryCode))
        {
            existingDictionary[countryCode] = countryName;
        }

        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if(CheckCodeExists(existingDictionary, countryCode))     
        {
            existingDictionary.Remove(countryCode);
        }

        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string longestCountryName = "";
               
        foreach(KeyValuePair<int, string> par in existingDictionary){
            if(longestCountryName.Length == 0){
                longestCountryName = par.Value;
            }

            if(par.Value.Length > longestCountryName.Length){
                longestCountryName = par.Value;
            }
        }

        return longestCountryName;
    }
}