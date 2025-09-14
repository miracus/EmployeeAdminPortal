namespace EmployeeAdminPortal.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public T? Value { get; }
        public string? ErrorMessage { get; }

        private Result(T value)
        {
            IsSuccess = true;
            Value = value;
        }

        private Result(string error)
        {
            IsSuccess = false;
            ErrorMessage = error;
        }

        public static Result<T> Success(T value) => new Result<T>(value);
        public static Result<T> Failure(string error) => new Result<T>(error);
    }
}