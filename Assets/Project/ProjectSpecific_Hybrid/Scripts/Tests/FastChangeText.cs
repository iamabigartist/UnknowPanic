using UnityEngine;
using UnityEngine.UI;
namespace ProjectSpecific_Hybrid.Tests
{
    public class FastChangeText : MonoBehaviour
    {
        Text m_text;
        void Start()
        {
            m_text = GetComponent<Text>();
        }

        void Update()
        {
            m_text.text += "asdasdasdasd";
        }
    }
}
