namespace Ianf.Gametracker.Services.Errors 
{
    public record SqlError(string ErrorMessage) : Error(ErrorMessage) { };
}
