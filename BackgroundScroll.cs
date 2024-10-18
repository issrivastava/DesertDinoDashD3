using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
public float scrollSpeed = 5f;
public static BackgroundScroll Instance 
    { 
        get ;
        private set;
    }

private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            gameObject.SetActive(false);
        } 
        else{
            Instance = this;
         }
    }
private void Start()
{
    NewGame();
}
private void NewGame()
{
    scrollSpeed = 5f ;
    enabled = true;
}      
  public void GameOver()
    {
        scrollSpeed = 0f;
        enabled = false;
    }
private void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        scrollSpeed += scrollSpeed *  Time.deltaTime / 1000  ;
    }
}