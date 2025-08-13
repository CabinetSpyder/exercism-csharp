using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        if(shiftKey < 0 || shiftKey > 26)
        {
            Console.Write("Hola");
            return "";
        }

        var str_encoded = new StringBuilder();
        int aux = 0;
     
        foreach(char ch in text){
            if(ch >= 'a' && ch <= 'z') //Encoding lower case
            {
                if(ch + shiftKey <= 'z')
                { 
                    str_encoded.Append((char)(ch + shiftKey));

                }else
                {
                    aux = (ch + shiftKey) - 'z'; 
                    str_encoded.Append((char)('a' + aux -1));
                }
                
                
            }else if(ch >= 'A' && ch <= 'Z') //Encoding lower case
            {
                if(ch + shiftKey <= 'Z')
                { 
                    str_encoded.Append((char)(ch + shiftKey));

                }else
                {
                    aux = (ch + shiftKey) - 'Z'; 
                    str_encoded.Append((char)('A' + aux -1));
                }
                
                
            }else
            {
                str_encoded.Append(ch); //Epacios, signos de puntuacion, numeros
            }
        }

        return str_encoded.ToString();

    }
}