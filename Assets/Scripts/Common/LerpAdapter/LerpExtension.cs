namespace Common.LerpAdapter
{
    public static class LerpExtension
    {
        public static ILerpAction Lerp(this ILerpAction adapter) => adapter.Lerp();
    }
}