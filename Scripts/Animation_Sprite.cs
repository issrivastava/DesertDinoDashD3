using UnityEngine;

public class Animation_Sprite : MonoBehaviour
{
public Sprite[] sprites ;
private SpriteRenderer spriteRenderer  ;
private int frame;

 private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
private void OnEnable()
{
    Invoke(nameof(Animate), 0f );
}
private void OnDisable()
{
    CancelInvoke();
}
private void Animate()
{
    frame++ ;
    if(frame >= sprites.Length)
    {
        frame = 0;
    }
    if ((frame >=0 ) && (frame < sprites.Length))
    {
       spriteRenderer.sprite = sprites[frame];
    }
    Invoke(nameof(Animate), 5f / BackgroundScroll.Instance.scrollSpeed);
}
}