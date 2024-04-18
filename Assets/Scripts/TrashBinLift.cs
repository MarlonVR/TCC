using System.Collections;
using UnityEngine;

public class TrashBinLift : MonoBehaviour
{
    public GameObject[] lixeiras; // Arraste suas lixeiras aqui no Inspector, na ordem correta
    public float targetHeight; // A altura em que a lixeira vai parar
    public float speed = 2f; // A velocidade com que a lixeira emerge
    public float delayBetweenLixeiras = 1f; // O tempo de atraso entre a subida de cada lixeira

    void Update(){
		
	}

    public void StartElevatingLixeiras()
    {
        StartCoroutine(ElevateLixeirasInOrder());
    }

    private IEnumerator ElevateLixeirasInOrder()
    {
        foreach (var lixeira in lixeiras)
        {
            // Mova a lixeira para a altura alvo
            yield return StartCoroutine(ElevateLixeira(lixeira));
            // Aguarde um pouco antes de mover a próxima lixeira
            yield return new WaitForSeconds(delayBetweenLixeiras);
        }
    }

    private IEnumerator ElevateLixeira(GameObject lixeira)
    {
        Vector3 startPos = lixeira.transform.position;
        Vector3 endPos = new Vector3(startPos.x, targetHeight, startPos.z);

        while (lixeira.transform.position.y < targetHeight)
        {
            lixeira.transform.position = Vector3.MoveTowards(lixeira.transform.position, endPos, speed * Time.deltaTime);
            yield return null;
        }
    }
}
