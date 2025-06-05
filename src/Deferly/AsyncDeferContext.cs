namespace Deferly.Core
{
    public class AsyncDeferContext : IAsyncDisposable
    {
        public Stack<Func<Task>> _actions = new();
        private bool _disposed;

        public AsyncDeferContext() { }


        /// <summary>
        /// Actions are going to execute in LIFO order
        /// </summary>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Defer(Func<Task> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            _actions.Push(action);
        }

        /// <summary>
        /// Execure all registered action reverse
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            if (_disposed)
                return;
            // set disposed true 
            _disposed = true;
            while (_actions.Count > 0)
            {
                try
                {
                    var action = _actions.Pop();
                    await action();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
