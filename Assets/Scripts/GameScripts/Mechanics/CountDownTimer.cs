using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace game.mechanics
{
    public class CountDownTimer : BaseBehaviour
    {
        [Tooltip("in seconds")]
        public int timerLenght;
        System.DateTime counter;

        public Text visualDisplay;

        bool timerDone;

        protected override void Start()
        {
            counter = System.DateTime.Now;
            startMainThreadUpdate();
            StartSecondThreadUpdate();
        }

        public override void MainUpdate()
        {
            visualDisplay.text = formatCounter();
        }

        public override void SecondaryThreadUpdate()
        {
            if ((System.DateTime.Now - counter).TotalSeconds > timerLenght)
                timerDone = true;
        }

        System.TimeSpan tm;
        string formatCounter()
        {
            tm = (new System.TimeSpan(0, 0, timerLenght) - (System.DateTime.Now - counter));
            string output = "";
            if (tm.Hours > 0)
            {
                if (tm.Hours < 10)
                    output += "0";

                output += tm.Hours;
                output += " : ";
            }

            if (tm.Minutes > 0)
            {
                if (tm.Minutes < 10)
                    output += "0";

                output += tm.Minutes;
                output += " : ";
            }

            if (tm.Seconds > 0)
            {
                if (tm.Seconds < 10)
                    output += "0";

                output += tm.Seconds;
            }


            return output;
        }
    }
}
