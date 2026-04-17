using System.Security.Cryptography;
using UnityEngine;

public class MoveCubo : MonoBehaviour
{

    public PlayerStats atributos;

    void Start()
    {
        print("Minha vida inicial é: " + atributos.vidaMaxima);
    }

    // Update is called once per frame
    void Update()
    {
        // Ação: Let o teclado (Setas ou WASD) para mover o jogador
        float eixoX = Input.GetAxis("Horizontal"); // Captura o input horizontal
        float eixoZ = Input.GetAxis("Vertical"); // Captura o input vertical

        // Resultado: Move o jogador com base no input e na velocidade
        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);
        transform.Translate(direcao * atributos.velocidade * Time.deltaTime); // Move o jogador
    }

    public void receberDano(int dano)
    {
        atributos.vidaMaxima -= dano; // Reduz a vida atual do jogador
        atributos.velocidade -= 0.5f; // Reduz a velocidade do jogador a cada dano recebido
        print("Jogador recebeu dano: " + dano);
        print("Vida atual: " + atributos.vidaMaxima);


        if (atributos.vidaMaxima <= 0)
        {
            atributos.vidaMaxima = 0;
            print("O jogador morreu!");
            Destroy(gameObject);
        }
    }
}
