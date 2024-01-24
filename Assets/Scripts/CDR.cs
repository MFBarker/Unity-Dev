using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDR : MonoBehaviour
{
    [SerializeField] float time = 3;
    [SerializeField] bool go = false;

    Coroutine timerCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        timerCoroutine = StartCoroutine(Timer(time));
        StartCoroutine("StoryTime");
        StartCoroutine(WaitAction());
    }

    // Update is called once per frame
    void Update()
    {
        //time -= Time.deltaTime;
        //if (time <= 0)
        //{
        //    time = 3;
        //    print("Hello");
        //}
    }

    IEnumerator Timer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            //check perception
            print("Hello");
        }
        
        //yield return null;
    }

    IEnumerator StoryTime()
    {
        print("Hello");
        yield return new WaitForSeconds(1);
        print("Crazy? I was crazy once");
        yield return new WaitForSeconds(1);
        print("They Locked Me In A Room. A Rubber Room.");
        yield return new WaitForSeconds(1);
        print("A Rubber Room With Rats.");
        yield return new WaitForSeconds(1);
        print("And Rats Make Me Crazy.");

        StopCoroutine(timerCoroutine);



        yield return null;
    }

    IEnumerator WaitAction() 
    {
        yield return new WaitUntil(() => go);
        print("go");

        yield return null;
    }
}
