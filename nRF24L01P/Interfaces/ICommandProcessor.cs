using Common.Logging;
using System;
using Windows.Devices.Radios.nRF24L01P.Enums;

namespace Windows.Devices.Radios.nRF24L01P.Interfaces
{
    public interface ICommandProcessor : IDisposable
    {
        bool CheckOperatingMode { get; set; }
        Action<byte[]> LoadStatusRegister { get; set; }
        Func<OperatingModes> GetOperatingMode { get; set; }
        ILoggerFactoryAdapter LoggerFactory { get; set; }
        byte[] ExecuteCommand(DeviceCommands deviceCommand, byte address, byte[] value, bool autoRevert = true);
        byte ExecuteCommand(DeviceCommands deviceCommand, byte address);
        byte ExecuteCommand(DeviceCommands deviceCommand);
    }
}