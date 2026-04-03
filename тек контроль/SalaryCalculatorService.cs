using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator
{
    public class SalaryCalculatorService
    {
        /// <summary>
        /// Вычисляет заработную плату преподавателя
        /// </summary>
        /// <param name="hours">Количество часов</param>
        /// <param name="position">Должность ("ассистент", "доцент", "профессор")</param>
        /// <param name="applyTax">Применять ли подоходный налог 13%</param>
        /// <returns>Кортеж (Начислено всего, Сумма налога)</returns>
        public (double Gross, double Tax) CalculateSalary(double hours, string position, bool applyTax)
        {
            double rate;

            // Определяем почасовую ставку через if-else
            if (position == "ассистент")
            {
                rate = 150;
            }
            else if (position == "доцент")
            {
                rate = 250;
            }
            else if (position == "профессор")
            {
                rate = 350;
            }
            else
            {
                throw new ArgumentException("Неизвестная должность преподавателя. Допустимые значения: ассистент, доцент, профессор.");
            }

            // Начисленная сумма
            double gross = hours * rate;

            // Подоходный налог
            double tax = applyTax ? gross * 0.13 : 0;

            return (gross, tax);
        }
    }
}
