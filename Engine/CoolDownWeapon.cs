using Raylib_cs;

namespace Engine
{
    public class CooldownWeapon(ICollidable hitBox, float _cooldown)
    {
        private float _currentCooldown = _cooldown;
        

        public void OnTick()
        {
            if (_currentCooldown <= 0f) return; 

            _currentCooldown -= Raylib.GetFrameTime();
        }
        public void OnHit()
        {
            _currentCooldown = _cooldown;
        }
        public bool CanSwing()
        {
            return _currentCooldown <= 0;
        }

        public bool CanHit(ICollidable other)
        {
           return CanSwing()&& Raylib.CheckCollisionRecs(hitBox.BoundingRect,other.BoundingRect);
        }
        
    }
}