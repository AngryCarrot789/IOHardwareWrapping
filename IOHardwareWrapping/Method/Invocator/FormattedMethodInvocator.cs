using System;
using System.Collections.Generic;
using IOHardwareWrapping.Method.Format;

namespace IOHardwareWrapping.Method.Invocator {
    /// <summary>
    /// A Method Invocator that uses a method formatter to "format" methods (e.g by changing the arrangement in some way)
    /// </summary>
    /// <typeparam name="TMethodFormatter">The type of formatter to use</typeparam>
    public abstract class FormattedMethodInvocator<TMethodFormatter> : IMethodInvocator where TMethodFormatter : IMethodFormatter {
        /// <summary>
        /// A formatter used to format methods
        /// </summary>
        public TMethodFormatter Formatter { get; }

        protected FormattedMethodInvocator(TMethodFormatter formatter) {
            this.Formatter = formatter;
        }

        public abstract void Invoke(string name, params object[] parameters);
    }
}