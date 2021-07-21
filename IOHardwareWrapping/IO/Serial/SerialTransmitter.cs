using System;
using System.IO.Ports;

namespace IOHardwareWrapping.IO.Serial {
    public class SerialTransmitter {
        public SerialPort Port { get; }

        public SerialTransmitter(SerialPort port) {
            if (port == null) {
                throw new NullReferenceException("Serial port cannot be null");
            }

            this.Port = port;
        }

        public void PrintLine(String message) {
            SerialPort port = this.Port;
            foreach (byte t in port.Encoding.GetBytes(message + '\n')) {
                port.BaseStream.WriteByte(t);
            }
        }

        public void Print(String message) {
            SerialPort port = this.Port;
            foreach (byte t in port.Encoding.GetBytes(message)) {
                port.BaseStream.WriteByte(t);
            }
        }
    }
}