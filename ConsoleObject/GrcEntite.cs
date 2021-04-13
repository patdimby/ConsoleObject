
using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleObject
{
    public enum Categorical
    {
        Entite,
        Entreprise,
        Testeur,
        Cabinet,
        Collaborateur,
        Bureau,
        Profil
    }

    public class GrcEntite
    {
        public GrcEntite()
        {
         
            Categorie = Categorical.Entite;           
        }

        public GrcEntite(string fonction)
        {
            // Default constructor.
            Categorie = Categorical.Entite;          
            Fonction = fonction;
        }

        protected virtual void Init()
        {
            Categorie = Categorical.Entite;            
        }

      
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Vous devez saisir un numéro SIREN")]
        [Display(Name = "Siren*", Prompt = "Saisir le numéro SIREN", Description = "Numéro SIREN", ShortName = "Siren")]
        [DisplayFormat(DataFormatString = "### ### ###")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Le SIREN doit comporter 9 caractères")]
    
        public string SIREN { get; set; }

       
        [Required(ErrorMessage = "Vous devez saisir un code NIC")]
        [DisplayFormat(DataFormatString = "99999")]
        [Display(Name = "Nic*", Prompt = "Saisir le code NIC", Description = "Code NIC", ShortName = "Nic")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Le NIC doit comporter 5 caractères")]
        public string NIC { get; set; }

        [Display(Name = "Forme", Prompt = "Saisir la forme juridique", Description = "Forme juridique", ShortName = "Forme")]
        [StringLength(5, MinimumLength = 2)]        
        public string FORME { get; set; }

        [Required(ErrorMessage = "Vous devez saisir un nom")]
        [Display(Name = "Nom / Raison*", Prompt = "Saisir le nom du cabinet", Description = "Nom de l'exploitation ou raison sociale", ShortName = "Nom")]
        [StringLength(50)]
     
        public virtual string RAISON { get; set; }

        [Display(Name = "Code APE", Prompt = "Saisir le code APE", Description = "Code APE", ShortName = "APE")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Le code APE doit comporter 5 caractères")]
       
        public string APE { get; set; }

        [Display(Name = "Activité", Prompt = "Saisir l'activité", Description = "Description de l'activité", ShortName = "Activite")]
        [StringLength(30)]
        
        public string ACTIVITE { get; set; }

        [Required(ErrorMessage = "Vous devez saisir un Montant du capital")]
        [Display(Name = "Capital*", Prompt = "Saisir le montant du capital", Description = "Montant du capital", ShortName = "Capital")]
       
        public Single CAPITAL { get; set; }

        [Display(Name = "Devise", Prompt = "Saisir la devise", Description = "Monnaie dans laquelle est exprimée le capital", ShortName = "Devise")]
        [StringLength(10)]
        
        public string DEVISE { get; set; }

        [Display(Name = "Greffe", Prompt = "Saisir le nom du Greffe", Description = "Greffe du Tribunal de Commerce dont dépend le cabinet", ShortName = "Greffe")]
        [StringLength(30)]
        
        public string GREFFE { get; set; }

        [Display(Name = "Numéro TVA", Prompt = "Saisir le numéro de TVA", Description = "Numéro de TVA intracommunautaire du cabinet", ShortName = "TVA")]
        [StringLength(13)]
        
        public string TVA { get; set; }

        [Required(ErrorMessage = "Vous devez saisir une adresse")]
        [Display(Name = "Adresse 1*", Prompt = "Saisir l'adresse", Description = "Adresse de l'entreprise", ShortName = "Adresse1")]
        [StringLength(50)]
        
        public string ADRESSE1 { get; set; }

        [Display(Name = "Adresse 2", Prompt = "Saisir l'adresse", Description = "Complément d'adresse du cabinet", ShortName = "Adresse2")]
        [StringLength(50)]
       
        public string ADRESSE2 { get; set; }

        [Required(ErrorMessage = "Vous devez saisir un code postal")]
        [Display(Name = "Code postal*", Prompt = "Saisir le code postal", Description = "Code postal du cabinet", ShortName = "CODEPOSTAL")]
        [StringLength(5)]
        
        public string CODEPOSTAL { get; set; }

        [Required(ErrorMessage = "Vous devez saisir une ville")]
        [Display(Name = "Ville*", Prompt = "Saisir la ville", Description = "Ville du cabinet", ShortName = "Ville")]
        [StringLength(50)]
        
        public string VILLE { get; set; }

        [Display(Name = "Pays", Prompt = "Saisir le pays", Description = "Pays du cabinet", ShortName = "Pays")]
        [StringLength(50)]
        
        public string PAYS { get; set; }

        [Required(ErrorMessage = "Vous devez saisir un numéro de téléphone")]
        [Display(Name = "Téléphone*", Prompt = "Saisir le numéro de téléphone", Description = "Numéro de téléphone du cabinet", ShortName = "Telephone")]
        [Phone(ErrorMessage = "Numéro de téléphone non valide")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        
        public string TELEPHONE { get; set; }

        [Required(ErrorMessage = "Vous devez saisir une adresse email")]
        [Display(Name = "Email*", Prompt = "Saisir l'adresse email", Description = "Email principal du cabinet", ShortName = "Email")]
        [EmailAddress(ErrorMessage = "Addresse email non valide")]
        [StringLength(50)]
       
        public string EMAIL { get; set; }

        [StringLength(20)]
        
        [Display(Name = "Site internet", Prompt = "Saisir l'adresse web", Description = "Site internet du cabinet", ShortName = "Siteweb")]
        public string SITEWEB { get; set; }

        [Display(Name = "Fonction", Prompt = "Fonction", Description = "Fonction", ShortName = "Fonction")]

        private string Fonction { get; set; }

        [Display(Name = "Profil", Prompt = "Profil", Description = "Profil", ShortName = "Profil")]
        
        public string Profil { get; set; }
   
        public Categorical Categorie { get; set; }
    }
}