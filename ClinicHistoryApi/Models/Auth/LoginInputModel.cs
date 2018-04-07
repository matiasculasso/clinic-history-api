// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClinicHistoryApi.Auth.Models
{
    public class LoginInputModel
    {
        [Required]
		[DisplayName("Nombre de Usuario")]
		public string Username { get; set; }
        [Required]
        public string Password { get; set; }

		[DisplayName("Recordar Contraseña")]
		public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}