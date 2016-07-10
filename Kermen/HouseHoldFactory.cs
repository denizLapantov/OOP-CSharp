using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kermen
{
    public class HouseHoldFactory
    {
        public static HouseHold CreatehHouseHold(string input)
        {
            string pattern = @"(\D+)\(([\d\s\,\.]+)\)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            if (regex.IsMatch(input))
            {
                string houseHoldType = matches[0].Groups[1].Value;
                if (houseHoldType == "YoungCouple")
                {
                    decimal[] salaries =
                        matches[0].Groups[2].Value.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(decimal.Parse)
                            .ToArray();
                    decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                    decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                    decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);

                    return new YoungCouple(salaries[0],salaries[1],tvCost,fridgeCost,laptopCost);
                }
                if (houseHoldType == "YoungCoupleWithChildren")
                {
                    decimal[] salaries =
                       matches[0].Groups[2].Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(decimal.Parse)
                           .ToArray();
                    decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                    decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                    decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);
                    Child[] children = new Child[matches.Count - 4];
                    for (int i = 4; i < matches.Count; i++)
                    {
                        decimal[] consumption =
                   matches[i].Groups[2].Value.Split(new char[] { ',',' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(decimal.Parse)
                       .ToArray();

                        children[i - 4 ] = new Child(consumption);
                    }
                    return  new YoungCoupleWithChildren(salaries[0],salaries[1],tvCost,fridgeCost,laptopCost, children);

                }
                if (houseHoldType == "OldCouple")
                {

                    decimal[] pensions =
                       matches[0].Groups[2].Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(decimal.Parse)
                           .ToArray();
                    decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                    decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                    decimal stove = decimal.Parse(matches[3].Groups[2].Value);

                    return new OldCouple(pensions[0],pensions[1],tvCost,fridgeCost,stove);
                }
                if (houseHoldType == "AloneYoung")
                {
                    decimal salary = decimal.Parse(matches[0].Groups[2].Value);
                    decimal laptopCost = decimal.Parse(matches[1].Groups[2].Value);

                    return  new AloneYoung(salary,laptopCost);

                }
                if (houseHoldType == "AloneOld")
                {
                    decimal pension = decimal.Parse(matches[0].Groups[2].Value);

                    return new AloneOld(pension);
                }
                else
                {
                    throw new ArgumentException();
                }


            }
            throw new ArgumentException();
        }
    }
}
