using UnityEngine;

namespace Input
{
    public class CharacterInputActioner : MonoBehaviour
    {
        public void Jump()
        {
            CharacterInput.Instance.Jump();
        }
    }
}