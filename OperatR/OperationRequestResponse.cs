namespace OperatR;

public class OperationRequestResponse<T>
{
    public OperationRequestResponse(T result, IEnumerable<string> errors)
    {
        Result = result;
        Errors = errors;
    }

    public T Result { get; }
    public IEnumerable<string> Errors { get; } = Enumerable.Empty<string>();
    public bool IsValid => !Errors.Any();
}
