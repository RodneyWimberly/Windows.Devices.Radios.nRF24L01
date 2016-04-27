﻿using Common.Logging;
using Windows.Devices.Radios.nRF24L01P.Interfaces;

namespace Windows.Devices.Radios.nRF24L01P.Registers
{
    /// <summary>
    ///   Enabled RX Addresses
    /// </summary>
    public class EnableReceiveAddressRegister : RegisterBase
    {
        public EnableReceiveAddressRegister(ILoggerFactoryAdapter loggerFactoryAdapter, ICommandProcessor commandProcessor) :
            base( loggerFactoryAdapter, commandProcessor, 1, RegisterAddresses.EN_RXADDR, RegisterDefaults.EN_RXADDR, "EN_RXADDR")
        { }

        /// <summary>
        /// Enable all receive data pipes
        /// </summary>
        public bool EnableReceiveDataPipe
        {
            get
            {
                return EnableReceiveDataPipe0 &&
                       EnableReceiveDataPipe1 &&
                       EnableReceiveDataPipe2 &&
                       EnableReceiveDataPipe3 &&
                       EnableReceiveDataPipe4 &&
                       EnableReceiveDataPipe5;
            }
            set
            {
                EnableReceiveDataPipe0 =
                       EnableReceiveDataPipe1 =
                       EnableReceiveDataPipe2 =
                       EnableReceiveDataPipe3 =
                       EnableReceiveDataPipe4 =
                       EnableReceiveDataPipe5 =
                       value;
            }
        }

        /// <summary>
        /// Enable data pipe 5
        /// </summary>
        public bool EnableReceiveDataPipe5
        {
            get { return GetBoolProperty(PropertyMasks.ERX_P5); }
            set { SetBoolProperty(PropertyMasks.ERX_P5, value); }
        }

        /// <summary>
        /// Enable data pipe 4
        /// </summary>
        public bool EnableReceiveDataPipe4
        {
            get { return GetBoolProperty(PropertyMasks.ERX_P4); }
            set { SetBoolProperty(PropertyMasks.ERX_P4, value); }
        }

        /// <summary>
        /// Enable data pipe 3
        /// </summary>
        public bool EnableReceiveDataPipe3
        {
            get { return GetBoolProperty(PropertyMasks.ERX_P3); }
            set { SetBoolProperty(PropertyMasks.ERX_P3, value); }
        }

        /// <summary>
        /// Enable data pipe 2
        /// </summary>
        public bool EnableReceiveDataPipe2
        {
            get { return GetBoolProperty(PropertyMasks.ERX_P2); }
            set { SetBoolProperty(PropertyMasks.ERX_P2, value); }
        }

        /// <summary>
        /// Enable data pipe 1
        /// </summary>
        public bool EnableReceiveDataPipe1
        {
            get { return GetBoolProperty(PropertyMasks.ERX_P1); }
            set { SetBoolProperty(PropertyMasks.ERX_P1, value); }
        }

        /// <summary>
        /// Enable data pipe 0
        /// </summary>
        public bool EnableReceiveDataPipe0
        {
            get { return GetBoolProperty(PropertyMasks.ERX_P0); }
            set { SetBoolProperty(PropertyMasks.ERX_P0, value); }
        }
    }
}
