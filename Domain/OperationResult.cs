using System;

namespace Domain
{
    public class OperationResult<TEntity>
    {
        private OperationResult()
        {
        }

        public bool Success { get; private set; }
        public TEntity Data { get; private set; }
        public string NonSuccessMessage { get; private set; }
        public Exception Exception { get; private set; }

        public static OperationResult<TEntity> CreateSuccessResult(TEntity data)
        {
            return new OperationResult<TEntity> { Success = true, Data = data };
        }

        public static OperationResult<TEntity> CreateFailure(string nonSuccessMessage)
        {
            return new OperationResult<TEntity> { Success = false, NonSuccessMessage = nonSuccessMessage };
        }

        public static OperationResult<TEntity> CreateFailure(Exception ex)
        {
            return new OperationResult<TEntity>
            {
                Success = false,
                NonSuccessMessage = String.Format("{0}{1}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace),
                Exception = ex
            };
        }
    }
}