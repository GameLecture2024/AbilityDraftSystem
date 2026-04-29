using UnityEngine;
using UnityEngine.UI;

public class TestImage : MonoBehaviour
{
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = Managers.Data.IconDict["Icon_KingBible"].iconSprite;
    }


}
