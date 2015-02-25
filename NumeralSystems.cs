
using System;

class NumSystemConversion
{
    static string DecimalToBase(long decimalNum, int numeralSystem)
    {
        string result = string.Empty;
        while (decimalNum > 0)
        {
            long digit = decimalNum % numeralSystem;
            if (digit >= 0 && digit <= 9)
            {
                result = (char)(digit + '0') + result;
            }
            else
            {
                result = (char)(digit - 10 + 'A') + result;
            }
            decimalNum /= numeralSystem;
        }
        return result;
    }

    static long BaseToDecimal(string input, int numeralSystem)
    {
        long decimalNum = 0;
        for (int i = 0; i < input.Length; i++) 
        {
            int digit = 0;
            if (input[i] >= '0' && input[i] <= '9')
            {
                digit = input[i] - '0';
            }
            else
            {
                digit = input[i] - 'A' + 10;
            }
            decimalNum += digit * (long)Math.Pow(numeralSystem, input.Length - 1 - i);
        }
        return decimalNum;
    }

    //Hex-Bin-Hex direct conversion

    static string BinaryToHex(string binaryNum)
    {
        //fill number with zeroes so it's divisible by 4
        if (binaryNum.Length % 4 != 0)
        {
            binaryNum = binaryNum.PadLeft((binaryNum.Length + (4 - binaryNum.Length % 4)), '0');
        }
        string[] binArray = new string[binaryNum.Length / 4];
        //fill new array
        int index = 0, newIndex = 0;
        while (index + 4 <= binaryNum.Length)
        {
            binArray[newIndex] = binaryNum.Substring(index, 4);
            index += 4;
            newIndex++;
        }

        string[] binHexConvTable = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", 
                                       "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
        string[] hexBinConvTable = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        string hexResult = string.Empty;

        for (int i = 0; i < binArray.Length; i++)
        {
            for (int j = 0; j < binHexConvTable.Length; j++)
            {
                if (binArray[i] == binHexConvTable[j])
                {
                    hexResult = hexResult + hexBinConvTable[j];
                }
            }
        }
        return hexResult;
    }

    static string HexToBinary(string hexNum)
    {
        string hexResult = string.Empty;
        string[] binHexConvTable = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", 
                                       "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
        string[] hexBinConvTable = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

        for (int i = 0; i < hexNum.Length; i++)
        {
            for (int j = 0; j < hexBinConvTable.Length; j++)
            {
                if (Convert.ToString(hexNum[i]) == hexBinConvTable[j])
                {
                    hexResult = hexResult + binHexConvTable[j];
                }
            }
        }
        return hexResult;
    }

    static void Main()
    {
        //IO
    }
}