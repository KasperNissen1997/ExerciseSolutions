namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static string Shift(this string s, int n)
        {
            if (string.IsNullOrEmpty(s))
                return "";

            char[] sArray = s.ToCharArray();

            for (int i = 0; i < s.Length; i++)
            {
                int targetIndex = (i + n) % s.Length;

                if (targetIndex < 0)
                    targetIndex += s.Length;

                sArray[targetIndex] = s[i];
            }

            return new string(sArray);
        }

        public static int Age(this DateTime startDT, DateTime refDT)
        {
            int age = refDT.Year - startDT.Year;

            // edge case
            bool isStartDTEndOfFebruaryInLeapYear = startDT.Month == 2 && startDT.Day == 29;
            bool isRefDateEndOfFebruaryInNormalYear = refDT.Month == 2 && refDT.Day == 28;

            if (isStartDTEndOfFebruaryInLeapYear && isRefDateEndOfFebruaryInNormalYear)
                age--;


            if (age < 0)
                age = 0;

            return age;
        }
    }
}
