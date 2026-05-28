namespace ServiceLayer.Utilities
{
    public class OperationResult
    {
        public string? Message { get; set; }
        public ResultStatus Status { get; set; }

        public static OperationResult Error(string message)
        {
            return new OperationResult
            {
                Message = message,
                Status = ResultStatus.Error
            };
        }
        public static OperationResult Error()
        {
            return new OperationResult
            {
                Message = "عملیات با خطا مواجه شد!",
                Status = ResultStatus.Error
            };
        }
        public static OperationResult NotFound(string message)
        {
            return new OperationResult
            {
                Message = message,
                Status = ResultStatus.NotFound
            };
        }
        public static OperationResult NotFound()
        {
            return new OperationResult
            {
                Message = "اطلاعات مورد نظر یافت نشد!",
                Status = ResultStatus.NotFound
            };
        }
        public static OperationResult Success(string message)
        {
            return new OperationResult
            {
                Message = message,
                Status = ResultStatus.Success
            };
        }
        public static OperationResult Success()
        {
            return new OperationResult
            {
                Message = "عملیات با موفقیت انجام شد",
                Status = ResultStatus.Success
            };
        }

        public enum ResultStatus
        {
            Error = 10,
            NotFound = 404,
            Success = 200
        }
    }
}
