// <copyright file="EmailSender.cs" company="Cuyahoga Community College">
// Copyright (c) Cuyahoga Community College. All rights reserved.
// </copyright>

namespace EmailService
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using MailKit.Net.Smtp;
    using MimeKit;

    /// <summary>
    /// Email sender class.
    /// </summary>
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings? emailSettings = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSender"/> class.
        /// </summary>
        /// <param name="emailSettings">The email setting.</param>
        public EmailSender(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }

        /// <summary>
        /// Send the email.
        /// </summary>
        /// <param name="emailData">the email data.</param>
        /// <returns>True if successful, False if not.</returns>
        public bool SendEmail(EmailData emailData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress(this.emailSettings!.FromName, this.emailSettings.EmailFrom);
                emailMessage.From.Add(emailFrom);

                if (emailData.EmailToAddressesAndNames.Count != 0)
                {
                    // Email and name dictionary provided
                    foreach (var addressNamePair in emailData.EmailToAddressesAndNames)
                    {
                        MailboxAddress emailTo = new MailboxAddress(addressNamePair.Value, addressNamePair.Key);
                        emailMessage.To.Add(emailTo);
                    }
                }
                else if (emailData.EmailToAddressesList.Count != 0)
                {
                    // Email list is provided
                    foreach (var addressListItem in emailData.EmailToAddressesList)
                    {
                        MailboxAddress emailTo = new MailboxAddress(addressListItem, string.Empty);
                        emailMessage.To.Add(emailTo);
                    }
                }
                else if (!string.IsNullOrEmpty(emailData.EmailToAddresses))
                {
                    // string of emails seperataed by semi-colon provided
                    List<string> emailToAddressesList = emailData.EmailToAddresses.Split(";").ToList();
                    foreach (var addressListItem in emailToAddressesList)
                    {
                        MailboxAddress emailTo = new MailboxAddress(addressListItem, string.Empty);
                        emailMessage.To.Add(emailTo);
                    }
                }
                else
                {
                    // no email to address provided
                    return false;
                }

                emailMessage.Subject = emailData.EmailSubject;
                BodyBuilder emailBodyBuilder = new BodyBuilder();

                // emailBodyBuilder.TextBody = emailData.EmailBody;
                emailBodyBuilder.HtmlBody = string.Format(emailData.EmailBody);
                if (emailData.Attachments != null && emailData.Attachments.Any())
                {
                    byte[] fileBytes;
                    foreach (var attachment in emailData.Attachments)
                    {
                        using (var ms = new MemoryStream())
                        {
                            attachment.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }

                        emailBodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                    }
                }

                emailMessage.Body = emailBodyBuilder.ToMessageBody();
                SmtpClient emailClient = new SmtpClient();
                emailClient.Connect(this.emailSettings.Host, this.emailSettings.Port);

                // emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return true;
            }
            catch (Exception)
            {
                // Log Exception Details
                return false;
            }
        }
    }
}
