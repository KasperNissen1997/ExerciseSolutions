using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProject.Exercise15And16And17
{
    public class Book
    {
        public string ItemId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public Book (string itemId, string title, double price) {
            ItemId = itemId;
            Title = title;
            Price = price;
        }

        public Book (string itemId, string title) : this (itemId, title, 0) { }

        public Book (string itemId) : this (itemId, "", 0) { }
        
        public string ToString () {
            return "ItemId: " + ItemId + ", Title: " + Title + ", Price: " + Price;
        }
    }
}
