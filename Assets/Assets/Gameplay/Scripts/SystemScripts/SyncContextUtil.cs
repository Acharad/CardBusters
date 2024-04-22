using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Gameplay.Scripts.SystemScripts
{
    public static class SyncContextUtil
    {
        public static SynchronizationContext UnitySynchronizationContext { get; private set; }
        public static TaskScheduler UnityTaskScheduler { get; private set; }

        public static int UnityThreadId { get; private set; }

        public static bool IsCurrentlyInUnityContext => SynchronizationContext.Current == UnitySynchronizationContext;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            UnitySynchronizationContext = SynchronizationContext.Current;
            UnityTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            UnityThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        public static void RunOnUnityScheduler(Action fn)
        {
            if (IsCurrentlyInUnityContext)
            {
                fn();
            }
            else
            {
                UnitySynchronizationContext.Post(_ => fn(), null);
            }
        }

        public static void RunOnUnityScheduler<T>(Action<T> fn, T state)
        {
            if (IsCurrentlyInUnityContext)
            {
                fn(state);
            }
            else
            {
                UnitySynchronizationContext.Post(o => fn((T) o), state);
            }
        }

        public static Task<T> RunOnUnityScheduler<T>(Func<T> fn)
        {
            if (IsCurrentlyInUnityContext)
            {
                var result = fn();
                return Task.FromResult(result);
            }

            var tcs = new TaskCompletionSource<T>();
            UnitySynchronizationContext.Post(_ =>
            {
                var result = fn();
                tcs.SetResult(result);
            }, null);

            return tcs.Task;
        }
    }
}