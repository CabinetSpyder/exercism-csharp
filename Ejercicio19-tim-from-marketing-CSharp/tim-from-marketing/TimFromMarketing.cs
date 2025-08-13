static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string? idString = null;
        string tag;
        string? dp = null;

        if(id != null)
        {
            idString = "[" + id.ToString() + "] - ";
        }

        if(department != null){
            dp =  " - " + department.ToUpper();
        }else{
            dp = " - OWNER";  
        }

        tag = idString + name + dp;        

        return tag;
    }
}
