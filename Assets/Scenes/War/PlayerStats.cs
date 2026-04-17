using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Sistema/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    [Header("Atributos do Jogador")]
    public int vidaMaxima;
    public float velocidade;
}
