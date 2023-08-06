public interface IUserRepository 
{
    Task<CustomActionResult> sendSms(string phoneNumber);
    Task<CustomActionResult> checkCode(string phoneNumber,string code);

}
