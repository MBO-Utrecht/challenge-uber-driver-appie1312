using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carscript : MonoBehaviour
{
    public  float speed = 1.0f;
    public  float rotationspeed = 1.0f;
    public GameController  gameController;
    bool haspackage  = false;








    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log ("game Over: "  + gameController.gameOver );

        if (gameController.gameOver == false) {
            Movecar ();
        }
        else {
            Debug.Log ("je score is "  + gameController.score);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
    if (col.gameObject.CompareTag ("Package")){
        Debug.Log ("Collided with " + col.gameObject.name);
        if (haspackage == false) {
        Destroy  (col.gameObject);
        haspackage  = true;}
        gameController.score++;
        } 

        if (col.gameObject.CompareTag ("Customer")){
            Debug.Log ("klant klaagt");
            if (haspackage == true){
                Destroy (col.gameObject);
                haspackage = false;
                gameController.score++;


    }
        }
    }
    
    void Movecar ()
    {

        float throttle = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        //Debug.Log(throttle);
        transform.Translate(0,throttle * speed * Time.deltaTime,0);
        transform.Rotate(0,0, -steer * rotationspeed * Time.deltaTime);
    }
}
    
