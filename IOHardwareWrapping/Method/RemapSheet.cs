using System;
using System.Collections.Generic;

namespace IOHardwareWrapping.Method {
    /// <summary>
    /// Used for remapping method names from "unmapped" to "remapped" (to save transmission time, aka converting a method called "doSomethingWith(1,2,3)" to "dsw(1,2,3)")
    /// </summary>
    public class RemapSheet {
        /// <summary>
        /// Unmapped to remapped
        /// </summary>
        public Dictionary<String, String> MappingsUR { get; }

        /// <summary>
        /// Remapped to unmapped
        /// </summary>
        public Dictionary<String, String> MappingsRU { get; }

        public RemapSheet() {
            this.MappingsUR = new Dictionary<string, string>();
            this.MappingsRU = new Dictionary<string, string>();
        }

        public void PutMapping(String unmapped, String remapped) {
            this.MappingsUR.Add(unmapped, remapped);
            this.MappingsRU.Add(remapped, unmapped);
        }

        public String GetRemapped(String unmapped) {
            return this.MappingsUR[unmapped];
        }

        public String GetUnmapped(String remapped) {
            return this.MappingsRU[remapped];
        }

        public bool TryGetRemapped(String unmapped, out String remapped) {
            return this.MappingsUR.TryGetValue(unmapped, out remapped);
        }

        public bool TryGetUnmapped(String remapped, out String unmapped) {
            return this.MappingsRU.TryGetValue(remapped, out unmapped);
        }
    }
}