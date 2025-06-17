namespace Hospital_Project;
public class Doctor:Human
{
    public Doctor(string? name, string? surname, double experienceYear) : base(name, surname)
    {
        ExperienceYear = experienceYear;
    }
    public double ExperienceYear { get; set; }
    public bool NineToEleven { get; set; } = true;
    public bool TwelveToThirteen { get; set; } = true;
    public bool FifteenToSeventeen { get; set; } = true;

}