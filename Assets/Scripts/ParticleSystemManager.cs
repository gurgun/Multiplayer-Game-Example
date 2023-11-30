using UnityEngine;
using UnityEngine.Serialization;


    public class ParticleSystemManager : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particleEffect;
        
        
        private void Start()
        {
            particleEffect.Stop();
        }
        
        public void Play()
        {
            
            if (particleEffect.isPlaying) return;
            particleEffect.Play();
            
        }

        public void Stop()
        {
            
            if (!particleEffect.isPlaying) return;
            particleEffect.Stop();
        }
        
        
        
    }
