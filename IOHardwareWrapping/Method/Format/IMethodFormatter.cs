using System;

namespace IOHardwareWrapping.Method.Format {
    public interface IMethodFormatter {
        String Serialise(String methodName, params Object[] methodParameters);
        String SerialiseMethod(String methodName);
        String SerialiseParams(params Object[] parameters);
    }
}