using System;

namespace RhythmGamesBot.Utils
{
    public struct Option<T>
    {
        private bool _isSome;
        private T _value;

        private Option(T value)
        {
            this._value = value;
            this._isSome = true;
        }

        // Creates a new `Option<T>` that does contain a value.
        public static Option Some(T value) => new Option(value);

        // Creates a new `Option<T>` that does not contain a value.
        public static Option None => default;

        // Returns whether the current `Option<T>` is a `Some` (which contains a value).
        public bool IsSome() 
        {
            return this._isSome;
        }

        // Returns whether the current `Option<T>` is a `None` (which does not contain a value).
        public bool IsNone()
        {
            return !this._isSome;
        }

        // Unwraps the current `Option<T>`, retrieves the underlying `T` if the current `Option<T>` contains a value.
        // If the current `Option<T>` does not contain a value, throw an `InvalidOperationException`.
        public T Unwrap() 
        {
            return this._isSome switch 
            {
                true => this._value,
                _ => throw new InvalidOperationException("Attempted to call `.Unwrap()` on an `Option.None()` value.")
            };
        }

        // Replaces the underlying `T` with the specified `value` parameter. Returns the old value if the current `Option<T>` before replacing
        // contains a value, otherwise returns an `Option<T>.None`.
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
