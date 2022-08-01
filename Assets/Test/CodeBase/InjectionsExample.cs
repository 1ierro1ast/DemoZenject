using Zenject;

namespace Test.CodeBase
{
    public class InjectionsExample
    {
        [Inject]
        private IInputService _inputService;
        
        [Inject]
        public IMovements Movements { get; private set; }

        [Inject]
        public void Construct(IMovements movements)
        {
            // do something
        }

        [Inject]
        public InjectionsExample(IMovements movements)
        {
            // do something
        }
    }
}