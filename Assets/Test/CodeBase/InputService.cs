using UnityEngine;

namespace Test.CodeBase
{
    public class InputService : MonoBehaviour, IInputService
    {
        public float HorizontalSpeed => Input.GetAxis("Horizontal");
        public float VerticalSpeed => Input.GetAxis("Vertical");
    }
}