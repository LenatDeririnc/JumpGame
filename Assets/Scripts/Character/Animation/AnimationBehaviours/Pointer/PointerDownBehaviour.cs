using Common;

namespace Character.Animation.AnimationBehaviours.Pointer
{
    public abstract class PointerDownBehaviour : BasePointerBehaviour, IPointerDown
    {
        public void OnPointerDown()
        {
            Action();
        }
    }
}