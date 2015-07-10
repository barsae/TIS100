using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIS100 {
    public struct Number {
        private int value;

        public Number(int value) {
            this.value = Math.Max(-999, Math.Min(value, 999));
        }

        public static IEnumerable<Number> Convert(IEnumerable<int> values) {
            foreach (var value in values) {
                yield return new Number(value);
            }
        }

        public override string ToString() {
            return this.value.ToString();
        }

        public int ToInteger() {
            return value;
        }

        public static Number operator+(Number one, Number two) {
            return new Number(one.value + two.value);
        }

        public static Number operator-(Number one) {
            return new Number(-one.value);
        }
        
        public static Number operator-(Number one, Number two) {
            return new Number(one.value - two.value);
        }
    }
}
