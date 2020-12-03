using System.Collections.Generic;

namespace Day02
{
    public static class PasswordCheckerV2
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

            bool isPosition1Equal = password[rule.Position1] == rule.Character;
            bool isPosition2Equal = password[rule.Position2] == rule.Character;

            bool isValid = isPosition1Equal && !isPosition2Equal || !isPosition1Equal && isPosition2Equal;

            return isValid;
        }

        private static PasswordRule ParseRule(string ruleString)
        {
            var parts = ruleString.Split('-', ' ');
            return new PasswordRule(Position1: int.Parse(parts[0]) - 1, Position2: int.Parse(parts[1]) - 1, Character: parts[2].ToCharArray()[0]);
        }

        public record PasswordRule(int Position1, int Position2, char Character);

    }
}
