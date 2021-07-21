using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace IOHardwareWrapping.IO.Serial {
    public class SerialReceiver {
        public Thread ReceiverThread { get; }
        public SerialPort Port { get; }
        public Action<string> LineReceivedCallback { get; }

        private bool _canThreadRun;
        private bool _isPaused;

        public bool IsPaused {
            get => _isPaused;
            set => _isPaused = value;
        }

        public SerialReceiver(SerialPort port, Action<string> lineReceivedCallback) {
            if (port == null) {
                throw new NullReferenceException("Serial port cannot be null");
            }

            if (lineReceivedCallback == null) {
                throw new NullReferenceException("The line received callback was null!");
            }

            this.LineReceivedCallback = lineReceivedCallback;
            this.Port = port;
            this.ReceiverThread = new Thread(Run);
            this.IsPaused = false;
        }

        public void Start() {
            this._canThreadRun = true;
            this.ReceiverThread.Start();
        }

        public void Stop() {
            this._canThreadRun = false;
            this.ReceiverThread.Join();
        }

        private void Run() {
            StringBuilder buffer = new StringBuilder(128);
            Action<string> callback = this.LineReceivedCallback;
            while (_canThreadRun) {
                if (this._isPaused) {
                    Thread.Sleep(1);
                    continue;
                }

                if (Port.IsOpen) {
                    while (Port.BytesToRead > 0) {
                        char read = (char) Port.ReadChar();
                        switch (read) {
                            case '\r': break;
                            case '\n':
                                callback(buffer.ToString());
                                buffer.Clear();
                                break;
                            default:
                                buffer.Append(read);
                                break;
                        }
                    }
                }

                Thread.Sleep(1);
            }
        }
    }
}