using UnityEngine;
using UnityEngine.EventSystems;

namespace Character
{
    public class CharacterControllerActioner : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            CharacterController.Instance.OnPointerDown();
        }
    }
}