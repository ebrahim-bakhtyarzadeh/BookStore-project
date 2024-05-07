namespace Common.Domain.Exceptions;

public class SlugIsDuplicateException : BaseDomainException
{
    public SlugIsDuplicateException() : base("Slug Is Duplicate")
    {

    }
    public SlugIsDuplicateException(string message) : base(message)
    {

    }
}