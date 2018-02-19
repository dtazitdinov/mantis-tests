using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class TestBase
    {
        protected ApplicationManager appManager;

        [TestFixtureSetUp]
        public void SetupApplicationManager()
        {
            appManager = ApplicationManager.GetThreadInstance();
        }

        private static Random rndNumber = new Random((int)DateTime.Now.Ticks);
        public static int GenerateRandomNumber(int maxNum)
        {
            return rndNumber.Next(maxNum);
        }
    }
}
