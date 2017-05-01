namespace TeachingPlan
{
    public enum AccountType
    {
        AdministrativeWorker,
        CathedralManager,
        Teacher,
        Student
    }

    static class AccountTypeMethods
    {
        public static string text(this AccountType type)
        {
            switch (type)
            {
                case AccountType.AdministrativeWorker:
                    return "Pracownik administracyjny";
                case AccountType.CathedralManager:
                    return "Kierownik katedry";
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
