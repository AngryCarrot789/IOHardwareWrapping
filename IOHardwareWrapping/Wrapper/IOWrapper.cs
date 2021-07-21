using System;
using IOHardwareWrapping.IO;
using IOHardwareWrapping.Method.Invocator;

namespace IOHardwareWrapping.Wrapper {
    /// <summary>
    /// An abstract class for wrapping IO functions in a simplified way
    /// </summary>
    public class IOWrapper<TMethodInvocator> where TMethodInvocator : IMethodInvocator {
        public TMethodInvocator MethodInvocator { get; }

        protected IOWrapper(TMethodInvocator methodInvocator) {
            MethodInvocator = methodInvocator;
        }

        public void Invoke(String name, params Object[] parameters) {
            this.MethodInvocator.Invoke(name, parameters);
        }
    }
}