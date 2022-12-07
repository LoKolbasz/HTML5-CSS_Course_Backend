using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;

namespace HTML5_CSS_Course_Backend_Models
{
    [JsonSerializable(typeof(Reservation))]
    public class Reservation
    {
        #nullable disable
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string? id { get; set; }
        [MaxLength(20)]
        [MinLength(3)]
        [Required]
        public string name { get; set; }    //Foglaló neve
        [Required]
        public string contact { get; set; } //Foglalás kezdete (pl.: 2021-10-10T10:00:10)
        public DateTime begin { get; set; } //Foglalás kezdete
        public DateTime end { get; set; }   //Foglalás vége
        [NotMapped]
        public virtual Table ? table { get; set; }
        [ForeignKey(nameof(Table))]
        [Range(1,long.MaxValue)]
        [JsonIgnore]
        public long tableId { get; set; }
        [NotNull]
        public byte[] person { get; set; }    //Személyek száma

        public static string dateTimeFormat = "yyyy-MM-ddThh:mm:ss";
        public static IFormatProvider formatProvider = new CultureInfo("hu-HU");
        public static DateTimeStyles dateTimeStyles = DateTimeStyles.AllowInnerWhite;

        public Reservation(string id, string name, string contact, DateTime begin, DateTime end, long tableId, string person)
        {
            this.id = id;
            this.name = name;
            this.contact = contact;
            this.begin = begin;
            this.end = end;
            this.tableId = tableId;
            this.person = Encoding.UTF8.GetBytes(person);
        }

        public Reservation()
        {
        }
        public bool CompareDates(DateTime start, DateTime stop) => start <= this.begin || start <= this.end || stop >= this.begin || stop >= this.end;

        public override bool Equals(object obj)
        {
            return obj is Reservation reservation &&
                   name == reservation.name &&
                   contact == reservation.contact &&
                   begin == reservation.begin &&
                   end == reservation.end &&
                   tableId == reservation.tableId &&
                   EqualityComparer<byte[]>.Default.Equals(person, reservation.person);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, contact, begin, end, tableId, person);
        }

#nullable restore
    }
}