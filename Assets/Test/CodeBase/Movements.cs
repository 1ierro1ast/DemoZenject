using UnityEngine;

namespace Test.CodeBase
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movements : MonoBehaviour, IMovements
    {
        [SerializeField] private float _speed;
        
        private Rigidbody2D _rigidbody2D;
        
        public void Move(Vector2 direction)
        {
            _rigidbody2D.velocity = direction * _speed;
        }
    }
}
