using BerlinClock.Classes;
using System;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private const char delimiter = ':';
        private Int32 totalHours;
        private Int32 totalMinutes;
        private Int32 totalSeconds;
        private StringBuilder berlinClockBuilder;
        private const Int32 fiveHours = 5;
        private static readonly string zeroLight = "OOOO", oneLight = "ROOO", twoLights = "RROO", threeLights = "RRRO", fourLights = "RRRR";
        public TimeConverter()
        {
            berlinClockBuilder = new StringBuilder();
        }
        public string convertTime(string time)
        {
            parseTime(time);
            SecondsRow();
            FiveHoursRow();
            OneHoursRow();
            berlinClockBuilder.Append(Minutes.FiveMinutesRow(totalMinutes));
            berlinClockBuilder.Append(Minutes.OneMinutesRow(totalMinutes));
            return Convert.ToString(berlinClockBuilder);
        }

        private void parseTime(string inputTime)
        {
            string[] splitTime = inputTime.Split(new char[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
            Int32.TryParse(splitTime[0], out totalHours);
            Int32.TryParse(splitTime[1], out totalMinutes);
            Int32.TryParse(splitTime[2], out totalSeconds);
        }

        private void SecondsRow()
        {
            berlinClockBuilder.Append(totalSeconds % 2 == 0 ? (char) LightStatus.Yellow : (char) LightStatus.Orange);
            berlinClockBuilder.Append(Environment.NewLine);
        }

        private void FiveHoursRow()
        {
            berlinClockBuilder.Append((totalHours / fiveHours == (Int32) Values.Zero) ? zeroLight : (totalHours / fiveHours == (Int32) Values.One) ? oneLight 
                                        : (totalHours / fiveHours == (Int32) Values.Two) ? twoLights : (totalHours / fiveHours == (Int32) Values.Three) ? threeLights 
                                        : (totalHours / fiveHours == (Int32) Values.Four) ? fourLights : string.Empty);
            berlinClockBuilder.Append(Environment.NewLine);
        }
        private void OneHoursRow()
        {
            berlinClockBuilder.Append((totalHours % fiveHours == (Int32)Values.Zero) ? zeroLight : (totalHours % fiveHours == (Int32)Values.One) ? oneLight 
                                : (totalHours % fiveHours == (Int32)Values.Two) ? twoLights: (totalHours % fiveHours == (Int32)Values.Three) ? threeLights 
                                : (totalHours % fiveHours == (Int32)Values.Four) ? fourLights : string.Empty);
            berlinClockBuilder.Append(Environment.NewLine);
        }
    }
}