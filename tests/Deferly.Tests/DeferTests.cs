using Deferly.Core;

namespace Deferly.Tests
{
    public class DeferTests
    {
        [Fact]
        public void Create_ReturnsNewContext()
        {
            var c1 = Defer.Create();
            var c2 = Defer.Create();
            Assert.NotSame(c1, c2);
        }

        [Fact]
        public void OnExit_RegistersActionToContext()
        {
            var context = Defer.Create();
            var executed = false;

            Defer.OnExit(context, () => executed = true);

            context.Dispose();
            Assert.True(executed);
        }

        [Fact]
        public void OnExit_NullContext_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Defer.OnExit(null, () => { }));
        }

        [Fact]
        public void OnExit_NullAction_PropagatesArgumentNullException()
        {
            var context = Defer.Create();
            Assert.Throws<ArgumentNullException>(() => Defer.OnExit(context, null));
        }
    }
}
