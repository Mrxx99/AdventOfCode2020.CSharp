using Day02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public void FindValidPasswordsV1Test()
        {
            var input = new[]
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc",
            };

            var validPasswords = PasswordCheckerV1.FindValidPasswords(input);

            Assert.AreEqual(2, validPasswords.Count);
            Assert.AreEqual("abcde", validPasswords[0]);
            Assert.AreEqual("ccccccccc", validPasswords[1]);
        }

        [TestMethod]
        public void FindValidPasswordsV2Test()
        {
            var input = new[]
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc",
            };

            var validPasswords = PasswordCheckerV2.FindValidPasswords(input);

            Assert.AreEqual(1, validPasswords.Count);
            Assert.AreEqual("abcde", validPasswords[0]);
        }
    }
}
