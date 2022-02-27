using System;
using UnityEngine;
namespace ProjectSpecific_Hybrid.Tests
{
    [Serializable]
    public class Mammal
    {
        public int life;
        public Color fur;
    }

    [Serializable]
    public class Cat : Mammal
    {
        public string friend;
    }


    [Serializable]
    public class Dog : Mammal
    {
        public string master;
    }


    public class testPSC : MonoBehaviour
    {
        [SerializeReference]
        [SerializeReferenceButton]
        public Mammal m_mammal;

        void Start() { }
    }
}
