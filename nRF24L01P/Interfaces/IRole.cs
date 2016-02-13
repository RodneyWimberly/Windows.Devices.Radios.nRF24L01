﻿namespace Windows.Devices.Radios.nRF24L01P.Interfaces
{
    public interface IRole
    {
        void AttachDevice(IRadio radio);
        void DetachDevice();
        void Start();
        void Stop();
    }
}
