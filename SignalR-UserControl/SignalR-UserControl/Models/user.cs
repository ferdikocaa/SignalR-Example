//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SignalR_UserControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class user
    {
        public int userID { get; set; }
        [Required(ErrorMessage ="Kullan�c� ad� bo� b�rak�lamaz")]
        public string userName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Ge�erli bi parola giriniz")]
        public string userPassword { get; set; }
        public string LoginErrorMessage { get; set; }
        public string conId { get; set; }
        public string IPadress { get; set; }

    }
}
