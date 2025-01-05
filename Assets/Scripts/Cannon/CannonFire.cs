using Poolers;
using ScriptableObjects;
using UnityEngine;

namespace Cannon
{
    public class CannonFire
    {
        private readonly Transform _firePoint;
        private readonly ProjectilePooler _projectilePooler;
        private readonly CannonFireSettings _cannonFireSettings;
        private readonly Transform _cannonPipe;

        private readonly Vector3 _cannonRecoilOffset = new (0.5f, 0f, 0f);
        private readonly Vector3 _startFirePipePosition;
        
        private bool _isRecoiling;

        public CannonFire(ProjectilePooler projectilePooler, CannonFireSettings cannonFireSettings, Transform firePoint, Transform cannonPipe)
        {
            _firePoint = firePoint;
            _projectilePooler = projectilePooler;
            _cannonPipe = cannonPipe;
            _cannonFireSettings = cannonFireSettings;
            
            _startFirePipePosition = _cannonPipe.localPosition;
        }
        
        public void Shoot()
        {
            if (_isRecoiling) return;
            
            var projectile = _projectilePooler.GetProjectile();
            projectile.Initialize(_firePoint, _projectilePooler);
            projectile.gameObject.SetActive(true);
            
            _isRecoiling = true;
        }

        public void TryPlayRecoilAnimation()
        {
            if (_isRecoiling)
            {
                var endPoint = _startFirePipePosition + _cannonPipe.up * _cannonRecoilOffset.x;
                _cannonPipe.localPosition = Vector3.Lerp(_cannonPipe.localPosition, endPoint, _cannonFireSettings.RecoilSpeed * Time.deltaTime);
                
                if (Vector3.Distance(_cannonPipe.localPosition, endPoint) < 0.01f)
                {
                    _isRecoiling = false;
                }
            }
            else
            {
                _cannonPipe.localPosition = Vector3.Lerp(_cannonPipe.localPosition, _startFirePipePosition, _cannonFireSettings.RecoilSpeed * Time.deltaTime);
            }
        }
    }
}