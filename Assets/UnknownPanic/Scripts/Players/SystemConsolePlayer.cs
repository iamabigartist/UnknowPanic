using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnknownPanic.Players
{
    [Flags]
    public enum Accessor
    {
        A, B, C
    }

    public class SystemConsoleLog
    {
        public string text;
        public Accessor access_authority;
        public SystemConsoleLog(string text, Accessor access_authority)
        {
            this.text = text;
            this.access_authority = access_authority;
        }
    }

    public class SystemConsolePlayer : MonoBehaviour
    {
    #region State

        public List<SystemConsoleLog> history_logs;

    #endregion

    #region Reference

        InputField m_inputField;

    #endregion

    #region Utils

        public Action<string> onSubmitInput;

    #endregion
        void Start()
        {
            m_inputField = GetComponentInChildren<InputField>();
            m_inputField.onEndEdit.AddListener( (str) =>
            {
                if (Input.GetKeyDown( KeyCode.KeypadEnter ) || Input.GetKeyDown( KeyCode.Return ))
                {
                    onSubmitInput?.Invoke( m_inputField.text );
                }
            } );
        }

        void Update()
        {

        }
    }
}
