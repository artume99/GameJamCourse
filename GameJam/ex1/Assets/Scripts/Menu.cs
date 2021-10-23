using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
   private int currentBulletType = 0;
   public Image currentBulletSprite;
   public Animator menuAnimator;
   private string menuTrigger = "Hide";
   
   public void OnArrowClick(bool right)
   {
      if (right)
      {
         currentBulletType++;
         if (currentBulletType == Shooter.instance.bulletSprites.Length)
         {
            currentBulletType = 0;
         }
         
      }

      else
      {
         currentBulletType--;
         if (currentBulletType < 0)
         {
            currentBulletType = Shooter.instance.bulletSprites.Length - 1;
         }
      }
      OnBulletSelection();
   }

   public void OnAmmoPress()
   {
      Debug.Log(menuTrigger);
      if (menuTrigger == "Hide")
      {
         menuTrigger = "Show";
      }
      else
      {
         menuTrigger = "Hide";
      }
      menuAnimator.SetTrigger(menuTrigger);
   }

   public void OnBulletSelection()
   {
      currentBulletSprite.sprite = Shooter.instance.bulletSprites[currentBulletType];
      Shooter.instance.SetBulletSprite(currentBulletSprite.sprite);
   }
}
