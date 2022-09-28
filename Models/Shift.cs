using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvedinceFinal.Models
{
    public class Shift
    {
        [Key]
        public int Shift_ID{ get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("Short Code")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(11)]
        public string ShortCode{ get; set; }

        [DisplayName("Deauty Time Start")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(11)]
        [DataType(DataType.Time)]
        public string Onetime { get; set; }

        [DataType(DataType.Time)]
        [DisplayName("OverTime Start")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(11)]
        public string OvertimeStart { get; set; }

        [DataType(DataType.Time)]
        [DisplayName("OverTime End")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(11)]
        public string OvertimeEnd { get; set; }

        [DisplayName("Shift Type")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(11)]
        public string ShiftType { get; set; }
        
    }
}
