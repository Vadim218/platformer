using UnityEngine;

public class dead : MonoBehaviour {
    public GameObject respa;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            collision.transform.position = respa.transform.position;
        }
    }


}
