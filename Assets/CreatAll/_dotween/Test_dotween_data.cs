using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_dotween_data : MonoBehaviour
{
    [SerializeField] Text text;
    public void Contents(int num)
    {
        switch (num)
        {
            case 0:
                Debug.LogError("”Žš‚ð“ü‚ê‚Ä‚­‚¾‚³‚¢I");
                break;
            case 1:
                this.transform.DOMoveX(5, 1f);
                break;
            case 2:
                this.transform.DORotate(new Vector3(0, 240, 0), 2f).SetEase(Ease.OutBounce);
                break;
            case 3:
                this.transform.DOScale(new Vector3(2, 2, 2), 2f).SetEase(Ease.OutBounce);
                break;
            case 4:
                this.transform.DOMoveX(5, 1f).OnComplete(() =>
                {
                    Debug.Log("ˆÚ“®I—¹");
                });
                break;
            case 5:
                this.transform.DOMoveX(5, 1f).SetDelay(0.4f);
                break;
            case 6:
                this.transform.DOMoveX(5, 1f)
                    .SetDelay(0.4f)
                    .SetEase(Ease.InExpo)
                    .OnComplete(() => { Debug.Log("OK"); });
                break;
            case 7:
                this.transform.DOMoveX(5, 1f).SetRelative();
                break;
            case 8:
                DOTween.Sequence()
                    .Append(this.transform.DOMoveX(3, 1f).SetRelative())
                    .Append(this.transform.DOMoveY(-3, 1f).SetRelative())
                    .Play();
                break;
            case 9:
                DOTween.Sequence()
                    .Append(this.transform.DOMoveX(3, 1f).SetRelative())
                    .Append(this.transform.DOMoveY(-3, 1f).SetRelative())
                    .Join(this.transform.DORotate(new Vector3(0, 300, 0), 1f).SetRelative())
                    .Play();
                break;
            case 10:
                DOTween.Sequence()
                    .Append(this.transform.DOMoveX(3, 1f).SetRelative())
                    .Append(this.transform.DOMoveX(-3, 2f).SetRelative())
                    .SetLoops(5)
                    .Play();
                break;
            case 11:
                var material = GetComponent<MeshRenderer>().material;
                material.DOColor(Color.cyan, 2f);
                break;
            case 12:
                DOVirtual.Float(0f, 100f, 3f, value =>
                {
                    text.text = "Count : " + (int)value;
                });
                break;
        }
    }
}
