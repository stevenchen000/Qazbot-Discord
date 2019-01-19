using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.TenYears
{
    public class TenYears
    {

        public static string TenYearsAgo(string name, string action) {
            string result = $"{name} {action} exactly 10 years 3 months";
            int weeks = ModuleHandler.rand.Next() % 4;
            int days = ModuleHandler.rand.Next() % 7;
            int hours = ModuleHandler.rand.Next() % 24;
            int minutes = ModuleHandler.rand.Next() % 60;
            int seconds = ModuleHandler.rand.Next() % 60;

            if (weeks > 0) {
                result += $" {weeks} weeks";
            }

            if (days > 0) {
                result += $" {days} days";
            }

            if (hours > 0) {
                result += $" {hours} hours";
            }

            if (minutes > 0) {
                result += $" {minutes} minutes";
            }

            if(seconds > 0)
            {
                result += $" {seconds} seconds";
            }

            result += " ago!";

            return result;
        }

    }
}
