using System;
using System.Collections.Generic;
using System.Text;

namespace KosanOOP
{
    class Property
    {
        public string Name { get; private set; }
        public long Price { get; private set; }
        
        public string isFull { get; private set; }
        
        public string isPaid { get; set; }
       
        

        public Property(string name, long price, string isfull, string ispaid) 
        {
            this.Name = name;
            this.Price = price;
            this.isFull = isfull;
            this.isPaid = ispaid;
        }
    }
}
