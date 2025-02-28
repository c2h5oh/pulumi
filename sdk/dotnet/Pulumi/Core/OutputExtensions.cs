﻿// Copyright 2016-2019, Pulumi Corporation

using System.Collections.Immutable;

namespace Pulumi
{
    /// <summary>
    /// Extension methods for <see cref="Output{T}"/>.
    /// </summary>
    public static class OutputExtensions
    {
        /// <summary>
        /// Convert an output containing an array to an output containing the array element
        /// at the specified index.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">An array wrapped into <see cref="Output{T}"/>.</param>
        /// <param name="index">An index to get an element at.</param>
        /// <returns>An <see cref="Output{T}"/> containing an array element.</returns>
        public static Output<T> GetAt<T>(this Output<ImmutableArray<T>> array, Input<int> index)
        {
            var inputArray = (Input<ImmutableArray<T>>)array;
            return Output.Tuple(inputArray, index).Apply(v => v.Item1[v.Item2]);
        }

        /// <summary>
        /// Convert an output containing an array to an output containing its first element.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">An array wrapped into <see cref="Output{T}"/>.</param>
        /// <returns>An <see cref="Output{T}"/> containing the first array element.</returns>
        public static Output<T> First<T>(this Output<ImmutableArray<T>> array) => array.GetAt(0);

        /// <summary>
        /// Convert an output containing an array to an output containing the length of the array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">An array wrapped into <see cref="Output{T}"/>.</param>
        /// <returns>An <see cref="Output{T}"/> containing the array length.</returns>
        public static Output<int> Length<T>(this Output<ImmutableArray<T>> array)
            => array.Apply(xs => xs.Length);
    } 
}
