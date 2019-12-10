using System;
using System.Linq;
using System.Text;

namespace BerlinClock.Classes
{
    internal class Minutes
    {        
        private static readonly Int32 totalCharactersInMinutesLine1 = 11;
        private static readonly Int32 fiveMinutes = 5;
        private const string zeroLight = "OOOO", oneLight = "YOOO", twoLights = "YYOO", threeLights = "YYYO", fourLights = "YYYY";
        internal static StringBuilder FiveMinutesRow(Int32 totalMinutes)
        {
            Int32 numberOfFiveMinutes = totalMinutes / fiveMinutes;
            StringBuilder fiveMinutesRow = new StringBuilder();
            for (Int32 i = 1; i <= numberOfFiveMinutes; i++)
            {
                fiveMinutesRow.Append(i % 3 == (Int32) Values.Zero ? (char)LightStatus.Red : (char)LightStatus.Yellow);
            }
            Int32 paddingEmptyCharactersCount = totalCharactersInMinutesLine1 - fiveMinutesRow.ToString().Count();
            while (paddingEmptyCharactersCount > 0)
            {
                fiveMinutesRow.Append((char)LightStatus.Orange);
                paddingEmptyCharactersCount--;
            }
            fiveMinutesRow.Append(Environment.NewLine);
            return fiveMinutesRow;
        }
        internal static StringBuilder OneMinutesRow(Int32 totalMinutes)
        {
            StringBuilder OneMinutesRow = new StringBuilder();
            OneMinutesRow.Append((totalMinutes % fiveMinutes == (Int32) Values.Zero) ? zeroLight : (totalMinutes % fiveMinutes == (Int32)Values.One) ? oneLight 
                                                : (totalMinutes % fiveMinutes == (Int32)Values.Two) ? twoLights : (totalMinutes % fiveMinutes == (Int32)Values.Three) ? threeLights 
                                                : (totalMinutes % fiveMinutes == (Int32)Values.Four) ? fourLights : string.Empty);            
            return OneMinutesRow;
        }
    }
}