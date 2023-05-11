using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandosBasicos : MonoBehaviour
{

    public int velocidade;// define a velocidade de movimentação 
    private Rigidbody2D rbPlayer; // criar variavel para receber os componetes de física 
    public float forcaPulo; // define a força do pulo 


    public bool sensor; //sensor para verificar se o sensor esta colidindo com o chao
    public Transform posicaoSensor; //posiçãoonde o sensor será posicionado
    public LayerMask layerChao; //Camada de interação



    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimentoX = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(movimentoX * velocidade, rbPlayer.velocity.y);

        if(Input.GetButtonDown("Jump") && sensor == true)
        {
            rbPlayer.AddForce(new Vector2(0, forcaPulo));
        }
    }



    private void FixedUpdate()
    {
        //cria um sensor em posição definida com o raio e layer tb definidas 
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f ,layerChao);
    }
}







