using System;
using System.Linq;
using System.Collections.Generic;

namespace TodoMvcBlazor.Models
{
    public static class Extensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> seq) =>
            seq.Select((x, i) => (x, i));
    }
}