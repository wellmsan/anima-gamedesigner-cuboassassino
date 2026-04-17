using System.Security.Cryptography;
using UnityEngine;

public class MoveJogador : MonoBehaviour
{

    public float velocidade = 5f; // Velocidade de movimento do jogador

    // Update is called once per frame
    void Update()
    {
        // Ação: Let o teclado (Setas ou WASD) para mover o jogador
        float eixoX = Input.GetAxis("Horizontal"); // Captura o input horizontal
        float eixoZ = Input.GetAxis("Vertical"); // Captura o input vertical

        // Resultado: Move o jogador com base no input e na velocidade
        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);
        transform.Translate(direcao * velocidade * Time.deltaTime); // Move o jogador
    }
}
