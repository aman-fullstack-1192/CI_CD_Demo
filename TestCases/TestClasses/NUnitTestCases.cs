using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace SampleBTApp.DeploymentTests
{
    [TestFixture]
    public static class VerifyDeployment
    {
        [Test]
        public static void TestBizTalkWCFService()
        {
            var retVal = NUnitUtility.TestBizTalkAppService("Aman", "Kumar");
            Assert.AreEqual(true, retVal);
 
        }
    }
}