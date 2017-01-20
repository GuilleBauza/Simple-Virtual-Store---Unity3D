using System;
using System.Collections.Generic;

namespace VirtualStore
{
    public class MyVirtualStore
    {
        private float item_cost_value;
        private string item_name;
        private long item_amount = 1;

        /// <summary>
        /// Create an Item with default values: Item Name = Gems; Item Cost Value = 10; Item Amount = 1;
        /// </summary>
        public MyVirtualStore()
        {
            item_name = "Gems";
            item_cost_value = 10;
            item_amount = 1;
        }

        /// <summary>
        /// Create my own Virtual Good.
        /// </summary>
        /// <param name="item_name"> Name of whatever we selling on the store.</param>
        /// <param name="currency_cost_value"> Cost of whatever we selling on the store.</param>
        public MyVirtualStore(string item_name, float item_cost_value)
        {
            this.item_name = item_name;
            this.item_cost_value = item_cost_value;
        }

        // ------------ GETTERS -------------
        /// <summary>
        /// Get Item Cost Value.
        /// </summary>
        /// <returns>float: Item Cost Value.</returns>
        public float getItemCostValue()
        {
            return item_cost_value;
        }
        /// <summary>
        /// Get Item Amount.
        /// </summary>
        /// <returns>float: Item Amount.</returns>
        public long getItemAmount()
        {
            return item_amount;
        }
        /// <summary>
        /// Get Item Name.
        /// </summary>
        /// <returns>string: Item Name.</returns>
        public string getItemName()
        {
            return item_name;
        }

        // ------------ SETTERS -------------
        /// <summary>
        /// Set or Change my created item cost value.
        /// </summary>
        /// <param name="item_cost_value">Cost of whatever we selling on the store.</param>
        public void setItemCostValue(float item_cost_value)
        {
            this.item_cost_value = item_cost_value;
        }

        /// <summary>
        /// Set or Change my created item name.
        /// </summary>
        /// <param name="item_name">Name of whatever we selling on the store.</param>
        public void setItemName(string item_name)
        {
            this.item_name = item_name;
        }

        /// <summary>
        /// Buy any virtual good created before with MyCurrency.currency.
        /// </summary>
        /// <param name="myItemAmount">My current amount of Item that I'm buying.</param>
        /// <returns>Update item amount.</returns>
        public long buy_virtual_good(long myItemAmount)
        {
            if (MyCurrency.currency >= getItemCostValue())
            {
                myItemAmount += getItemAmount();
                MyCurrency.currency -= getItemCostValue();

                if (MyCurrency.Currency_Type == MyCurrency.CURRENCY_TYPE.INTEGER)
                    MyCurrency.currency = (long)MyCurrency.currency;

                if (MyCurrency.currency < 0)
                    MyCurrency.currency = 0;

                return myItemAmount;
            }

            return myItemAmount;
        }//Buy with Integer

        /// <summary>
        /// Buy packs of any virtual good created before with MyCurrency.currency.
        /// </summary>
        /// <param name="myItemAmount">My current amount of Item that I'm buying.</param>
        /// <param name="Packs">How many packs of this Item I want to buy.</param>
        /// <returns></returns>
        public long buy_virtual_good(long myItemAmount, long Amount)
        {
            if (MyCurrency.currency >= (getItemCostValue() * Amount))
            {
                myItemAmount += Amount;
                MyCurrency.currency = MyCurrency.currency - getItemCostValue() * Amount;

                if (MyCurrency.Currency_Type == MyCurrency.CURRENCY_TYPE.INTEGER)
                    MyCurrency.currency = (long)MyCurrency.currency;

                return myItemAmount;
            }

            return myItemAmount;
        }//Buy with Integer

    }// Virtual Store Class

    public class SellVirtualGoods
    {
        public enum SELL_PRICE { REGULAR_PRICE, HALF_PRICE }

        /// <summary>
        /// Sell any virtual good created before with MyCurrency.currency by regular price.
        /// </summary>
        /// <param name="myVirtualStore">Item Reference created.</param>
        /// <param name="myItemAmount">My current amount of the Item I'm selling.</param>
        /// <param name="amountToSell">How many of my items I'm going to sell.</param>
        /// <param name="SpecialPrice">If the Item will be sold by half price, regular price or any other kind of special selling price.</param>
        /// <returns>Update item amount.</returns>
        public static long sell_virtual_good(MyVirtualStore myVirtualStore, long myItemAmount, long amountToSell, SELL_PRICE SellPrice)
        {
            if (amountToSell <= myItemAmount)
            {
                myItemAmount -= amountToSell;

                if (SellPrice == SELL_PRICE.REGULAR_PRICE)
                    MyCurrency.currency = MyCurrency.currency + (myVirtualStore.getItemCostValue() * amountToSell);

                else if (SellPrice == SELL_PRICE.HALF_PRICE)
                    MyCurrency.currency = MyCurrency.currency + ((myVirtualStore.getItemCostValue() / 2) * amountToSell);

                if (MyCurrency.Currency_Type == MyCurrency.CURRENCY_TYPE.INTEGER)
                    MyCurrency.currency = (long)MyCurrency.currency;

                return myItemAmount;
            }

            return myItemAmount;
        }//Sell by half

    }// SellGoods

    /// <summary>
    /// My In-Game Currency.
    /// </summary>
    public class MyCurrency
    {
        public enum CURRENCY_TYPE { INTEGER, DECIMAL }
        public static CURRENCY_TYPE Currency_Type = CURRENCY_TYPE.DECIMAL;

        public static float currency { set; get; }

        /// <summary>
        /// Add certain amount of values to my currency value.
        /// </summary>
        /// <param name="Currency">Value that will be added to the current currency amount.</param>
        /// <param name="Currency_Type">Will use currency as the value Type you select.</param>
        public static void addCurrency(float Currency, CURRENCY_TYPE Currency_Type)
        {
            if (Currency_Type == CURRENCY_TYPE.DECIMAL)
                currency += Currency;
            else
                currency += (long)Currency;
        }

        /// <summary>
        /// Add certain amount of values to my currency value.
        /// Will be use the default value type:(DECIMAL) or INTEGER if it was changed.
        /// </summary>
        /// <param name="Currency">Value that will be added to the current currency amount.</param>
        public static void addCurrency(float Currency)
        {
            if (Currency_Type == CURRENCY_TYPE.DECIMAL)
                currency += Currency;
            else
                currency += (long)Currency;
        }

        /// <summary>
        /// Add certain amount of values to my currency value.
        /// </summary>
        /// <param name="Currency">Value that will be added to the current currency amount.</param>
        /// <param name="Currency_Type">Will use currency as the value Type you select.</param>
        public static void setCurrency(float Currency, CURRENCY_TYPE Currency_Type)
        {
            if (Currency_Type == CURRENCY_TYPE.DECIMAL)
                currency = Currency;
            else
                currency = (long)Currency;
        }

        /// <summary>
        /// Add certain amount of values to my currency value.
        /// Will be use the default value type:(DECIMAL) or INTEGER if it was changed.
        /// </summary>
        /// <param name="Currency">Value that will be added to the current currency amount.</param>
        public static void setCurrency(float Currency)
        {
            if (Currency_Type == CURRENCY_TYPE.DECIMAL)
                currency = Currency;
            else
                currency = (long)Currency;
        }
    }//My Currency Class

}//namespace

