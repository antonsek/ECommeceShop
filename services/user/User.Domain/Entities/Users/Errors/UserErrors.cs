using Shared;

namespace Domain.Users.Errors;

public static class UserErrors
{
    public static readonly Error CannotChangePassword = Error.Problem(
        "User.CannotChangePassword",
        "The password cannot be changed to the specified password.");
        
    public static readonly Error NotFound = Error.NotFound(
        "User.NotFound",
        "The user with the specified identifier was not found.");

    public static readonly Error ResetTokenInvalid = Error.Problem(
        "User.ResetTokenInvalid",
        "The reset token is invalid.");

    public static readonly Error ResetTokenExpired = Error.Problem(
        "User.ResetTokenExpired",
        "The reset token has expired.");

    public static readonly Error PasswordsDoNotMatch = Error.Problem(
        "User.PasswordsDoNotMatch",
        "The passwords do not match.");

    public static readonly Error InMeeting = Error.Problem(
        "User.InMeeting",
        "The user is in a meeting.");

    public static readonly Error NotActive = Error.Problem(
        "User.NotActive",
        "The user is not active.");

    public static Error NotFoundByFullName(string? fullName) => Error.NotFound(
        "User.NotFoundFullName",
        $"The user {fullName} not found.");

    public static readonly Error InvalidPermissions = Error.Problem(
        "User.InvalidPermissions",
        "The current user does not have the permissions to perform that operation.");
        
    public static readonly Error EmailAlreadyInUse = Error.Conflict(
        "User.EmailAlreadyInUse",
        "The specified email is already in use");
    
    public static readonly Error LoginAlreadyInUse = Error.Conflict(
        "User.LoginAlreadyInUse",
        "The specified login is already in use");
    
    public static readonly Error NameIsNotUnique = Error.Conflict(
        "User.NameIsNotUnique",
        "The specified firstname and lastname is not unique");
    
    public static readonly Error AlreadyInGroup = Error.Conflict(
        "User.AlreadyInGroup",
        "The specified user is already in group.");

    public static readonly Error CanNotDelete = Error.Problem(
        "User.CanNotDelete",
        "The specified user can not be deleted.");
}
