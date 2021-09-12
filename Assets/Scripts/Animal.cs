using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] int puntosDeVida;
    [SerializeField] GameManager gm;

    bool PowerActive = true;

    int Contador = 0;
    int RContador;
    int RpuntodDeVida;

    float minX, maxX;
    float tiempo = 0;
    float Limittiempo = 5;
 

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;

        RContador = Contador;
        RpuntodDeVida = puntosDeVida;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingRight)
        {
            Vector2 movimiento = new Vector2(speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        else
        {
            Vector2 movimiento = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        

        if(transform.position.x >= maxX)
        {
            movingRight = false;
        }
        else if(transform.position.x <= minX)
        {
            movingRight = true;
        }

        if (PowerActive == true)
        {
            PoweUp();
        }

    }


    
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if(collision.gameObject.CompareTag("Disparo") )
        {   
            int puntos = collision.gameObject.GetComponent<Bullet>().Dano();
            puntosDeVida = puntosDeVida - puntos;

            if(puntosDeVida <= 0)
            {
              gm.ReducirNumEnemigos();
              Destroy(this.gameObject);
            } 
        }
    }

    void PoweUp()
    {
        if (Input.GetKeyDown(KeyCode.X) && Time.unscaledTime >= tiempo)
        {
            puntosDeVida = 1;
            Time.timeScale = 0.5f;

            tiempo = Time.unscaledTime + Limittiempo;

            RContador++;

        }

        if(tiempo <= Time.unscaledTime)
        {
            Time.timeScale = 1f;
            puntosDeVida = RpuntodDeVida;

            if(RContador == 3)
            {
                PowerActive = false;
            }
        }

    }

}