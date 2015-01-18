using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNet;

namespace Tests.UnitTests
{
    [TestClass]
    public class BackPropNetworkTests
    {
        [TestMethod]
        public void InitializeTest()
        {
            BackpropNetwork bpn = new BackpropNetwork();
            bpn.Initialize(3, 4, 2);
            Assert.AreEqual(1, 1);
        }
    }
}
