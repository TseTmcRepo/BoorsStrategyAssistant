using System;
using System.Collections.Generic;

namespace TsetmcLib
{
    public class ActiveDate
    {
        public string DEven { get; set; }
        public string NSCEnd { get; set; }

        public override bool Equals(object obj)
        {
            var date = obj as ActiveDate;
            return date != null &&
                   DEven == date.DEven &&
                   NSCEnd == date.NSCEnd;
        }

        public override int GetHashCode()
        {
            var hashCode = 1504641299;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DEven);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NSCEnd);
            return hashCode;
        }
    }
}
