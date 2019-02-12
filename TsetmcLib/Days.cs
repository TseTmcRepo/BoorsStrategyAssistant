namespace TsetmcLib
{
    public class Days
    {

        public int TodayInt { get; internal set; }
        public int Yesterday { get; internal set; }
        public int TwoDaysAgo { get; internal set; }

        public override bool Equals(object obj)
        {
            var days = obj as Days;
            return days != null &&
                   TodayInt == days.TodayInt &&
                   Yesterday == days.Yesterday &&
                   TwoDaysAgo == days.TwoDaysAgo;
        }

        public override int GetHashCode()
        {
            var hashCode = 480274905;
            hashCode = hashCode * -1521134295 + TodayInt.GetHashCode();
            hashCode = hashCode * -1521134295 + Yesterday.GetHashCode();
            hashCode = hashCode * -1521134295 + TwoDaysAgo.GetHashCode();
            return hashCode;
        }
    }
}