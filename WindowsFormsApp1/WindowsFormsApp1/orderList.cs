using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class orderList
    {
        private string name;
        private string store;
        private string order;
        private string classes;
        private int amount;
        private int priceEach;

        public orderList(string inputName,string inputStore, string inputOrder, string inputClasses, int inputAmount, int inputPriceEach)
        {
            Name = inputName;
            Store = inputStore;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Store
        {
            get => store;
            set => store = value;
        }
    }
}
