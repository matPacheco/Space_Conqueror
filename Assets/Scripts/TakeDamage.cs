using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDamage : MonoBehaviour
{
    public int health;
    public GameObject explosion;
    private GameController score;

    void Start()
    {
        score = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {        
        if(other.CompareTag("Bolt"))
        {
            Destroy(other.gameObject);
            health--;
        }
        if(health <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(explosion, transform.position, transform.rotation);
            score.AddScore(100);
            Invoke(nameof(DelayMenu), 0.5f);
        }
    }
    private void DelayMenu()
    {
        Destroy(gameObject);
        Debug.Log("Funcionou");
        SceneManager.LoadScene("Creditos");
    }
}
