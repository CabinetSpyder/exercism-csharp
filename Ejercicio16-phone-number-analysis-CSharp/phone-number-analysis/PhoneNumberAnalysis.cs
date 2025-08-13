public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        (bool fromNewYork, bool fakeNumber, string localDigits) phoneNumberInfo;
        //Separar los numeros en tres.
        string[] phoneNumberParts = phoneNumber.Split("-", StringSplitOptions.None);
        if(phoneNumberParts[0] == "212"){
            phoneNumberInfo.fromNewYork = true;
        }else
        {
            phoneNumberInfo.fromNewYork = false;
        }

        if(phoneNumberParts[1] == "555")
        {
            phoneNumberInfo.fakeNumber = true;
        }else
        {
            phoneNumberInfo.fakeNumber = false;
        }

        phoneNumberInfo.localDigits = phoneNumberParts[2];

        return phoneNumberInfo;
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;        
    }
}
