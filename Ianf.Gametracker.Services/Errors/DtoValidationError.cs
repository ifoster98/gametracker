namespace Ianf.Gametracker.Services.Errors 
{
    public record DtoValidationError(string ErrorMessage, string DtoType, string DtoProperty) : Error(ErrorMessage) { };
}
