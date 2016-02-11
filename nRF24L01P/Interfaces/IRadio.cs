using System.Collections.Generic;
using Windows.Devices.Radios.nRF24L01P.Enums;

namespace Windows.Devices.Radios.nRF24L01P.Interfaces
{
    public interface IRadio
    {
        ICommandProcessor CommandProcessor { get; }
        IRadioConfiguration Configuration { get; }
        TransmitPipe TransmitPipe { get; }
        IDictionary<int, ReceivePipe> ReceivePipes { get; }
        string Name { get; }
        bool ChannelReceivedPowerDector { get; }
        DeviceStatus Status { get; set; }
        string ToString();
        void Initialize();
        void ChipEnable(bool enabled);
    }
}