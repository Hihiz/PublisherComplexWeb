namespace PublisherComplexWeb.Domain.Enums
{
    public enum ErrorCode
    {
        NotFound = 404,
        AlreadyExists = 403,
        BadRequest = 400,
        NotCreated = 400,
        NotUpdated = 400,
        NotDeleted = 400,

        OK = 200,
        InternalServerError = 500
    }
}