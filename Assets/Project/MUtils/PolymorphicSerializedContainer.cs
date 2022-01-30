using System;
using System.Collections.Generic;
using UnityEngine;
namespace MUtils
{
    [Serializable]
    public class PolymorphicSerializedContainer : MonoBehaviour
    {
        public List<string> type_list = new List<string>() { "A", "B", "C" };
        public (int a, string b) choice;
    }
}
