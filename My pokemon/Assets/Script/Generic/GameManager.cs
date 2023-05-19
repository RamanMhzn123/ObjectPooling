using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Setter<GameManager> //0 duplicate script with different gameobjject
{
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Game Manager Awake");
    }

    public void Button(int index)
    {
        SceneManager.LoadScene(index);
    }
}
