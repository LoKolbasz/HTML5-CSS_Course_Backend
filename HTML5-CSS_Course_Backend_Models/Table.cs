using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace HTML5_CSS_Course_Backend_Models;

[PrimaryKey(nameof(id))]
[JsonSerializable(typeof(Table))]
public class Table
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public long id { get; set; }
    [Required]
    [Key]
    [MaxLength(20)]
    [MinLength(0)]
    public string ? name { get; set; } //Asztal elnevezése
    [JsonConverter(typeof(ByteStringJson))]
    public byte[] capacity { get; set; } //székek száma az asztalnál
    [NotMapped]
    [JsonIgnore]
    public virtual ICollection<Reservation> ? reservations { get; set; }

    [JsonIgnore]
    public bool isEnabled { get; set; }

    // [JsonConstructor]
    public Table(long id, string name, string capacity)
    {
        this.id = id;
        this.name = name;
        this.capacity = Encoding.UTF8.GetBytes(capacity);
        this.isEnabled = false;
    }

    public Table()
    {
    }

    public override bool Equals(object? obj)
    {
        return obj is Table table &&
               name == table.name &&
               EqualityComparer<byte[]>.Default.Equals(capacity, table.capacity);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, capacity);
    }
}
