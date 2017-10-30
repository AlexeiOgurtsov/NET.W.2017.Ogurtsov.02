using System;

namespace LogicInsertNumber
{
    public static class Insert
    {
        /// <summary>
        /// Takes bits from <paramref name="number2"/> and inserts them into <paramref name="number1"/> to positions from <paramref name="startPosition"/> to <paramref name="endPosition"/>.
        /// </summary>
        /// <param name="number1">32-bit number, which accepts insertion</param>
        /// <param name="number2">32-bit number, which is being inserted</param>
        /// <param name="startPosition"><paramref name="number1"/> position from which insertion starts</param>
        /// <param name="endPosition"><paramref name="number1"/> position at which insertion ends</param>
        /// <returns>result of insertion</returns>
        public static int InsertNumber(int number1, int number2, byte startPosition, byte endPosition)
        {
            const byte BITS = sizeof(int) * 8;

            #region arguments validation
            if (endPosition >= BITS || startPosition > BITS)
            {
                throw new ArgumentOutOfRangeException($"Number of bit position must be less than {BITS}.");
            }

            if (startPosition > endPosition)
            {
                throw new ArgumentException("Start position cannot be greater than end position.");
            }
            #endregion

            var mask = (2 << endPosition - startPosition) - 1 << startPosition;
            return ~mask & number1 | number2 << startPosition & mask;

        }
    }
}
