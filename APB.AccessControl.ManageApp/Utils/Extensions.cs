using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APB.AccessControl.ManageApp.Utils
{
    internal static class Extensions
    {
        internal static string ToMaskedPan(this string pan)
        {
            if (string.IsNullOrEmpty(pan))
                return string.Empty;
            // Маскируем PAN - показываем только первые 4 и последние 4 цифры
            string maskedPan = pan;
            if (maskedPan.Length == 16) // стандартный размер номера карты
            {
                maskedPan = $"{maskedPan.Substring(0, 4)}********{maskedPan.Substring(12, 4)}";
            }
            else if (maskedPan.Length > 8) // если длина достаточна для маскирования
            {
                int firstPart = 4;
                int lastPart = 4;
                int middlePart = maskedPan.Length - firstPart - lastPart;

                if (middlePart < 0) // если номер карты слишком короткий
                {
                    lastPart = maskedPan.Length - firstPart;
                    if (lastPart < 0)
                    {
                        firstPart = maskedPan.Length;
                        lastPart = 0;
                    }
                }

                maskedPan = $"{maskedPan.Substring(0, firstPart)}";
                if (middlePart > 0)
                    maskedPan += new string('*', middlePart);
                if (lastPart > 0)
                    maskedPan += pan.Substring(pan.Length - lastPart, lastPart);
            }

            return maskedPan;
        }
    }
}
