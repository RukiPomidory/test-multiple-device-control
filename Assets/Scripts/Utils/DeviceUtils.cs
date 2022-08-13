using System;

namespace Utils
{
    public static class DeviceUtils
    {
        private static double startTime;

        static DeviceUtils()
        {
            startTime = Time();
        }

        public static double Time()
        {
            var totalMilliseconds = TimeSpan.FromTicks(DateTime.Now.Ticks).TotalMilliseconds;
            var seconds = totalMilliseconds / 1000;

            return seconds;
        }
        
        public static float LocalTime()
        {
            var localTime = Time() - startTime;

            return (float) localTime;
        }

        public static int GetTaskDeltaMilliseconds()
        {
            // 10 мс для 100 фпс внутри тасков
            return 10;
        }
    }
}