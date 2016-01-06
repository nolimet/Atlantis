using UnityEngine;
using System.Collections;

public class BaseBehaviour : MonoBehaviour
{

    //MainThreadDeltaTime;
    System.DateTime t;
    protected System.TimeSpan deltaTimeMain;

    //SecondaryThreadDeltaTime;
    System.DateTime t2;
    protected System.TimeSpan deltaTimeSecondary;

    private bool startedSecondThread;

    protected virtual void Start()
    {
        startMainThreadUpdate();
    }

    protected void CalcDeltaTimeMain()
    {
        deltaTimeMain = (t - System.DateTime.Now);
        t = System.DateTime.Now;
    }

    protected void CalcDeltaTimeSecondary()
    {
        deltaTimeSecondary = (t2 - System.DateTime.Now);
        t2 = System.DateTime.Now;
    }

    protected void startMainThreadUpdate()
    {
        ScriptManager.registerScriptMainThread(this);
    }

    protected void StartSecondThreadUpdate()
    {
        ScriptManager.registerScriptSecondaryThread(this);
        startedSecondThread = true;
    }

    protected void OnDestroy()
    {
        if (!Application.isPlaying)
            return;

        ScriptManager.unregisterScriptMainThread(this);
        if (startedSecondThread)
            ScriptManager.unregisterScriptSecondaryThread(this);
    }

    /// <summary>
    /// runs in the main thread of unity
    /// </summary>
    public virtual void MainUpdate()
    {

    }

    /// <summary>
    /// runs in a self managed thread so out side the main thread of unity
    /// </summary>
    public virtual void SecondaryThreadUpdate()
    {

    }
}
