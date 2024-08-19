using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    bool alive = true;
    private Rigidbody rg;

    public float speedIncreasedPerPoint = 0.1f;
    //public Rigidbody rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (!alive)
            return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rg.MovePosition(rg.position + forwardMove);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    public void Die()
    {
        alive = false;
        Invoke("Restart",0.5f);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGround = Physics.Raycast(transform.position, Vector3.down, (height / 2) * 0.1f, groundMask);

        rg.AddForce(Vector3.up * jumpForce);
    }
}
