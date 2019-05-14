using FluentAssertions;
using MobilePhoneSimulator;
using MobilePhoneSimulator.Contract;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    public class PhoneSimulatorTests
    {
        [Test]
        public void Given_wireleas_connected_and_signal_is_strong_Then_wireless_should_active()
        {
            // Arrange
            var wirelessAntennaSubs = Substitute.For<IWirelessReceiever>();
            var gprsAntennaSubs = Substitute.For<IGprsReciever>();

            wirelessAntennaSubs.IsConnected.Returns(true);
            wirelessAntennaSubs.SignalStrength.Returns(600);

            var phoneSimulator = Substitute.For<PhoneSimulator>(wirelessAntennaSubs, gprsAntennaSubs);

            // Act & Assert
            phoneSimulator.IsWireless.Should().BeTrue();
        }

        [Test]
        public void Given_wireleas_not_connected_and_signal_is_strong_Then_gprc_should_active()
        {
            // Arrange
            var wirelessAntennaSubs = Substitute.For<IWirelessReceiever>();
            var gprsAntennaSubs = Substitute.For<IGprsReciever>();

            wirelessAntennaSubs.IsConnected.Returns(true);
            wirelessAntennaSubs.SignalStrength.Returns(300);
            gprsAntennaSubs.SignalStrength.Returns(300);

            var phoneSimulator = Substitute.For<PhoneSimulator>(wirelessAntennaSubs, gprsAntennaSubs);

            // Act & Assert
            phoneSimulator.IsGprs.Should().BeTrue();
            phoneSimulator.IsWireless.Should().BeFalse();
        }
    }
}