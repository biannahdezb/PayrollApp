using System;

namespace payroll.Validators;
public static class CedulaValidator
{
    public static bool IsValidCedula(string cedula)
    {
        // Variable declaration
        int verifier = 0;
        int digit = 0;
        int verifierDigit = 0;
        int oddDigit = 0;
        int evenSum = 0;
        int oddSum = 0;
        int length = cedula.Length;

        // Error control
        try
        {
            // Check that the length of the parameter is 11
            if (length == 11)
            {
                verifierDigit = Convert.ToInt32(cedula.Substring(10, 1));

                // Loop through each digit of the cedula
                for (int i = 9; i >= 0; i--)
                {
                    digit = Convert.ToInt32(cedula.Substring(i, 1));

                    // If the digit is odd, multiply by 2
                    if ((i % 2) != 0)
                    {
                        oddDigit = digit * 2;

                        // If the resulting digit is greater than 10, subtract 9
                        if (oddDigit >= 10)
                        {
                            oddDigit -= 9;
                        }

                        oddSum += oddDigit;
                    }
                    else
                    {
                        evenSum += digit;
                    }
                }

                // Obtain the verifier by subtracting 10 from the modulo 10 of the total sum of digits
                verifier = 10 - ((evenSum + oddSum) % 10);

                // If the verifier is 10 and the verifier digit is zero, or the verifier and verifier digit are equal, return true
                if ((verifier == 10 && verifierDigit == 0) || (verifier == verifierDigit))
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine("La cedula debe contener (11) digits");
            }
        }
        catch
        {
            Console.WriteLine("La cedula no pudo ser validada");
        }

        return false;
    }
}
