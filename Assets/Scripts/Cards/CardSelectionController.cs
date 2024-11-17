using UnityEngine;

public class CardSelectionController : MonoBehaviour
{
    // �b�d�P����W�����o�Ӹ}��
    void Update()
    {
        // �ˬd�ƹ��I��
        if (Input.GetMouseButtonDown(0))  // ���U���� (0 �N����)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // �q�ƹ���m�o�g�g�u

            // �o�g�g�u�A�ˬd�O�_�I����d�P
            if (Physics.Raycast(ray, out hit))
            {
                // �ˬd�O�_�I���즳 Card �}��������
                Card card = hit.transform.GetComponent<Card>();
                if (card != null)
                {
                    card.OnCardClicked();  // �I���d�P��AĲ�o�������ĪG
                }
            }
        }
    }
}
