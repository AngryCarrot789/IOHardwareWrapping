using System;
using System.Text;

namespace IOHardwareWrapping.Method.Format {
    public class RemappingMethodFormatter : IMethodFormatter {
        public RemapSheet RemapSheet { get; }

        public RemappingMethodFormatter(RemapSheet remapSheet) {
            this.RemapSheet = remapSheet;
        }

        public void PutMapping(String unmapped, String remapped) {
            this.RemapSheet.PutMapping(unmapped, remapped);
        }

        public String Serialise(String name, params Object[] parameters) {
            return $"{SerialiseMethod(name)}({SerialiseParams(parameters)})";
        }

        public string SerialiseMethod(string methodName) {
            return this.RemapSheet.TryGetRemapped(methodName, out string serialised) ? serialised : methodName;
        }

        public String SerialiseParams(params Object[] parameters) {
            StringBuilder builder = new StringBuilder(128);

            int lastIndex = parameters.Length - 1;
            int i = 0;
            foreach (Object parameter in parameters) {
                if (parameter is String value) {
                    builder.Append(SerialiseString(value));
                }
                else if (parameter is Int32 int32) {
                    builder.Append(SerialiseInt32(int32));
                }
                else if (parameter is Boolean boolean) {
                    builder.Append(SerialiseBoolean(boolean));
                }
                else if (parameter is Int16 int16) {
                    builder.Append(SerialiseInt16(int16));
                }
                else if (parameter is Int64 int64) {
                    builder.Append(SerialiseInt64(int64));
                }

                if (i < lastIndex) {
                    builder.Append(',');
                }

                i++;
            }

            return builder.ToString();
        }

        public static String SerialiseString(String value) {
            StringBuilder builder = new StringBuilder(value.Length).Append('\'');
            foreach (char c in value) {
                if (c == '\'') {
                    builder.Append('\\');
                }

                builder.Append(c);
            }
            return builder.Append('\'').ToString();
        }

        public static String SerialiseBoolean(Boolean value) {
            return value ? "t" : "f";
        }

        public static String SerialiseInt16(Int16 value) {
            return value + "s";
        }

        public static String SerialiseInt32(Int32 value) {
            return value + "i";
        }

        public static String SerialiseInt64(Int64 value) {
            return value + "l";
        }
    }
}