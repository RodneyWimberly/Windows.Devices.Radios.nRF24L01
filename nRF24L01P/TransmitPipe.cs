﻿using System;
using Windows.Devices.Radios.nRF24L01P.Enums;
using Windows.Devices.Radios.nRF24L01P.Registers;

namespace Windows.Devices.Radios.nRF24L01P
{
    public class TransmitPipe
    {
        private readonly Registers.RegisterManager _registers;
        private readonly RadioConfiguration _configuration;
        private readonly ICommandProcessor _commandProcessor;
        public TransmitPipe(RadioConfiguration configuration, ICommandProcessor commandProcessor)
        {
            _configuration = configuration;
            _commandProcessor = commandProcessor;
            _registers = configuration.Registers;
        }

        public byte[] Address
        {
            get
            {
                return _registers.TransmitAddressRegister;
            }
            set
            {
                int addressWidth = _configuration.AddressWidth;
                if (value.Length < addressWidth)
                    throw new InvalidOperationException("Address length should equal or greater than device.Config.AddressWidth");
                else if (value.Length > addressWidth)
                    Array.Resize(ref value, addressWidth);
                _registers.TransmitAddressRegister.Load(value);
                _registers.TransmitAddressRegister.Save();
            }
        }

        public void FlushBuffer()
        {
            _commandProcessor.ExecuteCommand(DeviceCommands.FLUSH_TX);
        }

        public FifoStatus FifoStatus
        {
            get
            {
                _registers.FifoStatusRegister.Load();
                if (_registers.FifoStatusRegister.TX_FULL)
                    return FifoStatus.Full;
                if (_registers.FifoStatusRegister.TX_EMPTY)
                    return FifoStatus.Empty;
                return FifoStatus.InUse;
            }
        }

        public void Write(byte[] data, bool disableACK = false)
        {
            if (data.Length > Constants.MaxPayloadWidth)
                throw new ArgumentOutOfRangeException(nameof(data), string.Format("data should be 0-{0} bytes", Constants.MaxPayloadWidth));

            _commandProcessor.ExecuteCommand(disableACK ? DeviceCommands.W_TX_PAYLOAD_NO_ACK : DeviceCommands.W_TX_PAYLOAD, RegisterAddresses.EMPTY_ADDRESS, data);
        }
    }
}
