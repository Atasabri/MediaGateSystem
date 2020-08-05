//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Accessories.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Accessory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accessory()
        {
            this.colors = new HashSet<color>();
        }
    
        public int ID { get; set; }
        [Required(ErrorMessage ="Accessory Name Is Required")]
        [Display(Name ="Accessory Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Serial Number Is Required")]
        [Display(Name = "Serial Number")]
        public string Serial_Number { get; set; }
        [Required(ErrorMessage = "Model Is Required")]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Weight Is Required")]
        [Display(Name = "Weight")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Entry Date Is Required")]
        [Display(Name = "Entry Date")]
        public System.DateTime Entry_Data { get; set; }
        [Required(ErrorMessage = "Departure Date Is Required")]
        [Display(Name = "Departure Date")]
        public System.DateTime Departure_Date { get; set; }
        [Required(ErrorMessage = "Work In Is Required")]
        [Display(Name = "Work In")]
        public string Work_In { get; set; }
        [Required(ErrorMessage = "Buying Date Is Required")]
        [Display(Name = "Buying Date")]
        public System.DateTime Buy_Date { get; set; }
        [Required(ErrorMessage = "Notes Is Required")]
        [Display(Name = "Notes")]
        public string Special_Prop { get; set; }
        [Required(ErrorMessage = "Quantity Is Required")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        public int Cat_ID { get; set; }
        public int Stat_ID { get; set; }
        public int User_ID { get; set; }
        [Required(ErrorMessage = "Location Is Required")]
        [Display(Name = "Location")]
        public string Location { get; set; }
        public Nullable<int> SubCat1_ID { get; set; }
        public Nullable<int> SubCat2_ID { get; set; }
        public Nullable<int> Depart_ID { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Statue Statue { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<color> colors { get; set; }
        public virtual SubCat1 SubCat1 { get; set; }
        public virtual SubCat2 SubCat2 { get; set; }
        public virtual Department Department { get; set; }
    }
}
