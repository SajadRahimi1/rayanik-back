using AutoMapper;

public class AppMapper:Profile
{
    public AppMapper()
    {
        CreateMap<CreateCoursDto,Course>();
        CreateMap<AddLessonDto,Lesson>();
        CreateMap<AddBookDto,Book>();
    }
    
}