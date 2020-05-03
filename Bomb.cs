using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject BombFx;
    public float StartForce = 13f;
    public int point = 0;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * StartForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blade")
        {
            GameManager.instance.GameOver();
            //GameManager.instance.UpScore(point);
            //Vector3 direction = (collision.transform.position - transform.position).normalized;

            //Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject bombfx = Instantiate(BombFx, transform.position, Quaternion.identity);
            Destroy(bombfx, 3f);
            Destroy(gameObject);
        }
    }
}
