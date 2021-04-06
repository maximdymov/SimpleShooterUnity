using TMPro;
using UnityEngine;

public class GameInfoView : MonoBehaviour
{
    [SerializeField] private TMP_Text lifeView;
    [SerializeField] private TMP_Text scoreView;
    [SerializeField] private TMP_Text ammoView;

    private int enemiesDead = 0;

    private void OnEnable()
    {
        EnemyInfo.EnemyDead += RefreshScore;
    }

    private void Update()
    {
        lifeView.text = $"Lifes: {PlayerInfo.GetPlayerHealth()}";
        ammoView.text = $"Ammo: {PlayerInfo.GetAmmoCount()}";
    }

    private void RefreshScore()
    {
        enemiesDead += 1;
        scoreView.text = $"Score: {enemiesDead}";
    }
}
