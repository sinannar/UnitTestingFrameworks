using FakeItEasy;
using MobilePhoneSimulator;
using MobilePhoneSimulator.Contract;
using Shouldly;
using System;
using Xunit;

namespace xunit_fakeiteasy_shouldly
{
    public class PhoneSimulatorTests
    {
        [Fact]
        public void Given_wireleas_connected_and_signal_is_strong_Then_wireless_should_active()
        {
            // Arrange
            var wirelessAntennaSubs = A.Fake<IWirelessReceiever>();
            var gprsAntennaSubs = A.Fake<IGprsReciever>();

            A.CallTo(() => wirelessAntennaSubs.IsConnected).Returns(true);
            A.CallTo(() => wirelessAntennaSubs.SignalStrength).Returns(600);

            var phoneSimulator = new PhoneSimulator(wirelessAntennaSubs, gprsAntennaSubs);

            // Act & Assert
            phoneSimulator.IsWireless.ShouldBeTrue();
        }

        [Fact]
        public void Given_wireleas_not_connected_and_signal_is_strong_Then_gprc_should_active()
        {
            // Arrange
            var wirelessAntennaSubs = A.Fake<IWirelessReceiever>();
            var gprsAntennaSubs = A.Fake<IGprsReciever>();

            A.CallTo(() => wirelessAntennaSubs.IsConnected).Returns(true);
            A.CallTo(() => wirelessAntennaSubs.SignalStrength).Returns(300);
            A.CallTo(() => gprsAntennaSubs.SignalStrength).Returns(300);

            var phoneSimulator = new PhoneSimulator(wirelessAntennaSubs, gprsAntennaSubs);

            // Act & Assert
            phoneSimulator.IsGprs.ShouldBeTrue();
            phoneSimulator.IsWireless.ShouldBeFalse();
        }
    }
}
