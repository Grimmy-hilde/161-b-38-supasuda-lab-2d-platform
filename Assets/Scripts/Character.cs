using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private int health;
    public int Health {  
        get { return health; } 
        set { health = (value < 0) ? 0 : value; }
    }

    protected Animator anim;
    protected Rigidbody2D rb;

    public void Initialize (int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} health is {this.Health}.");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} take {damage} damage, Current Health {Health}");

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
