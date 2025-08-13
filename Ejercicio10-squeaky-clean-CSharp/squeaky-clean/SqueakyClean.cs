using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var sb = new StringBuilder();
        bool kebab = false;
        
        foreach(char ch in identifier){
            if(ch == ' '){
                sb.Append('_');

            }else if(char.IsControl(ch)){
                sb.Append("CTRL");

            }else if(ch == '-'){
                kebab = true;

            }else if(!char.IsLetter(ch) || (ch >= 'α' && ch <= 'ω')){
                continue;
                
            }else{
                if(kebab){
                    sb.Append(char.ToUpper(ch));
                    kebab = false;
                }else{
                    sb.Append(ch);
                }
                
            }
        }

        return sb.ToString();


    }
}
