using Engine.Scene;
using Raylib_cs;

namespace Engine.Util
{
    public class CooldownWeapon(ICollidable hitBox, float cooldown)
    {
#pragma warning disable CS9124
        private float _currentCooldown = cooldown;
#pragma warning restore CS9124


        public void OnTick()
        {
            if (_currentCooldown <= 0f) return;

            _currentCooldown -= Raylib.GetFrameTime();
        }

        public void OnHit()
        {
            _currentCooldown = cooldown;
        }

        public bool CanSwing()
        {
            return _currentCooldown <= 0;
        }

        public bool CanHit(ICollidable other)
        {
            return CanSwing() && Raylib.CheckCollisionRecs(hitBox.BoundingRect, other.BoundingRect);
        }
    }
}