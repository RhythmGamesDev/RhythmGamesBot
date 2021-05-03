using System;

namespace RhythmGamesBot.Utils
{
    public struct Option<T>
    {
        private bool _isSome;
        private T _value;

        private Option() 
        {
            this._isSome = false;
        }

        private Option(T value)
        {
            this._value = value;
            this._isSome = true;
        }

        public static Option Some(T value)
        {
            return new Option(value);
        }

        public static Option None() 
        {
            return new Option();
        }

        public bool IsSome() 
        {
            return this._isSome;
        }

        public bool IsNone()
        {
            return !this._isSome;
        }

        public T Unwrap() 
        {
            return this._isSome switch 
            {
                true => this._value,
                _ => throw new InvalidOperationException("Attempted to call `.Unwrap()` on an `Option.None()` value.")
            };
        }

        public Option<T> Replace(T value)
        {
            if (this._isSome) 
            {
                T temp = this._value;
                this._value = value;

                return temp;
            }

            this._value = value;
            return Option<T>.None();
        }
    }
}
