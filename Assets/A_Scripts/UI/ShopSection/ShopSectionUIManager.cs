using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSectionUIManager : MonoBehaviour
{
    [SerializeField] GameObject weaponSection;
    [SerializeField] GameObject consumeableSection;
    [SerializeField] GameObject tresureSection;

    public void WeponSectionSelected()
    {
        weaponSection.SetActive(true);
        consumeableSection.SetActive(false);
        tresureSection.SetActive(false);
    }

    public void ConsumeableSectionSelected()
    {
        weaponSection.SetActive(false);
        consumeableSection.SetActive(true);
        tresureSection.SetActive(false);
    }

    public void TresureSectionSelected()
    {
        weaponSection.SetActive(false);
        consumeableSection.SetActive(false);
        tresureSection.SetActive(true);
    }







}
