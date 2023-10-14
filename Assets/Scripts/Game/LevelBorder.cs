using UnityEngine;

public class LevelBorder: MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.parent != null)
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
        }

        Destroy(collision.gameObject);
    }
}
