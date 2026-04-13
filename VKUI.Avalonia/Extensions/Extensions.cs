using Avalonia.Reactive;
using System;

namespace VKUI.Extensions
{
    internal static class Extensions
    {
        public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> action)
        {
            return source.Subscribe(new AnonymousObserver<T>(action));
        }
    }
}
