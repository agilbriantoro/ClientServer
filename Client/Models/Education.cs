using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;

[Table("tb_m_educations")]
public class Education
{
  
    public int Id { get; set; }

    public string Major { get; set; }

    public string Degree { get; set; }

    public float GPA { get; set; }

    public int UniversityId { get; set; }


}
