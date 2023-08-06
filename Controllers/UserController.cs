using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet, Route("send-sms")]
    public async Task<IActionResult> sendSms(string phoneNumber)
    {
        return await _userRepository.sendSms(phoneNumber);
    }

    [HttpGet, Route("check-code")]
    public async Task<IActionResult> checkCode(string phoneNumber, string code)
    {
        return await _userRepository.checkCode(phoneNumber, code);
    }

    [HttpGet, Route("all")]
    public async Task<IActionResult> getAll()
    {
        return await _userRepository.getAll();
    }
}
