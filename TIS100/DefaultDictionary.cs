using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS100 {
    public class DefaultDictionary<TKey, TValue> : Dictionary<TKey, TValue> {
        private Func<TValue> makeDefault;

        public DefaultDictionary(Func<TValue> makeDefault) {
            this.makeDefault = makeDefault;
        }

        public TValue this[TKey key] {
            get {
                if (!ContainsKey(key) ) {
                    base[key] = makeDefault();
                }
                return base[key];
            }
            set {
                base[key] = value;
            }
        }
    }
}
