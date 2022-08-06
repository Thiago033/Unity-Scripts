using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject card;

    //public List<GameObject> deckMonsters = new List<GameObject>();
    //public List<GameObject> deckNilfgaard = new List<GameObject>();
    //etc...

    [SerializeField]
    List<GameObject> cards = new List<GameObject>();

    public GameObject playerArea;
    public GameObject player2Area;

    public GameObject playerDropZone;
    public GameObject player2DropZone;

    
    // Start is called before the first frame update
    public override void OnStartClient(){
        base.OnStartClient();

        playerArea = GameObject.Find("PlayerArea");
        player2Area = GameObject.Find("Player2Area");

        playerDropZone = GameObject.Find("PlayerDropZone");
        player2DropZone = GameObject.Find("Player2DropZone");
    }

    [Server]
    public override void OnStartServer(){
        cards.Add(card);
    }

    [Command]
    public void CmdDealCards(){
        //um FOR para cada player com "i = deck(X).lengh"
        //GameObject playerCards = Instantiate(deckMonsters[i], new Vector3(0,0,0), Quaternion.identity);

        for (int i = 0; i < 5; i++)
        {   
            GameObject card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector2(0,0), Quaternion.identity);

            NetworkServer.Spawn(card, connectionToClient);
            RpcShowCards(card, "Dealt");
        }
    }
    
    [ClientRpc]
    void RpcShowCards(GameObject card, string type){
        if (type == "Dealt")
        {
            if (hasAuthority)
            {
                card.transform.SetParent(playerArea.transform, false);
            }
            else
            {
                card.transform.SetParent(player2Area.transform, false);
                card.GetComponent<CardFlip>().Flip();
            }
        }
        else if(type == "Player")
        {
            card.transform.SetParent(playerDropZone.transform, false);
            if (!hasAuthority)
            {
                card.GetComponent<CardFlip>().Flip();
            }
        }
    }

    public void PlayCard(GameObject card){
        CmdPlayCard(card);
    }

    [Command]
    void CmdPlayCard(GameObject card){
        RpcShowCards(card, "Played");
    }
}