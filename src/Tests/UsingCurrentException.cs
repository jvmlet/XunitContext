#if DEBUG

public class UsingCurrentException :
    XunitContextBase
{
    [Fact]
    public void Fails() =>
        Assert.True(false);

    [Fact]
    public void Fails_CommonException() => throw new();

    [Fact]
    public void Passes()
    {
    }

    public UsingCurrentException(ITestOutputHelper testOutput) :
        base(testOutput)
    {
    }

    public override void Dispose()
    {
        var contextTestException = Context.TestException;
        var methodName = Context.Test.TestCase.TestMethod.Method.Name;
        if (methodName.Contains("Passes"))
        {
            Assert.Null(contextTestException);
        }
        if (methodName.Contains("Fails"))
        {
            Assert.NotNull(contextTestException);
        }
        base.Dispose();
    }
}

#endif