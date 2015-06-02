using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIS100 {
    public class Number : RW {
        public int Value { get; set; }

        public Number(int value) {
            this.Value = value;
        }

        public static IEnumerable<Number> Convert(IEnumerable<int> values) {
            foreach (var value in values) {
                yield return new Number(value);
            }
        }

        public override string ToString() {
            return this.Value.ToString();
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

        public void Write(Number value) {
            Value = value.Value;
        }

        public Number Copy() {
            return new Number(Value);
        }

        public static Number operator+(Number one, Number two) {
            return new Number(one.Value + two.Value);
        }

        public static Number operator-(Number one) {
            return new Number(-one.Value);
        }
        
        public static Number operator-(Number one, Number two) {
            return new Number(one.Value - two.Value);
        }
    }
}
