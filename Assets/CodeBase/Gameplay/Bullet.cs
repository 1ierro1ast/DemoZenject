using Zenject;

namespace CodeBase.Gameplay
{
    public class Bullet : IBullet
    {
        public Bullet()
        {
            
        }
        
        public class Factory : PlaceholderFactory<Bullet>
        {
            
        }
    }
}