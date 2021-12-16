using UnityEngine;

namespace Character.Input
{
    public class CharacterInputActioner : MonoBehaviour
    {
        public void Jump()
        {
            CharacterInput.Instance.Jump();
        }
    }
}