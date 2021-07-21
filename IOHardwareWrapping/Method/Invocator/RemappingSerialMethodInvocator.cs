using System;
using IOHardwareWrapping.IO.Serial;
using IOHardwareWrapping.Method.Format;

namespace IOHardwareWrapping.Method.Invocator {
    public class RemappingSerialMethodInvocator : FormattedMethodInvocator<RemappingMethodFormatter> {
        public SerialTransmitter Transmitter { get; }

        public RemappingSerialMethodInvocator(SerialTransmitter transmitter) : this(transmitter, new RemappingMethodFormatter(new RemapSheet())) {
            this.Transmitter = transmitter;
        }

        public RemappingSerialMethodInvocator(SerialTransmitter transmitter, RemappingMethodFormatter formatter) : base(formatter) {
            this.Transmitter = transmitter;
        }

        public override void Invoke(String name, params Object[] parameters) {
            this.Transmitter.PrintLine(this.Formatter.Serialise(name, parameters));
        }
    }
}