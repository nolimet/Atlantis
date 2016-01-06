using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class _Debug : MonoBehaviour
{
    #region Statics
    public static Level LogLevel = Level.Trace;
    private static bool createdDebuger;
    public static Profile currentUser = Profile.Jesse;

    /// <summary>
    /// Log leves that are currently defined and available
    /// </summary>
    /// When adding a new level
    /// Please keep the order in mind. It decides what will show when a certain level is selected
    public enum Level
    {
        Trace = 0,
        Info = 1,
        Debug = 2,
        Warn = 3,
        Error = 4
    };

    /// <summary>
    /// User profiles that are available
    /// System is alway visable
    /// </summary>
    public enum Profile
    {
        Jesse,
        Jochin,
        Ilona,
        System //system will always show
    };

    /// <summary>
    /// Log an event. You can set your profile in the editor
    /// </summary>
    /// <param name="context">Object you are logging in. Just use this</param>
    /// <param name="Message">The message you want to pass</param>
    /// <param name="level">The level you want to log on</param>
    /// <param name="user">The user that is wanting the see tye log</param>
    public static void Log(Object context, object Message, Level level = Level.Info, Profile user = Profile.System)
    {
        string output;
        if (user == Profile.System)
            output = "[System]";
        else
            output = "[" + currentUser.ToString() + "]";

        if (!((int)level >= (int)LogLevel && (user == currentUser | user == Profile.System)))
        {
            return;
        }

        switch (level)
        {
            case Level.Trace:
                output += "<color=green>[Trace] ";
                output += "[at: " + context.ToString() + "] ";
                output += Message;
                output += "</color>";
                Debug.Log(output, context);
                break;

            case Level.Info:
                output += "<color=cyan>[Info] ";
                output += "[at: " + context.ToString() + "] ";
                output += Message;
                output += "</color>";
                Debug.Log(output, context); 
                break;

            case Level.Debug:
                output += "<color=brown>[Debug] ";
                output += "[at: " + context.ToString() + "] ";
                output += Message;
                output += "</color>";
                Debug.Log(output, context);
                break;

            case Level.Warn:
                output += "<color=orange>[Warning] ";
                output += "[at: " + context.ToString() + "] ";
                output += Message;
                output += "</color>";
                Debug.LogWarning(output, context);
                break;

            case Level.Error:
                output += "<color=red>[Error] ";
                output += "[at: " + context.ToString() + "] ";
                output += Message;
                output += "</color>";
                Debug.LogError(output, context);
                break;
        }
    }

    #region QuickProfileLogs
    /// <summary>
    /// Log as Jesse
    /// </summary>
    /// <param name="context">Object you are logging in. Just use this</param>
    /// <param name="Message">The message you want to pass</param>
    /// <param name="level">The level you want to log on</param>
    public static void NLog(Object context, object Message, Level level = Level.Info)
    {
        Log(context, Message, level, Profile.Jesse);
    }

    /// <summary>
    /// Log as Jochin
    /// </summary>
    /// <param name="context">Object you are logging in. Just use this</param>
    /// <param name="Message">The message you want to pass</param>
    /// <param name="level">The level you want to log on</param>
    public static void JLog(Object context, object Message, Level level = Level.Info)
    {
        Log(context, Message, level, Profile.Jochin);
    }

    /// <summary>
    /// Log as Ilona
    /// </summary>
    /// <param name="context">Object you are logging in. Just use this</param>
    /// <param name="Message">The message you want to pass</param>
    /// <param name="level">The level you want to log on</param>
    public static void ILog(Object context, object Message, Level level = Level.Info)
    {
        Log(context, Message, level, Profile.Ilona);
    }
    #endregion
    #endregion

    #region public
    public _Debug.Level NewLevel;
    public _Debug.Profile NewProfile;

    void Start()
    {
        if (createdDebuger)
        {
            Destroy(this.gameObject);
        }
        else
        {
            createdDebuger = true;
            Object.DontDestroyOnLoad(this);
            Log(this, "Custom Debug Started for " + NewProfile.ToString() + " on level " + NewLevel.ToString(), Level.Debug, Profile.System);

            LogLevel = NewLevel;
            currentUser = NewProfile;
        #if UNITY_EDITOR
            Application.runInBackground = true;
        #endif
        }
    }
    #endregion

    #region Custom Inspector
    #if UNITY_EDITOR
    [CustomEditor(typeof(_Debug))]
    public class CustomDebugEditor : Editor
    {        
        public override void OnInspectorGUI()
        {
            _Debug t = (_Debug)target;

            t.NewLevel = (_Debug.Level)EditorGUILayout.EnumPopup("Log Level", t.NewLevel);
            t.NewProfile = (_Debug.Profile)EditorGUILayout.EnumPopup("Current User", t.NewProfile);

            EditorUtility.SetDirty(t);
        }
    }
#endif
    #endregion
}
