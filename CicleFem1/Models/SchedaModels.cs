using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CicleFem1.Models
{
    public class DettaglioScheda
    {
        [Key]
        public int DettaglioScheda_Id { get; set; }
        [Display(Name ="Data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        [Display(Name ="Giorno")]
        public int? Giorno { get; set; }
        [Display(Name ="Temperatura")]
        public double? Temperatura { get; set; }
        public int Scheda_Id { get; set; }
        [Display(Name ="Perdite ematiche")]
        public int? Ematic { get; set; }
        [Display(Name ="Muco q.tà")]
        public int? Muco { get; set; }
        [Display(Name ="Caratteristiche muco")]
        public string MucoC { get; set; }
        [Display(Name ="Coito")]
        public string Coito { get; set; }
        [Display(Name = "Consistenza")]
        public String UteCon { get; set; }
        [Display(Name = "Inclinazione")]
        public String UteInc { get; set; }
        [Display(Name = "Apertura")]
        public String UteApe { get; set; }
        [Display(Name = "Posizione")]
        public String UtePos { get; set; }
        [Display(Name = "Sensazione")]
        public String Sensazione { get; set; }
        [Display(Name = "Note")]
        public String Note { get; set; }

    }

    public class Scheda
    {
        [Key]
        public int Scheda_Id { get; set; }
        [Display(Name ="Numero scheda")]
        public int? Numero { get; set; }
        [Display(Name = "Numero giorni previsti")]
        public int? NumeroG { get; set; }
        [Display(Name ="Data inizio scheda")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataI { get; set; }
        [Display(Name ="Data fine scheda")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataF { get; set; }
        public string Uid { get; set; }

        public virtual ICollection<DettaglioScheda> DettaglioScheda { get; set; }
    }

    public class Osservatori
    {
        [Key]
        public int Osservatore_Id { get; set; }
        [Display(Name = "Tipo di osservatore")]
        public string TipoOsservatore { get; set; }
        public string Uid { get; set; }
        [Display(Name = "Osservatore")]
        public string Id { get; set; }
        public virtual ApplicationUser Cognome { get; set; }
    }
}