using System;

namespace RhythmGamesBot.Utils
{
    /// <summary>
    ///     A structure meant to replace `null` for solving several problems with it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
        public static Option<T> Some(T value) => new Option<T>(value);

        // Creates a new `Option<T>` that does not contain a value.
        public static Option<T> None => default;

        /// <summary>
        ///     Returns whether the current `Option<T>` is a `Some` (which contains a value).
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        public bool IsSome() 
        {
            return this._isSome;
        }

        /// <summary> 
        ///     Returns whether the current `Option<T>` is a `None` (which does not contain a value).
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        public bool IsNone()
        {
            return !this._isSome;
        }

        /// <summary>
        ///     Unwraps the current `Option<T>`, retrieves the underlying `T` if the current `Option<T>` contains a value.
        ///     If the current `Option<T>` does not contain a value, throw an `InvalidOperationException`.\
        /// </summary>
        /// <returns><typeparamref name="T"/></returns>
        /// <exception><see cref="InvalidOperationException"/></exception>
        public T Unwrap() 
        {
            return this._isSome switch 
            {
                true => this._value,
                _ => throw new InvalidOperationException("Attempted to call `.Unwrap()` on an `Option.None()` value.")
            };
        }

        /// <summary>
        ///     Replaces the underlying `T` with the specified `value` parameter. Returns the old value if the current `Option<T>` before replacing
        ///     contains a value, otherwise returns an `Option<T>.None`.
        /// </summary>
        /// <returns><see cref="Option{T}"/></returns>
        public Option<T> Replace(T value)
        {
            if (this._isSome) 
            {
                T temp = this._value;
                this._value = value;

                return new Option<T>(temp);
            }

            this._value = value;
            return None;
        }
    }
}
