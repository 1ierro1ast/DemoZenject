using UnityEngine;

namespace Test.CodeBase
{
    [RequireComponent(typeof(IMovements))]
    [RequireComponent(typeof(IInputService))]
    public class Character : MonoBehaviour
    {
        public IMovements Movements { get; private set; }
        public IInputService InputService { get; private set; }

        private void Awake()
        {
            Movements = GetComponent<IMovements>();
        }

        private void FixedUpdate()
        {
            Movements.Move(new Vector2(InputService.HorizontalSpeed, InputService.VerticalSpeed));
        }
    }
}