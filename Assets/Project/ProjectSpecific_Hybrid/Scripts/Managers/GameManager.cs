using UnityEngine;
namespace UnknownPanic.Managers
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
