namespace Automarket.Domain.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,
        UserAlreadyExists = 1,
        
        CarNotFound = 10,

        OK = 200,
        InternalServerError = 500
    }
}