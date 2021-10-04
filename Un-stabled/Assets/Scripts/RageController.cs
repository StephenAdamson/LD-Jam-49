using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageController : MonoBehaviour
{
    private const float chargeRate = 0.833333333f;
    private const float drainRate = 5f;

    private const int MinRage = 25;
    public float _rage;
    private float rage {
        get { return _rage; }
        set {
            _rage = value;
            // bar.sizeDelta = new Vector2(200 * (_rage/max), 20);
            // icon.sprite = _rage > 75 || _isRaging ? sprite3 :
            //     _rage > 50 ? sprite2 :
            //     _rage > 25 ? sprite1 :
            //     null;
        }
    }

    public float startRage;
    public float max;

    public Image icon;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    

    // public RectTransform bar;

    // Raging can only be started by this class
    public bool _isRaging;
    public void StartRage() {
        rage = max;
        if (rage > MinRage) {
            _isRaging = true;
        }
        GameManager.Instance.lm.rageVignette.color = new Color(1, 1, 1, .2f);
    }
    // Start is called before the first frame update
    void Start()
    {
        rage = startRage;
        GameManager.Instance.lm.rageVignette.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) StartRage();

        if (!_isRaging) {
            GameManager.Instance.lm.rageVignette.color = new Color(1, 1, 1, 0);
            if (rage >= max) return;
            rage += chargeRate * Time.deltaTime;
        } else {
            rage -= drainRate * Time.deltaTime;
            if (rage < 0) {
                rage = 0;
                _isRaging = false;
                GameManager.Instance.lm.rageVignette.color = new Color(1, 1, 1, 0);
            }
        }
    }
}