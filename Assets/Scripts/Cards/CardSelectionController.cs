using UnityEngine;

public class CardSelectionController : MonoBehaviour
{
    // 在卡牌物件上掛載這個腳本
    void Update()
    {
        // 檢查滑鼠點擊
        if (Input.GetMouseButtonDown(0))  // 按下左鍵 (0 代表左鍵)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // 從滑鼠位置發射射線

            // 發射射線，檢查是否碰撞到卡牌
            if (Physics.Raycast(ray, out hit))
            {
                // 檢查是否點擊到有 Card 腳本的物件
                Card card = hit.transform.GetComponent<Card>();
                if (card != null)
                {
                    card.OnCardClicked();  // 點擊卡牌後，觸發相應的效果
                }
            }
        }
    }
}
