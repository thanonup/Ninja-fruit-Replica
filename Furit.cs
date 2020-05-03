using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furit : MonoBehaviour
{

    public GameObject fruitSlicedPrefab;
    public float StartForce = 13f;
    public int point;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * StartForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Blade")
        {
            GameManager.instance.UpScore(point);
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            
            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruit = Instantiate(fruitSlicedPrefab,transform.position,rotation);
            Destroy(slicedFruit,3f);
            Destroy(gameObject);
        }
    }
}
