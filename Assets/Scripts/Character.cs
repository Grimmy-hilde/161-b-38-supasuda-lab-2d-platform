using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private int health;
    public int Health {  
        get { return health; } 
        set { health = (value < 0) ? 0 : value; }
    }

    public int MaxHealth;

    protected Animator anim;
    protected Rigidbody2D rb;
    [SerializeField] private HealthBar healthBar;


    public void Initialize (int startHealth)
    {
        Health = startHealth;
        MaxHealth = startHealth;
        Debug.Log($"{this.name} health is {this.Health}.");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} take {damage} damage, Current Health {Health}");
        if (healthBar != null)
        {
            healthBar.SetHealth(Health, MaxHealth);
        }

        IsDead();
    }

    public bool IsDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else { return false; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (healthBar != null)
        {
            // (สมมติว่าสคริปต์ของคุณมีตัวแปรชื่อ Hp และ MaxHp)
            healthBar.SetHealth(Health , MaxHealth);
        }
        else
        {
            Debug.LogWarning("Health bar is not assigned on " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
