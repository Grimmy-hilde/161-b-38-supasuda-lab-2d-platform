using UnityEngine;
using UnityEngine.UI; // ต้องมีบรรทัดนี้เพื่อใช้งาน Slider

public class HealthBar : MonoBehaviour
{
    
    [SerializeField] private Slider slider;

    
    public void SetHealth(float currentHealth, float maxHealth)
    {
        if (slider == null)
        {
            Debug.LogWarning("HealthBarController: Slider is not assigned!");
            return;
        }

        if (maxHealth > 0)
        {
            
            slider.value = currentHealth / maxHealth;
        }
    }

    
    private void LateUpdate()
    {
        
        transform.rotation = Quaternion.identity;
    }
}