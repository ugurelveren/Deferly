using Deferly.Core;

namespace Deferly.Examples
{
    public class DeferExamples
    {
        public void Example()
        {
            Console.WriteLine("Example 1: using statement with braces");

            using (var context = Defer.Create())
            {
                context.Defer(() => Console.WriteLine("Cleanup in Example 1"));
                Console.WriteLine("Doing work in Example 1...");
            } // Dispose() is called here — deferred action runs now

            Console.WriteLine("Deferred actions for Example 1 completed.");
            Console.WriteLine();

            Console.WriteLine("Example 2: using declaration without braces");

            using var context2 = Defer.Create();
            context2.Defer(() => Console.WriteLine("Cleanup in Example 2"));
            Console.WriteLine("Doing work in Example 2...");

            // context2.Dispose() will be called at the end of the method
            Console.WriteLine("Method is ending — deferred actions for Example 2 will now run.");
        }
    }
}
