namespace Common.FollowManager
{
    public interface ITargetSetter<in T>
    {
        void SetTarget(T target);
    }
}