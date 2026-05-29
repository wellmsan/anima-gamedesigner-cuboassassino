using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCubo : MonoBehaviour
{

    public PlayerStats atributos;
    public float limiteQueda = -5f;
    private int vidaAtual;
    private float velocidadeAtual;
    private Vector2 movimento;

    void Start()
    {
        vidaAtual = atributos.vidaMaxima;
        velocidadeAtual = atributos.velocidade;

        print("Minha vida inicial é: " + vidaAtual);
    }

    // Update is called once per frame
    void Update()
    {
        // Ação: Let o teclado (Setas ou WASD) para mover o jogador
        movimento = LerMovimento();
    }

    private void FixedUpdate()
    {
        // Resultado: Move o jogador com base no input e na velocidade
        Vector3 direcao = new Vector3(movimento.x, 0, movimento.y);
        transform.Translate(direcao * velocidadeAtual * Time.fixedDeltaTime); // Move o jogador

        if (transform.position.y <= limiteQueda)
        {
            Morrer();
        }
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

    public void receberDano(int dano)
    {
        vidaAtual -= dano; // Reduz a vida atual do jogador
        velocidadeAtual = Mathf.Max(0f, velocidadeAtual - 0.5f); // Reduz a velocidade do jogador a cada dano recebido
        print("Jogador recebeu dano: " + dano);
        print("Vida atual: " + vidaAtual);


        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        vidaAtual = 0;
        print("O jogador morreu!");
        Destroy(gameObject);
    }
}
