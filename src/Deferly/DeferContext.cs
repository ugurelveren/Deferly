namespace Deferly.Core
{
    /// <summary>
    /// Context for registering deferred actions to run when disposed.
    /// </summary>
    public class DeferContext : IDisposable
    {
        public Stack<Action> _actions = new();
        private bool _disposed;

        // basic ctor
        public DeferContext()
        {
                
        }
        /// <summary>
        /// Actions are going to execute in LIFO order
        /// </summary>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Defer(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            _actions.Push(action);
        }

        /// <summary>
        /// Execure all registered action reverse
        /// </summary>
        public void Dispose()
        {
            if (_disposed) 
                return;
            // set disposed true 
            _disposed = true;
            while(_actions.Count > 0)
            {
                try
                {
                    var action = _actions.Pop();
                    action();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
