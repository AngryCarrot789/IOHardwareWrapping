using IOHardwareWrapping.IO.Serial;
using IOHardwareWrapping.Wrapper;

namespace IOHardwareWrapping {
    public class TestMain {
        public void e() {
            SerialCommunicator communicator = new SerialCommunicator(null, null);
            ArduinoWrapper wrapper = new ArduinoWrapper(communicator.Transmitter);
            wrapper.DigitalWrite(2, true);
        }
    }
}