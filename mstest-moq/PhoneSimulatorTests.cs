using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhoneSimulator;
using MobilePhoneSimulator.Contract;
using Moq;

namespace mstest_moq
{
    [TestClass]
    public class PhoneSimulatorTests
    {
        [TestMethod]
        public void Given_wireleas_connected_and_signal_is_strong_Then_wireless_should_active()
        {
            // Arrange
            var wirelessAntennaMock = new Mock<IWirelessReceiever>();
            var gprsAntennaMock = new Mock<IGprsReciever>();

            wirelessAntennaMock.Setup(w => w.IsConnected).Returns(true);
            wirelessAntennaMock.Setup(w => w.SignalStrength).Returns(600);

            var phoneSimulator = new Mock<PhoneSimulator>(wirelessAntennaMock.Object, gprsAntennaMock.Object);

            // Act & Assert
            Assert.IsTrue(phoneSimulator.Object.IsWireless);
        }

        [TestMethod]
        public void Given_wireleas_not_connected_and_signal_is_strong_Then_gprc_should_active()
        {
            // Arrange
            var wirelessAntennaMock = new Mock<IWirelessReceiever>();
            var gprsAntennaMock = new Mock<IGprsReciever>();

            wirelessAntennaMock.Setup(w => w.IsConnected).Returns(true);
            wirelessAntennaMock.Setup(w => w.SignalStrength).Returns(300);
            gprsAntennaMock.Setup(w => w.SignalStrength).Returns(300);

            var phoneSimulator = new Mock<PhoneSimulator>(wirelessAntennaMock.Object, gprsAntennaMock.Object);

            // Act & Assert
            Assert.IsTrue(phoneSimulator.Object.IsGprs);
            Assert.IsFalse(phoneSimulator.Object.IsWireless);
        }
    }
}
