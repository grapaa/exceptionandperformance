using LanguageExt.Common;

namespace ExceptionHandling;

public interface IFoo
{
    bool Original();
    Result<bool> Functional();
}

public class Foo : IFoo
{
    public bool Original()
    {
        throw new Exception("Oh no!");

        return true;
    }

    public Result<bool> Functional()
    {
        
        return new Result<bool>( new Exception("Oh no!"));
        
        return true;
        
    }

    
}