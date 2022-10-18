using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    //all of these can be made into difficulty parameters
    public int numObstacles = 128;
    public float minScale = 1.0f;
    public float maxScale = 10.0f;
    public int numPads = 8;

    //objects to clone for build
    public GameObject obstacle;
    public GameObject pad;

    //place in hierarchy to put them
    public Transform obstacles;
    public Transform pads;


    // Start is called before the first frame update
    void Start()
    {

        //give it a random seed (explain this)
        Random.InitState( (int) System.DateTime.Now.Ticks );

        for (int i = 0; i < numObstacles; i++)
        {
            //lets make a new one
            GameObject newobj = Instantiate(obstacle, obstacles);
                        
            //lets put it someplace
            float x = Random.Range(-50f, 50f);
            float z = Random.Range(-50f, 50f);

            Vector3 pos = new Vector3(x, 0, z);
            newobj.transform.position = pos;

            //lets scale it
            float y = Random.Range(minScale, maxScale);
            x = Random.Range(minScale, maxScale);
            z = Random.Range(minScale, maxScale);

            Vector3 scale = new Vector3(x, y, z);
            newobj.transform.localScale = scale;

        }

        //now remove/delete the creating object so I have exactly numObstacles in my list
        obstacle.transform.parent = null;
        Destroy(obstacle);

        //add the pads. I need to invent some rule to prevent a pad from penetrating
        //a terrain obstacle. simplest thing is to drop them from a height and let 
        //them fall, constraining x,z physics. later we will need to disable physics,
        //AFTER they all hit the ground. prolly check physics sleep.

        for (int i = 0; i < numPads; i++)
        {
            //if I chose a randomly placed obstacle as a start point, I know
            //it will fall to the center point of an obstacle, with a good chance of
            //being on a solid surface. 

            //lets make a new one
            GameObject newobj = Instantiate(pad, pads);

            //just get the child obstacle by number, should be in a totally random place
            float x, y, z;
            x = obstacles.GetChild(i).position.x;
            y = maxScale + 2; //good drop height
            z = obstacles.GetChild(i).position.z;

            Vector3 pos = new Vector3(x, y, z);
            newobj.transform.position = pos;

        }

        //now remove/delete the creating object so I have exactly numPads in my list
        pad.transform.parent = null;
        Destroy(pad);




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
