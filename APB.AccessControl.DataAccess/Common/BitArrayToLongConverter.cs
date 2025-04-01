using System.Collections;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APB.AccessControl.DataAccess.Common
{
    public class BitArrayToLongConverter : ValueConverter<BitArray, ulong>
    {
        public BitArrayToLongConverter()
            : base(
                bitArray => BitArrayToLong(bitArray),
                number => LongToBitArray(number, 7)) 
        { }

        private static ulong BitArrayToLong(BitArray bitArray)
        {
            if (bitArray == null || bitArray.Length == 0) return 0;

            ulong value = 0;
            for (int i = 0; i < bitArray.Length && i < 64; i++)
            {
                if (bitArray[i])
                    value |= 1UL << i;
            }
            return value;
        }

        private static BitArray LongToBitArray(ulong value, int bitCount)
        {
            BitArray bitArray = new BitArray(bitCount);
            for (int i = 0; i < bitCount; i++)
            {
                bitArray[i] = (value & (1UL << i)) != 0;
            }
            return bitArray;
        }
    }
}