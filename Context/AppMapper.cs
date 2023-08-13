using AutoMapper;

public class AppMapper:Profile
{
    public AppMapper()
    {
        CreateMap<CreateCoursDto,Course>();
    }
    
}