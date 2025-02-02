using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        Enemy.Instance.Init();
        Player.Instance.Init();
        InventoryManager.Instance.Init();
    }
}
