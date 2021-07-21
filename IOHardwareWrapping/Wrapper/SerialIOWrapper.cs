using IOHardwareWrapping.IO.Serial;
using IOHardwareWrapping.Method.Invocator;

namespace IOHardwareWrapping.Wrapper {
    /// <summary>
    /// A serial-based IO wrapper
    /// </summary>
    public class SerialIOWrapper : IOWrapper<RemappingSerialMethodInvocator> {
        public SerialTransmitter Transmitter { get; }

        protected SerialIOWrapper(SerialTransmitter transmitter) : this(transmitter, new RemappingSerialMethodInvocator(transmitter)) { }

        protected SerialIOWrapper(SerialTransmitter transmitter, RemappingSerialMethodInvocator invocator) : base(invocator) {
            this.Transmitter = transmitter;
        }

        // todo: maybe add DTR stuff
    }
}