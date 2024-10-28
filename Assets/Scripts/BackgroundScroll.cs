using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    public static BackgroundScroll Instance { get ; private set; }
    public float scrollSpeed = 5f ;
    public float increase_speed = 0.01f ;
    
    [SerializeField] private Button retryButton;

    public void Awake()
    {
        if(Instance != null && Instance != this) 
         {
            gameObject.SetActive(true);
         } 
        else
         {
            Instance = this;
         }
    }
    private void Start()
    {
        NewGame();
    }
    public void NewGame()
    {   
        scrollSpeed = 2f ;
        enabled = true;
        retryButton.gameObject.SetActive(false);
    }      
    public void GameOver()
    {
        scrollSpeed = 0f;
        enabled = false;
        SceneManager.LoadScene("GameOver");
        retryButton.gameObject.SetActive(true);
    }
    public void Update()
    {   
        scrollSpeed += increase_speed * Time.deltaTime;
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        if (transform.position.x < -10) 
        {
            transform.position = new Vector3(0, 0, 0); 
        }
    }
    }