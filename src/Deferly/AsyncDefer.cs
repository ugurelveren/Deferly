namespace Deferly.Core
{
    /// <summary>
    /// Static helpher to create AsyncDeferContext
    /// </summary>
    public static class AsyncDefer
    {
        public static AsyncDeferContext Create() => new AsyncDeferContext();

        /// <summary>
        /// Shortcut: registers an action on the given context.
        /// </summary>
        public static void OnExit(AsyncDeferContext context, Func<Task> action)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Defer(action);
        }
    }
}
