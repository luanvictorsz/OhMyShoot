using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Attack configs")]
    [SerializeField] private Camera cam;
    [SerializeField] private int maxAmmun = 10;
    [SerializeField] private int currentAmmun;
    [SerializeField] private GameObject prefabImpact;

    [SerializeField] public Animator anim;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            anim.SetTrigger("Shoot");
            RaycastHit hit;

            if (currentAmmun > 0)
            {
                currentAmmun--;
                anim.SetTrigger("Shooting");

                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(prefabImpact, hit.point, Quaternion.identity);
                    //Debug.Log("Hit: " + hit.transform.name);
                }
                else
                {
                    Debug.Log("Missed");
                }

                Debug.Log("Current ammun: " + currentAmmun);
            }
            else
            {
                Debug.Log("No ammun");
                return;
            }

            
        }  
    }
}
