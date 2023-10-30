namespace OperatR.App
{
    public class Operation1
    {
        public class Query : IOperationRequest<string>
        { 
            
        }

        public class Handler : OperationRequestHandler<Query, string>
        {
            protected override Task<string> DoOperation(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
