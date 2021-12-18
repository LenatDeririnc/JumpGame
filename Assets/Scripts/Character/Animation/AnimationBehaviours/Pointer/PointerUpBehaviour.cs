using Common;

namespace Character.Animation.AnimationBehaviours.Pointer
{
    public abstract class PointerUpBehaviour : BasePointerBehaviour, IPointerUp
    {
        public void OnPointerUp()
        {
            Action();
        }
    }
}