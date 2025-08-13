// TODO: define the 'AccountType' enum
using System.Globalization;

enum AccountType
{
    Guest,
    User,
    Moderator
    
}


// TODO: define the 'Permission' enum
// se asignan potencias de dos para que cada valor represente un bit único. Para luego ser combinablaes y comparables con | &, etc
[Flags]
enum Permission
{
    //Operador << desplaza los bits de un número hacia la izquierda una cierta cantidad de posiciones.
    None   = 0,        // 0000
    Read   = 1 << 0,   // 0001 = 1
    Write  = 1 << 1,   // 0010 = 2
    Delete = 1 << 2,   // 0100 = 4
    All    = Read | Write | Delete // 0111 = 7
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        if(accountType == AccountType.Guest)
        {
            return Permission.Read;

        }else if(accountType == AccountType.User)
        {
            return Permission.Read | Permission.Write;

        }else if(accountType == AccountType.Moderator)
        {
            return Permission.Read | Permission.Write | Permission.Delete;
        }else
        {
            return Permission.None;
        }
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        if(current == Permission.None || current == grant)
        {
            return grant;

        }else
        {
            return current | grant;
        }

    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        //El operador & se queda solo con los bits que están a 1 en ambos operandos. Aplica un AND bit a bit
        //El ~ delante de revoke hace que se inviertan los bits. Los que son 1 pasan a ser 0 y vicerversa
        //Al pasarle el & te quedas solo con los permisos
        return current & ~revoke;
    }

    public static bool Check(Permission current, Permission check)
    {
        return (current & check) == check;     
    }
}
