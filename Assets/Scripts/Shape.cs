using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [Header("Set in Inspector: Shape")]
    public float speed = 6f;
    public float health = 3;
	public GameObject explosionParticlesPrefab;

    [Header("Set Dynamically: Shape")]
    public Animator anim;

    public Vector3 pos
    {
        get{return (this.transform.position);}
        set{this.transform.position = value;}
    }
    public void Start()
    {
        anim = GameObject.Find("Dancer").GetComponent<Animator>();
    }
    public void OnCollisionStay(Collision collision)
    {
        Move();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            ShowHit();
            anim.SetTrigger("HIT");
        }
        if (health <= 0 )
        {
            DestroyShape();
            UIManager.EVENT(eUIEvent.destroedShape);
        }
        if (collision.gameObject.tag == "Border")
        {
            DestroyShape();
            UIManager.EVENT(eUIEvent.lostShape);
            anim.SetTrigger("LOST");
            
        }        
    }
    public void Move()
    {
        Vector3 tempPos = pos;
        tempPos.z -= speed * Time.deltaTime;
        pos = tempPos;
    }
    public void DestroyShape()
    {
        if (explosionParticlesPrefab)
        {
            GameObject explosion = (GameObject)Instantiate(
                explosionParticlesPrefab, transform.position, explosionParticlesPrefab.transform.rotation);
            Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
        }
        Destroy(gameObject);
    } 
    public virtual void ShowHit()
    {
    }
}
