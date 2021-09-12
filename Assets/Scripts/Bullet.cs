using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int puntosDeDano; 
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public int Dano()
    {
        return puntosDeDano;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;

        string etiqueta = objeto.tag;

        Destroy(this.gameObject);

    }
}
