using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    private async Task<User?> getSingleUser(string phoneNumber)
    {
        return await _appDbContext.Users.SingleOrDefaultAsync(user => user.phoneNumber == phoneNumber);
    }

    private async Task CreateNewUser(User user)
    {
        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateUser(User updatedUser)
    {
        _appDbContext.ChangeTracker.Clear();
        _appDbContext.Users.Update(updatedUser);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<CustomActionResult> checkCode(string phoneNumber, string code)
    {
        var user = await getSingleUser(phoneNumber);
        if (user == null)
        {
            return new CustomActionResult(new Result
            {
                ErrorMessage = new ErrorModel { ErrorMessage = "کاربری با این شماره یافت نشد" },
                statusCodes = StatusCodes.Status400BadRequest
            });
        }
        if (user.code != code)
        {
            return new CustomActionResult(new Result
            {
                ErrorMessage = new ErrorModel { ErrorMessage = "کد وارد شده اشتباه است" },
                statusCodes = StatusCodes.Status400BadRequest
            });
        }

        // user.Token = Guid.NewGuid();
        user.code = null;
        await UpdateUser(user);
        return new CustomActionResult(new Result
        {
            Data = user,
        });
    }



    public async Task<CustomActionResult> sendSms(string phoneNumber)
    {
        var user = await getSingleUser(phoneNumber);
        string code = new Random().Next(1000, 10000).ToString();

        if (user == null)
        {
            user = new User { phoneNumber = phoneNumber, code = code };
            await CreateNewUser(user);
            return new CustomActionResult(new Result { Data = "کد با موفقیت ارسال شد" });
        }

        user.code = code;
        await UpdateUser(user);
        return new CustomActionResult(new Result { Data = "کد با موفقیت ارسال شد" });

    }

    public async Task<CustomActionResult> getAll()
    {
        return new CustomActionResult(new Result { Data = await _appDbContext.Users.ToListAsync() });
    }
}
