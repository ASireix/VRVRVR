using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectionnerDesTrucs : MonoBehaviour
{

    private int nbCollectables;
    public  GameObject banderolle;
    public  GameObject banderolle1;
    public  GameObject banderolle2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
      if( other.gameObject.layer == 6)
      {
        Destroy(other.gameObject);
        nbCollectables++;
        if(nbCollectables == 2)
        {
          Destroy(banderolle2);
        }
        else if (nbCollectables == 4)
        {
          Destroy(banderolle1);
        }
        else if (nbCollectables == 6) {
          Destroy(banderolle);
        }
      }
    }
}
