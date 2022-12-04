using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    [SerializeField] Image FlashPower;
    [SerializeField] GameObject MASKObj;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject charge;
    [SerializeField] GameObject ready;
    private float Num;
    // Start is called before the first frame update
    void Start()
    {
        FlashPower.fillAmount = 0;
        Num = Time.deltaTime/10f;
        canvas.SetActive(true);
        ready.SetActive(false);
        charge.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        FlashPower.fillAmount += Num;

        if (FlashPower.fillAmount >= 1)
        {
            charge.SetActive(false);
            ready.SetActive(true);
            
            if (Input.GetKey("space")){
                Num = 0f;
                StartCoroutine(FlashStart());
            }
        }
           
    }
    IEnumerator FlashStart()
    {
        FlashPower.fillAmount = 0;
        MASKObj.SetActive(false);
        ready.SetActive(false);
        charge.SetActive(true);
        yield return new WaitForSeconds(1);@//spaininterval‚ÌŠÔ‚¾‚¯‘Ò‚Á‚Äwhile‚É–ß‚è‚Ü‚·
        MASKObj.SetActive(true);
        yield return new WaitForSeconds(0.5f);@//spaininterval‚ÌŠÔ‚¾‚¯‘Ò‚Á‚Äwhile‚É–ß‚è‚Ü‚·
        Num = Time.deltaTime/10f;
    }
}
