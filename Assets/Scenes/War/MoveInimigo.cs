using UnityEngine;

public class MoveInimigo : MonoBehaviour
{
    public int dano = 10;
    public float velocidade = 2f;
    public float distanciaMinima = 0.75f;
    public Collider plano;

    private Transform alvo;
    private Collider colisaoInimigo;

    private void Start()
    {
        colisaoInimigo = GetComponent<Collider>();

        if (plano == null)
        {
            GameObject chao = GameObject.Find("Chão");

            if (chao != null)
            {
                plano = chao.GetComponent<Collider>();
            }
        }

        GameObject jogador = GameObject.FindGameObjectWithTag("Player");

        if (jogador != null)
        {
            alvo = jogador.transform;
        }
    }

    private void Update()
    {
        if (alvo == null)
        {
            return;
        }

        Vector3 direcao = alvo.position - transform.position;
        direcao.y = 0f;

        if (direcao.magnitude <= distanciaMinima)
        {
            return;
        }

        transform.Translate(direcao.normalized * velocidade * Time.deltaTime, Space.World);
        ManterDentroDoPlano();
    }

    private void ManterDentroDoPlano()
    {
        if (plano == null)
        {
            return;
        }

        Bounds limites = plano.bounds;
        Vector3 margem = colisaoInimigo != null ? colisaoInimigo.bounds.extents : Vector3.zero;
        Vector3 posicao = transform.position;

        posicao.x = Mathf.Clamp(posicao.x, limites.min.x + margem.x, limites.max.x - margem.x);
        posicao.z = Mathf.Clamp(posicao.z, limites.min.z + margem.z, limites.max.z - margem.z);

        transform.position = posicao;
    }

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
