using UnityEngine;
using System.Collections;

public class CardModel {
    public string cardNumber, cardName, cardLifePoint, cardAttack, cardSpeed, attackRange, gold,
           attackType, cardAttribute, cardPicturePath, effectCmd, effectInfo, state;
    public string[] cardAlbums;
    public string[] info;

    public CardModel(string [] info) {
        this.cardNumber = info[0];
        this.cardName = info[1];
        this.cardLifePoint = info[2];
        this.cardAttack = info[3];
        this.cardSpeed = info[4];
        this.attackRange = info[5];
        this.attackType = info[7];
        this.gold = info[8];
        this.cardAttribute = info[9];
        this.cardPicturePath = info[10];
        this.cardAlbums = info[11].Split('/');
        this.state = "OnHand";
        this.info = info;
    }

}
