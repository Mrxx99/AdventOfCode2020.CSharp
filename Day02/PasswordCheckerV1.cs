using System.Collections.Generic;
using System.Linq;

namespace Day02
{
    public static class PasswordCheckerV1
    {
        public static IReadOnlyList<string> FindValidPasswords(IEnumerable<string> input)
        {
            var output = new List<string>();

            foreach (var ruleAndPassword in input)
            {
                var parts = ruleAndPassword.Split(": ");
                string rule = parts[0];
                string password = parts[1];

                if (IsPasswordValid(password, rule))
                {
                    output.Add(password);
                }
            }

            return output;
        }

        private static bool IsPasswordValid(string password, string ruleString)
        {
            var rule = ParseRule(ruleString);

            int countOfRequiredCharacter = password.Count(character => character == rule.Character);
            bool isValid = countOfRequiredCharacter >= rule.MinCount && countOfRequiredCharacter <= rule.MaxCount;

            return isValid;
        }

        private static PasswordRule ParseRule(string ruleString)
        {
            var parts = ruleString.Split('-', ' ');
            return new PasswordRule(MinCount: int.Parse(parts[0]), MaxCount: int.Parse(parts[1]), Character: parts[2].ToCharArray()[0]);
        }

        public record PasswordRule(int MinCount, int MaxCount, char Character);
    }
}
