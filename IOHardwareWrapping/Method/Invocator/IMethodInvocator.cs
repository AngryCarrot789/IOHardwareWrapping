using System;

namespace IOHardwareWrapping.Method.Invocator {
    /// <summary>
    /// An abstract class for invocating methods
    /// </summary>
    public interface IMethodInvocator {
        /// <summary>
        /// Invokes a method with the given name, and parameters
        /// </summary>
        /// <param name="name">The method name</param>
        /// <param name="parameters">The method's parameters</param>
        void Invoke(String name, params Object[] parameters);
    }
}