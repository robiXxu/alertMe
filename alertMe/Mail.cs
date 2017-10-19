using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace alertMe {
    class Mail {
        Config cfg = null;
        SmtpClient smtp = null;
        MailMessage mail = null;


        public Mail( Config cfg ) {
            this.cfg = cfg;

            this.setupSMTP();
            this.setupMail();
        }

        public void send(String otherInformations = "") {
            this.mail.Body += "\n" + otherInformations;
            this.smtp.Send(this.mail);
        }

        #region Setup

        public void setupSMTP () {
            this.smtp = new SmtpClient(this.cfg.smtpHost, this.cfg.smtpPort);
            this.smtp.Credentials = new System.Net.NetworkCredential(this.cfg.smtpUser, this.cfg.smtpPass);
            this.smtp.EnableSsl = this.cfg.smtpSSL;

            this.smtp.SendCompleted += Smtp_SendCompleted;
        }

        public void setupMail () {
            this.mail = new MailMessage(this.cfg.from, this.cfg.targetEmail, this.cfg.subject, this.cfg.message);
            this.mail.Priority = MailPriority.High;
            this.mail.IsBodyHtml = true;
        }

        #endregion Setup

        #region Events

        private void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            Console.WriteLine("Message Sent!");
        }

        #endregion Events
    }
}
