using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNet.Layers;

namespace Tests.UnitTests
{
    [TestClass]
    public class HiddenLayerTests
    {
        [TestMethod]
        public void ExplicitCastingTest()
        {
            InputLayer il = new InputLayer();
            il.AddNeurons(2);

            HiddenLayer hl = new HiddenLayer(il);
            hl.AddNeurons(3);

            OutputLayer ol = new OutputLayer(hl);
            ol.AddNeurons(1);

            HiddenLayer hl2 = (HiddenLayer)ol;

            OutputLayer ol2 = new OutputLayer(hl2);
            ol2.AddNeurons(4);
            Assert.AreEqual(1, 1);//haha...
        }
    }
}
