using UnityEngine;
using UnityEngine.EventSystems;

namespace Character
{
    public class CharacterControllerActioner : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            CharacterController.Instance.OnPointerDown();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            CharacterController.Instance.OnPointerUp();
        }
    }
}