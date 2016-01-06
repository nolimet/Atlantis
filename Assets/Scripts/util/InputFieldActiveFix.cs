using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class InputFieldActiveFix : MonoBehaviour
{
    public delegate void VoidDelegate();
    public event VoidDelegate onEditEnd;
    public event VoidDelegate onValueChanged;
    public event VoidDelegate onClearField;

    [SerializeField]
    UnityEngine.UI.InputField Inputfield;

    string _text = "";

    /// <summary>
    /// Set's text in inputfield and the backupValue
    /// Gets retuns value of backupValue
    /// </summary>
    public string text
    {
        get { return _text; }
        set { _text = value; Inputfield.text = value; }
    }
    
    void Start()
    {
        if (!Inputfield)
            Inputfield = GetComponent<UnityEngine.UI.InputField>();

        Inputfield.onValueChanged.RemoveAllListeners();
        Inputfield.onValueChanged.AddListener(delegate { this.Inputfield_onValueChanged(); });

        Inputfield.onEndEdit.AddListener(delegate { this.Inputfield_OnEditEnd(); });
    }

    /// <summary>
    /// clears the inputfield and makes sure it does not get reset
    /// Then call onClearField when it's cleared
    /// </summary>
    public void ClearField()
    {
        _text = "";
        Inputfield.text = "";
        if (onClearField != null)
        {
            onClearField();
        }
    }

    /// <summary>
    /// Should not becalled from script
    /// Checks if the inputfield not changed completely
    /// if it did it resets it to _text
    /// It finaly calls onValueChanged;
    /// </summary>
    public void Inputfield_onValueChanged()
    {
        if ((Inputfield.text.Length - _text.Length) > 0 || (Inputfield.text.Length - _text.Length) == -1)
        {
            _text = Inputfield.text;
        }
        else
        {
            if (Inputfield.text != _text)
            {
                int NumberDiffs = 0;
                if (Inputfield.text.Length == _text.Length)
                {
                    for (int i = 0; i < Inputfield.text.Length; i++)
                    {
                        if (Inputfield.text[i] != _text[i])
                        {
                            NumberDiffs++;
                        }
                    }
                }

                if (NumberDiffs != (0 | 1))
                {
                    Inputfield.text = _text;
                }
            }
        }
        if (onValueChanged != null)
        {
            onValueChanged();
        }
    }

    /// <summary>
    /// Should not becalled from script
    /// makes sure inputfield.text is the same as _text
    /// It then calls onEditEnd Event
    /// </summary>
    public void Inputfield_OnEditEnd()
    {
        Inputfield.text = _text;

        if (onEditEnd != null)
        {
            onEditEnd();
        }
    }

}

