// <copyright file="IEmailSender.cs" company="Cuyahoga Community College">
// Copyright (c) Cuyahoga Community College. All rights reserved.
// </copyright>

namespace EmailService
{
    /// <summary>
    /// The Email sender.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Send email function.
        /// </summary>
        /// <param name="emailData">the email data.</param>
        /// <returns>True if successful, False if not.</returns>
        bool SendEmail(EmailData emailData);
    }
}
