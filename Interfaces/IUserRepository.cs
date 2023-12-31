public interface IUserRepository 
{
    Task<CustomActionResult> getAll();
    Task<CustomActionResult> sendSms(string phoneNumber);
    Task<CustomActionResult> checkCode(string phoneNumber,string code);
    Task<CustomActionResult> buyCourse(string userId,string courseId);      

}
