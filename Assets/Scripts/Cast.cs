using UnityEngine;

public class Cast : MonoBehaviour
{
    private Vector3 mousePos;
    public float spellSpeed = 4f;
    public float spellDuration = 1f;
    public int spellDamage = 20;

    public void CastSpell(Vector3 casterPos)
    {
        mousePos = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = -new Vector3(mousePos.x, mousePos.y, this.transform.position.z).normalized;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);

        Destroy(gameObject, spellDuration);
    }

    void Update()
    {
        this.transform.Translate(mousePos * Time.deltaTime * spellSpeed, Space.World);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null)
        {

            enemy.TageDamage(spellDamage);
        }

        if(!hitInfo.GetComponent<Player>())
        Destroy(gameObject);
    }

}