using CodeBase.Gameplay;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    [CreateAssetMenu(menuName = "DemoZenject/Game Settings", fileName = "GameSettings", order = 51)]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public Bullet.Settings BulletSettings;

        public override void InstallBindings()
        {
            BindBulletSettings();
        }

        private void BindBulletSettings()
        {
            Container
                .BindInstance(BulletSettings)
                .IfNotBound();
        }
    }
}