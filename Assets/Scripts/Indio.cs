using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Indio : MonoBehaviour

{
    public float speed = 300;
    private float _h, _v;
    public float timeRate = 0;
    public float maxTime = 1;
    public bool canTripleShoot = false;

    public GameObject prefabBala;

    private Rigidbody2D _rb2dBody;

    void Start()
    {
        _rb2dBody = GetComponent<Rigidbody2D>();
    }

    private void TripleShoot()
    {
        Instantiate(prefabBala, transform.position + new Vector3(0, 1, 0), transform.rotation);
        Instantiate(prefabBala, transform.position + new Vector3(0.5f, 0.5f, 0), transform.rotation);
        Instantiate(prefabBala, transform.position + new Vector3(-0.5f, 0.5f, 0), transform.rotation);
    }
    
    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Jump")){
            Jump();
            new WaitForSeconds(115);
        }

        Shoot();

        ScreenBounds();
    }

    private void OneShoot()
    {
        Instantiate(prefabBala, transform.position + new Vector3(1, 0, 0), transform.rotation);
    }


    void Jump(){
       transform.position += new Vector3 (0.0f, 1.5f, 0f);
        
    }

      public void Shoot()
    {
        timeRate += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (timeRate >= maxTime)
            {
                if (!canTripleShoot){
                    OneShoot();
                }
                else{
                    OneShoot();
                }
                timeRate = 0;
            }
        }
    }

     public void ScreenBounds()
    {
        if (transform.position.x >= 10.0f)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -10.0f)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
        if (transform.position.y >= 2.2f)
        {
            transform.position = new Vector3(transform.position.x, 2.2f, transform.position.z);
        }
        if (transform.position.y <= -4.4f)
        {
            transform.position = new Vector3(transform.position.x, -4.4f, transform.position.z);
        }
    }

    void FixedUpdate()
    {
        _rb2dBody.velocity = new Vector2(_h * speed * Time.deltaTime,0);
        
    }
    
}