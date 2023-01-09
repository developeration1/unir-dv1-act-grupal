using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [SerializeField] UiManager ReferenciaUI;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject miniUva;
    //numero que determina el numero de fruta
    public int FruitID = 0;
    //0 - Bomba
    //1 - Naranja
    //2 - Coco
    //3 - Uvas
    //4 - Uva individual

    //solo para cocos
    public int FruitLife = 3;

    // Start is called before the first frame update
    void Start()
    {
        //No considero esto la manera mas eficiente, pero como estamos trabajando por escenas no queria hacer
        //una hard reference al UI object
        ReferenciaUI = GameObject.FindGameObjectWithTag("UI").GetComponent<UiManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //Ya que la fruta spawnea debajo de el screen, no quiza usar funciones que detectan salir de la pantalla, 
        //sino que use un valor de y bajo mas bajo que donde spawnearemos la fruta
        if (transform.position.y < -10f)
            OffscreenFruit();
    }

    public void BombExplosion()
    {
        //Instanciar la particula de explocion aqui luego

        //
        GameObject Explosion = Instantiate(explosionPrefab) as GameObject;
        Explosion.transform.position = transform.position;
        ReferenciaUI.PerderVida();
        Destroy(this.gameObject);
    }

    public void FruitExplosion(int x)
    {
        //Instanciar la particula de explocion aqui luego

        //
        GameObject Explosion = Instantiate(explosionPrefab) as GameObject;
        Explosion.transform.position = transform.position;
        ReferenciaUI.AddScore(x);
        Destroy(this.gameObject);
    }

    public void ManageCoco()
    {
        FruitLife--;
        //si da tiempo, cambio visual aqui

        //
        if (FruitLife <= 0)
            FruitExplosion(300);
    }

    public void CreateUvas()
    {
        //Instanciar las 3 miniuvas aqui
        GameObject miniUva1 = Instantiate(miniUva) as GameObject;
        miniUva1.transform.position = transform.position + new Vector3(0,0.5f,0);
        GameObject miniUva2 = Instantiate(miniUva) as GameObject;
        miniUva2.transform.position = transform.position + new Vector3(0.5f,0,0);
        GameObject miniUva3 = Instantiate(miniUva) as GameObject;
        miniUva3.transform.position = transform.position + new Vector3(-0.5f,0,0);
        //
        FruitExplosion(100);
    }

    public void OnMouseDown()
    {
        switch(FruitID)
        {
            case 0: //bomba
                BombExplosion();
                break;

            case 1: //naranja
                FruitExplosion(100);
                break;
            case 2: //coco
                ManageCoco();
                break;
            case 3: //uva
                CreateUvas();
                break;
            case 4: //miniuva
                FruitExplosion(50);
                break;
            default: 
                Destroy(this.gameObject);
                break;
        }
    }

    public void OffscreenFruit()
    {
        if(FruitID != 0)//las bombas no quitan vida al salir de la pantalla
        ReferenciaUI.PerderVida();
        Destroy(this.gameObject);
    }
}
