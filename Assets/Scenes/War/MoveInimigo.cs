using UnityEngine;

public class MoveInimigo : MonoBehaviour
{
    public int dano = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoveCubo jogador = collision.gameObject.GetComponent<MoveCubo>();

            if (jogador != null)
            {
                jogador.receberDano(dano);
            }
        }
    }
}