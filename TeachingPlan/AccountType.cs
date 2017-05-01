namespace TeachingPlan
{
    public enum AccountType
    {
        Teacher,
        Student
    }

    static class AccountTypeMethods
    {
        public static string text(this AccountType type)
        {
            switch (type)
            {
                case AccountType.Teacher:
                    return "Nauczyciel";
                case AccountType.Student:
                    return type.ToString();
                default:
                    return "Gość";
            }
        }
    }
}
