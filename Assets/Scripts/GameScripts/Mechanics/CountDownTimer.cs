using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace game.mechanics
{
    public class CountDownTimer : BaseBehaviour
    {
        public event ValueClasses.VoidDelegate onTimerDone;


        [Tooltip("in seconds")]
        public int timerLenght;
        System.DateTime counter;

        public Text visualDisplay;

        bool timerDone;
        bool firedEvent;

        protected override void Start()
        {
            counter = System.DateTime.Now;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            StartSecondThreadUpdate();
        }

        public override void MainUpdate()
        {
            visualDisplay.text = formatCounter();
            if(timerDone&& !firedEvent)
            {
                firedEvent = true;
                if (onTimerDone != null)
                    onTimerDone();
            }
        }

        public override void SecondaryThreadUpdate()
        {
            if (((System.DateTime.Now - counter) - ScriptManager.PausedTime).TotalSeconds > timerLenght) 
                timerDone = true;
        }

        System.TimeSpan tm;
        int mili;
        string formatCounter()
        {
            tm = (new System.TimeSpan(0, 0, timerLenght) - (System.DateTime.Now - counter) - ScriptManager.PausedTime);

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
            else
                output += "00 : ";

            if (tm.Seconds > 0)
            {
                if (tm.Seconds < 10)
                    output += "0";

                output += tm.Seconds;
                output += " : ";
            }
            else
                output += "00 : ";

            if(tm.Milliseconds > 0)
            {
                mili = tm.Milliseconds;
                mili /= 10;
                if (mili < 10)
                    output += "0";

                output += mili;

            }

            return output;
        }
    }
}
