using UnityEngine;
using UnityEngine.UI;
namespace UnknownPanic.Tests
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
