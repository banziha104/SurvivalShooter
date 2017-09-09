using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit; // 맞춘걸 반환함 
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Debug.Log("Fire");
            Shoot();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;   //선을 지우고 
        gunLight.enabled = false;  // 조명을 끔
    }
    /* */
    void Shoot()
    {
        
        timer = 0f;

        gunAudio.Play ();
        gunLight.enabled = true;

        // gunParticles.Stop (); // 기존 파티클 제거
        // gunParticles.Play (); // 새 파티클 재생

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position); //0은 첫번째 점을 의미하고, transform.position은 위치를 말
        
        shootRay.origin = transform.position; //
        shootRay.direction = transform.forward;
        
        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> (); // 맞춘적의 스크립트를 가져
            if(enemyHealth != null)
            {
                
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
            Debug.Log("shoot");
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            Debug.Log("Don't shoot");
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range); //
        }
    }
}
