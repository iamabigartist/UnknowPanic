using System.Collections.Generic;
using UnityEngine;
namespace ProjectSpecific_Hybrid.Binders
{
    public class MainCanvasSetter : MonoBehaviour
    {
        public int Ma;
        public string Mb;
        public Color Mc;
        public List<AnimationCurve> Ml;
        public void ResetColor()
        {
            Mc = Color.red;
        }
        public void DoAdd()
        {
            Ml.Add( new AnimationCurve(
                new Keyframe( 0, 0 ),
                new Keyframe( 1, 1 ) ) );
        }

        void Start()
        {
            Ml = new List<AnimationCurve>();
        }
    }
}
