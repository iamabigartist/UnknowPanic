using MUtils;
using UnityEngine;
using UnityEngine.UI;
using static MUtils.AnimationUtils;
namespace ProjectSpecific_Hybrid.Binders
{
    public class AttackPanelBinder : MonoBehaviour
    {

        public float cur_time;

        [SerializeField]
        float alarm_1_time;
        [SerializeField]
        float alarm_2_time;
        [SerializeField]
        string normal_indicators;
        [SerializeField]
        string horror_indicator;
        [SerializeField]
        StepTimer m_stepTimer;

        Text indicator_text;
        Text time_text;
        AudioSource m_audioSource;

        public int alarm_level
        {
            get
            {
                if (cur_time > alarm_1_time)
                {
                    return 0;
                }
                else if (cur_time > alarm_2_time)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }


        void Start()
        {
            indicator_text = transform.GetChild( 0 ).GetComponent<Text>();
            time_text = transform.GetChild( 1 ).GetComponent<Text>();
            m_audioSource = GetComponent<AudioSource>();
        }

        bool audio_button;

        void Update()
        {
            cur_time = 25f - Time.time % 25f;

            switch (alarm_level)
            {
                case 0:
                    {
                        time_text.text = $"{cur_time} s";
                        indicator_text.text = normal_indicators + new string( '.', m_stepTimer.GetStep( cur_time ) );
                        break;
                    }
                case 1:
                    {
                        time_text.text = $"{cur_time} s".COLOR( Color.red );
                        var cur_alpha = blink( cur_time, 0.01f + Mathf.Pow( cur_time, 0.6f ) / 20f );
                        if (cur_alpha > 0.5f && !audio_button)
                        {
                            m_audioSource.PlayOneShot( m_audioSource.clip );
                            audio_button.press();
                        }
                        else if (cur_alpha < 0.5f && audio_button)
                        {
                            audio_button.press();
                        }
                        var cur_color = Color.red;
                        cur_color.a = cur_alpha;
                        indicator_text.text = normal_indicators.COLOR( cur_color );
                        break;
                    }
                case 2:
                    {
                        // time_text.text = $"{cur_time} s".ColorRT( AddColorTag.red );
                        time_text.text = "";
                        indicator_text.text = horror_indicator.COLOR( Color.red ).BOLD();
                        break;
                    }
            }
        }
    }
}
