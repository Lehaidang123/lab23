using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab2.Models
{
    public class Book
    {
        private int id;
        private string tilte;
        private string author;
        private string imgae;
        public Book()
        {

        }
        public Book(int id, string tilte, string author, string imgae)
        {
            this.id = id;
            this.tilte = tilte;
            this.author = author;
            this.imgae = imgae;
        }

        [Required(ErrorMessage = "Mã sách không được để trống")]
        [Display(Name = "Mã sách")]
        public int Id { get { return id; }set { id = value; } }
        [Required(ErrorMessage ="Tiêu đề không được trống")]
        [StringLength(250,ErrorMessage ="Tiêu đề sách không vượt quá 250 kí tự ")]
        [Display(Name ="Tiêu đề")]
        public string Tilte { get { return tilte; } 
            
            set { tilte = value; } }
            
        public string Author { get { return author; } set { author = value; } }
        public string Image { get { return imgae; } set { imgae = value; } }

    }
    
    
}