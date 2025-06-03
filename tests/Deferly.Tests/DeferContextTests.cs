using Deferly.Core;

namespace Deferly.Tests;

public class DeferContextTests
{
    [Fact]
    public void Dispose_ExecutesDeferredActionsInLIFOOrder()
    {
        var context = new DeferContext();
        var results = new List<int>();

        context.Defer(() => results.Add(1));
        context.Defer(() => results.Add(2));
        context.Defer(() => results.Add(3));

        context.Dispose();

        Assert.Equal(new List<int> { 3, 2, 1 }, results);
    }

    [Fact]
    public void Dispose_ShouldThrowExceptions()
    {
        var context = new DeferContext();
        var results = new List<int>();

        context.Defer(() => throw new InvalidOperationException());
        context.Defer(() => results.Add(1));

        // Should throw
        Assert.Throws<InvalidOperationException>(() => context.Dispose());
    }

    [Fact]
    public void Defer_NullAction_ThrowsArgumentNullException()
    {
        var context = new DeferContext();
        Assert.Throws<ArgumentNullException>(() => context.Defer(null));
    }
}
