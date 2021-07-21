using System;
using System.IO.Ports;

namespace IOHardwareWrapping.IO.Serial {
    public class SerialCommunicator {
        public SerialReceiver Receiver { get; }
        public SerialTransmitter Transmitter { get; }
        public SerialPort Port { get; }

        public SerialCommunicator(SerialPort port, Action<String> onLineReceived) {
            this.Port = port;
            this.Transmitter = new SerialTransmitter(port);
            this.Receiver = new SerialReceiver(port, onLineReceived);
        }

        public void Start() {
            this.Receiver.Start();
        }
    }
}