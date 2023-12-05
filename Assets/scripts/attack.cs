using UnityEngine;

public class attack : MonoBehaviour
{
    public float Timer = 1f;
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
