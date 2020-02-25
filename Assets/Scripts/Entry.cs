using UnityEngine;

public class Entry : MonoBehaviour
{
    // Set public properties in Unity
    public Sprite icon;

    private GameObject player { get; set; }
    private GameObject obj { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        if (obj != null && obj.GetComponent<Renderer>().enabled)
        {
            obj.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.4f);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Enter Tavern");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            obj = new GameObject("Entry");
            SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
            renderer.sprite = icon;
            renderer.sortingLayerName = "UI";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(obj);
    }
}