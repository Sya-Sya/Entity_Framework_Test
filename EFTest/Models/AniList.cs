using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFTest.Models
{
    //Data Annotations Attributes
    [Table("AniLists")]
    public class AniList
    {
        private int _price; //Since it doesnt have getter;setter property EF will not create Column for it.
        [Key]
        [Column(Order =0)] // orders the ID as 1st
        public int Id { get; set; }
        [Column("Nawa")]
        [Required] // Creates Not null column in DB
        [MaxLength(50)] // Can have length upto 50
        public string Name { get; set; }
        [StringLength(200)] //creates a NVARCHAR with (200)
        public string Description { get; set; }
        [Column(Order = 2)]
        [NotMapped] // EF will not create Column for Genre since its has NotMapped Property
        public string Genre { get; set; }
        [Column("ReleasedDate", TypeName ="DateTime2")] // changes the datatype of Datetime to Datetime2
        public DateTime ReleasedDate { get; set; }
        public Rating AnimeRating { get; set; }
        public Rating MangaRating { get; set; }
    }

    public class Rating
    {
        [Key]
        public int RateId { get; set; }
        public float RatiingNumber { get; set; }
        public ICollection<AniList> MyAniList { get; set; }
        //[InverseProperty("MyMangaList")] // if the tables have more than one relation then we use InverseProperty else it will throw an exception
        //public ICollection<AniList> MyMangaList { get; set; }
    }
}