
using UnityEngine;

public class DamageOnTrigger : MonoBehaviour
{

    [SerializeField] private int damageAmount;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        other.gameObject.TryGetComponent(out IDamageable hittable);
        
        if (hittable != null)
        {
            hittable.Damage(damageAmount);
        }
        
            
    }
}
