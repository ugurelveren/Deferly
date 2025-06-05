using Deferly.Core;

namespace Deferly.Examples
{
    public class AsyncDeferExamples
    {
        public async Task Example()
        {
            await using var context = AsyncDefer.Create(); // create and set current context

            AsyncDefer.OnExit(context, async () =>
            {
                Console.WriteLine("Deferred: Start");
                await Task.Delay(100);
                Console.WriteLine("Deferred: End");
            });

            await Task.Delay(2);
            Console.WriteLine("Inside Example Method");
        }
    }
}
