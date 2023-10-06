

namespace AgeCalculatorKata
{
    public class AgeCalculator
    {
        public object getAge(DateTime Birth, DateTime Target)
        {
            if(Target.Month < Birth.Month)
            {
                return Target.Year - Birth.Year - 1;
            }

            if(Target.Month == Birth.Month)
            {
                if(Target.Day < Birth.Day)
                {
                    return Target.Year - Birth.Year - 1;
                }
            }
            return Target.Year - Birth.Year;
        }
    }
}
