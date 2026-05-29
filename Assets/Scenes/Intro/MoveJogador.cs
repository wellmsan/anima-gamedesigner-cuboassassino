using UnityEngine;
using UnityEngine.InputSystem;

public class MoveJogador : MonoBehaviour
{

    public float velocidade = 5f; // Velocidade de movimento do jogador

    // Update is called once per frame
    void Update()
    {
        // Ação: Let o teclado (Setas ou WASD) para mover o jogador
        Vector2 movimento = LerMovimento();

        // Resultado: Move o jogador com base no input e na velocidade
        Vector3 direcao = new Vector3(movimento.x, 0, movimento.y);
        transform.Translate(direcao * velocidade * Time.deltaTime); // Move o jogador
    }

    private Vector2 LerMovimento()
    {
        Keyboard teclado = Keyboard.current;

        if (teclado == null)
        {
            return Vector2.zero;
        }

        Vector2 movimento = Vector2.zero;

        if (teclado.aKey.isPressed || teclado.leftArrowKey.isPressed)
        {
            movimento.x -= 1f;
        }

        if (teclado.dKey.isPressed || teclado.rightArrowKey.isPressed)
        {
            movimento.x += 1f;
        }

        if (teclado.sKey.isPressed || teclado.downArrowKey.isPressed)
        {
            movimento.y -= 1f;
        }

        if (teclado.wKey.isPressed || teclado.upArrowKey.isPressed)
        {
            movimento.y += 1f;
        }

        return Vector2.ClampMagnitude(movimento, 1f);
    }
}
