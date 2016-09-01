using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public int startHealth = 100;
    public int currentHealth;
    bool isDead = false;
    public float attackSpeed = 0.5f;
    public int attackDamage = 10;
    bool inRange;
    float timer;
    Health playerHealth;
    GameObject player;
    //EnemyHealth enemyHealth;
	// Use this for initialization
	void Start ()
    {
        currentHealth = startHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
        //enemyHealth = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(inRange)
        {
            timer += Time.deltaTime;
        }
        if(timer >= attackSpeed && inRange && currentHealth > 0)
        {
            //attack();
        }

	}

    void attack()
    {
        timer = 0;
        if (playerHealth.currenthealth > 0)
        {
            playerHealth.takeDamage(attackDamage);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
           inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject == player)
        {
            inRange = false;
        }
    }


    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth < 0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        //play death animation here
        isDead = true;

    }
}
