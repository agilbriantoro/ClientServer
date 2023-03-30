using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;

[Table("tb_m_universities")]
public class University
{
   
    public int Id { get; set; }
   
    public string? Name { get; set; }

}
