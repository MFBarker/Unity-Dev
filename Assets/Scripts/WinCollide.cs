using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollide : MonoBehaviour
{
    float timer = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            timer += Time.deltaTime;
            if (timer >= 10.0f)
            {
                GameManager.Instance.GameWin();
            }
        }

    }
}
