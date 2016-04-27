﻿using Common.Logging;
using System;
using Windows.Devices.Radios.nRF24L01P.Interfaces;

namespace Windows.Devices.Radios.nRF24L01P.Registers
{
    /// <summary>
    ///   Transmit/Receive address data pipe. 
    /// </summary>
    /// <remarks>
    ///   5 Bytes maximum length for transmit and receive pipes 0 and 1 
    ///     (LSByte is written first. Write the number of bytes defined by SETUP_AW)
    ///   1 Byte length for receive pipes 2 - 5 (LSByte). 
    ///     The 4 MSBytes of the address come from the 4 MSBytes from Pipe 1
    ///   For Transmit address set RX_ADDR_P0 equal to this address to handle automatic acknowledge 
    ///     if this is a PTX device with Enhanced ShockBurst™ enabled.
    /// </remarks>
    public class AddressPipeRegister : PipeRegisterBase
    {
        public AddressPipeRegister(ILoggerFactoryAdapter loggerFactoryAdapter, ICommandProcessor commandProcessor, byte address, byte[] defaultValue, byte pipeNumber, string name = "") :
                base(loggerFactoryAdapter, commandProcessor, address, (byte)(pipeNumber <= 1 ? 5 : 1), defaultValue, pipeNumber, name)
        {
            bool transmitPipe = Address == RegisterAddresses.TX_ADDR;
            Name = string.Format("{0}{1}{2}{3}",
                                 transmitPipe ? "Transmit" : "Receive",
                                 GetType().Name,
                                 transmitPipe ? "" : PipeNumber.ToString(),
                                 string.IsNullOrEmpty(name) ? "" : string.Format(" ({0})", name));
            Logger = loggerFactoryAdapter.GetLogger(Name);
        }

        public byte[] PipeAddress
        {
            get { return Buffer; }
            set
            {
                if (value.Length != Length)
                    throw new InvalidOperationException(string.Format("The length of the PipeAddress must be {0}", Length));
                Buffer = value;
            }
        }
    }
}
