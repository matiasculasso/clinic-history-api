﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Collections.Generic;
using System.Linq;


namespace ClinicHistoryApi.Auth.Models
{
	public class LoginViewModel : LoginInputModel
	{
		public bool AllowRememberLogin { get; set; }
		public bool EnableLocalLogin { get; set; }

		public IEnumerable<ExternalProvider> ExternalProviders { get; set; }
		public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));
	}
}