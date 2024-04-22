using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Gameplay.Scripts.SystemScripts
{
    public static class TaskExtensions
    {
        
        public static Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
        {
            if (!cancellationToken.CanBeCanceled)
                return task;

            if (task.IsCompleted)

                return task;
            if (cancellationToken.IsCancellationRequested)
                return Task.FromCanceled<T>(cancellationToken);

            return WithCancellationInternal(task, cancellationToken);
        }

        public static Task<T> WithCancellation<T>(this Task<T> task, TimeSpan timeout)
        {
            if (task.IsCompleted)
                return task;

            return WithCancellationInternal(task, timeout);
        }

        public static Task WithCancellation(this Task task, CancellationToken cancellationToken)
        {
            if (!cancellationToken.CanBeCanceled)
                return task;

            if (task.IsCompleted)
                return task;

            if (cancellationToken.IsCancellationRequested)
                return Task.FromCanceled(cancellationToken);

            return WithCancellationInternal(task, cancellationToken);
        }

        public static Task WithCancellation(this Task task, TimeSpan timeout)
        {
            if (task.IsCompleted)
                return task;

            return WithCancellationInternal(task, timeout);
        }

        private static async Task<T> WithCancellationInternal<T>(Task<T> task, TimeSpan timeout)
        {
            using var cts = new CancellationTokenSource(timeout);
            return await WithCancellationInternal(task, cts.Token).ConfigureAwait(false);
        }

        private static async Task WithCancellationInternal(Task task, TimeSpan timeout)
        {
            using var cts = new CancellationTokenSource(timeout);
            await WithCancellationInternal(task, cts.Token).ConfigureAwait(false);
        }

        private static async Task<T> WithCancellationInternal<T>(Task<T> task, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<object>();
            using (cancellationToken.Register(s => ((TaskCompletionSource<object>)s).TrySetResult(null), tcs))
            {
                if (task != await Task.WhenAny(task, tcs.Task).ConfigureAwait(false))
                    throw new OperationCanceledException(cancellationToken);
            }

            return await task.ConfigureAwait(false);
        }

        private static async Task WithCancellationInternal(Task task, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<object>();
            using (cancellationToken.Register(s => ((TaskCompletionSource<object>)s).TrySetResult(null), tcs))
            {
                if (task != await Task.WhenAny(task, tcs.Task).ConfigureAwait(false))
                    throw new OperationCanceledException(cancellationToken);
            }

            await task.ConfigureAwait(false);
        }

        public static async void FireAndForget(this Task task)
        {
            if (task.IsCompleted)
                return;

            await task.ContinueWith(t =>
            {
                if (t.IsCompleted && (t.Status != TaskStatus.RanToCompletion))
                {
                    Debug.LogError($"Fire & Forget task was unsuccessful ({t.Status}): {t.Exception}");
                }
            }, SyncContextUtil.UnityTaskScheduler);
        }

        public static Coroutine ToCoroutine(this Task task, MonoBehaviour behaviour)
        {
            return behaviour.StartCoroutine(WaitForTaskCompletionCor(task));

            IEnumerator WaitForTaskCompletionCor(IAsyncResult t)
            {
                while (!t.IsCompleted)
                    yield return null;
            }
        }
    }
}
