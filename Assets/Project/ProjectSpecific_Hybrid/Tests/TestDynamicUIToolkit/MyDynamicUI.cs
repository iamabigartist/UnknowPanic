using System;
using UnityEngine;
using UnityEngine.UIElements;
namespace ProjectSpecific_Hybrid.Tests.TestDynamicUIToolkit
{

    public class SplinkLabel : Label
    {

        Color base_color;

        public void Registry(ref Action OnUpdate)
        {
            OnUpdate += Update;
        }

        public SplinkLabel(Color base_color, string text = "") : base( text )
        {
            this.base_color = base_color;
        }

        public void Update()
        {
            var lerp = (Mathf.Sin( Time.time ) + 1) / 2f;
            style.color = Color.Lerp( base_color, Color.white, lerp );
            style.fontSize = Mathf.Lerp( 20f, 30f, lerp );
        }
    }
    public class MyDynamicUI : MonoBehaviour
    {
        UIDocument document;
        event Action UpdateUIState;

        void InitUI()
        {
            var s_l = new SplinkLabel( Color.red, "szdvfgsedfsdf" );
            s_l.Registry( ref UpdateUIState );
            document.rootVisualElement.Add( s_l );
        }

        void Start()
        {
            document = GetComponent<UIDocument>();

            InitUI();
        }

        void Update()
        {
            UpdateUIState?.Invoke();
        }
    }
}
