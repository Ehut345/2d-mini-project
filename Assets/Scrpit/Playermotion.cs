using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playermotion : MonoBehaviour
{
    //float horizontal;
    //float vertical;
    Rigidbody2D body;
    Playerinput actions;
    public float speed;
    public Transform shootpoint;

    public int maxhealth = 6;
    public int currenthealth;
    public Healthbar healthbar;
    public Animator anim;
    public UImanager ui;

    private Vector3 _rotate;
    //public float rotationSpeed = 15f;

    // Start is called before the first frame update
    void Awake()
    {
        actions = new Playerinput();
        //actions.Player.Look.performed += ctx => _rotate = ctx.ReadValue<Vector2>();
        //actions.Player.Look.canceled += ctx => _rotate = Vector2.zero;
    }
    private void OnEnable()
    {
        actions.Enable();
    }
    private void OnDisable()
    {
        actions.Disable();
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        healthbar.setmaxhealth(maxhealth);
        currenthealth = maxhealth;
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
        shoot();
        if (currenthealth <= 0)
        {
            gameObject.SetActive(false);
            ui.Endgame();
        }
    }
    public void takedamage()
    {
        currenthealth -= 1;
        healthbar.sethealth(currenthealth);
    }
    void MovePlayer()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Vertical");
        //body.velocity = new Vector2(horizontal * speed, vertical * speed);
        Vector2 move = actions.Player.Move.ReadValue<Vector2>();
        body.velocity = new Vector2(move.x * speed, move.y * speed);
    }
    void RotatePlayer()
    {
        if (!Pausemenu.GameIsPaused)//pc
        {
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        //if (!Pausemenu.GameIsPaused)//android
        //{
        //    Vector3 rotatePlayer = Vector3.forward * _rotate.x * rotationSpeed * Time.deltaTime;
        //    transform.Rotate(rotatePlayer * rotationSpeed, Space.Self);
        //}
    }
    void shoot()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("shoot");
            //GameObject temp = objectPooling.instance.SpwanFrompool("Bullet", shootpoint.position, Quaternion.identity);////old spawner
            GameObject temp = NewPooler.Instance.GetPooledObject("Bullet", shootpoint.position, Quaternion.identity);
            var direction = temp.transform.position - transform.position;
            temp.GetComponent<Bullet>().fire(direction);
        }*/
        if (actions.Player.Fire.triggered && !Pausemenu.GameIsPaused)
        {
            anim.SetTrigger("shoot");
            GameObject temp = NewPooler.Instance.GetPooledObject("Bullet", shootpoint.position, Quaternion.identity);
            var direction = temp.transform.position - transform.position;
            temp.GetComponent<Bullet>().fire(direction);
        }
    }
}
