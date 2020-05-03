using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject BladeTrailPrefeb;
    public float MinCuttingVelocity = .001f;

    GameObject CurrentBladeTrail;
    bool isCutting = false;
    Vector2 previosposition;
    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (GameManager.instance.Gameover == true)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }
    }
    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previosposition).magnitude * Time.deltaTime;
        if(velocity > MinCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }
        previosposition = newPosition;
    }

    void StartCutting()
    {
        isCutting = true;
        CurrentBladeTrail = Instantiate(BladeTrailPrefeb, transform);
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = rb.position;
        circleCollider.enabled = false;    
        
    }
    void StopCutting()
    {
        isCutting = false;
        CurrentBladeTrail.transform.SetParent(null);
        Destroy(CurrentBladeTrail, 1f);
        circleCollider.enabled = false;
    }
}
