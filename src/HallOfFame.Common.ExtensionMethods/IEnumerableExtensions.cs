﻿namespace HallOfFame.Common.ExtensionMethods
{
    using System;
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}