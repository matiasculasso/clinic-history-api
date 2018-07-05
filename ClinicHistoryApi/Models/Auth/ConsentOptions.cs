// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace ClinicHistoryApi.Models.Auth
{
    public class ConsentOptions
    {
        public static bool EnableOfflineAccess = true;
        public static string OfflineAccessDisplayName = "Offline Access";
        public static string OfflineAccessDescription = "Access to your applications and resources, even when you are offline";

        public static readonly string MustChooseOneErrorMessage = "Debe seleccionar aunque sea una opción";
        public static readonly string InvalidSelectionErrorMessage = "Selección inválida";
    }
}
