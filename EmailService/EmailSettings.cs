// <copyright file="EmailSettings.cs" company="Cuyahoga Community College">
// Copyright (c) Cuyahoga Community College. All rights reserved.
// </copyright>

#nullable disable
namespace EmailService
{
    /// <summary>
    /// Email settings.
    /// </summary>
    public class EmailSettings
    {
        /// <summary>
        /// Gets or sets Email from field.
        /// </summary>
        public string EmailFrom { get; set; }

        /// <summary>
        ///  Gets or sets Email Name field.
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        ///  Gets or sets the host field.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        ///  Gets or sets the port field.
        /// </summary>
        public int Port { get; set; }
    }
}
#nullable enable