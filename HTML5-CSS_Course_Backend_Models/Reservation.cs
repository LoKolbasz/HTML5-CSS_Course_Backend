using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HTML5_CSS_Course_Backend_Models
{
    public class Reservation
    {
        [Key]
        public string id { get; set; }
        [MaxLength(20)]
        [MinLength(3)]
        public string name { get; set; }    //Foglaló neve
        public string contact { get; set; } //Foglalás kezdete (pl.: 2021-10-10T10:00:10)
        public DateTime begin { get; set; } //Foglalás kezdete
        public DateTime end { get; set; }   //Foglalás vége
        [NotMapped]
        public virtual Table ? table { get; set; }
        [ForeignKey(nameof(Table))]
        [JsonIgnore]
        public long tableId { get; set; }
        public byte person { get; set; }    //Személyek száma

        public Reservation(string id, string name, string contact, DateTime begin, DateTime end, long tableId, byte person)
        {
            this.id = id;
            this.name = name;
            this.contact = contact;
            this.begin = begin;
            this.end = end;
            this.tableId = tableId;
            this.person = person;
        }
    }
}