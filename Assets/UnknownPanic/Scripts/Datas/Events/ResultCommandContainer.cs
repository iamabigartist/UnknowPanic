using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace UnknownPanic.Datas.Events
{
    [Serializable]
    public class ResultCommandContainer
    {
        static Dictionary<string, Type> command_type_dict;
        static ResultCommandContainer()
        {
            command_type_dict = new Dictionary<string, Type>();
            foreach (var child_class in
                     Assembly.GetAssembly( typeof(ResultCommand) ).GetTypes().
                         Where( child_class =>
                             child_class.IsClass && !child_class.IsAbstract &&
                             child_class.IsSubclassOf( typeof(ResultCommand) ) ))
            {
                command_type_dict[child_class.Name] = child_class;
            }
        }
        public Type cur_command_type;
        public ResultCommand cur_command;
    }

    [Serializable]
    public abstract class ResultCommand
    {
        public abstract void Execute(GlobalState globalState);
    }

    [Serializable]
    public class EscaperStateChangeCommand : ResultCommand
    {
        public PlayerAlias effected_player;
        public Escaper.StateType state_type;
        public int change_value;
        public override void Execute(GlobalState globalState) { }
    }

    [Serializable]
    public class StoryUnlockCommand : ResultCommand
    {
        public string unlock_name;
        public override void Execute(GlobalState globalState) { }
    }



}
