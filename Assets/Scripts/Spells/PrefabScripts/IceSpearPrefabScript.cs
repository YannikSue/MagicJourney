using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpearPrefabScript : MonoBehaviour
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

        GameObject iceSpearTrail = MonoBehaviour.Instantiate(Resources.Load("IceSpear/IceSpearTrail") as GameObject, casterPos, new Quaternion());
        iceSpearTrail.GetComponent<IceSpearTrailScript>().AddGameObject(gameObject);

        Destroy(gameObject, spellDuration);
    }

    void Update()
    {
        this.transform.Translate(mousePos * Time.deltaTime * spellSpeed, Space.World);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Debug.Log(hitInfo.gameObject.name);

        if (enemy != null)
        {
            enemy.TageDamage(spellDamage);
        }

        if (!hitInfo.GetComponent<Player>())
        {
            GameObject impactParticles = (Resources.Load("IceSpear/IceSpearImpact") as GameObject);
            MonoBehaviour.Instantiate(impactParticles, gameObject.transform.position, new Quaternion());
            Destroy(gameObject);
        }
    }
}
