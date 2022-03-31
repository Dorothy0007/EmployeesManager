﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Model
{
    public class Education
    {
        public int EducationId { get; set; }

        [Display(Name = "Naziv edukacije")]
        public string EducationName { get; set; }
       
        [Display(Name = "Vrsta edukacije")]
        public EducationCategory EducationCategory { get; set; }
        
        [Display(Name = "Tip edukacije")]
        public EducationType EducationType { get; set; }
        
        [Display(Name = "Tip sudjelovanja")]
        public ParticipationType ParticipationType { get; set; }
       
        [Display(Name = "Datum početka")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }
        
        [Display(Name = "Datum završetka")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "Opis")]
        public string Description { get; set; }
        
        [Display(Name = "Napomena")]
        public string Remark { get; set; }
        
        [Display(Name = "Obavezno")]
        public bool Mandatory { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }

    public enum EducationType
    {
        [Display(Name = "Usavršavanja unutar Zavoda")]
        UsavrsavanjaUnutarZavoda,
        [Display(Name = "Usavršavanja izvan Zavoda")]
        UsavrsavanjaIzvanZavoda,
        [Display(Name = "Edukacije specijalizanata")]
        EdukacijeSpecijalizanata,
        [Display(Name = "Edukacije stažista")]
        EdukacijeStazista,
        [Display(Name = "Edukacije pomoćnog osoblja")]
        EdukacijePomocnogOsoblja
    }

    public enum EducationCategory
    {
        [Display(Name = "Stručni sastanci Zavoda - VSS")]
        StrucniSastanciZavodaVSS,
        [Display(Name = "Stručni sastanci Zavoda - VŠS/SSS")]
        StrucniSastanciZavodaVŠSSSS,
        [Display(Name = "Kongresi (domaći)")]
        KongresiDomaci,
        [Display(Name = "Kongresi (međunarodni)")]
        KongresiMedjunarodni,
        [Display(Name = "Konferencija")]
        Konferencija,
        [Display(Name = "Stručni skup")]
        StrucniSkup,
        [Display(Name = "Sastanak međunarodnog strukovnog tijela")]
        SastanakMedjunarodnogStrukovnogTijela,
        [Display(Name = "Seminari / škola")]
        SeminariSkola,
        [Display(Name = "Tečajevi")]
        Tecajevi,
        [Display(Name = "Simpoziji")]
        Simpoziji,
        [Display(Name = "Radionica")]
        Radionica,
        [Display(Name = "Radionice / predavanja / edukacije")]
        RadionicePRedavanjaEdukacije,
        [Display(Name = "Specijalistički obilasci")]
        SpecijalistickiObilasci,
        [Display(Name = "Stažistički obilasci")]
        StazistickiObilasci,
        [Display(Name = "Stručni sastanci - VŠS / SSS")]
        StrucniSastanciVssSss
    }

    public enum ParticipationType
    {
        [Display(Name = "Pasivno sudjelovanje (slušač)")]
        PasivnoSudjelovanje,
        [Display(Name = "Sudjelovanje s posterom")]
        SudjelovanjeSPosterom,
        [Display(Name = "Pozvano predavanje")]
        PozvanoPredavanje,
        [Display(Name = "Organizator")]
        Organizator
    }
}
