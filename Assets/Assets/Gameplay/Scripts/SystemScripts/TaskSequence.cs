using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using ParallelTaskFactoryList =
    System.Collections.Generic.List<(System.Func<System.Threading.Tasks.Task> factory, int parallelIndex)>;

namespace Assets.Gameplay.Scripts.SystemScripts
{
    public class TaskSequence
    {
        private readonly ParallelTaskFactoryList _taskFactories = new();

        public void Clear()
        {
            _taskFactories.Clear();
        }

        public void Join(Func<Task> taskFactory)
        {
            if (!_taskFactories.Any())
            {
                _taskFactories.Add((taskFactory, 0));
                return;
            }

            var parallelIndex = _taskFactories[^1].parallelIndex;
            _taskFactories.Add((taskFactory, parallelIndex));
        }

        public void Append(Func<Task> taskFactory)
        {
            if (!_taskFactories.Any())
            {
                _taskFactories.Add((taskFactory, 0));
                return;
            }

            var parallelIndex = _taskFactories[^1].parallelIndex;
            _taskFactories.Add((taskFactory, parallelIndex + 1));
        }

        public void Run()
        {
            Run(CancellationToken.None);
        }

        public void Run(CancellationToken token)
        {
            RunAsync(token).FireAndForget();
        }

        public async Task RunAsync(CancellationToken token)
        {
            if (!_taskFactories.Any())
                return;

            var taskGroupings = _taskFactories.GroupBy(tuple => tuple.parallelIndex);

            var groupIndex = 0;
            foreach (var grouping in taskGroupings)
            {
                try
                {
                    var tasks = grouping.Select(t => t.factory().WithCancellation(token));
                    await Task.WhenAll(tasks);
                }
                catch (OperationCanceledException e)
                {
                    if (token.IsCancellationRequested)
                        Debug.LogError($"Operation(s) timed out for task group #{groupIndex}: {e}");
                    else
                        Debug.LogError($"Caught exception for task group #{groupIndex}: {e}");
                }
                catch (Exception e)
                {
                    Debug.LogError($"Caught exception for task group #{groupIndex}: {e}");
                }

                groupIndex++;
            }
        }
    }
}
