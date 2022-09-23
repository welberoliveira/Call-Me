using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CallMe.Models;

public enum Grade
{
    A, B, C, D, F
}

public class DesejoProduto
{
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    [DisplayFormat(NullDisplayText = "No grade")]
    public Grade? Grade { get; set; }

    [Display(Name = "Produto")]
    public Produto Produto { get; set; }
        
    [Display(Name = "Pessoa")]
    public Pessoa Pessoa { get; set; }
}

