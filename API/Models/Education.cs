using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_m_educations")]
public class Education
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("major"), MaxLength(100)]
    public string Major { get; set; }
    [Required, Column("degree", TypeName = "nchar(2)")]
    public string Degree { get; set; }
    [Required, Column("gpa")]
    public float GPA { get; set; }
    [Required, Column("university_id")]
    public int UniversityId { get; set; }

    // Relation & Cardinality
    [ForeignKey(nameof(UniversityId))]
    [JsonIgnore]
    public University? University { get; set; }
    [JsonIgnore]

    public ICollection<Profiling>? Profilings { get; set; }
}
