using UnityEngine;
using System.Collections;

namespace util
{
    public static class StringUtils
    {
        /// <summary>
        /// Convects Seconds to Minutes and second formated into a string
        /// </summary>
        /// <param name="length">Seconds there will be</param>
        /// <returns>formated string in mm:ss</returns>
        public static string timeString(int length)
        {
            int m = length / 60;
            int s = length % 60;
            string strS, strM;
            if (s < 10)
                strS = "0" + s;
            else
                strS = s.ToString();
            if (m < 10)
                strM = "0" + m;
            else
                strM = m.ToString();

            return strM + ":" + strS;
        }
    }
}