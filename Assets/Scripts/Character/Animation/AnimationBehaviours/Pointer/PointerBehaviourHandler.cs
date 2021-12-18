namespace Character.Animation.AnimationBehaviours.Pointer
{
    public class PointerBehaviourHandler
    {
        private BasePointerBehaviour currentPointerBehaviour;
        public PointerBehaviourHandler()
        {}

        public void SetPointerBehaviour(BasePointerBehaviour newBehaviour)
        {
            currentPointerBehaviour = newBehaviour;
        }

        public BasePointerBehaviour GetPointerBehaviour() 
            => currentPointerBehaviour;
    }
}