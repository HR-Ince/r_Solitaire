using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplayLibrary : MonoBehaviour
{
    public TMP_Text nameText = null;
    public Image image = null;
    public TMP_Text typeText = null;
    public GameObject costContainer = null;
    public List<Image> costImages = null;
    public List<TMP_Text> costTexts = null;
    public GameObject rankContainer = null;
    public TMP_Text rankText = null;
    public GameObject contributionContainer = null;
    public List<Image> contributionImages = null;
    public List<TMP_Text> contributionTexts = null;
    public TMP_Text descriptionText = null;
    public GameObject atkDefHolder = null;
    public TMP_Text atkText = null;
    public TMP_Text defText = null;
}
