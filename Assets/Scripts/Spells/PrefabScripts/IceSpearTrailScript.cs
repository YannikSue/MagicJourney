using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpearTrailScript : MonoBehaviour
{
    GameObject Projectile;

    ParticleSystem Ps;

    public void AddGameObject(GameObject projectile)
    {
        this.Projectile = projectile;
        this.Ps = this.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(Projectile != null)
        {
            this.transform.position = Projectile.transform.position;
        } else if(Ps.particleCount <= 0 && Projectile == null)
        {
            Destroy(Ps.gameObject);
        }
    }
}
