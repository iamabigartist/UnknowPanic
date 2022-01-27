using UnityEngine;
namespace ProjectSpecific_Hybrid.Managers
{
    public class GameManager : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad( this );
        }

        void Update() { }
    }
}
