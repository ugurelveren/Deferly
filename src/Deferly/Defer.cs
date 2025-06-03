namespace Deferly.Core
{
    /// <summary>
    /// Static helper for creating and using DeferContext.
    /// </summary>
    public static class Defer
    {
        /// <summary>
        /// Creates a new DeferContext for deferring actions.
        /// </summary>
        public static DeferContext Create() => new DeferContext();

        /// <summary>
        /// Shortcut: registers an action on the given context.
        /// </summary>
        public static void OnExit(DeferContext context, Action action)
        {
            if(context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Defer(action);
        }
    }
}
