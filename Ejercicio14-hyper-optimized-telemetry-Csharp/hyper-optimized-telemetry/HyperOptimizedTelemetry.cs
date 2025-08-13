using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9]; 
        byte[] numberInBytes = BitConverter.GetBytes(reading);
        
        int _prefixBytes = 0;
        int significantByteCount = 0;
        /*
        tiene que ser (long)uint.MaxValue+1, por que uint.MaxValue se evalua como intt y al sumarle +1 estamos desbordando el tipo de dato
        */
        if(((reading >= (long)uint.MaxValue+1) && (reading <= long.MaxValue)) || 
            ((reading >= long.MinValue) && (reading <= (long)int.MinValue-1)))
        {
            _prefixBytes = 256 - sizeof(long);
            significantByteCount = sizeof(long);

        }else if((reading >= (long)int.MaxValue+1) && (reading <= uint.MaxValue))
        {
            _prefixBytes = sizeof(uint);
            significantByteCount = sizeof(uint);
            
        
        }else if(((reading >= (long)ushort.MaxValue+1) && (reading <= int.MaxValue)) ||
            ((reading >= int.MinValue) && (reading <= (long)short.MinValue-1)))
        {
            _prefixBytes = 256 - sizeof(int);
             significantByteCount = sizeof(int);

        }else if((reading >= 0) && (reading <= ushort.MaxValue))
        {
            _prefixBytes = sizeof(ushort);
             significantByteCount = sizeof(ushort);
        
        }else if((reading >= short.MinValue) && (reading <= -1))
        {
            _prefixBytes = 256 - sizeof(short);
             significantByteCount = sizeof(short);

        }

        buffer[0] = (byte)_prefixBytes;
        /* Esto no funciona para los negativos. En binario los negativos se hacen con complemento a dos,que te rellena los bytes con 0xFF en vez de 0
        for(int i = 0; i < numberInBytes.Length; i++)
        {
            buffer[i+1] = numberInBytes[i];
        }
        */

        for(int i=0; i < significantByteCount; i++)
        {
            buffer[i+1] = numberInBytes[i];
        }

        return buffer;


    }

    public static long FromBuffer(byte[] buffer)
    {
        if(buffer[0] == 256-sizeof(short)) 
        {
            return BitConverter.ToInt16(buffer, 1);

        }else if(buffer[0] == sizeof(ushort))
        {
            return BitConverter.ToUInt16(buffer, 1);

        }else if(buffer[0] == 256 -sizeof(int))
        {
            return BitConverter.ToInt32(buffer, 1);

        }else if(buffer[0] == sizeof(uint)){
            return BitConverter.ToUInt32(buffer, 1);

        }else if(buffer[0] == 256 - sizeof(long))
        {
            return BitConverter.ToInt64(buffer, 1);
        }else
            return 0;

        


    }
}
