using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Ball : MonoBehaviour {

    static private int _count = 0;

    static public int Count
    {
        get
        {
            return _count;
        }
    }

	void Start () {
        _count++;

        StartCoroutine(DeleteBall(30f));
    }

    IEnumerator DeleteBall(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }	

    void OnDestroy()
    {
        _count--;
    }

    // 玉が重ならないようにする
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            var delta = ( col.gameObject.transform.position - this.gameObject.transform.position ).normalized;
            GetComponent<Rigidbody2D>().AddForce(delta / 30);
            //this.gameObject.rigidbody2D.AddForce(delta/30);
        }
    }

    // 玉が重ならないようにする
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            var delta = (col.gameObject.transform.position - this.gameObject.transform.position).normalized;
            GetComponent<Rigidbody2D>().AddForce(delta / 30);
            //this.gameObject.rigidbody2D.AddForce(delta / 30);
        }
    }
}
