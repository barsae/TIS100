using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIS100 {
    public class Number : RW {
        private int value;

        public Number(int value) {
            this.value = value;
        }

        public static IEnumerable<Number> Convert(IEnumerable<int> values) {
            foreach (var value in values) {
                yield return new Number(value);
            }
        }

        public override string ToString() {
            return this.value.ToString();
        }

        public bool Readable() {
            return true;
        }

        public bool Writeable() {
            return true;
        }

        public Number Read() {
            return this;
        }

        public void Write(Number newValue) {
            this.value = newValue.value;
        }

        public Number Copy() {
            return new Number(value);
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

        public int ToInteger() {
            return value;
        }
    }
}
