using System;
namespace Game_UnknownPanic.Rules
{
    public static class InputRules
    {
        public enum InputType
        {
            Yes, No,
            Continue,
            Question, Answer
        }

        static bool input_validations(string input, InputType input_type)
        {
            return input_type switch
            {
                InputType.Yes      => input == "y" || input == "Y" || input == "Yes" || input == "YES",
                InputType.No       => input == "n" || input == "N" || input == "No" || input == "NO",
                InputType.Continue => true,
                InputType.Question => input.StartsWith( "q:" ) || input.StartsWith( "Q:" ),
                InputType.Answer   => input.StartsWith( "a:" ) || input.StartsWith( "A:" ),
                _                  => throw new ArgumentOutOfRangeException( nameof(input_type), input_type, null )
            };

        }

        static string input_parsing(string input, InputType input_type)
        {
            return input_type switch
            {
                InputType.Yes      => null,
                InputType.No       => null,
                InputType.Continue => input,
                InputType.Question => input.Remove( 0, 2 ),
                InputType.Answer   => input.Remove( 0, 2 ),
                _                  => throw new ArgumentOutOfRangeException( nameof(input_type), input_type, null )
            };
        }

        /// <summary>
        ///     Parse the input to one single valid type
        /// </summary>
        /// <returns>the input type will be null if no valid types, the info is the extra info</returns>
        public static (InputType? input_type, string info) ParseInput(string input, params InputType[] valid_input_types)
        {
            foreach (var input_type in valid_input_types)
            {
                if (input_validations( input, input_type ))
                {
                    return (input_type, input_parsing( input, input_type ));
                }
            }

            return (null, null);
        }
    }
}
