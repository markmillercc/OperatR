using MediatR;

namespace OperatR;

public abstract class OperationRequestHandler<TRequest, TResult> : IRequestHandler<TRequest, OperationRequestResponse<TResult>>
    where TRequest : IOperationRequest<TResult>
{
    private readonly List<string> _errors = new();

    protected bool HasErrors => _errors.Any();

    public async Task<OperationRequestResponse<TResult>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var result = await DoOperation(request, cancellationToken);

        return new OperationRequestResponse<TResult>(result, _errors);
    }

    protected abstract Task<TResult> DoOperation(TRequest request, CancellationToken cancellationToken);

    protected TResult Error(string error)
    {
        _errors.Add(error);
        return default;
    }
}
