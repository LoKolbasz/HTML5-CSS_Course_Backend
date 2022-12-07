using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HTML5_CSS_Course_Backend_Models;
public class Table
{
    [Key]
    public long id { get; set; }
    [Required]
    [MaxLength(20)]
    [MinLength(0)]
    public string ? name { get; set; } //Asztal elnevezése
    [Required]
    public byte capacity { get; set; } //székek száma az asztalnál
    [NotMapped]
    [JsonIgnore]
    public ICollection<Reservation> reservations { get; set; }

    public Table(long id, string name, byte capacity)
    {
        this.id = id;
        this.name = name;
        this.capacity = capacity;
    }

    public Table()
    {
    }
}
