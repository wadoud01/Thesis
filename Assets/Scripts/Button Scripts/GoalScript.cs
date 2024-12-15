using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;











public class GoalScript : MonoBehaviour
{
    public GameObject dog;
    public GameObject cat;
    public GameObject paper;


    public void Onbutton()
    {
        dog.SetActive(false);
        cat.SetActive(true);




    }
}
