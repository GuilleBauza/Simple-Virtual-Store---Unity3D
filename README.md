# Simple-Virtual-Store---Unity3D
A Plugin for a simple Virtual store for your game on Unity3D. 

#This repository was created by Guille Bauza.

#META of Simple Virtual Store: 
>Simple Virtual Store was made mainly for Unity3D, but you can try and use it wherever you need and allow dll files. 

#Making the plugin better:
 >You can edit and/or add features, as long as its functional and useful for others.

##Tutorial Video (Unity3D): [Youtube Tutorial](https://www.youtube.com/watch?v=mvTDNbV1pu8&lc=z12mwlgaptr2drurz04cerawzrbfzdv42yw0k).
 >Feel free to replace it or add more as long as its helpful.
 
#Unity3D Guide:
1. Import to unity asset folder our dll file.
2. Importing our library/namespace to our project: `using VirtualStore;`
3. We create a C# Script called as example: **StoreManagerExample**, call it how ever you want.
  - This will manage our virtual store.
4. Start creating items to sell:
  - **Create "blue gem" item.**
   ```
   MyVirtualStore blueGem;
   void Start()
   {
     //Create Store Item "blueGem".
     //object has the following format(name, price, amount).
     blueGem = new MyVirtualStore("Blue Gem", 100.34f, 10);
   }
 ```
5. Using our presset currency:
  - **Way to add currency #1:**
 ```
 MyCurrency.addCurrency(1000, MyCurrency.CURRENCY_TYPE.INTEGER); //(amount, value type)
 ```
  - **Way to add currency #2:**
 ```
 MyCurrency.currency = 1000.45f; // (float)
 MyCurrency.Currency_Type = MyCurrency.CURRENCY_TYPE.DECIMAL; // (float)
 ```
 
  - **Way to add currency #3:**
 ```
 MyCurrency.addCurrency(1000); //(amount)
 MyCurrency.Currency_Type = MyCurrency.CURRENCY_TYPE.DECIMAL; // (float)
 ```
6. Buy functions:
 - Buy Items functions example:
 ```
 /**
 Important: you should manage your save and load assets information.
 The following method will delete all information if the game stop.
 */
 
 // create a item holder, this will contain all blue gems you actually have. (Refer Important notice above).
 public static long MyCurrent_Blue_Gem_Amount = 0;
 
 //create simple buy function.
 public void BuyBlueGem()
 {
      MyCurrent_Blue_Gem_Amount = blueGem.buy_virtual_good(MyCurrent_Blue_Gem_Amount);
 }
 
 //create buy item pack function.
 public void BuyBlueGemPack()
 {
      // format:(current item amount, packs amount)
      MyCurrent_Blue_Gem_Amount = blueGem.buy_virtual_good(MyCurrent_Blue_Gem_Amount, 5);
 }
 ```
7. Sell functions:
 - Sell Items functions example:
 ```
 /**
 Important: you should manage your save and load assets information.
 The following method will delete all information if the game stop.
 */
 
 // use a item holder, refer to step #6 also refer to Important notice above).
 
 //create simple buy function.
 public void SellBlueGem()
 {
 //FORMAT: (ITEM, CURRENT_ITEM_AMOUNT, AMOUNT_TO_SELL, AT_WHAT_PRICE)
      MyCurrent_Blue_Gem_Amount = SellVirtualGoods.sellvirtual_good
                                   (
                                     blueGem, 
                                     MyCurrent_Blue_Gem_Amount,
                                     5, 
                                     SellVirtualGoods.SELL_PRICE.REGULAR_PRICE
                                   );
 }
 
 //create buy item pack function.
 public void SellBlueGemByHalfPrice()
 {
 //FORMAT: (ITEM, CURRENT_ITEM_AMOUNT, AMOUNT_TO_SELL, AT_WHAT_PRICE)
      MyCurrent_Blue_Gem_Amount = SellVirtualGoods.sellvirtual_good
                                   (
                                      blueGem, 
                                      MyCurrent_Blue_Gem_Amount,
                                      5, 
                                      SellVirtualGoods.SELL_PRICE.HALF_PRICE
                                    );
 }
 ```
 
# Notes: 
> This plugin is at first release, we will continue to add more features to help you do less code. Please contact us if need futher assistance

#**Supporters:**
   >Guille Bauza

