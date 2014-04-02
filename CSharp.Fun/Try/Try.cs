﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Fun.Try
{
    public interface Try<out T>
    {
        bool IsSuccess { get; }

        T Value { get; }
    }

    public sealed class Failure<T> : Try<T>
    {
        private readonly Exception _exception;

        public Failure(Exception exception)
        {
            _exception = exception;
        }

        public bool IsSuccess { get { return false; } }

        public T Value { get { throw new Exception("Failure has no value");} }

        public Exception Exception { get { return _exception; } }
    }

    public sealed class Success<T> : Try<T>
    {
        private readonly T _value;

        public Success(T value)
        {
            _value = value;
        }

        public bool IsSuccess { get { return true; } }

        public T Value { get { return _value; } }
    }
}
