using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 상점 구매물품에 들어가는 스크립트
/// 231204 배경택
/// </summary>
public class StoreObject : MonoBehaviour
{
    protected int price;
    private GameObject cantBuyImage;

    protected virtual void Awake()
    {        
        cantBuyImage = Utility.FindChildObj(this.gameObject, "Image(CantBuy)");
        GameEventsManager.instance.coinEvents.onChangeCoin += ChangeButtonUI;       
    }

    private void OnEnable()
    {
        ChangeButtonUI(0);
    }

    private void OnDestroy()
    {
        GameEventsManager.instance.coinEvents.onChangeCoin -= ChangeButtonUI;
    }

    // 상점 UI버튼 누르면 실행되는 함수
    protected virtual void BuyStoreObject() 
    {        
        CoinManager.instance.UseCoin(price); //코인 반영
    }

    /// <summary>
    /// 구매 불가 소리 재생
    /// </summary>
    protected void PlayCantBuySound()
    {
        // 사운드 추가
        SoundManager.instance.PlaySound(GroupList.UI, (int)UISoundList.Cant_BuySound);
    }

    /// <summary>
    /// 구매 가능 소리 재생
    /// </summary>
    protected void PlayCanBuySound()
    {
        // 사운드 추가
        int id = (int)UISoundList.Can_BuySound;
        SoundManager.instance.PlaySound(GroupList.UI, id);
    }

    /// <summary>
    /// 버튼 검정색 이미지로 덮을지 덮지 않을지 변경
    /// </summary>
    protected void ChangeButtonUI(int temp)
    {
        if (IsCanBuy()) cantBuyImage.SetActive(false);
        else cantBuyImage.SetActive(true);
    }

    // 구매 가능여부를 체크하는 함수
    protected bool IsCanBuy()
    {
        if (CoinManager.instance.currentCoin >= price) return true;        
        else return false;
    }
}
