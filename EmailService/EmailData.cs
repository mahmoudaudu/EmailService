// <copyright file="EmailData.cs" company="Cuyahoga Community College">
// Copyright (c) Cuyahoga Community College. All rights reserved.
// </copyright>

#nullable disable
namespace EmailService
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Sets the email data.
    /// </summary>
    public class EmailData
    {
        /// <summary>
        /// Gets or sets each dictionary entry with Key: Email Address, Value: Name.
        /// </summary>
        public Dictionary<string, string> EmailToAddressesAndNames { get; set; }

        /// <summary>
        /// Gets or sets the Email Address List.
        /// </summary>
        public List<string> EmailToAddressesList { get; set; }

        /// <summary>
        /// Gets or sets delimted email addresses.
        /// </summary>
        public string EmailToAddresses { get; set; }

        /// <summary>
        /// Gets or sets the email subject.
        /// </summary>
        public string EmailSubject { get; set; }

        /// <summary>
        /// Gets or sets the email body.
        /// </summary>
        public string EmailBody { get; set; }

        /// <summary>
        /// Gets or sets attachments.
        /// </summary>
        public IFormFileCollection Attachments { get; set; }
    }
}
#nullable enable
