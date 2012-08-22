namespace BuildEmUp.Implementation
{
    public interface IRandom
    {
        int Next(int minValue, int maxValueExcluded);
        decimal NextDecimal(int minValue, int maxValueExcluded);
    }
}