using IOHardwareWrapping.IO;
using IOHardwareWrapping.IO.Serial;

namespace IOHardwareWrapping.Wrapper {
    public class ArduinoWrapper : SerialIOWrapper {
        public ArduinoWrapper(SerialTransmitter transmitter) : base(transmitter) {
            LoadMappings();
        }

        public void DigitalWrite(int pin, bool value) {
            this.Invoke("digitalWrite", pin, value);
        }

        /// <summary>
        /// Writes an analog PWM square wave to the given pin, with the given duty cycle ranging from 0 to 255,
        /// where 0 is always off, and 255 is always on, and 128 is on half the time
        /// </summary>
        /// <param name="pin">The pin to write to</param>
        /// <param name="value">The PWM duty cycle, between 0 and 255, where 0 is always off, and 255 is always on, 128 is on half the time</param>
        public void AnalogWrite(int pin, int value) {
            this.Invoke("analogWrite", pin, value);
        }

        /// <summary>
        /// Same as <see cref="AnalogWrite"/>, but where the float-value to be written is between 0 and 1, and is converted to a value between 0 and 255
        /// </summary>
        /// <param name="pin">The pin to write to</param>
        /// <param name="value">The PWM duty cycle, between 0 and 1, where 0 is always off, and 1 is always on, 0.5 is on half the time</param>
        public void AnalogWriteF(int pin, float value) {
            AnalogWrite(pin, (int) (value * 255.0f));
        }

        private void LoadMappings() {
            this.MethodInvocator.Formatter.RemapSheet.PutMapping("digitalWrite", "dw");
            this.MethodInvocator.Formatter.RemapSheet.PutMapping("analogWrite", "dw");
        }
    }
}