using UnityEngine;
namespace UnknownPanic.Datas.StoryEvents
{
    public abstract class BasicEvent : ScriptableObject
    {
        public string beginning_description;
        public int choice_situation_count;
        public string[] result_description;

    }
}
