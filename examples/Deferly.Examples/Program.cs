// See https://aka.ms/new-console-template for more information


using Deferly.Core;


Console.WriteLine("Example 1: using with braces");

using (var context = Defer.Create())
{
    context.Defer(() => Console.WriteLine("Cleanup in Example 1"));
    Console.WriteLine("Doing work in Example 1...");
}

Console.WriteLine("Deferred actions for Example 1 completed.");

Console.WriteLine();
Console.WriteLine("Example 2: using declaration without braces");

using var context2 = Defer.Create();
context2.Defer(() => Console.WriteLine("Cleanup in Example 2"));
Console.WriteLine("Doing work in Example 2...");

// context2.Dispose() will be called at the end of Main
Console.WriteLine("End of Main - deferred actions for Example 2 will now run.");