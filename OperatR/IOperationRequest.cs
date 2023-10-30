using MediatR;

namespace OperatR;

public interface IOperationRequest<TResult> : IRequest<OperationRequestResponse<TResult>>
{
}
